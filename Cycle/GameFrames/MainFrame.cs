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

        private const string DefaultAttackName = "[Empty Slot]";
        private const string NormalType = "Normal";
        private const string MagicType = "Magic";

        // TODO: Add save file screen
        // TODO: Add skill tree screen
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