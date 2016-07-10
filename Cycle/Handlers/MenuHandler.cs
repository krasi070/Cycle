namespace Cycle.Handlers
{
    using System;
    using Interfaces;
    using Enums;

    public class MenuHandler : IMenuHandler
    {
        private const string BackButtonMessage = "Return to battle.";
        private const string NoMagicRobbersMessage = "{0} doesn't have any magic robbers.";
        private const string IncreaseHP = "Increase HP.";
        private const string IncreaseMP = "Increase MP.";
        private const string IncreaseAttack = "Increase attack power.";
        private const string IncreaseDefense = "Increase defense.";
        private const string IncreaseAccuracy = "Increase accuracy.";
        private const string IncreaseCritChance = "Increase critical chance.";
        private const string CloseStatusMenuMessage = "Close status menu.";
        private const string NotEnoughPointsMessage = "Not enough points.";

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

        private Option Option { get; set; }

        public void DisplayMainMenu()
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

        public void DisplayIncreaseStatusScreen(IPlayer player)
        {
            this.mainFrame.ClearInside();
            this.mainFrame.ShowIncreaseStatusScreen(player);
        }

        public void DisplayOptionsBox()
        {
            this.optionsFrame.Draw();
        }

        public void UpdatePlayerStatus(IPlayer player)
        {
            this.playerStatusFrame.Update(player);
        }

        public void UpdatePointsInIncreaseScreen(IPlayer player)
        {
            this.mainFrame.UpdatePointCounter(player);
        }

        public void UpdateHPBarInIncreaseScreen(IPlayer player)
        {
            this.mainFrame.UpdateHPBar(player, ConsoleColor.Yellow, true);
        }

        public void UpdateMPBarInIncreaseScreen(IPlayer player)
        {
            this.mainFrame.UpdateMPBar(player, ConsoleColor.Yellow, true);
        }

        public void UpdateAttackBarInIncreaseScreen(IPlayer player)
        {
            this.mainFrame.UpdateAttackBar(player, ConsoleColor.Yellow, true);
        }

        public void UpdateDefenseBarInIncreaseScreen(IPlayer player)
        {
            this.mainFrame.UpdateDefenseBar(player, ConsoleColor.Yellow, true);
        }

        public void UpdateAccuracyBarInIncreaseScreen(IPlayer player)
        {
            this.mainFrame.UpdateAccuracyBar(player, ConsoleColor.Yellow, true);
        }

        public void UpdateCritChanceBarInIncreaseScreen(IPlayer player)
        {
            this.mainFrame.UpdateCriticalChanceBar(player, ConsoleColor.Yellow, true);
        }

        public void DisplayMonster(IMonster monster)
        {
            this.mainFrame.ClearInside();
            monster.Draw();
            this.monsterStatusFrame.Update(monster);
        }

        public void DisplayArea(IArea area, IPlayer player, IMonster monster = null)
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
                this.ShowMagicRobbingMessage(monster);

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

        public Option ChooseMainMenuOption()
        {
            this.Option = Option.First;
            ConsoleKey pressedKey = Console.ReadKey(true).Key;
            while (pressedKey != ConsoleKey.Enter)
            {
                switch (this.Option)
                {
                    case Option.First:
                        this.MoveFromCurrentOption(
                            Option.Third,
                            Option.Second, 
                            Option.First,
                            Option.First,
                            pressedKey);
                        break;
                    case Option.Second:
                        this.MoveFromCurrentOption(
                            Option.First,
                            Option.Third,
                            Option.Second,
                            Option.Second,
                            pressedKey);
                        break;
                    case Option.Third:
                        this.MoveFromCurrentOption(
                            Option.Second,
                            Option.First,
                            Option.Third,
                            Option.Third,
                            pressedKey);
                        break;
                }

                this.LightUpCorrespondingMainMenuOption();
                pressedKey = Console.ReadKey(true).Key;
            }

            return this.Option;
        }

        public Option ChooseMagicToRob(IUnit monster)
        {
            this.Option = Option.First;
            var pressedKey = Console.ReadKey(true).Key;
            while (pressedKey != ConsoleKey.Enter)
            {
                switch (this.Option)
                {
                    case Option.First:
                        this.MoveFromCurrentOption(
                            Option.Fifth,
                            Option.Third,
                            Option.Second,
                            Option.Second,
                            pressedKey);
                        break;
                    case Option.Second:
                        this.MoveFromCurrentOption(
                            Option.Sixth,
                            Option.Fourth,
                            Option.First,
                            Option.First,
                            pressedKey);
                        break;
                    case Option.Third:
                        this.MoveFromCurrentOption(
                            Option.First,
                            Option.Fifth,
                            Option.Fourth,
                            Option.Fourth,
                            pressedKey);
                        break;
                    case Option.Fourth:
                        this.MoveFromCurrentOption(
                            Option.Second,
                            Option.Sixth,
                            Option.Third,
                            Option.Third,
                            pressedKey);
                        break;
                    case Option.Fifth:
                        this.MoveFromCurrentOption(
                            Option.Third,
                            Option.First,
                            Option.Sixth,
                            Option.Sixth,
                            pressedKey);
                        break;
                    case Option.Sixth:
                        this.MoveFromCurrentOption(
                            Option.Fourth,
                            Option.Second,
                            Option.Fifth,
                            Option.Fifth,
                            pressedKey);
                        break;
                }

                this.LightUpCorrespondingMagicToRob(monster);
                this.ShowMagicRobbingMessage(monster);
                pressedKey = Console.ReadKey(true).Key;
            }

            return this.Option;
        }

        public Option ChooseBattleOption()
        {
            this.Option = Option.First;
            var pressedKey = Console.ReadKey(true).Key;
            while (pressedKey != ConsoleKey.Enter)
            {
                switch (this.Option)
                {
                    case Option.First:
                        this.MoveFromCurrentOption(
                            Option.Third,
                            Option.Third,
                            Option.Second,
                            Option.Second,
                            pressedKey);
                        break;
                    case Option.Second:
                        this.MoveFromCurrentOption(
                            Option.Fourth,
                            Option.Fourth,
                            Option.First,
                            Option.First,
                            pressedKey);
                        break;
                    case Option.Third:
                        this.MoveFromCurrentOption(
                            Option.First,
                            Option.First,
                            Option.Fourth,
                            Option.Fourth,
                            pressedKey);
                        break;
                    case Option.Fourth:
                        this.MoveFromCurrentOption(
                            Option.Second,
                            Option.Second,
                            Option.Third,
                            Option.Third,
                            pressedKey);
                        break;
                }

                this.LightCorrespondingBattleOption();
                pressedKey = Console.ReadKey(true).Key;
            }

            return this.Option;
        }

        public Option ChooseNormalAttack(IPlayer player)
        {
            this.Option = Option.First;
            var pressedKey = Console.ReadKey(true).Key;
            while (pressedKey != ConsoleKey.Enter)
            {
                switch (this.Option)
                {
                    case Option.First:
                        this.MoveFromCurrentOption(
                            Option.Third,
                            Option.Third,
                            Option.Second,
                            Option.Fifth,
                            pressedKey);
                        break;
                    case Option.Second:
                        this.MoveFromCurrentOption(
                            Option.Fourth,
                            Option.Fourth,
                            Option.Fifth,
                            Option.First,
                            pressedKey);
                        break;
                    case Option.Third:
                        this.MoveFromCurrentOption(
                            Option.First,
                            Option.First,
                            Option.Fourth,
                            Option.Fifth,
                            pressedKey);
                        break;
                    case Option.Fourth:
                        this.MoveFromCurrentOption(
                            Option.Second,
                            Option.Second,
                            Option.Fifth,
                            Option.Third,
                            pressedKey);
                        break;
                    case Option.Fifth:
                        this.MoveFromCurrentOption(
                            Option.Fifth,
                            Option.Fifth,
                            Option.First,
                            Option.Second,
                            pressedKey);
                        break;
                }

                this.LightUpCorrespondingNormalAttack(player);
                pressedKey = Console.ReadKey(true).Key;
            }

            return this.Option;
        }

        public Option ChooseMagicAttack(IPlayer player)
        {
            this.Option = Option.First;
            var pressedKey = Console.ReadKey(true).Key;
            while (pressedKey != ConsoleKey.Enter)
            {
                switch (this.Option)
                {
                    case Option.First:
                        this.MoveFromCurrentOption(
                            Option.Fourth,
                            Option.Fourth,
                            Option.Second,
                            Option.Seventh,
                            pressedKey);
                        break;
                    case Option.Second:
                        this.MoveFromCurrentOption(
                            Option.Fifth,
                            Option.Fifth,
                            Option.Third,
                            Option.First,
                            pressedKey);
                        break;
                    case Option.Third:
                        this.MoveFromCurrentOption(
                            Option.Sixth,
                            Option.Sixth,
                            Option.Seventh,
                            Option.Second,
                            pressedKey);
                        break;
                    case Option.Fourth:
                        this.MoveFromCurrentOption(
                            Option.First,
                            Option.First,
                            Option.Fifth,
                            Option.Seventh,
                            pressedKey);
                        break;
                    case Option.Fifth:
                        this.MoveFromCurrentOption(
                            Option.Second,
                            Option.Second,
                            Option.Sixth,
                            Option.Fourth,
                            pressedKey);
                        break;
                    case Option.Sixth:
                        this.MoveFromCurrentOption(
                            Option.Third,
                            Option.Third,
                            Option.Seventh,
                            Option.Fifth,
                            pressedKey);
                        break;
                    case Option.Seventh:
                        this.MoveFromCurrentOption(
                            Option.Seventh,
                            Option.Seventh,
                            Option.First,
                            Option.Third,
                            pressedKey);
                        break;
                }

                this.LightUpCorrespondingMagicAttack(player);
                pressedKey = Console.ReadKey(true).Key;
            }

            return this.Option;
        }

        public Option ChooseStatusOption(IPlayer player)
        {
            this.optionsFrame.ClearInside();
            this.Option = Option.First;
            var pressedKey = Console.ReadKey(true).Key;
            while (pressedKey != ConsoleKey.Enter)
            {
                switch (this.Option)
                {
                    case Option.First:
                        this.MoveFromCurrentOption(
                            Option.First,
                            Option.First,
                            Option.Fifth,
                            Option.Eleventh,
                            pressedKey);
                        break;
                    case Option.Second:
                        this.MoveFromCurrentOption(
                            Option.Fifth,
                            Option.Third,
                            Option.Sixth,
                            Option.First,
                            pressedKey);
                        break;
                    case Option.Third:
                        this.MoveFromCurrentOption(
                            Option.Second,
                            Option.Fourth,
                            Option.Eighth,
                            Option.First,
                            pressedKey);
                        break;
                    case Option.Fourth:
                        this.MoveFromCurrentOption(
                            Option.Third,
                            Option.Fifth,
                            Option.Eighth,
                            Option.First,
                            pressedKey);
                        break;
                    case Option.Fifth:
                        this.MoveFromCurrentOption(
                            Option.Fourth,
                            Option.Second,
                            Option.Tenth,
                            Option.First,
                            pressedKey);
                        break;
                    case Option.Sixth:
                        this.MoveFromCurrentOption(
                            Option.Tenth,
                            Option.Eighth,
                            Option.Seventh,
                            Option.Second,
                            pressedKey);
                        break;
                    case Option.Seventh:
                        this.MoveFromCurrentOption(
                            Option.Eleventh,
                            Option.Ninth,
                            Option.First,
                            Option.Sixth,
                            pressedKey);
                        break;
                    case Option.Eighth:
                        this.MoveFromCurrentOption(
                            Option.Sixth,
                            Option.Tenth,
                            Option.Ninth,
                            Option.Third,
                            pressedKey);
                        break;
                    case Option.Ninth:
                        this.MoveFromCurrentOption(
                            Option.Seventh,
                            Option.Eleventh,
                            Option.First,
                            Option.Eighth,
                            pressedKey);
                        break;
                    case Option.Tenth:
                        this.MoveFromCurrentOption(
                            Option.Eighth,
                            Option.Sixth,
                            Option.Eleventh,
                            Option.Fifth,
                            pressedKey);
                        break;
                    case Option.Eleventh:
                        this.MoveFromCurrentOption(
                            Option.Ninth,
                            Option.Seventh,
                            Option.First,
                            Option.Tenth,
                            pressedKey);
                        break;
                }

                this.LightUpCorrespondingStatusOption(player);
                this.DisplayDescription(player);
                pressedKey = Console.ReadKey(true).Key;
            }

            return this.Option;
        }

        public Option ChooseYesOrNo()
        {
            this.Option = Option.First;
            var pressedKey = Console.ReadKey(true).Key;
            while (pressedKey != ConsoleKey.Enter)
            {
                switch (this.Option)
                {
                    case Option.First:
                        this.MoveFromCurrentOption(
                            Option.Second,
                            Option.Second,
                            Option.First,
                            Option.First,
                            pressedKey);
                        break;
                    case Option.Second:
                        this.MoveFromCurrentOption(
                            Option.First,
                            Option.First,
                            Option.Second,
                            Option.Second,
                            pressedKey);
                        break;
                }

                this.LightUpYesOrNo();
                pressedKey = Console.ReadKey(true).Key;
            }

            return this.Option;
        }

        public Option ChooseOptionInStatusIncreaseScreen(IPlayer player, Option currOption = Option.First)
        {
            this.Option = currOption;
            this.LightUpCorrespondingStatus(player);
            this.WriteCorrespondingDescription(player);
            var pressedKey = Console.ReadKey(true).Key;
            while (pressedKey != ConsoleKey.Enter)
            {
                switch (this.Option)
                {
                    case Option.First:
                        this.MoveFromCurrentOption(
                            Option.Sixth, 
                            Option.Second, 
                            Option.First, 
                            Option.First, 
                            pressedKey);
                        break;
                    case Option.Second:
                        this.MoveFromCurrentOption(
                            Option.First,
                            Option.Third,
                            Option.Second,
                            Option.Second,
                            pressedKey);
                        break;
                    case Option.Third:
                        this.MoveFromCurrentOption(
                            Option.Second,
                            Option.Fourth,
                            Option.Third,
                            Option.Third,
                            pressedKey);
                        break;
                    case Option.Fourth:
                        this.MoveFromCurrentOption(
                            Option.Third,
                            Option.Fifth,
                            Option.Fourth,
                            Option.Fourth,
                            pressedKey);
                        break;
                    case Option.Fifth:
                        this.MoveFromCurrentOption(
                            Option.Fourth,
                            Option.Sixth,
                            Option.Seventh,
                            Option.Seventh,
                            pressedKey);
                        break;
                    case Option.Sixth:
                        this.MoveFromCurrentOption(
                            Option.Fifth,
                            Option.First,
                            Option.Seventh,
                            Option.Seventh,
                            pressedKey);
                        break;
                    case Option.Seventh:
                        this.MoveFromCurrentOption(
                            Option.Seventh,
                            Option.Seventh,
                            Option.Sixth,
                            Option.Sixth,
                            pressedKey);
                        break;
                }

                this.LightUpCorrespondingStatus(player);
                this.WriteCorrespondingDescription(player);
                pressedKey = Console.ReadKey(true).Key;
            }

            return this.Option;
        }

        private void LightUpCorrespondingStatus(IPlayer player)
        {
            switch (this.Option)
            {
                case Option.First:
                    this.mainFrame.LightUpHPBar(player);
                    break;
                case Option.Second:
                    this.mainFrame.LightUpMPBar(player);
                    break;
                case Option.Third:
                    this.mainFrame.LightUpAttackBar(player);
                    break;
                case Option.Fourth:
                    this.mainFrame.LightUpDefenseBar(player);
                    break;
                case Option.Fifth:
                    this.mainFrame.LightUpAccuracyBar(player);
                    break;
                case Option.Sixth:
                    this.mainFrame.LightUpCriticalChanceBar(player);
                    break;
                case Option.Seventh:
                    this.mainFrame.LightUpBackButtonInIncreaseStatusScreen(player);
                    break;
            }
        }

        private void WriteCorrespondingDescription(IPlayer player)
        {
            switch (this.Option)
            {
                case Option.First:
                    this.WriteText(player.Points > 0 ? IncreaseHP : NotEnoughPointsMessage);
                    break;
                case Option.Second:
                    this.WriteText(player.Points > 0 ? IncreaseMP : NotEnoughPointsMessage);
                    break;
                case Option.Third:
                    this.WriteText(player.Points > 0 ? IncreaseAttack : NotEnoughPointsMessage);
                    break;
                case Option.Fourth:
                    this.WriteText(player.Points > 0 ? IncreaseDefense : NotEnoughPointsMessage);
                    break;
                case Option.Fifth:
                    this.WriteText(player.Points > 0 ? IncreaseAccuracy : NotEnoughPointsMessage);
                    break;
                case Option.Sixth:
                    this.WriteText(player.Points > 0 ? IncreaseCritChance : NotEnoughPointsMessage);
                    break;
                case Option.Seventh:
                    this.WriteText(CloseStatusMenuMessage);
                    break;
            }
        }

        private void LightUpYesOrNo()
        {
            switch (this.Option)
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
            switch (this.Option)
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
            switch (this.Option)
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
            switch (this.Option)
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

        private void LightUpCorrespondingMagicToRob(IUnit monster)
        {
            switch (this.Option)
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
            switch (this.Option)
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
            switch (this.Option)
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

        private void LightCorrespondingBattleOption()
        {
            switch (this.Option)
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

        private void ShowMagicRobbingMessage(IUnit monster)
        {
            switch (this.Option)
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
            ConsoleKey pressedKey)
        {
            switch (pressedKey)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    this.Option = up;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    this.Option = down;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    this.Option = right;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    this.Option = left;
                    break;
            }
        }
    }
}