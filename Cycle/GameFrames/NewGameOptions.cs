namespace Cycle.GameFrames
{
    using System;
    using Args;
    using Enums;
    using Interfaces;

    public class NewGameOptions : INewGameOptions
    {
        private Option currOption;

        public void PrintMessage()
        {
            currOption = Option.First;
            Console.Clear();
            Console.SetCursorPosition(33, 5);
            Console.Write("Enter name: _ _ _ _ _");
            Console.SetCursorPosition(32, 9);
            Console.Write("Choose character color:");
            this.DrawWhiteColorOption();
            this.DrawRedColorOption();
            this.DrawBlueColorOption();
            this.DrawYellowColorOption();
            this.DrawGreenColorOption();
            Console.SetCursorPosition(38, 17);
            Console.Write("Text Speed:");
            this.DrawImmediateTextSpeed();
            this.DrawFastTextSpeed();
            this.DrawNormalTextSpeed();
            this.DrawSlowTextSpeed();
            this.DrawVerySlowTextSpeed();
        }

        public NewGameOptionsArgs GetGameOptionsArgs()
        {
            string name = this.GetName();
            var colorOption = this.ChooseColorOption();
            var textOption = this.ChooseTextSpeed();
            ConsoleColor color = ConsoleColor.White;
            switch (colorOption)
            {
                case Option.First:
                    color = ConsoleColor.White;
                    break;
                case Option.Second:
                    color = ConsoleColor.Red;
                    break;
                case Option.Third:
                    color = ConsoleColor.Blue;
                    break;
                case Option.Fourth:
                    color = ConsoleColor.Yellow;
                    break;
                case Option.Fifth:
                    color = ConsoleColor.Green;
                    break;
            }

            int textSpeed = 0;
            switch (textOption)
            {
                case Option.First:
                    textSpeed = 0;
                    break;
                case Option.Second:
                    textSpeed = 50;
                    break;
                case Option.Third:
                    textSpeed = 100;
                    break;
                case Option.Fourth:
                    textSpeed = 175;
                    break;
                case Option.Fifth:
                    textSpeed = 250;
                    break;
            }

            var args = new NewGameOptionsArgs(name, color, textSpeed);

            return args;
        }

        private string GetName()
        {
            string name = string.Empty;

            char letter = Console.ReadKey(true).KeyChar;
            while (letter != 13 || name.Length < 2)
            {
                if (name.Length >= 5 && letter != 8)
                {
                    letter = Console.ReadKey(true).KeyChar;
                    continue;
                }

                if ((letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z'))
                {
                    name += letter.ToString();
                }
                else if (letter == 8 && name.Length > 0)
                {
                    name = name.Substring(0, name.Length - 1);
                }

                Console.SetCursorPosition(45, 5);
                for (int i = 0; i < 5; i++)
                {
                    if (i >= name.Length)
                    {
                        Console.Write("_ ");
                    }
                    else
                    {
                        Console.Write(name[i] + " ");
                    }
                }

                letter = Console.ReadKey(true).KeyChar;
            }

            return name;
        }

        public Option ChooseColorOption()
        {
            currOption = Option.First;
            this.LightUpWhiteColorOption();
            ConsoleKey pressedKey = Console.ReadKey(true).Key;
            while (pressedKey != ConsoleKey.Enter)
            {
                switch (this.currOption)
                {
                    case Option.First:
                        switch (pressedKey)
                        {
                            case ConsoleKey.A:
                            case ConsoleKey.LeftArrow:
                                this.currOption = Option.Fifth;
                                this.LightUpGreenColorOption();
                                break;
                            case ConsoleKey.D:
                            case ConsoleKey.RightArrow:
                                this.currOption = Option.Second;
                                this.LightUpRedColorOption();
                                break;
                        }
                        break;
                    case Option.Second:
                        switch (pressedKey)
                        {
                            case ConsoleKey.A:
                            case ConsoleKey.LeftArrow:
                                this.currOption = Option.First;
                                this.LightUpWhiteColorOption();
                                break;
                            case ConsoleKey.D:
                            case ConsoleKey.RightArrow:
                                this.currOption = Option.Third;
                                this.LightUpBlueColorOption();
                                break;
                        }
                        break;
                    case Option.Third:
                        switch (pressedKey)
                        {
                            case ConsoleKey.A:
                            case ConsoleKey.LeftArrow:
                                this.currOption = Option.Second;
                                this.LightUpRedColorOption();
                                break;
                            case ConsoleKey.D:
                            case ConsoleKey.RightArrow:
                                this.currOption = Option.Fourth;
                                this.LightUpYellowColorOption();
                                break;
                        }
                        break;
                    case Option.Fourth:
                        switch (pressedKey)
                        {
                            case ConsoleKey.A:
                            case ConsoleKey.LeftArrow:
                                this.currOption = Option.Third;
                                this.LightUpBlueColorOption();
                                break;
                            case ConsoleKey.D:
                            case ConsoleKey.RightArrow:
                                this.currOption = Option.Fifth;
                                this.LightUpGreenColorOption();
                                break;
                        }
                        break;
                    case Option.Fifth:
                        switch (pressedKey)
                        {
                            case ConsoleKey.A:
                            case ConsoleKey.LeftArrow:
                                this.currOption = Option.Fourth;
                                this.LightUpYellowColorOption();
                                break;
                            case ConsoleKey.D:
                            case ConsoleKey.RightArrow:
                                this.currOption = Option.First;
                                this.LightUpWhiteColorOption();
                                break;
                        }
                        break;
                }

                pressedKey = Console.ReadKey(true).Key;
            }

            return this.currOption;
        }

        public Option ChooseTextSpeed()
        {
            currOption = Option.Third;
            this.LightUpNormalTextSpeed();
            ConsoleKey pressedKey = Console.ReadKey(true).Key;
            while (pressedKey != ConsoleKey.Enter)
            {
                switch (currOption)
                {
                    case Option.First:
                        switch (pressedKey)
                        {
                            case ConsoleKey.A:
                            case ConsoleKey.LeftArrow:
                                this.currOption = Option.Fifth;
                                this.LightUpVerySlowSpeed();
                                break;
                            case ConsoleKey.D:
                            case ConsoleKey.RightArrow:
                                this.currOption = Option.Second;
                                this.LightUpFastTextSpeed();
                                break;
                        }
                        break;
                    case Option.Second:
                        switch (pressedKey)
                        {
                            case ConsoleKey.A:
                            case ConsoleKey.LeftArrow:
                                this.currOption = Option.First;
                                this.LightUpImmediateTextSpeed();
                                break;
                            case ConsoleKey.D:
                            case ConsoleKey.RightArrow:
                                this.currOption = Option.Third;
                                this.LightUpNormalTextSpeed();
                                break;
                        }
                        break;
                    case Option.Third:
                        switch (pressedKey)
                        {
                            case ConsoleKey.A:
                            case ConsoleKey.LeftArrow:
                                this.currOption = Option.Second;
                                this.LightUpFastTextSpeed();
                                break;
                            case ConsoleKey.D:
                            case ConsoleKey.RightArrow:
                                this.currOption = Option.Fourth;
                                this.LightUpSlowTextSpeed();
                                break;
                        }
                        break;
                    case Option.Fourth:
                        switch (pressedKey)
                        {
                            case ConsoleKey.A:
                            case ConsoleKey.LeftArrow:
                                this.currOption = Option.Third;
                                this.LightUpNormalTextSpeed();
                                break;
                            case ConsoleKey.D:
                            case ConsoleKey.RightArrow:
                                this.currOption = Option.Fifth;
                                this.LightUpVerySlowSpeed();
                                break;
                        }
                        break;
                    case Option.Fifth:
                        switch (pressedKey)
                        {
                            case ConsoleKey.A:
                            case ConsoleKey.LeftArrow:
                                this.currOption = Option.Fourth;
                                this.LightUpSlowTextSpeed();
                                break;
                            case ConsoleKey.D:
                            case ConsoleKey.RightArrow:
                                this.currOption = Option.First;
                                this.LightUpImmediateTextSpeed();
                                break;
                        }
                        break;
                }

                pressedKey = Console.ReadKey(true).Key;
            }

            return this.currOption;
        }

        public void LightUpWhiteColorOption()
        {
            this.DrawWhiteColorOption(ConsoleColor.White, true);
            this.DrawRedColorOption();
            this.DrawGreenColorOption();
        }

        public void LightUpRedColorOption()
        {
            this.DrawRedColorOption(ConsoleColor.Red, true);
            this.DrawBlueColorOption();
            this.DrawWhiteColorOption();
        }

        public void LightUpBlueColorOption()
        {
            this.DrawBlueColorOption(ConsoleColor.Blue, true);
            this.DrawYellowColorOption();
            this.DrawRedColorOption();
        }

        public void LightUpYellowColorOption()
        {
            this.DrawYellowColorOption(ConsoleColor.Yellow, true);
            this.DrawGreenColorOption();
            this.DrawBlueColorOption();
        }

        public void LightUpGreenColorOption()
        {
            this.DrawGreenColorOption(ConsoleColor.Green, true);
            this.DrawWhiteColorOption();
            this.DrawYellowColorOption();
        }

        public void LightUpImmediateTextSpeed()
        {
            this.DrawImmediateTextSpeed(ConsoleColor.Yellow, true);
            this.DrawVerySlowTextSpeed();
            this.DrawFastTextSpeed();
        }

        public void LightUpFastTextSpeed()
        {
            this.DrawFastTextSpeed(ConsoleColor.Yellow, true);
            this.DrawImmediateTextSpeed();
            this.DrawNormalTextSpeed();
        }

        public void LightUpNormalTextSpeed()
        {
            this.DrawNormalTextSpeed(ConsoleColor.Yellow, true);
            this.DrawFastTextSpeed();
            this.DrawSlowTextSpeed();
        }

        public void LightUpSlowTextSpeed()
        {
            this.DrawSlowTextSpeed(ConsoleColor.Yellow, true);
            this.DrawNormalTextSpeed();
            this.DrawVerySlowTextSpeed();
        }

        public void LightUpVerySlowSpeed()
        {
            this.DrawVerySlowTextSpeed(ConsoleColor.Yellow, true);
            this.DrawImmediateTextSpeed();
            this.DrawSlowTextSpeed();
        }

        private void DrawWhiteColorOption(ConsoleColor color = ConsoleColor.White, bool showArrows = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(7, 11);
            Console.Write("+----------+");
            Console.SetCursorPosition(7, 12);
            Console.Write("|{0}White{1}|", new string(' ', 3), new string(' ', 2));
            Console.SetCursorPosition(7, 13);
            Console.Write("+----------+");

            if (showArrows)
            {
                Console.SetCursorPosition(6, 12);
                Console.Write(">");
                Console.SetCursorPosition(19, 12);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(6, 12);
                Console.Write(" ");
                Console.SetCursorPosition(19, 12);
                Console.Write(" ");
            }
        }

        private void DrawRedColorOption(ConsoleColor color = ConsoleColor.White, bool showArrows = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(23, 11);
            Console.Write("+----------+");
            Console.SetCursorPosition(23, 12);
            Console.Write("|{0}Red{1}|", new string(' ', 4), new string(' ', 3));
            Console.SetCursorPosition(23, 13);
            Console.Write("+----------+");

            if (showArrows)
            {
                Console.SetCursorPosition(22, 12);
                Console.Write(">");
                Console.SetCursorPosition(35, 12);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(22, 12);
                Console.Write(" ");
                Console.SetCursorPosition(35, 12);
                Console.Write(" ");
            }
        }

        private void DrawBlueColorOption(ConsoleColor color = ConsoleColor.White, bool showArrows = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(39, 11);
            Console.Write("+----------+");
            Console.SetCursorPosition(39, 12);
            Console.Write("|{0}Blue{0}|", new string(' ', 3));
            Console.SetCursorPosition(39, 13);
            Console.Write("+----------+");

            if (showArrows)
            {
                Console.SetCursorPosition(38, 12);
                Console.Write(">");
                Console.SetCursorPosition(51, 12);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(38, 12);
                Console.Write(" ");
                Console.SetCursorPosition(51, 12);
                Console.Write(" ");
            }
        }

        private void DrawYellowColorOption(ConsoleColor color = ConsoleColor.White, bool showArrows = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(55, 11);
            Console.Write("+----------+");
            Console.SetCursorPosition(55, 12);
            Console.Write("|{0}Yellow{0}|", new string(' ', 2));
            Console.SetCursorPosition(55, 13);
            Console.Write("+----------+");

            if (showArrows)
            {
                Console.SetCursorPosition(54, 12);
                Console.Write(">");
                Console.SetCursorPosition(67, 12);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(54, 12);
                Console.Write(" ");
                Console.SetCursorPosition(67, 12);
                Console.Write(" ");
            }
        }

        private void DrawGreenColorOption(ConsoleColor color = ConsoleColor.White, bool showArrows = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(71, 11);
            Console.Write("+----------+");
            Console.SetCursorPosition(71, 12);
            Console.Write("|{0}Green{1}|", new string(' ', 3), new string(' ', 2));
            Console.SetCursorPosition(71, 13);
            Console.Write("+----------+");

            if (showArrows)
            {
                Console.SetCursorPosition(70, 12);
                Console.Write(">");
                Console.SetCursorPosition(83, 12);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(70, 12);
                Console.Write(" ");
                Console.SetCursorPosition(83, 12);
                Console.Write(" ");
            }
        }

        private void DrawImmediateTextSpeed(ConsoleColor color = ConsoleColor.White, bool showArrows = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(7, 19);
            Console.Write("+----------+");
            Console.SetCursorPosition(7, 20);
            Console.Write("|{0}Immediate|", " ");
            Console.SetCursorPosition(7, 21);
            Console.Write("+----------+");

            if (showArrows)
            {
                Console.SetCursorPosition(6, 20);
                Console.Write(">");
                Console.SetCursorPosition(19, 20);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(6, 20);
                Console.Write(" ");
                Console.SetCursorPosition(19, 20);
                Console.Write(" ");
            }
        }

        private void DrawFastTextSpeed(ConsoleColor color = ConsoleColor.White, bool showArrows = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(23, 19);
            Console.Write("+----------+");
            Console.SetCursorPosition(23, 20);
            Console.Write("|{0}Fast{0}|", new string(' ', 3));
            Console.SetCursorPosition(23, 21);
            Console.Write("+----------+");

            if (showArrows)
            {
                Console.SetCursorPosition(22, 20);
                Console.Write(">");
                Console.SetCursorPosition(35, 20);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(22, 20);
                Console.Write(" ");
                Console.SetCursorPosition(35, 20);
                Console.Write(" ");
            }
        }

        private void DrawNormalTextSpeed(ConsoleColor color = ConsoleColor.White, bool showArrows = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(39, 19);
            Console.Write("+----------+");
            Console.SetCursorPosition(39, 20);
            Console.Write("|{0}Normal{0}|", new string(' ', 2));
            Console.SetCursorPosition(39, 21);
            Console.Write("+----------+");

            if (showArrows)
            {
                Console.SetCursorPosition(38, 20);
                Console.Write(">");
                Console.SetCursorPosition(51, 20);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(38, 20);
                Console.Write(" ");
                Console.SetCursorPosition(51, 20);
                Console.Write(" ");
            }
        }

        private void DrawSlowTextSpeed(ConsoleColor color = ConsoleColor.White, bool showArrows = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(55, 19);
            Console.Write("+----------+");
            Console.SetCursorPosition(55, 20);
            Console.Write("|{0}Slow{0}|", new string(' ', 3));
            Console.SetCursorPosition(55, 21);
            Console.Write("+----------+");

            if (showArrows)
            {
                Console.SetCursorPosition(54, 20);
                Console.Write(">");
                Console.SetCursorPosition(67, 20);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(54, 20);
                Console.Write(" ");
                Console.SetCursorPosition(67, 20);
                Console.Write(" ");
            }
        }

        private void DrawVerySlowTextSpeed(ConsoleColor color = ConsoleColor.White, bool showArrows = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(71, 19);
            Console.Write("+----------+");
            Console.SetCursorPosition(71, 20);
            Console.Write("| Very Slow|");
            Console.SetCursorPosition(71, 21);
            Console.Write("+----------+");

            if (showArrows)
            {
                Console.SetCursorPosition(70, 20);
                Console.Write(">");
                Console.SetCursorPosition(83, 20);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(70, 20);
                Console.Write(" ");
                Console.SetCursorPosition(83, 20);
                Console.Write(" ");
            }
        }
    }
}