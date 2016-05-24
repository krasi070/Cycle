namespace Cycle.Handlers
{
    using System;
    using Interfaces;
    using Enums;

    public class MenuHandler : IMenuHandler
    {
        private const string BackButtonMessage = "Return to battle.";
        private const string NoMagicRobbersMessage = "{0} doesn't have any magic robbers.";

        private readonly IMainMenu mainMenu;
        private readonly IMainFrame mainFrame;
        private readonly IOptionsFrame optionsFrame;
        private readonly IStatusFrame playerStatusFrame;
        private readonly IStatusFrame monsterStatusFrame;

        public MenuHandler(
            IMainMenu mainMenu,
            IMainFrame mainFrame,
            IOptionsFrame optionsFrame, 
            IStatusFrame playerStatusFrame,
            IStatusFrame monsterStatusFrame)
        {
            this.mainMenu = mainMenu;
            this.mainFrame = mainFrame;
            this.optionsFrame = optionsFrame;
            this.playerStatusFrame = playerStatusFrame;
            this.monsterStatusFrame = monsterStatusFrame;
        }

        public void ShowMainMenu()
        {
            this.mainMenu.DisplayTitle();
            this.mainMenu.DisplayOptions();
        }

        public void WriteText(params string[] text)
        {
            this.optionsFrame.WriteText(text);
        }

        public void WriteTextSlowly(int timeInMilliseconds, params string[] text)
        {
            this.optionsFrame.WriteTextSlowly(timeInMilliseconds, text);
        }

        public void DisplayGameFrame()
        {
            this.mainFrame.Draw();
        }

        public void DisplayPlayerStatusFrame()
        {
            this.playerStatusFrame.Draw();
        }

        public void DisplayOptionsBox()
        {
            this.optionsFrame.Draw();
        }

        public void UpdatePlayerStatus(IPlayer player)
        {
            this.playerStatusFrame.Update(player);
        }

        public void ShowMonster(IMonster monster)
        {
            this.mainFrame.ClearInside();
            monster.Draw();
            this.monsterStatusFrame.Update(monster);
        }

        public void ShowArea(IArea area, IPlayer player, IMonster monster = null)
        {
            this.mainFrame.ClearInside();
            area.Draw();
            player.Draw();
            if (monster != null)
            {
                monster.Draw();
            }
        }

        public void DisplayBattleOptions()
        {
            this.optionsFrame.DisplayOptions();
        }

        public void DisplayBattleNormalAttacks(IPlayer player)
        {
            this.optionsFrame.DisplayNormalAttackOptions(player);
        }

        public void DisplayBattleMagicAttacks(IPlayer player)
        {
            this.optionsFrame.DisplayMagicAttackOptions(player);
        }

        public void DisplayMagicToRob(IPlayer player, IUnit monster)
        {
            if (player.MagicRobbers > 0)
            {
                this.mainFrame.ClearInside();
                this.ShowMagicRobbingMessage(player, monster);

                this.mainFrame.ShowMagicChoiceMenu(monster);
            }
            else
            {
                this.WriteText(string.Format(NoMagicRobbersMessage, player.Name));
            }
        }

        public void DisplayYesAndNo()
        {
            this.optionsFrame.ClearInside();

            this.optionsFrame.DisplayBinaryChoice();
        }

        public void DisplayStatusScreen(IPlayer player)
        {
            this.mainFrame.ShowStatus(player, this.optionsFrame);
        }

        public void UpdateMonsterStatus(IUnit unit)
        {
            this.monsterStatusFrame.Update(unit);
        }

        public Option ChooseMainMenuOption(ConsoleKey pressedKey)
        {
            switch (this.mainMenu.CurrentOption)
            {
                case Option.First:
                    switch (pressedKey)
                    {
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            this.mainMenu.CurrentOption = Option.Third;
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            this.mainMenu.CurrentOption = Option.Second;
                            break;
                    }
                    break;
                case Option.Second:
                    switch (pressedKey)
                    {
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            this.mainMenu.CurrentOption = Option.First;
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            this.mainMenu.CurrentOption = Option.Third;
                            break;
                    }
                    break;
                case Option.Third:
                    switch (pressedKey)
                    {
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            this.mainMenu.CurrentOption = Option.Second;
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            this.mainMenu.CurrentOption = Option.First;
                            break;
                    }
                    break;
            }

            this.LightUpCorrespondingMainMenuOption();

            return this.mainMenu.CurrentOption;
        }

        public void ChooseMagicToRob(ConsoleKey pressedKey, IPlayer player, IUnit monster)
        {
            if (player.IsInBattle)
            {
                switch (player.Option)
                {
                    case Option.First:
                        this.MoveFromCurrentOption(
                            Option.Fifth, 
                            Option.Third, 
                            Option.Second, 
                            Option.Second, 
                            pressedKey,
                            player);
                        break;
                    case Option.Second:
                        this.MoveFromCurrentOption(
                            Option.Sixth, 
                            Option.Fourth, 
                            Option.First, 
                            Option.First, 
                            pressedKey,
                            player);
                        break;
                    case Option.Third:
                        this.MoveFromCurrentOption(
                            Option.First, 
                            Option.Fifth, 
                            Option.Fourth, 
                            Option.Fourth, 
                            pressedKey,
                            player);
                        break;
                    case Option.Fourth:
                        this.MoveFromCurrentOption(
                            Option.Second, 
                            Option.Sixth, 
                            Option.Third, 
                            Option.Third, 
                            pressedKey,
                            player);
                        break;
                    case Option.Fifth:
                        this.MoveFromCurrentOption(
                            Option.Third, 
                            Option.First, 
                            Option.Sixth, 
                            Option.Sixth, 
                            pressedKey,
                            player);
                        break;
                    case Option.Sixth:
                        this.MoveFromCurrentOption(
                            Option.Fourth, 
                            Option.Second, 
                            Option.Fifth, 
                            Option.Fifth, 
                            pressedKey,
                            player);
                        break;
                }

                this.LightUpCorrespondingMagicToRob(player, monster);
                this.ShowMagicRobbingMessage(player, monster);
            }
        }

        public void ChooseBattleOption(ConsoleKey pressedKey, IPlayer player)
        {
            if (player.IsInBattle)
            {
                switch (player.Option)
                {
                    case Option.First:
                        this.MoveFromCurrentOption(
                            Option.Third, 
                            Option.Third, 
                            Option.Second, 
                            Option.Second, 
                            pressedKey,
                            player);
                        break;
                    case Option.Second:
                        this.MoveFromCurrentOption(
                            Option.Fourth, 
                            Option.Fourth, 
                            Option.First, 
                            Option.First, 
                            pressedKey,
                            player);
                        break;
                    case Option.Third:
                        this.MoveFromCurrentOption(
                            Option.First, 
                            Option.First, 
                            Option.Fourth, 
                            Option.Fourth, 
                            pressedKey,
                            player);
                        break;
                    case Option.Fourth:
                        this.MoveFromCurrentOption(
                            Option.Second, 
                            Option.Second, 
                            Option.Third, 
                            Option.Third, 
                            pressedKey,
                            player);
                        break;
                }

                this.LightCorrespondingBattleOption(player);
            }
        }

        public void ChooseNormalAttack(ConsoleKey pressedKey, IPlayer player)
        {
            if (player.IsInBattle)
            {
                switch (player.Option)
                {
                    case Option.First:
                        this.MoveFromCurrentOption(
                            Option.Third, 
                            Option.Third, 
                            Option.Second, 
                            Option.Fifth, 
                            pressedKey,
                            player);
                        break;
                    case Option.Second:
                        this.MoveFromCurrentOption(
                            Option.Fourth, 
                            Option.Fourth, 
                            Option.Fifth, 
                            Option.First, 
                            pressedKey,
                            player);
                        break;
                    case Option.Third:
                        this.MoveFromCurrentOption(
                            Option.First, 
                            Option.First, 
                            Option.Fourth, 
                            Option.Fifth, 
                            pressedKey,
                            player);
                        break;
                    case Option.Fourth:
                        this.MoveFromCurrentOption(
                            Option.Second, 
                            Option.Second, 
                            Option.Fifth, 
                            Option.Third, 
                            pressedKey,
                            player);
                        break;
                    case Option.Fifth:
                        this.MoveFromCurrentOption(
                            Option.Fifth, 
                            Option.Fifth, 
                            Option.First, 
                            Option.Second, 
                            pressedKey,
                            player);
                        break;
                }

                this.LightUpCorrespondingNormalAttack(player);
            }
        }

        public void ChooseMagicAttack(ConsoleKey pressedKey, IPlayer player)
        {
            if (player.IsInBattle)
            {
                switch (player.Option)
                {
                    case Option.First:
                        this.MoveFromCurrentOption(
                            Option.Fourth,
                            Option.Fourth,
                            Option.Second,
                            Option.Seventh,
                            pressedKey,
                            player);
                        break;
                    case Option.Second:
                        this.MoveFromCurrentOption(
                            Option.Fifth, 
                            Option.Fifth, 
                            Option.Third, 
                            Option.First, 
                            pressedKey,
                            player);
                        break;
                    case Option.Third:
                        this.MoveFromCurrentOption(
                            Option.Sixth, 
                            Option.Sixth, 
                            Option.Seventh, 
                            Option.Second, 
                            pressedKey,
                            player);
                        break;
                    case Option.Fourth:
                        this.MoveFromCurrentOption(
                            Option.First, 
                            Option.First, 
                            Option.Fifth, 
                            Option.Seventh, 
                            pressedKey,
                            player);
                        break;
                    case Option.Fifth:
                        this.MoveFromCurrentOption(
                            Option.Second, 
                            Option.Second, 
                            Option.Sixth, 
                            Option.Fourth, 
                            pressedKey,
                            player);
                        break;
                    case Option.Sixth:
                        this.MoveFromCurrentOption(
                            Option.Third, 
                            Option.Third, 
                            Option.Seventh, 
                            Option.Fifth, 
                            pressedKey,
                            player);
                        break;
                    case Option.Seventh:
                        this.MoveFromCurrentOption(
                            Option.Seventh, 
                            Option.Seventh, 
                            Option.First, 
                            Option.Third, 
                            pressedKey,
                            player);
                        break;
                }

                this.LightUpCorrespondingMagicAttack(player);
            }
        }

        public void MoveInStatusOption(ConsoleKey pressedKey, IPlayer player)
        {
            this.optionsFrame.ClearInside();

            if (player.IsInBattle)
            {
                switch (player.Option)
                {
                    case Option.First:
                        this.MoveFromCurrentOption(
                            Option.First, 
                            Option.First, 
                            Option.Fifth, 
                            Option.Eleventh, 
                            pressedKey,
                            player);
                        break;
                    case Option.Second:
                        this.MoveFromCurrentOption(
                            Option.Fifth, 
                            Option.Third, 
                            Option.Sixth, 
                            Option.First, 
                            pressedKey,
                            player);
                        break;
                    case Option.Third:
                        this.MoveFromCurrentOption(
                            Option.Second, 
                            Option.Fourth, 
                            Option.Eighth, 
                            Option.First, 
                            pressedKey,
                            player);
                        break;
                    case Option.Fourth:
                        this.MoveFromCurrentOption(
                            Option.Third, 
                            Option.Fifth, 
                            Option.Eighth, 
                            Option.First, 
                            pressedKey,
                            player);
                        break;
                    case Option.Fifth:
                        this.MoveFromCurrentOption(
                            Option.Fourth, 
                            Option.Second, 
                            Option.Tenth, 
                            Option.First, 
                            pressedKey,
                            player);
                        break;
                    case Option.Sixth:
                        this.MoveFromCurrentOption(
                            Option.Tenth, 
                            Option.Eighth, 
                            Option.Seventh, 
                            Option.Second, 
                            pressedKey,
                            player);
                        break;
                    case Option.Seventh:
                        this.MoveFromCurrentOption(
                            Option.Eleventh, 
                            Option.Ninth, 
                            Option.First, 
                            Option.Sixth, 
                            pressedKey,
                            player);
                        break;
                    case Option.Eighth:
                        this.MoveFromCurrentOption(
                            Option.Sixth, 
                            Option.Tenth, 
                            Option.Ninth, 
                            Option.Third, 
                            pressedKey,
                            player);
                        break;
                    case Option.Ninth:
                        this.MoveFromCurrentOption(
                            Option.Seventh, 
                            Option.Eleventh, 
                            Option.First, 
                            Option.Eighth, 
                            pressedKey,
                            player);
                        break;
                    case Option.Tenth:
                        this.MoveFromCurrentOption(
                            Option.Eighth, 
                            Option.Sixth, 
                            Option.Eleventh, 
                            Option.Fifth, 
                            pressedKey,
                            player);
                        break;
                    case Option.Eleventh:
                        this.MoveFromCurrentOption(
                            Option.Ninth, 
                            Option.Seventh, 
                            Option.First, 
                            Option.Tenth, 
                            pressedKey,
                            player);
                        break;
                }

                this.LightUpCorrespondingStatusOption(player);
                this.DisplayDescription(player);
            }
        }

        public void ChooseYesOrNo(ConsoleKey pressedKey, IPlayer player)
        {
            switch (player.Option)
            {
                case Option.First:
                    this.MoveFromCurrentOption(
                        Option.Second, 
                        Option.Second, 
                        Option.First, 
                        Option.First, 
                        pressedKey,
                        player);
                    break;
                case Option.Second:
                    this.MoveFromCurrentOption(
                        Option.First, 
                        Option.First, 
                        Option.Second, 
                        Option.Second, 
                        pressedKey,
                        player);
                    break;
            }

            this.LightUpYesOrNo(player);
        }

        private void LightUpYesOrNo(IPlayer player)
        {
            switch (player.Option)
            {
                case Option.First:
                    this.optionsFrame.LightUpNoButton();
                    break;
                case Option.Second:
                    this.optionsFrame.LightUpYesButton();
                    break;
            }
        }

        private void LightUpCorrespondingMainMenuOption()
        {
            switch (this.mainMenu.CurrentOption)
            {
                case Option.First:
                    this.mainMenu.LightUpNewGameButton();
                    break;
                case Option.Second:
                    this.mainMenu.LightUpLoadGameButton();
                    break;
                case Option.Third:
                    this.mainMenu.LightUpQuitButton();
                    break;
            }
        }

        private void LightUpCorrespondingMagicAttack(IPlayer player)
        {
            switch (player.Option)
            {
                case Option.First:
                    this.optionsFrame.LightUpFirstMagicAttack(player);
                    break;
                case Option.Second:
                    this.optionsFrame.LightUpSecondMagicAttack(player);
                    break;
                case Option.Third:
                    this.optionsFrame.LightUpThirdMagicAttack(player);
                    break;
                case Option.Fourth:
                    this.optionsFrame.LightUpFourthMagicAttack(player);
                    break;
                case Option.Fifth:
                    this.optionsFrame.LightUpFifthMagicAttack(player);
                    break;
                case Option.Sixth:
                    this.optionsFrame.LightUpSixthMagicAttack(player);
                    break;
                case Option.Seventh:
                    this.optionsFrame.LightUpBattleMagicBackButton(player);
                    break;
            }
        }

        private void DisplayDescription(IPlayer player)
        {
            switch (player.Option)
            {
                case Option.First:
                    this.optionsFrame.WriteText(BackButtonMessage);
                    break;
                case Option.Second:
                    if (player.NormalAttacks.Count >= 1)
                    {
                        this.optionsFrame.WriteText(player.NormalAttacks[0].Description);
                    }

                    break;
                case Option.Third:
                    if (player.NormalAttacks.Count >= 2)
                    {
                        this.optionsFrame.WriteText(player.NormalAttacks[1].Description);
                    }

                    break;
                case Option.Fourth:
                    if (player.NormalAttacks.Count >= 3)
                    {
                        this.optionsFrame.WriteText(player.NormalAttacks[2].Description);
                    }

                    break;
                case Option.Fifth:
                    if (player.NormalAttacks.Count >= 4)
                    {
                        this.optionsFrame.WriteText(player.NormalAttacks[3].Description);
                    }

                    break;
                case Option.Sixth:
                    if (player.MagicAttacks.Count >= 1)
                    {
                        this.optionsFrame.WriteText(player.MagicAttacks[0].Description);
                    }

                    break;
                case Option.Seventh:
                    if (player.MagicAttacks.Count >= 2)
                    {
                        this.optionsFrame.WriteText(player.MagicAttacks[1].Description);
                    }

                    break;
                case Option.Eighth:
                    if (player.MagicAttacks.Count >= 3)
                    {
                        this.optionsFrame.WriteText(player.MagicAttacks[2].Description);
                    }

                    break;
                case Option.Ninth:
                    if (player.MagicAttacks.Count >= 4)
                    {
                        this.optionsFrame.WriteText(player.MagicAttacks[3].Description);
                    }

                    break;
                case Option.Tenth:
                    if (player.MagicAttacks.Count >= 5)
                    {
                        this.optionsFrame.WriteText(player.MagicAttacks[4].Description);
                    }

                    break;
                case Option.Eleventh:
                    if (player.MagicAttacks.Count >= 6)
                    {
                        this.optionsFrame.WriteText(player.MagicAttacks[5].Description);
                    }

                    break;
            }
        }

        private void LightUpCorrespondingMagicToRob(IPlayer player, IUnit monster)
        {
            switch (player.Option)
            {
                case Option.First:
                    this.mainFrame.LightUpFirstMagicToRob(monster);
                    break;
                case Option.Second:
                    this.mainFrame.LightUpSecondMagicToRob(monster);
                    break;
                case Option.Third:
                    this.mainFrame.LightUpThirdMagicToRob(monster);
                    break;
                case Option.Fourth:
                    this.mainFrame.LightUpFourthMagicToRob(monster);
                    break;
                case Option.Fifth:
                    this.mainFrame.LightUpFifthMagicToRob(monster);
                    break;
                case Option.Sixth:
                    this.mainFrame.LightUpSixthMagicToRob(monster);
                    break;
            }
        }

        private void LightUpCorrespondingStatusOption(IPlayer player)
        {
            switch (player.Option)
            {
                case Option.First:
                    this.mainFrame.LightUpBackButton(player);
                    break;
                case Option.Second:
                    this.mainFrame.LightUpFirstNormalAttack(player);
                    break;
                case Option.Third:
                    this.mainFrame.LightUpSecondNormalAttack(player);
                    break;
                case Option.Fourth:
                    this.mainFrame.LightUpThirdNormalAttack(player);
                    break;
                case Option.Fifth:
                    this.mainFrame.LightUpFourthNormalAttack(player);
                    break;
                case Option.Sixth:
                    this.mainFrame.LightUpFirstMagicAttack(player);
                    break;
                case Option.Seventh:
                    this.mainFrame.LightUpSecondMagicAttack(player);
                    break;
                case Option.Eighth:
                    this.mainFrame.LightUpThirdMagicAttack(player);
                    break;
                case Option.Ninth:
                    this.mainFrame.LightUpFourthMagicAttack(player);
                    break;
                case Option.Tenth:
                    this.mainFrame.LightUpFifthMagicAttack(player);
                    break;
                case Option.Eleventh:
                    this.mainFrame.LightUpSixthMagicAttack(player);
                    break;
            }
        }

        private void LightUpCorrespondingNormalAttack(IPlayer player)
        {
            switch (player.Option)
            {
                case Option.First:
                    this.optionsFrame.LightUpFirstNormalAttack(player);
                    break;
                case Option.Second:
                    this.optionsFrame.LightUpSecondNormalAttack(player);
                    break;
                case Option.Third:
                    this.optionsFrame.LightUpThirdNormalAttack(player);
                    break;
                case Option.Fourth:
                    this.optionsFrame.LightUpFourthNormalAttack(player);
                    break;
                case Option.Fifth:
                    this.optionsFrame.LightUpBattleNormalBackButton(player);
                    break;
            }
        }

        private void LightCorrespondingBattleOption(IPlayer player)
        {
            switch (player.Option)
            {
                case Option.First:
                    this.optionsFrame.LightUpAttackOption();
                    break;
                case Option.Second:
                    this.optionsFrame.LightUpMagicOption();
                    break;
                case Option.Third:
                    this.optionsFrame.LightUpMagicRobberOption();
                    break;
                case Option.Fourth:
                    this.optionsFrame.LightUpStatusOption();
                    break;
                default:
                    break;
            }
        }

        private void ShowMagicRobbingMessage(IPlayer player, IUnit monster)
        {
            switch (player.Option)
            {
                case Option.First:
                    if (monster.MagicAttacks.Count >= 1)
                    {
                        this.WriteText(monster.MagicAttacks[0].Description);
                    }
                    else
                    {
                        this.optionsFrame.ClearInside();
                    }
                    break;
                case Option.Second:
                    if (monster.MagicAttacks.Count >= 2)
                    {
                        this.WriteText(monster.MagicAttacks[1].Description);
                    }
                    else
                    {
                        this.optionsFrame.ClearInside();
                    }
                    break;
                case Option.Third:
                    if (monster.MagicAttacks.Count >= 3)
                    {
                        this.WriteText(monster.MagicAttacks[2].Description);
                    }
                    else
                    {
                        this.optionsFrame.ClearInside();
                    }
                    break;
                case Option.Fourth:
                    if (monster.MagicAttacks.Count >= 4)
                    {
                        this.WriteText(monster.MagicAttacks[3].Description);
                    }
                    else
                    {
                        this.optionsFrame.ClearInside();
                    }
                    break;
                case Option.Fifth:
                    if (monster.MagicAttacks.Count >= 5)
                    {
                        this.WriteText(monster.MagicAttacks[4].Description);
                    }
                    else
                    {
                        this.optionsFrame.ClearInside();
                    }
                    break;
                case Option.Sixth:
                    if (monster.MagicAttacks.Count >= 6)
                    {
                        this.WriteText(monster.MagicAttacks[5].Description);
                    }
                    else
                    {
                        this.optionsFrame.ClearInside();
                    }
                    break;
            }
        }

        private void MoveFromCurrentOption(
            Option up,
            Option down,
            Option right,
            Option left,
            ConsoleKey pressedKey,
            IPlayer player)
        {
            switch (pressedKey)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    player.Option = up;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    player.Option = down;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    player.Option = right;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    player.Option = left;
                    break;
            }
        }
    }
}