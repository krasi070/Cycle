namespace Cycle.GameFrames
{
    using System;
    using System.Threading;
    using Interfaces;

    public class OptionsFrame : SimpleGameFrame, IOptionsFrame
    {
        public static int StartWidth = 5;
        public static int EndWidth = 84;
        public static int Width = EndWidth - StartWidth;
        public static int StartHeight = 21;
        public static int EndHeight = 28;
        public static int Height = EndHeight - StartHeight;

        private const string NormalAttackButtonName = "Normal Attack ";
        private const string MagicAttackButtonName = "Magic Attack";
        private const string MagicRobberButtonName = "Use Magic Robber";
        private const string ShowStatusButtonName = " Show Status";

        public OptionsFrame()
            : base(StartWidth, EndWidth, StartHeight, EndHeight)
        {          
        }

        public void DisplayOptions()
        {
            this.ClearInside();

            this.LightUpAttackOption();
        }

        public void WriteText(params string[] text)
        {
            if (text.Length > 6)
            {
                throw new ArgumentOutOfRangeException("text", "The text array cannot contain more than 6 strings.");
            }

            this.ClearInside();

            for (int i = StartHeight + 1; i < StartHeight + 1 + text.Length; i++)
            {
                Console.SetCursorPosition(StartWidth + 1, i);
                Console.Write(text[i - (StartHeight + 1)]);
            }
        }

        public void WriteTextSlowly(int timeInMilliseconds, params string[] text)
        {
            if (text.Length > 6)
            {
                throw new ArgumentOutOfRangeException("text", "The text array cannot contain more than 6 strings.");
            }

            this.ClearInside();

            for (int i = StartHeight + 1; i < StartHeight + 1 + text.Length; i++)
            {
                Console.SetCursorPosition(StartWidth + 1, i);
                // i - (StartHeight + 1)
                for (int j = 0; j < text[i - (StartHeight + 1)].Length; j++)
                {
                    Console.Write(text[i - (StartHeight + 1)][j].ToString());
                    Thread.Sleep(timeInMilliseconds);
                }
            }
        }

        public void DisplayNormalAttackOptions(IPlayer player)
        {
            this.ClearInside();

            this.LightUpFirstNormalAttack(player);
        }

        public void DisplayMagicAttackOptions(IPlayer player)
        {
            this.ClearInside();

            this.LightUpFirstMagicAttack(player);
            this.DisplayBattleSecondMagicAttack(player);
            this.DisplayBattleThirdMagicAttack(player);
            this.DisplayBattleFourthMagicAttack(player);
            this.DisplayBattleFifthMagicAttack(player);
            this.DisplayBattleSixthMagicAttack(player);
            this.DisplayBattleBackButton();
        }

        public void DisplayBinaryChoice()
        {
            this.LightUpNoButton();
        }

        public void LightUpNoButton()
        {
            this.DisplayYesButton();

            this.DisplayNoButton(ConsoleColor.Yellow, true);
        }

        public void LightUpYesButton()
        {
            this.DisplayNoButton();

            this.DisplayYesButton(ConsoleColor.Yellow, true);
        }

        public void LightUpAttackOption()
        {
            int optionWidth = 32;

            this.DisplaySecondBigButton(optionWidth, MagicAttackButtonName);
            this.DisplayThirdBigButton(optionWidth, MagicRobberButtonName);
            this.DisplayFourthBigButton(optionWidth, ShowStatusButtonName);
            this.DisplayFirstBigButton(optionWidth, NormalAttackButtonName, ConsoleColor.Yellow, true);
        }

        public void LightUpMagicOption()
        {
            int optionWidth = 32;

            this.DisplayFirstBigButton(optionWidth, NormalAttackButtonName);
            this.DisplayThirdBigButton(optionWidth, MagicRobberButtonName);
            this.DisplayFourthBigButton(optionWidth, ShowStatusButtonName);
            this.DisplaySecondBigButton(optionWidth, MagicAttackButtonName, ConsoleColor.Yellow, true);
        }

        public void LightUpMagicRobberOption()
        {
            int optionWidth = 32;

            this.DisplayFirstBigButton(optionWidth, NormalAttackButtonName);
            this.DisplaySecondBigButton(optionWidth, MagicAttackButtonName);
            this.DisplayFourthBigButton(optionWidth, ShowStatusButtonName);
            this.DisplayThirdBigButton(optionWidth, MagicRobberButtonName, ConsoleColor.Yellow, true);
        }

        public void LightUpStatusOption()
        {
            int optionWidth = 32;

            this.DisplayFirstBigButton(optionWidth, NormalAttackButtonName);
            this.DisplaySecondBigButton(optionWidth, MagicAttackButtonName);
            this.DisplayThirdBigButton(optionWidth, MagicRobberButtonName);
            this.DisplayFourthBigButton(optionWidth, ShowStatusButtonName, ConsoleColor.Yellow, true);
        }

        public void LightUpFirstNormalAttack(IPlayer player)
        {
            int optionWidth = 30;

            this.DisplayBattleBackButton();
            this.DisplaySecondNormalAttack(optionWidth, player);
            this.DisplayThirdNormalAttack(optionWidth, player);
            this.DisplayFourthNormalAttack(optionWidth, player);
            this.DisplayFirstNormalAttack(optionWidth, player, ConsoleColor.Yellow, true);
        }

        public void LightUpSecondNormalAttack(IPlayer player)
        {
            int optionWidth = 30;

            this.DisplayBattleBackButton();
            this.DisplayFirstNormalAttack(optionWidth, player);
            this.DisplayThirdNormalAttack(optionWidth, player);
            this.DisplayFourthNormalAttack(optionWidth, player);
            this.DisplaySecondNormalAttack(optionWidth, player, ConsoleColor.Yellow, true);
        }

        public void LightUpThirdNormalAttack(IPlayer player)
        {
            int optionWidth = 30;

            this.DisplayBattleBackButton();
            this.DisplayFirstNormalAttack(optionWidth, player);
            this.DisplaySecondNormalAttack(optionWidth, player);
            this.DisplayFourthNormalAttack(optionWidth, player);
            this.DisplayThirdNormalAttack(optionWidth, player, ConsoleColor.Yellow, true);
        }

        public void LightUpFourthNormalAttack(IPlayer player)
        {
            int optionWidth = 30;

            this.DisplayBattleBackButton();
            this.DisplayFirstNormalAttack(optionWidth, player);
            this.DisplaySecondNormalAttack(optionWidth, player);
            this.DisplayThirdNormalAttack(optionWidth, player);
            this.DisplayFourthNormalAttack(optionWidth, player, ConsoleColor.Yellow, true);
        }

        public void LightUpBattleNormalBackButton(IPlayer player)
        {
            int optionWidth = 30;

            this.DisplayFirstNormalAttack(optionWidth, player);
            this.DisplaySecondNormalAttack(optionWidth, player);
            this.DisplayThirdNormalAttack(optionWidth, player);
            this.DisplayFourthNormalAttack(optionWidth, player);
            this.DisplayBattleBackButton(ConsoleColor.Yellow, true);
        }

        public void LightUpBattleMagicBackButton(IPlayer player)
        {
            this.DisplayBattleFirstMagicAttack(player);
            this.DisplayBattleThirdMagicAttack(player);
            this.DisplayBattleFourthMagicAttack(player);
            this.DisplayBattleSixthMagicAttack(player);

            this.DisplayBattleBackButton(ConsoleColor.Yellow, true);
        }

        public void LightUpFirstMagicAttack(IPlayer player)
        {
            this.DisplayBattleSecondMagicAttack(player);
            this.DisplayBattleFourthMagicAttack(player);
            this.DisplayBattleBackButton();

            this.DisplayBattleFirstMagicAttack(player, ConsoleColor.Yellow, true);
        }

        public void LightUpSecondMagicAttack(IPlayer player)
        {
            this.DisplayBattleFirstMagicAttack(player);
            this.DisplayBattleThirdMagicAttack(player);
            this.DisplayBattleFifthMagicAttack(player);

            this.DisplayBattleSecondMagicAttack(player, ConsoleColor.Yellow, true);
        }

        public void LightUpThirdMagicAttack(IPlayer player)
        {
            this.DisplayBattleSecondMagicAttack(player);
            this.DisplayBattleSixthMagicAttack(player);
            this.DisplayBattleBackButton();

            this.DisplayBattleThirdMagicAttack(player, ConsoleColor.Yellow, true);
        }

        public void LightUpFourthMagicAttack(IPlayer player)
        {
            this.DisplayBattleFirstMagicAttack(player);
            this.DisplayBattleFifthMagicAttack(player);
            this.DisplayBattleBackButton();

            this.DisplayBattleFourthMagicAttack(player, ConsoleColor.Yellow, true);
        }

        public void LightUpFifthMagicAttack(IPlayer player)
        {
            this.DisplayBattleSecondMagicAttack(player);
            this.DisplayBattleFourthMagicAttack(player);
            this.DisplayBattleSixthMagicAttack(player);

            this.DisplayBattleFifthMagicAttack(player, ConsoleColor.Yellow, true);
        }

        public void LightUpSixthMagicAttack(IPlayer player)
        {
            this.DisplayBattleThirdMagicAttack(player);
            this.DisplayBattleFifthMagicAttack(player);
            this.DisplayBattleBackButton();

            this.DisplayBattleSixthMagicAttack(player, ConsoleColor.Yellow, true);
        }

        private void DisplayFirstNormalAttack(
            int optionWidth,
            IPlayer player,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            string attackName = "[Empty Slot]";
            if (player.NormalAttacks.Count >= 1)
            {
                attackName = player.NormalAttacks[0].Name;
                if (attackName.Length % 2 == 1)
                {
                    attackName = " " + attackName;
                }
            }

            this.DisplayFirstBigButton(optionWidth, attackName, color, showArrows);
        }

        private void DisplaySecondNormalAttack(
            int optionWidth,
            IPlayer player,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            string attackName = "[Empty Slot]";
            if (player.NormalAttacks.Count >= 2)
            {
                attackName = player.NormalAttacks[1].Name;
                if (attackName.Length % 2 == 1)
                {
                    attackName = " " + attackName;
                }
            }

            this.DisplaySecondBigButton(optionWidth, attackName, color, showArrows);
        }

        private void DisplayThirdNormalAttack(
            int optionWidth,
            IPlayer player,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            string attackName = "[Empty Slot]";
            if (player.NormalAttacks.Count >= 3)
            {
                attackName = player.NormalAttacks[2].Name;
                if (attackName.Length % 2 == 1)
                {
                    attackName = " " + attackName;
                }
            }

            this.DisplayThirdBigButton(optionWidth, attackName, color, showArrows);
        }

        private void DisplayFourthNormalAttack(
            int optionWidth,
            IPlayer player,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            string attackName = "[Empty Slot]";
            if (player.NormalAttacks.Count >= 4)
            {
                attackName = player.NormalAttacks[3].Name;
                if (attackName.Length % 2 == 1)
                {
                    attackName = " " + attackName;
                }
            }

            this.DisplayFourthBigButton(optionWidth, attackName, color, showArrows);
        }

        private void DisplayBattleBackButton(ConsoleColor color = ConsoleColor.White, bool showArrows = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(EndWidth - 7, StartHeight + 1);
            Console.Write("+{0}+", new string('-', 3));

            Console.SetCursorPosition(EndWidth - 7, StartHeight + 2);
            Console.Write("| B |");
            Console.SetCursorPosition(EndWidth - 7, StartHeight + 3);
            Console.Write("| a |");
            Console.SetCursorPosition(EndWidth - 7, StartHeight + 4);
            Console.Write("| c |");
            Console.SetCursorPosition(EndWidth - 7, StartHeight + 5);
            Console.Write("| k |");

            Console.SetCursorPosition(EndWidth - 7, StartHeight + 6);
            Console.Write("+{0}+", new string('-', 3));

            if (showArrows)
            {
                Console.SetCursorPosition(EndWidth - 8, StartHeight + 4);
                Console.Write(">");
                Console.SetCursorPosition(EndWidth - 2, StartHeight + 4);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(EndWidth - 8, StartHeight + 4);
                Console.Write(" ");
                Console.SetCursorPosition(EndWidth - 2, StartHeight + 4);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayFirstBigButton(
            int optionWidth,
            string buttonName,
            ConsoleColor color = ConsoleColor.White, 
            bool showArrows = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 5, StartHeight + 1);
            Console.Write("+{0}+", new string('-', optionWidth - 2));

            Console.SetCursorPosition(StartWidth + 5, StartHeight + 2);
            Console.Write("|{0}{1}{0}|", new string(' ', (optionWidth - 2 - buttonName.Length) / 2), buttonName);

            Console.SetCursorPosition(StartWidth + 5, StartHeight + 3);
            Console.Write("+{0}+", new string('-', optionWidth - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 4, StartHeight + 2);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 5 + optionWidth, StartHeight + 2);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 4, StartHeight + 2);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 5 + optionWidth, StartHeight + 2);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplaySecondBigButton(
            int optionWidth,
            string buttonName,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 10 + optionWidth, StartHeight + 1);
            Console.Write("+{0}+", new string('-', optionWidth - 2));

            Console.SetCursorPosition(StartWidth + 10 + optionWidth, StartHeight + 2);
            Console.Write("|{0}{1}{0}|", new string(' ', (optionWidth - 2 - buttonName.Length) / 2), buttonName);

            Console.SetCursorPosition(StartWidth + 10 + optionWidth, StartHeight + 3);
            Console.Write("+{0}+", new string('-', optionWidth - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 9 + optionWidth, StartHeight + 2);
                Console.Write(">");
                Console.SetCursorPosition((StartWidth + 10) + (2 * optionWidth), StartHeight + 2);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 9 + optionWidth, StartHeight + 2);
                Console.Write(" ");
                Console.SetCursorPosition((StartWidth + 10) + (2 * optionWidth), StartHeight + 2);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayThirdBigButton(
            int optionWidth,
            string buttonName,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 5, StartHeight + 4);
            Console.Write("+{0}+", new string('-', optionWidth - 2));

            Console.SetCursorPosition(StartWidth + 5, StartHeight + 5);
            Console.Write("|{0}{1}{0}|", new string(' ', (optionWidth - 2 - buttonName.Length) / 2), buttonName);

            Console.SetCursorPosition(StartWidth + 5, StartHeight + 6);
            Console.Write("+{0}+", new string('-', optionWidth - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 4, StartHeight + 5);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 5 + optionWidth, StartHeight + 5);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 4, StartHeight + 5);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 5 + optionWidth, StartHeight + 5);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayFourthBigButton(
            int optionWidth,
            string buttonName,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 10 + optionWidth, StartHeight + 4);
            Console.Write("+{0}+", new string('-', optionWidth - 2));

            Console.SetCursorPosition(StartWidth + 10 + optionWidth, StartHeight + 5);
            Console.Write("|{0}{1}{0}|", new string(' ', (optionWidth - 2 - buttonName.Length) / 2), buttonName);

            Console.SetCursorPosition(StartWidth + 10 + optionWidth, StartHeight + 6);
            Console.Write("+{0}+", new string('-', optionWidth - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 9 + optionWidth, StartHeight + 5);
                Console.Write(">");
                Console.SetCursorPosition((StartWidth + 10) + (2 * optionWidth), StartHeight + 5);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 9 + optionWidth, StartHeight + 5);
                Console.Write(" ");
                Console.SetCursorPosition((StartWidth + 10) + (2 * optionWidth), StartHeight + 5);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayBattleFirstMagicAttack(
            IPlayer player, 
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int magicAttack = 20;
            string buttonName = "[Empty Slot]";
            if (player.MagicAttacks.Count >= 1)
            {
                buttonName = player.MagicAttacks[0].Name;
                if (buttonName.Length % 2 == 1)
                {
                    buttonName = " " + buttonName;
                }
            }

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 3, StartHeight + 1);
            Console.Write("+{0}+", new string('-', magicAttack - 2));

            Console.SetCursorPosition(StartWidth + 3, StartHeight + 2);
            Console.Write("|{0}{1}{0}|", new string(' ', (magicAttack - 2 - buttonName.Length) / 2), buttonName);

            Console.SetCursorPosition(StartWidth + 3, StartHeight + 3);
            Console.Write("+{0}+", new string('-', magicAttack - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 2, StartHeight + 2);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 3 + magicAttack, StartHeight + 2);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 2, StartHeight + 2);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 3 + magicAttack, StartHeight + 2);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayBattleSecondMagicAttack(
            IPlayer player,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int magicAttack = 20;
            string buttonName = "[Empty Slot]";
            if (player.MagicAttacks.Count >= 2)
            {
                buttonName = player.MagicAttacks[1].Name;
                if (buttonName.Length % 2 == 1)
                {
                    buttonName = " " + buttonName;
                }
            }

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 6 + magicAttack, StartHeight + 1);
            Console.Write("+{0}+", new string('-', magicAttack - 2));

            Console.SetCursorPosition(StartWidth + 6 + magicAttack, StartHeight + 2);
            Console.Write("|{0}{1}{0}|", new string(' ', (magicAttack - 2 - buttonName.Length) / 2), buttonName);

            Console.SetCursorPosition(StartWidth + 6 + magicAttack, StartHeight + 3);
            Console.Write("+{0}+", new string('-', magicAttack - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 5 + magicAttack, StartHeight + 2);
                Console.Write(">");
                Console.SetCursorPosition((StartWidth + 6) + (2 * magicAttack), StartHeight + 2);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 5 + magicAttack, StartHeight + 2);
                Console.Write(" ");
                Console.SetCursorPosition((StartWidth + 6) + (2 * magicAttack), StartHeight + 2);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayBattleThirdMagicAttack(
            IPlayer player,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int magicAttack = 20;
            string buttonName = "[Empty Slot]";
            if (player.MagicAttacks.Count >= 3)
            {
                buttonName = player.MagicAttacks[2].Name;
                if (buttonName.Length % 2 == 1)
                {
                    buttonName = " " + buttonName;
                }
            }

            Console.ForegroundColor = color;
            Console.SetCursorPosition((StartWidth + 9) + (2 * magicAttack), StartHeight + 1);
            Console.Write("+{0}+", new string('-', magicAttack - 2));

            Console.SetCursorPosition((StartWidth + 9) + (2 * magicAttack), StartHeight + 2);
            Console.Write("|{0}{1}{0}|", new string(' ', (magicAttack - 2 - buttonName.Length) / 2), buttonName);

            Console.SetCursorPosition((StartWidth + 9) + (2 * magicAttack), StartHeight + 3);
            Console.Write("+{0}+", new string('-', magicAttack - 2));

            if (showArrows)
            {
                Console.SetCursorPosition((StartWidth + 8) + (2 * magicAttack), StartHeight + 2);
                Console.Write(">");
                Console.SetCursorPosition((StartWidth + 9) + (3 * magicAttack), StartHeight + 2);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition((StartWidth + 8) + (2 * magicAttack), StartHeight + 2);
                Console.Write(" ");
                Console.SetCursorPosition((StartWidth + 9) + (3 * magicAttack), StartHeight + 2);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayBattleFourthMagicAttack(
            IPlayer player,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int magicAttack = 20;
            string buttonName = "[Empty Slot]";
            if (player.MagicAttacks.Count >= 4)
            {
                buttonName = player.MagicAttacks[3].Name;
                if (buttonName.Length % 2 == 1)
                {
                    buttonName = " " + buttonName;
                }
            }

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 3, StartHeight + 4);
            Console.Write("+{0}+", new string('-', magicAttack - 2));

            Console.SetCursorPosition(StartWidth + 3, StartHeight + 5);
            Console.Write("|{0}{1}{0}|", new string(' ', (magicAttack - 2 - buttonName.Length) / 2), buttonName);

            Console.SetCursorPosition(StartWidth + 3, StartHeight + 6);
            Console.Write("+{0}+", new string('-', magicAttack - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 2, StartHeight + 5);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 3 + magicAttack, StartHeight + 5);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 2, StartHeight + 5);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 3 + magicAttack, StartHeight + 5);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayBattleFifthMagicAttack(
            IPlayer player,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int magicAttack = 20;
            string buttonName = "[Empty Slot]";
            if (player.MagicAttacks.Count >= 5)
            {
                buttonName = player.MagicAttacks[4].Name;
                if (buttonName.Length % 2 == 1)
                {
                    buttonName = " " + buttonName;
                }
            }

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 6 + magicAttack, StartHeight + 4);
            Console.Write("+{0}+", new string('-', magicAttack - 2));

            Console.SetCursorPosition(StartWidth + 6 + magicAttack, StartHeight + 5);
            Console.Write("|{0}{1}{0}|", new string(' ', (magicAttack - 2 - buttonName.Length) / 2), buttonName);

            Console.SetCursorPosition(StartWidth + 6 + magicAttack, StartHeight + 6);
            Console.Write("+{0}+", new string('-', magicAttack - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 5 + magicAttack, StartHeight + 5);
                Console.Write(">");
                Console.SetCursorPosition((StartWidth + 6) + (2 * magicAttack), StartHeight + 5);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 5 + magicAttack, StartHeight + 5);
                Console.Write(" ");
                Console.SetCursorPosition((StartWidth + 6) + (2 * magicAttack), StartHeight + 5);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayBattleSixthMagicAttack(
            IPlayer player,
            ConsoleColor color = ConsoleColor.White,
            bool showArrows = false)
        {
            int magicAttack = 20;
            string buttonName = "[Empty Slot]";
            if (player.MagicAttacks.Count >= 6)
            {
                buttonName = player.MagicAttacks[5].Name;
                if (buttonName.Length % 2 == 1)
                {
                    buttonName = " " + buttonName;
                }
            }

            Console.ForegroundColor = color;
            Console.SetCursorPosition((StartWidth + 9) + (2 * magicAttack), StartHeight + 4);
            Console.Write("+{0}+", new string('-', magicAttack - 2));

            Console.SetCursorPosition((StartWidth + 9) + (2 * magicAttack), StartHeight + 5);
            Console.Write("|{0}{1}{0}|", new string(' ', (magicAttack - 2 - buttonName.Length) / 2), buttonName);

            Console.SetCursorPosition((StartWidth + 9) + (2 * magicAttack), StartHeight + 6);
            Console.Write("+{0}+", new string('-', magicAttack - 2));

            if (showArrows)
            {
                Console.SetCursorPosition((StartWidth + 8) + (2 * magicAttack), StartHeight + 5);
                Console.Write(">");
                Console.SetCursorPosition((StartWidth + 9) + (3 * magicAttack), StartHeight + 5);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition((StartWidth + 8) + (2 * magicAttack), StartHeight + 5);
                Console.Write(" ");
                Console.SetCursorPosition((StartWidth + 9) + (3 * magicAttack), StartHeight + 5);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayNoButton(ConsoleColor color = ConsoleColor.White, bool showArrows = false)
        {
            int width = 60;

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 10, StartHeight + 1);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 10, StartHeight + 2);
            Console.Write("|{0}NO{0}|", new string(' ', (width - 4) / 2));
            Console.SetCursorPosition(StartWidth + 10, StartHeight + 3);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 9, StartHeight + 2);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 10 + width, StartHeight + 2);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 9, StartHeight + 2);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 10 + width, StartHeight + 2);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayYesButton(ConsoleColor color = ConsoleColor.White, bool showArrows = false)
        {
            int width = 60;

            Console.ForegroundColor = color;
            Console.SetCursorPosition(StartWidth + 10, StartHeight + 4);
            Console.Write("+{0}+", new string('-', width - 2));
            Console.SetCursorPosition(StartWidth + 10, StartHeight + 5);
            Console.Write("|{0} YES{0}|", new string(' ', (width - 6) / 2));
            Console.SetCursorPosition(StartWidth + 10, StartHeight + 6);
            Console.Write("+{0}+", new string('-', width - 2));

            if (showArrows)
            {
                Console.SetCursorPosition(StartWidth + 9, StartHeight + 5);
                Console.Write(">");
                Console.SetCursorPosition(StartWidth + 10 + width, StartHeight + 5);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(StartWidth + 9, StartHeight + 5);
                Console.Write(" ");
                Console.SetCursorPosition(StartWidth + 10 + width, StartHeight + 5);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}