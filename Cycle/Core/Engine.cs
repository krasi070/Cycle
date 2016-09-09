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
        private const ConsoleKey IncreaseStatusKey = ConsoleKey.I;

        private const int PlayerNewGameStartX = 45;
        private const int PlayerNewGameStartY = 16;
        private const int PlayerNewGameStartLevel = 1;
        private const int PlayerNewGameMagicRobbers = 0;
        private const int PlayerNewGamePoints = 0;
        private const int PlayerNewGameHP = 40;
        private const int PlayerNewGameMP = 20;
        private const int PlayerNewGameAttack = 20;
        private const int PlayerNewGameDefense = 10;
        private const int PlayerNewGameAccuracy = 80;
        private const int PlayerNewGameCriticalChance = 0;

        private const int IncreaseHPBar = 10;
        private const int IncreaseMPBar = 10;
        private const int IncreaseAttackBar = 10;
        private const int IncreaseDefenseBar = 10;
        private const int IncreaseAccuracyBar = 2;
        private const int IncreaseCriticalChanceBar = 1;

        private const int CodeForStay = 0;
        private const int CodeForWentUp = 1;
        private const int CodeForWentDown = 2;
        private const int CodeForWentRight = 3;
        private const int CodeForWentLeft = 4;

        private const string NewGameMoveMessage = "Move {0} with WASD or with the arrow keys.";

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

        private int AreaNumber { get; set; }

        public void Run()
        {
            this.LaunchMainMenu();
        }

        private void LaunchMainMenu()
        {
            menuHandler.DisplayMainMenu();
            var chosenOption = menuHandler.ChooseMainMenuOption();
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
                PlayerNewGamePoints,
                PlayerNewGameMagicRobbers,
                PlayerNewGameHP,
                PlayerNewGameMP,
                PlayerNewGameAttack,
                PlayerNewGameDefense,
                PlayerNewGameAccuracy,
                PlayerNewGameCriticalChance,
                defaultNormalAttacks, 
                new List<IMagicAttack>(),
                color);

            this.AreaNumber = 1;
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
            this.menuHandler.DisplayArea(startArea, player);
            this.menuHandler.WriteTextSlowly(this.TextSpeed, string.Format(NewGameMoveMessage, player.Name));
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
                        this.AreaNumber++;
                        this.LoadArea(player, code, true);
                    }

                    bool collideWithMonster = this.CheckIfPlayerCollidedWithMonster(player, monster);
                    if (collideWithMonster)
                    {
                        this.StartBattleMode(player, monster, area);
                        this.Battle(player, monster, area);
                    }

                    if (pressedKey == IncreaseStatusKey)
                    {
                        this.OpenIncreaseStatusScreen(player, area, monster, Option.First, true);
                    }

                    pressedKey = Console.ReadKey(true).Key;
                }
            }
        }

        private int CheckIfPlayerLeftArea(IPlayer player, IArea area)
        {
            if (area.ExitAreaPointsUp != null)
            {
                for (int i = 0; i < area.ExitAreaPointsUp.Count; i++)
                {
                    if (player.X == area.ExitAreaPointsUp[i].X && player.Y == area.ExitAreaPointsUp[i].Y)
                    {
                        return CodeForWentUp;
                    }
                }
            }

            if (area.ExitAreaPointsDown != null)
            {
                for (int i = 0; i < area.ExitAreaPointsDown.Count; i++)
                {
                    if (player.X == area.ExitAreaPointsDown[i].X && player.Y == area.ExitAreaPointsDown[i].Y)
                    {
                        return CodeForWentDown;
                    }
                }
            }

            if (area.ExitAreaPointsRight != null)
            {
                for (int i = 0; i < area.ExitAreaPointsRight.Count; i++)
                {
                    if (player.X == area.ExitAreaPointsRight[i].X && player.Y == area.ExitAreaPointsRight[i].Y)
                    {
                        return CodeForWentRight;
                    }
                }
            }

            if (area.ExitAreaPointsLeft != null)
            {
                for (int i = 0; i < area.ExitAreaPointsLeft.Count; i++)
                {
                    if (player.X == area.ExitAreaPointsLeft[i].X && player.Y == area.ExitAreaPointsLeft[i].Y)
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
                    player.X = area.PlayerStartPoints[0].X;
                    player.Y = area.PlayerStartPoints[0].Y;
                    break;
                case CodeForWentUp:
                    area = this.areaDatabase.GetRandomAreaWithDownEntrance();
                    player.X = area.PlayerStartPoints[1].X;
                    player.Y = area.PlayerStartPoints[1].Y;
                    break;
                case CodeForWentLeft:
                    area = this.areaDatabase.GetRandomAreaWithRightEntrance();
                    player.X = area.PlayerStartPoints[2].X;
                    player.Y = area.PlayerStartPoints[2].Y;
                    break;
                case CodeForWentRight:
                    area = this.areaDatabase.GetRandomAreaWithLeftEntrance();
                    player.X = area.PlayerStartPoints[3].X;
                    player.Y = area.PlayerStartPoints[3].Y;
                    break;
            }

            this.menuHandler.DisplayArea(area, player);
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
            this.menuHandler.DisplayMonster(monster);
            this.menuHandler.UpdateMonsterStatus(monster);
            this.menuHandler.DisplayBattleOptions();
        }

        private void Battle(IPlayer player, IMonster monster, IArea area)
        {
            var battleOption = this.menuHandler.ChooseBattleOption();
            switch (battleOption)
            {
                case Option.First:
                    // Attack
                    break;
                case Option.Second:
                    // Magic
                    break;
                case Option.Third:
                    // Magic Rober
                    break;
                case Option.Fourth:
                    // Show status
                    break;
            }
        }

        private void OpenIncreaseStatusScreen(
            IPlayer player, 
            IArea area, 
            IMonster monster, 
            Option currOption = Option.First, 
            bool display = false)
        {
            if (display)
            {
                this.menuHandler.DisplayIncreaseStatusScreen(player);    
            }
            
            var option = this.menuHandler.ChooseOptionInStatusIncreaseScreen(player, currOption);
            switch (option)
            {
                case Option.First:
                    this.IncreaseHPIfPossible(player, area, monster);
                    break;
                case Option.Second:
                    this.IncreaseMPIfPossible(player, area, monster);
                    break;
                case Option.Third:
                    this.IncreaseAttackIfPossible(player, area, monster);
                    break;
                case Option.Fourth:
                    this.IncreaseDefenseIfPossible(player, area, monster);
                    break;
                case Option.Fifth:
                    this.IncreaseAccuracyIfPossible(player, area, monster);
                    break;
                case Option.Sixth:
                    this.IncreaseCriticalChanceIfPossible(player, area, monster);
                    break;
                case Option.Seventh:
                    this.CloseStatusMenu(player, area, monster);
                    break;
            }
        }

        private void IncreaseHPIfPossible(IPlayer player, IArea area, IMonster monster)
        {
            if (this.CheckIfPlayerHasEnoughPoints(player))
            {
                player.Points--;
                player.MaxHP += IncreaseHPBar;
                player.Level++;
                this.menuHandler.UpdatePointsInIncreaseScreen(player);
                this.menuHandler.UpdateHPBarInIncreaseScreen(player);
            }

            this.OpenIncreaseStatusScreen(player, area, monster);
        }

        private void IncreaseMPIfPossible(IPlayer player, IArea area, IMonster monster)
        {
            if (this.CheckIfPlayerHasEnoughPoints(player))
            {
                player.Points--;
                player.MaxMP += IncreaseMPBar;
                player.Level++;
                this.menuHandler.UpdatePointsInIncreaseScreen(player);
                this.menuHandler.UpdateMPBarInIncreaseScreen(player);
            }

            this.OpenIncreaseStatusScreen(player, area, monster, Option.Second);
        }

        private void IncreaseAttackIfPossible(IPlayer player, IArea area, IMonster monster)
        {
            if (this.CheckIfPlayerHasEnoughPoints(player))
            {
                player.Points--;
                player.MaxDamage += IncreaseAttackBar;
                player.Level++;
                this.menuHandler.UpdatePointsInIncreaseScreen(player);
                this.menuHandler.UpdateAttackBarInIncreaseScreen(player);
            }

            this.OpenIncreaseStatusScreen(player, area, monster, Option.Third);
        }

        private void IncreaseDefenseIfPossible(IPlayer player, IArea area, IMonster monster)
        {
            if (this.CheckIfPlayerHasEnoughPoints(player))
            {
                player.Points--;
                player.MaxDefense += IncreaseDefenseBar;
                player.Level++;
                this.menuHandler.UpdatePointsInIncreaseScreen(player);
                this.menuHandler.UpdateDefenseBarInIncreaseScreen(player);
            }

            this.OpenIncreaseStatusScreen(player, area, monster, Option.Fourth);
        }

        private void IncreaseAccuracyIfPossible(IPlayer player, IArea area, IMonster monster)
        {
            if (this.CheckIfPlayerHasEnoughPoints(player))
            {
                player.Points--;
                player.MaxAccuracy += IncreaseAccuracyBar;
                player.Level++;
                this.menuHandler.UpdatePointsInIncreaseScreen(player);
                this.menuHandler.UpdateAccuracyBarInIncreaseScreen(player);
            }

            this.OpenIncreaseStatusScreen(player, area, monster, Option.Fifth);
        }

        private void IncreaseCriticalChanceIfPossible(IPlayer player, IArea area, IMonster monster)
        {
            if (this.CheckIfPlayerHasEnoughPoints(player))
            {
                player.Points--;
                player.CriticalChance += IncreaseCriticalChanceBar;
                player.Level++;
                this.menuHandler.UpdatePointsInIncreaseScreen(player);
                this.menuHandler.UpdateCritChanceBarInIncreaseScreen(player);
            }

            this.OpenIncreaseStatusScreen(player, area, monster, Option.Sixth);
        }

        private void CloseStatusMenu(IPlayer player, IArea area, IMonster monster)
        {
            this.menuHandler.DisplayArea(area, player, monster);
            this.menuHandler.WriteText();
            this.MovePlayer(player, area, monster);
        }

        private bool CheckIfPlayerHasEnoughPoints(IPlayer player)
        {
            return player.Points > 0;
        }

        private IMonster SpawnMonster(int level, IArea area)
        {
            int randomSpawnPoint = Random.Next(0, area.SpawningPoints.Count);
            int spawnX = area.SpawningPoints[randomSpawnPoint].X;
            int spawnY = area.SpawningPoints[randomSpawnPoint].Y;
            var monster = this.monsterDatabase.GetRandomMonsterByLevel(level);
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