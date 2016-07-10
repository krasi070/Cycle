namespace Cycle.GameFrames
{
    using System;
    using Interfaces;

    public class MainFrame : SimpleGameFrame, IMainFrame
    {
        public static int StartWidth = 5;
        public static int EndWidth = 84;
        public static int Width = EndWidth - StartWidth;
        public static int StartHeight = 5;
        public static int EndHeight = 19;
        public static int Height = EndHeight - StartHeight;

        private const int MaxPossiblePlayerHP = 1000;
        private const int MaxPossiblePlayerMP = 1000;
        private const int MaxPossiblePlayerATT = 1000;
        private const int MaxPossiblePlayerDEF = 1000;
        private const int MaxPossiblePlayerACC = 200;
        private const int MaxPossiblePlayerCRIT = 100;

        private const string DefaultAttackName = "[Empty Slot]";
        private const string NormalType = "Normal";
        private const string MagicType = "Magic";

        // TODO: Add save file screen
        public MainFrame()
            : base(StartWidth, EndWidth, StartHeight, EndHeight)
        {
        }

        public void ShowMagicChoiceMenu(IUnit monster)
        {
            this.DisplayFirstMonsterMagic(monster, ConsoleColor.DarkMagenta, true);
            this.DisplaySecondMonsterMagic(monster);
            this.DisplayThirdMonsterMagic(monster);
            this.DisplayFourthMonsterMagic(monster);
            this.DisplayFifthMonsterMagic(monster);
            this.DisplaySixthMonsterMagic(monster);
        }

        public void ShowStatus(IPlayer player, IOptionsFrame optionsFrame)
        {
            this.ClearInside();
            optionsFrame.ClearInside();
            optionsFrame.WriteText("Return to battle.");

            this.DisplayStats(player);
            this.DisplayBackButton(ConsoleColor.Yellow, true);

            Console.SetCursorPosition(StartWidth + 26, StartHeight + 1);
            Console.Write("Normal Attacks:");
            this.DisplayNormalAttacks(player);

            Console.SetCursorPosition(StartWidth + 54, StartHeight + 2);
            Console.Write("Magic Attacks:");
            this.DisplayMagicAttacks(player);
        }

        public void ShowIncreaseStatusScreen(IPlayer player)
        {
            this.UpdatePointCounter(player);
            this.UpdateHPBar(player);
            this.UpdateMPBar(player);
            this.UpdateAttackBar(player);
            this.UpdateDefenseBar(player);
            this.UpdateAccuracyBar(player);
            this.UpdateCriticalChanceBar(player);
            this.DisplayBackButtonInIncreaseStatusScreen();
        }

        public void UpdatePointCounter(IPlayer player)
        {
            Console.SetCursorPosition(StartWidth + 1, StartHeight + 1);
            Console.Write("Points: {0}", player.Points);
        }

        public void UpdateHPBar(IPlayer player, ConsoleColor color = ConsoleColor.White, bool showNewValue = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 5, StartHeight + 3);
            int hpBarHalf = player.MaxHP % 20 / 10;
            int hpBarFull = player.MaxHP / 20;
            if (showNewValue)
            {
                if (hpBarHalf == 0 && hpBarFull < 50)
                {
                    hpBarHalf = 1;
                }
                else
                {
                    hpBarFull++;
                    hpBarHalf = 0;
                }
            }

            Console.Write(
                "HP|{0}{1}{2}|",
                new string(':', hpBarFull),
                new string('.', hpBarHalf),
                new string(' ', 50 - hpBarFull - hpBarHalf));

            if (showNewValue)
            {
                if (player.MaxHP < MaxPossiblePlayerHP)
                {
                    Console.Write("   {0} -> {1}", player.MaxHP, player.MaxHP + 10);
                }
                else
                {
                    Console.Write("   MAX");
                }
            }
            else
            {
                Console.Write(new string(' ', EndWidth - (StartWidth + 59)));
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void UpdateMPBar(IPlayer player, ConsoleColor color = ConsoleColor.White, bool showNewValue = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 5, StartHeight + 5);
            int mpBarHalf = player.MaxMP % 20 / 10;
            int mpBarFull = player.MaxMP / 20;
            if (showNewValue)
            {
                if (mpBarHalf == 0 && mpBarFull < 50)
                {
                    mpBarHalf = 1;
                }
                else
                {
                    mpBarFull++;
                    mpBarHalf = 0;
                }
            }

            Console.Write(
                "MP|{0}{1}{2}|",
                new string(':', mpBarFull),
                new string('.', mpBarHalf),
                new string(' ', 50 - mpBarFull - mpBarHalf));

            if (showNewValue)
            {
                if (player.MaxMP < MaxPossiblePlayerMP)
                {
                    Console.Write("   {0} -> {1}", player.MaxMP, player.MaxMP + 10);
                }
                else
                {
                    Console.Write("   MAX");
                }
            }
            else
            {
                Console.Write(new string(' ', EndWidth - (StartWidth + 59)));
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void UpdateAttackBar(IPlayer player, ConsoleColor color = ConsoleColor.White, bool showNewValue = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 4, StartHeight + 7);
            int attackBarHalf = player.MaxDamage % 20 / 10;
            int attackBarFull = player.MaxDamage / 20;
            if (showNewValue)
            {
                if (attackBarHalf == 0 && attackBarFull < 50)
                {
                    attackBarHalf = 1;
                }
                else
                {
                    attackBarFull++;
                    attackBarHalf = 0;
                }
            }

            Console.Write("ATT|{0}{1}{2}|",
                new string(':', attackBarFull),
                new string('.', attackBarHalf),
                new string(' ', 50 - attackBarFull - attackBarHalf));

            if (showNewValue)
            {
                if (player.MaxDamage < MaxPossiblePlayerATT)
                {
                    Console.Write("   {0} -> {1}", player.MaxDamage, player.MaxDamage + 10);
                }
                else
                {
                    Console.Write("   MAX");
                }
            }
            else
            {
                Console.Write(new string(' ', EndWidth - (StartWidth + 59)));
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void UpdateDefenseBar(IPlayer player, ConsoleColor color = ConsoleColor.White, bool showNewValue = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 4, StartHeight + 9);
            int defBarHalf = player.MaxDefense % 20 / 10;
            int defBarFull = player.MaxDefense / 20;
            if (showNewValue)
            {
                if (defBarHalf == 0 && defBarFull < 50)
                {
                    defBarHalf = 1;
                }
                else
                {
                    defBarFull++;
                    defBarHalf = 0;
                }
            }

            Console.Write("DEF|{0}{1}{2}|",
                new string(':', defBarFull),
                new string('.', defBarHalf),
                new string(' ', 50 - defBarFull - defBarHalf));

            if (showNewValue)
            {
                if (player.MaxDefense < MaxPossiblePlayerDEF)
                {
                    Console.Write("   {0} -> {1}", player.MaxDefense, player.MaxDefense + 10);
                }
                else
                {
                    Console.Write("   MAX");
                }
            }
            else
            {
                Console.Write(new string(' ', EndWidth - (StartWidth + 59)));
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void UpdateAccuracyBar(IPlayer player, ConsoleColor color = ConsoleColor.White, bool showNewValue = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 4, StartHeight + 11);
            int accuracyBarHalf = player.MaxAccuracy % 4 / 2;
            int accuracyBarFull = player.MaxAccuracy / 4;
            if (showNewValue)
            {
                if (accuracyBarHalf == 0 && accuracyBarFull < 50)
                {
                    accuracyBarHalf = 1;
                }
                else
                {
                    accuracyBarFull++;
                    accuracyBarHalf = 0;
                }
            }

            Console.Write("ACC|{0}{1}{2}|",
                new string(':', accuracyBarFull),
                new string('.', accuracyBarHalf),
                new string(' ', 50 - accuracyBarFull - accuracyBarHalf));

            if (showNewValue)
            {
                if (player.MaxAccuracy < MaxPossiblePlayerACC)
                {
                    Console.Write("   {0} -> {1}", player.MaxAccuracy, player.MaxAccuracy + 2);
                }
                else
                {
                    Console.Write("   MAX");
                }
            }
            else
            {
                Console.Write(new string(' ', EndWidth - (StartWidth + 59)));
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void UpdateCriticalChanceBar(IPlayer player, ConsoleColor color = ConsoleColor.White, bool showNewValue = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 3, StartHeight + 13);
            int critBarFull = player.CriticalChance / 2;
            int critBarHalf = player.CriticalChance % 2;
            if (showNewValue)
            {
                if (critBarHalf == 0 && critBarFull < 50)
                {
                    critBarHalf = 1;
                }
                else
                {
                    critBarFull++;
                    critBarHalf = 0;
                }
            }

            Console.Write("CRIT|{0}{1}{2}|",
                new string(':', critBarFull),
                new string('.', critBarHalf),
                new string(' ', 50 - critBarFull - critBarHalf));

            if (showNewValue)
            {
                if (player.CriticalChance < MaxPossiblePlayerCRIT)
                {
                    Console.Write("   {0} -> {1}", player.CriticalChance, player.CriticalChance + 1);
                }
                else
                {
                    Console.Write("   MAX");
                }
            }
            else
            {
                Console.Write(new string(' ', EndWidth - (StartWidth + 59)));
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void LightUpHPBar(IPlayer player)
        {
            this.UpdateMPBar(player);
            this.UpdateCriticalChanceBar(player);
            this.DisplayBackButtonInIncreaseStatusScreen();
            this.UpdateHPBar(player, ConsoleColor.Yellow, true);
        }

        public void LightUpMPBar(IPlayer player)
        {
            this.UpdateMPBar(player, ConsoleColor.Yellow, true);
            this.UpdateAttackBar(player);
            this.UpdateHPBar(player);
        }

        public void LightUpAttackBar(IPlayer player)
        {
            this.UpdateAttackBar(player, ConsoleColor.Yellow, true);
            this.UpdateMPBar(player);
            this.UpdateDefenseBar(player);
        }

        public void LightUpDefenseBar(IPlayer player)
        {
            this.UpdateAttackBar(player);
            this.UpdateAccuracyBar(player);
            this.DisplayBackButtonInIncreaseStatusScreen();
            this.UpdateDefenseBar(player, ConsoleColor.Yellow, true);
        }

        public void LightUpAccuracyBar(IPlayer player)
        {
            this.UpdateDefenseBar(player);
            this.UpdateCriticalChanceBar(player);
            this.DisplayBackButtonInIncreaseStatusScreen();
            this.UpdateAccuracyBar(player, ConsoleColor.Yellow, true);
        }

        public void LightUpCriticalChanceBar(IPlayer player)
        {
            this.UpdateAccuracyBar(player);
            this.UpdateHPBar(player);
            this.DisplayBackButtonInIncreaseStatusScreen();
            this.UpdateCriticalChanceBar(player, ConsoleColor.Yellow, true);
        }

        public void LightUpBackButtonInIncreaseStatusScreen(IPlayer player)
        {
            this.UpdateCriticalChanceBar(player);
            this.UpdateAccuracyBar(player);
            this.DisplayBackButtonInIncreaseStatusScreen(ConsoleColor.Yellow, true);
        }

        public void LightUpFirstMagicToRob(IUnit monster)
        {
            this.DisplaySecondMonsterMagic(monster);
            this.DisplayThirdMonsterMagic(monster);
            this.DisplayFifthMonsterMagic(monster);

            this.DisplayFirstMonsterMagic(monster, ConsoleColor.DarkMagenta, true);
        }

        public void LightUpSecondMagicToRob(IUnit monster)
        {
            this.DisplayFirstMonsterMagic(monster);
            this.DisplayFourthMonsterMagic(monster);
            this.DisplaySixthMonsterMagic(monster);

            this.DisplaySecondMonsterMagic(monster, ConsoleColor.DarkMagenta, true);
        }

        public void LightUpThirdMagicToRob(IUnit monster)
        {
            this.DisplayFirstMonsterMagic(monster);
            this.DisplayFifthMonsterMagic(monster);
            this.DisplayFourthMonsterMagic(monster);

            this.DisplayThirdMonsterMagic(monster, ConsoleColor.DarkMagenta, true);
        }

        public void LightUpFourthMagicToRob(IUnit monster)
        {
            this.DisplaySecondMonsterMagic(monster);
            this.DisplaySixthMonsterMagic(monster);
            this.DisplayThirdMonsterMagic(monster);

            this.DisplayFourthMonsterMagic(monster, ConsoleColor.DarkMagenta, true);
        }

        public void LightUpFifthMagicToRob(IUnit monster)
        {
            this.DisplayFirstMonsterMagic(monster);
            this.DisplayThirdMonsterMagic(monster);
            this.DisplaySixthMonsterMagic(monster);

            this.DisplayFifthMonsterMagic(monster, ConsoleColor.DarkMagenta, true);
        }

        public void LightUpSixthMagicToRob(IUnit monster)
        {
            this.DisplaySecondMonsterMagic(monster);
            this.DisplayFourthMonsterMagic(monster);
            this.DisplayFifthMonsterMagic(monster);

            this.DisplaySixthMonsterMagic(monster, ConsoleColor.DarkMagenta, true);
        }

        public void LightUpBackButton(IPlayer player)
        {
            this.DisplayFirstNormalAttack(player);
            this.DisplaySecondNormalAttack(player);
            this.DisplayThirdNormalAttack(player);
            this.DisplayFourthNormalAttack(player);
            this.DisplaySecondMagicAttack(player);
            this.DisplayFourthMagicAttack(player);
            this.DisplaySixthMagicAttack(player);

            this.DisplayBackButton(ConsoleColor.Yellow, true);
        }

        public void LightUpFirstNormalAttack(IPlayer player)
        {
            this.DisplaySecondNormalAttack(player);
            this.DisplayFourthNormalAttack(player);
            this.DisplayFirstMagicAttack(player);

            this.DisplayFirstNormalAttack(player, ConsoleColor.Yellow, true);
        }

        public void LightUpSecondNormalAttack(IPlayer player)
        {
            this.DisplayFirstNormalAttack(player);
            this.DisplayThirdNormalAttack(player);
            this.DisplayThirdMagicAttack(player);

            this.DisplaySecondNormalAttack(player, ConsoleColor.Yellow, true);
        }

        public void LightUpThirdNormalAttack(IPlayer player)
        {
            this.DisplaySecondNormalAttack(player);
            this.DisplayFourthNormalAttack(player);

            this.DisplayThirdNormalAttack(player, ConsoleColor.Yellow, true);
        }

        public void LightUpFourthNormalAttack(IPlayer player)
        {
            this.DisplayBackButton();
            this.DisplayFirstNormalAttack(player);
            this.DisplayThirdNormalAttack(player);
            this.DisplayFifthMagicAttack(player);

            this.DisplayFourthNormalAttack(player, ConsoleColor.Yellow, true);
        }

        public void LightUpFirstMagicAttack(IPlayer player)
        {
            this.DisplayFirstNormalAttack(player);
            this.DisplaySecondMagicAttack(player);
            this.DisplayFifthMagicAttack(player);
            this.DisplayThirdMagicAttack(player);

            this.DisplayFirstMagicAttack(player, ConsoleColor.Yellow, true);
        }

        public void LightUpSecondMagicAttack(IPlayer player)
        {
            this.DisplayFirstMagicAttack(player);
            this.DisplayFourthMagicAttack(player);
            this.DisplaySixthMagicAttack(player);

            this.DisplaySecondMagicAttack(player, ConsoleColor.Yellow, true);
        }

        public void LightUpThirdMagicAttack(IPlayer player)
        {
            this.DisplaySecondNormalAttack(player);
            this.DisplayThirdNormalAttack(player);
            this.DisplayFirstMagicAttack(player);
            this.DisplayFourthMagicAttack(player);
            this.DisplayFifthMagicAttack(player);

            this.DisplayThirdMagicAttack(player, ConsoleColor.Yellow, true);
        }

        public void LightUpFourthMagicAttack(IPlayer player)
        {
            this.DisplaySecondMagicAttack(player);
            this.DisplayThirdMagicAttack(player);
            this.DisplaySixthMagicAttack(player);

            this.DisplayFourthMagicAttack(player, ConsoleColor.Yellow, true);
        }

        public void LightUpFifthMagicAttack(IPlayer player)
        {
            this.DisplayFourthNormalAttack(player);
            this.DisplayThirdMagicAttack(player);
            this.DisplayFirstMagicAttack(player);
            this.DisplaySixthMagicAttack(player);

            this.DisplayFifthMagicAttack(player, ConsoleColor.Yellow, true);
        }

        public void LightUpSixthMagicAttack(IPlayer player)
        {
            this.DisplaySecondMagicAttack(player);
            this.DisplayFourthMagicAttack(player);
            this.DisplayBackButton();
            this.DisplayFifthMagicAttack(player);

            this.DisplaySixthMagicAttack(player, ConsoleColor.Yellow, true);
        }

        private void DisplayBackButtonInIncreaseStatusScreen(
            ConsoleColor color = ConsoleColor.White,
            bool showArrow = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(EndWidth - 7, EndHeight - 3);
            Console.Write("+----+");
            Console.SetCursorPosition(EndWidth - 7, EndHeight - 2);
            Console.Write("|BACK|");
            Console.SetCursorPosition(EndWidth - 7, EndHeight - 1);
            Console.Write("+----+");

            if (showArrow)
            {
                Console.SetCursorPosition(EndWidth - 8, EndHeight - 2);
                Console.Write(">");
                Console.SetCursorPosition(EndWidth - 1, EndHeight - 2);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(EndWidth - 8, EndHeight - 2);
                Console.Write(" ");
                Console.SetCursorPosition(EndWidth - 1, EndHeight - 2);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayStats(IPlayer player)
        {
            Console.SetCursorPosition(StartWidth + 5, StartHeight + 2);
            Console.Write("Points: {0}", player.Points);

            Console.SetCursorPosition(StartWidth + 5, StartHeight + 4);
            Console.Write("Damage: {0}", player.MaxDamage);

            Console.SetCursorPosition(StartWidth + 5, StartHeight + 6);
            Console.Write("Accuracy: {0}", player.MaxAccuracy);

            Console.SetCursorPosition(StartWidth + 5, StartHeight + 8);
            Console.Write("Critical Chance: {0}", player.CriticalChance);

            Console.SetCursorPosition(StartWidth + 5, StartHeight + 10);
            Console.Write("Magic Robbers: {0}", player.MagicRobbers);
        }

        private void DisplayFirstMonsterMagic(
            IUnit monster,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int width = 30;
            string attackName = this.GetAttackName(1, MagicType, monster);

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 6, StartHeight + 2);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 6, StartHeight + 3);
            Console.Write("|{0}{1}{0}|", new string(' ', (width - 2 - attackName.Length) / 2), attackName);
            Console.SetCursorPosition(StartWidth + 6, StartHeight + 4);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 5, StartHeight + 3);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 6 + width, StartHeight + 3);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 5, StartHeight + 3);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 6 + width, StartHeight + 3);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplaySecondMonsterMagic(
            IUnit monster,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int width = 30;
            string attackName = this.GetAttackName(2, MagicType, monster);

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 14 + width, StartHeight + 2);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 14 + width, StartHeight + 3);
            Console.Write("|{0}{1}{0}|", new string(' ', (width - 2 - attackName.Length) / 2), attackName);
            Console.SetCursorPosition(StartWidth + 14 + width, StartHeight + 4);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 13 + width, StartHeight + 3);
                Console.Write(">");
                Console.SetCursorPosition((StartWidth + 14) + (2 * width), StartHeight + 3);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 13 + width, StartHeight + 3);
                Console.Write(" ");
                Console.SetCursorPosition((StartWidth + 14) + (2 * width), StartHeight + 3);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayThirdMonsterMagic(
            IUnit monster,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int width = 30;
            string attackName = this.GetAttackName(3, MagicType, monster);

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 6, StartHeight + 6);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 6, StartHeight + 7);
            Console.Write("|{0}{1}{0}|", new string(' ', (width - 2 - attackName.Length) / 2), attackName);
            Console.SetCursorPosition(StartWidth + 6, StartHeight + 8);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 5, StartHeight + 7);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 6 + width, StartHeight + 7);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 5, StartHeight + 7);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 6 + width, StartHeight + 7);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayFourthMonsterMagic(
            IUnit monster,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int width = 30;
            string attackName = this.GetAttackName(4, MagicType, monster);

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 14 + width, StartHeight + 6);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 14 + width, StartHeight + 7);
            Console.Write("|{0}{1}{0}|", new string(' ', (width - 2 - attackName.Length) / 2), attackName);
            Console.SetCursorPosition(StartWidth + 14 + width, StartHeight + 8);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 13 + width, StartHeight + 7);
                Console.Write(">");
                Console.SetCursorPosition((StartWidth + 14) + (2 * width), StartHeight + 7);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 13 + width, StartHeight + 7);
                Console.Write(" ");
                Console.SetCursorPosition((StartWidth + 14) + (2 * width), StartHeight + 7);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayFifthMonsterMagic(
            IUnit monster,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int width = 30;
            string attackName = this.GetAttackName(5, MagicType, monster);

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 6, StartHeight + 10);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 6, StartHeight + 11);
            Console.Write("|{0}{1}{0}|", new string(' ', (width - 2 - attackName.Length) / 2), attackName);
            Console.SetCursorPosition(StartWidth + 6, StartHeight + 12);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 5, StartHeight + 11);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 6 + width, StartHeight + 11);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 5, StartHeight + 11);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 6 + width, StartHeight + 11);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplaySixthMonsterMagic(
            IUnit monster,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int width = 30;
            string attackName = this.GetAttackName(6, MagicType, monster);

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 14 + width, StartHeight + 10);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 14 + width, StartHeight + 11);
            Console.Write("|{0}{1}{0}|", new string(' ', (width - 2 - attackName.Length) / 2), attackName);
            Console.SetCursorPosition(StartWidth + 14 + width, StartHeight + 12);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 13 + width, StartHeight + 11);
                Console.Write(">");
                Console.SetCursorPosition((StartWidth + 14) + (2 * width), StartHeight + 11);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 13 + width, StartHeight + 11);
                Console.Write(" ");
                Console.SetCursorPosition((StartWidth + 14) + (2 * width), StartHeight + 11);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayFirstNormalAttack(
            IPlayer player,
            ConsoleColor color = ConsoleColor.White, 
            bool showArrows = false)
        {
            int width = 20;
            string attackName = this.GetAttackName(1, NormalType, player);

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 24, StartHeight + 2);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 24, StartHeight + 3);
            Console.Write("|{0}{1}{0}|", new string(' ', (width - 2 - attackName.Length) / 2), attackName);
            Console.SetCursorPosition(StartWidth + 24, StartHeight + 4);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 23, StartHeight + 3);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 24 + width, StartHeight + 3);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 23, StartHeight + 3);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 24 + width, StartHeight + 3);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplaySecondNormalAttack(
            IPlayer player,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int width = 20;
            string attackName = this.GetAttackName(2, NormalType, player);

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 24, StartHeight + 5);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 24, StartHeight + 6);
            Console.Write("|{0}{1}{0}|", new string(' ', (width - 2 - attackName.Length) / 2), attackName);
            Console.SetCursorPosition(StartWidth + 24, StartHeight + 7);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 23, StartHeight + 6);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 24 + width, StartHeight + 6);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 23, StartHeight + 6);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 24 + width, StartHeight + 6);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayThirdNormalAttack(
            IPlayer player,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int width = 20;
            string attackName = this.GetAttackName(3, NormalType, player);

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 24, StartHeight + 8);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 24, StartHeight + 9);
            Console.Write("|{0}{1}{0}|", new string(' ', (width - 2 - attackName.Length) / 2), attackName);
            Console.SetCursorPosition(StartWidth + 24, StartHeight + 10);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 23, StartHeight + 9);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 24 + width, StartHeight + 9);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 23, StartHeight + 9);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 24 + width, StartHeight + 9);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayFourthNormalAttack(
            IPlayer player,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int width = 20;
            string attackName = this.GetAttackName(4, NormalType, player);

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 24, StartHeight + 11);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 24, StartHeight + 12);
            Console.Write("|{0}{1}{0}|", new string(' ', (width - 2 - attackName.Length) / 2), attackName);
            Console.SetCursorPosition(StartWidth + 24, StartHeight + 13);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 23, StartHeight + 12);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 24 + width, StartHeight + 12);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 23, StartHeight + 12);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 24 + width, StartHeight + 12);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayFirstMagicAttack(
            IPlayer player,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int width = 16;
            string attackName = this.GetAttackName(1, MagicType, player);

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 45, StartHeight + 3);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 45, StartHeight + 4);
            Console.Write("|{0}{1}{0}|", new string(' ', (width - 2 - attackName.Length) / 2), attackName);
            Console.SetCursorPosition(StartWidth + 45, StartHeight + 5);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 44, StartHeight + 4);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 45 + width, StartHeight + 4);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 44, StartHeight + 4);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 45 + width, StartHeight + 4);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplaySecondMagicAttack(
            IPlayer player,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int width = 16;
            string attackName = this.GetAttackName(2, MagicType, player);

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 62, StartHeight + 3);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 62, StartHeight + 4);
            Console.Write("|{0}{1}{0}|", new string(' ', (width - 2 - attackName.Length) / 2), attackName);
            Console.SetCursorPosition(StartWidth + 62, StartHeight + 5);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 61, StartHeight + 4);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 62 + width, StartHeight + 4);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 61, StartHeight + 4);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 62 + width, StartHeight + 4);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayThirdMagicAttack(
            IPlayer player,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int width = 16;
            string attackName = this.GetAttackName(3, MagicType, player);

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 45, StartHeight + 6);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 45, StartHeight + 7);
            Console.Write("|{0}{1}{0}|", new string(' ', (width - 2 - attackName.Length) / 2), attackName);
            Console.SetCursorPosition(StartWidth + 45, StartHeight + 8);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 44, StartHeight + 7);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 45 + width, StartHeight + 7);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 44, StartHeight + 7);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 45 + width, StartHeight + 7);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayFourthMagicAttack(
            IPlayer player,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int width = 16;
            string attackName = this.GetAttackName(4, MagicType, player);

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 62, StartHeight + 6);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 62, StartHeight + 7);
            Console.Write("|{0}{1}{0}|", new string(' ', (width - 2 - attackName.Length) / 2), attackName);
            Console.SetCursorPosition(StartWidth + 62, StartHeight + 8);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 61, StartHeight + 7);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 62 + width, StartHeight + 7);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 61, StartHeight + 7);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 62 + width, StartHeight + 7);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayFifthMagicAttack(
            IPlayer player,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int width = 16;
            string attackName = this.GetAttackName(5, MagicType, player);

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 45, StartHeight + 9);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 45, StartHeight + 10);
            Console.Write("|{0}{1}{0}|", new string(' ', (width - 2 - attackName.Length) / 2), attackName);
            Console.SetCursorPosition(StartWidth + 45, StartHeight + 11);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 44, StartHeight + 10);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 45 + width, StartHeight + 10);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 44, StartHeight + 10);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 45 + width, StartHeight + 10);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplaySixthMagicAttack(
            IPlayer player,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int width = 16;
            string attackName = this.GetAttackName(6, MagicType, player);

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 62, StartHeight + 9);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 62, StartHeight + 10);
            Console.Write("|{0}{1}{0}|", new string(' ', (width - 2 - attackName.Length) / 2), attackName);
            Console.SetCursorPosition(StartWidth + 62, StartHeight + 11);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 61, StartHeight + 10);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 62 + width, StartHeight + 10);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 61, StartHeight + 10);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 62 + width, StartHeight + 10);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayNormalAttacks(IPlayer player)
        {
            this.DisplayFirstNormalAttack(player);
            this.DisplaySecondNormalAttack(player);
            this.DisplayThirdNormalAttack(player);
            this.DisplayFourthNormalAttack(player);
        }

        private void DisplayMagicAttacks(IPlayer player)
        {
            this.DisplayFirstMagicAttack(player);
            this.DisplaySecondMagicAttack(player);
            this.DisplayThirdMagicAttack(player);
            this.DisplayFourthMagicAttack(player);
            this.DisplayFifthMagicAttack(player);
            this.DisplaySixthMagicAttack(player);
        }

        private void DisplayBackButton(ConsoleColor color = ConsoleColor.White, bool showArrows = false)
        {
            int width = 14;

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 3, StartHeight + 11);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 3, StartHeight + 12);
            Console.Write("|{0}Back{0}|", new string(' ', (width - 6) / 2));
            Console.SetCursorPosition(StartWidth + 3, StartHeight + 13);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 2, StartHeight + 12);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 3 + width, StartHeight + 12);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 2, StartHeight + 12);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 3 + width, StartHeight + 12);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

       private string GetAttackName(int place, string type, IUnit unit)
       {
           string name = DefaultAttackName;

           if (type == NormalType)
           {
               if (unit.NormalAttacks.Count >= place)
               {
                   name = unit.NormalAttacks[place - 1].Name;
               }
           }
           else
           {
               if (unit.MagicAttacks.Count >= place)
               {
                   name = unit.MagicAttacks[place - 1].Name;
               }
           }

           if (name.Length % 2 == 1)
           {
               name = " " + name;
           }

           return name;
       }
    }
}