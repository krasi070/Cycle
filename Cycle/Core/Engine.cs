namespace Cycle.Core
{
    using System;
    using System.Collections.Generic;
    using Args;
    using Enums;
    using GameFrames;
    using Interfaces;
    using Models.Units;
    using Models.Attacks.NormalAttacks;
    using Models.Attacks.MagicAttacks;

    public class Engine : IEngine
    {
        private const int PlayerNewGameStartX = 45;
        private const int PlayerNewGameStartY = 16;
        private const int PlayerNewGameStartLevel = 1;

        private const int CodeForStay = 0;
        private const int CodeForWentUp = 1;
        private const int CodeForWentDown = 2;
        private const int CodeForWentRight = 3;
        private const int CodeForWentLeft = 4;

        private readonly Random Random = new Random();

        private readonly IMenuHandler menuHandler;
        private readonly IMonsterDatabase monsterDatabase;
        private readonly IAreaDatabase areaDatabase;
        private readonly IAIDatabase aiDatabase;

        private IList<INormalAttack> defaultNormalAttacks = new List<INormalAttack>()
        {
            Tackle.Instance,
            Punch.Instance
        };

        // TODO: Add a method for retrieving a created character from a save file
        public Engine(
            IMenuHandler menuHandler, 
            IMonsterDatabase monsterDatabase, 
            IAreaDatabase areaDatabase,
            IAIDatabase aiDatabase)
        {
            this.menuHandler = menuHandler;
            this.monsterDatabase = monsterDatabase;
            this.areaDatabase = areaDatabase;
            this.aiDatabase = aiDatabase;
        }

        private int TextSpeed { get; set; }

        public void Run()
        {
            this.LaunchMainMenu();
        }

        private void LaunchMainMenu()
        {
            menuHandler.ShowMainMenu();
            Option chosenOption = Option.First;
            ConsoleKey pressedKey = Console.ReadKey(true).Key;
            while (pressedKey != ConsoleKey.Enter)
            {
                chosenOption = menuHandler.ChooseMainMenuOption(pressedKey);
                pressedKey = Console.ReadKey(true).Key;
            }

            switch (chosenOption)
            {
                case Option.First:
                    this.StartNewGame();
                    break;
                case Option.Second:
                    // TODO: Load Game
                    break;
                case Option.Third:
                    // Close game
                    Console.Clear();
                    Environment.Exit(0);
                    break;
            }
        }

        private void StartNewGame()
        {
            
            var playerArgs = this.GetPlayerArgs();
            string playerName = playerArgs.Name;
            var color = playerArgs.Color;
            int textSpeed = playerArgs.TextSpeed;
            this.TextSpeed = textSpeed;
            IPlayer player = new Player(
                PlayerNewGameStartX, 
                PlayerNewGameStartY, 
                playerName, 
                PlayerNewGameStartLevel,
                0,
                0,
                defaultNormalAttacks, 
                new List<IMagicAttack>(),
                color);

            this.ShowFirstScrene(player);
        }

        private void ShowFirstScrene(IPlayer player)
        {
            Console.Clear();
            this.menuHandler.DisplayGameFrame();
            this.menuHandler.DisplayOptionsBox();
            this.menuHandler.DisplayPlayerStatusFrame();
            this.menuHandler.UpdatePlayerStatus(player);
            var startArea = this.areaDatabase.GetAreaByName("One Way Out Area");
            player.X = PlayerNewGameStartX;
            player.Y = PlayerNewGameStartY;
            this.menuHandler.ShowArea(startArea, player);
            this.menuHandler.WriteTextSlowly(this.TextSpeed, "Move with WASD or with the arrow keys.");
            this.MovePlayer(player, startArea);
        }

        private void MovePlayer(IPlayer player, IArea area)
        {
            if (!player.IsInBattle)
            {
                player.Draw();

                ConsoleKey pressedKey = Console.ReadKey(true).Key;
                while (true)
                {
                    player.Move(pressedKey, area.BorderCoordinates);
                    int code = this.CheckIfPlayerLeftArea(player, area);
                    if (code != CodeForStay)
                    {
                        this.LoadArea(player, code, true);    
                    }

                    pressedKey = Console.ReadKey(true).Key;
                }
            }
        }

        private void MovePlayer(IPlayer player, IArea area, IMonster monster)
        {
            if (!player.IsInBattle)
            {
                player.Draw();

                ConsoleKey pressedKey = Console.ReadKey(true).Key;
                while (true)
                {
                    player.Move(pressedKey, area.BorderCoordinates);
                    int code = this.CheckIfPlayerLeftArea(player, area);
                    if (code != CodeForStay)
                    {
                        this.LoadArea(player, code, true);
                    }

                    bool collideWithMonster = this.CheckIfPlayerCollidedWithMonster(player, monster);
                    if (collideWithMonster)
                    {
                        this.StartBattleMode(player, monster, area);
                    }

                    pressedKey = Console.ReadKey(true).Key;
                }
            }
        }

        private int CheckIfPlayerLeftArea(IPlayer player, IArea area)
        {
            if (area.ExitAreaPointsUp != null)
            {
                for (int i = 0; i < area.ExitAreaPointsUp.Count; i += 2)
                {
                    if (player.X == area.ExitAreaPointsUp[i] && player.Y == area.ExitAreaPointsUp[i + 1])
                    {
                        return CodeForWentUp;
                    }
                }
            }

            if (area.ExitAreaPointsDown != null)
            {
                for (int i = 0; i < area.ExitAreaPointsDown.Count; i += 2)
                {
                    if (player.X == area.ExitAreaPointsDown[i] && player.Y == area.ExitAreaPointsDown[i + 1])
                    {
                        return CodeForWentDown;
                    }
                }
            }

            if (area.ExitAreaPointsRight != null)
            {
                for (int i = 0; i < area.ExitAreaPointsRight.Count; i += 2)
                {
                    if (player.X == area.ExitAreaPointsRight[i] && player.Y == area.ExitAreaPointsRight[i + 1])
                    {
                        return CodeForWentRight;
                    }
                }
            }

            if (area.ExitAreaPointsLeft != null)
            {
                for (int i = 0; i < area.ExitAreaPointsLeft.Count; i += 2)
                {
                    if (player.X == area.ExitAreaPointsLeft[i] && player.Y == area.ExitAreaPointsLeft[i + 1])
                    {
                        return CodeForWentLeft;
                    }
                }
            }

            return CodeForStay;
        }

        private bool CheckIfPlayerCollidedWithMonster(IPlayer player, IMonster monster)
        {
            return player.X == monster.X && player.Y == monster.Y;
        }

        private void LoadArea(IPlayer player, int code, bool loadMonster)
        {
            IArea area = null;
            switch (code)
            {
                case CodeForWentDown:
                    area = this.areaDatabase.GetRandomAreaWithUpEntrance();
                    player.X = area.PlayerStartPoints[0];
                    player.Y = area.PlayerStartPoints[1];
                    break;
                case CodeForWentUp:
                    area = this.areaDatabase.GetRandomAreaWithDownEntrance();
                    player.X = area.PlayerStartPoints[2];
                    player.Y = area.PlayerStartPoints[3];
                    break;
                case CodeForWentLeft:
                    area = this.areaDatabase.GetRandomAreaWithRightEntrance();
                    player.X = area.PlayerStartPoints[4];
                    player.Y = area.PlayerStartPoints[5];
                    break;
                case CodeForWentRight:
                    area = this.areaDatabase.GetRandomAreaWithLeftEntrance();
                    player.X = area.PlayerStartPoints[6];
                    player.Y = area.PlayerStartPoints[7];
                    break;
            }

            this.menuHandler.ShowArea(area, player);
            if (loadMonster)
            {
                var monster = this.SpawnMonster(1, area);
                this.MovePlayer(player, area, monster);
            }
            else
            {
                this.MovePlayer(player, area);
            }
        }

        private void StartBattleMode(IPlayer player, IMonster monster, IArea area)
        {
            player.IsInBattle = true;
            monster.IsInBattle = true;
            this.menuHandler.ShowMonster(monster);
            this.menuHandler.UpdateMonsterStatus(monster);
            this.menuHandler.DisplayBattleOptions();
        }

        private IMonster SpawnMonster(int level, IArea area)
        {
            int randomSpawnPoint = Random.Next(0, area.SpawningPoints.Count/2);
            int spawnX = area.SpawningPoints[randomSpawnPoint*2];
            int spawnY = area.SpawningPoints[randomSpawnPoint*2 + 1];
            var monster = this.monsterDatabase.GetRandomMonsterByLevel(1);
            monster.X = spawnX;
            monster.Y = spawnY;
            monster.Draw();

            return monster;
        }

        private NewGameOptionsArgs GetPlayerArgs()
        {
            INewGameOptions newGameOptions = new NewGameOptions();
            newGameOptions.PrintMessage();

            return newGameOptions.GetGameOptionsArgs();
        }
    }
}