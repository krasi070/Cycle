namespace Cycle.GameFrames
{
    using System;
    using Enums;
    using Interfaces;

    public class MainMenu : IMainMenu
    {
        public MainMenu()
        {
            this.CurrentOption = Option.First;
        }

        public Option CurrentOption { get; set; }

        public void DisplayTitle()
        {
            Console.Clear();
            Console.SetCursorPosition(12, 1);
            Console.Write("___________   ___      ___   ___________   __            ___________");
            Console.SetCursorPosition(11, 2);
            Console.Write("/  _________|  \\  \\    /  /  /  _________| |  |          |   ________|");
            Console.SetCursorPosition(10, 3);
            Console.Write("/  /             \\  \\  /  /  /  /           |  |          |  |");
            Console.SetCursorPosition(10, 4);
            Console.Write("|  |              \\  \\/  /   |  |           |  |          |  |");
            Console.SetCursorPosition(10, 5);
            Console.Write("|  |               \\    /    |  |           |  |          |  |________");
            Console.SetCursorPosition(10, 6);
            Console.Write("|  |                /  /     |  |           |  |          |   ________|");
            Console.SetCursorPosition(10, 7);
            Console.Write("|  |               /  /      |  |           |  |          |  |");
            Console.SetCursorPosition(10, 8);
            Console.Write("\\   \\________     /  /       \\   \\________  |  |_______   |  |________");
            Console.SetCursorPosition(6, 9);
            Console.Write("/--->\\___________|   /__/         \\___________| |__________|  |___________|--\\");
            Console.SetCursorPosition(5, 10);
            Console.Write("/	                                                                            \\");
            Console.SetCursorPosition(5, 11);
            Console.Write("|	  _      __    _	 ___	 _	       _   _	__     __  ___	__   \\");
            Console.SetCursorPosition(5, 12);
            Console.Write("|	 /_\\    | _   /_\\  |\\/| |___	|_| \\_/	  |_/ |_| /_\\  |_  || |  |   / |  |  |");
            Console.SetCursorPosition(5, 13);
            Console.Write("\\	/   \\ 	|__| /	 \\ |  |	|___	|_|  /	  | \\ |\\ /   \\ __| || |__|  /  |__|  |");
            Console.SetCursorPosition(6, 14);
            Console.Write("\\										     /");
            Console.SetCursorPosition(7, 15);
            Console.Write("\\----------------------------------------------------------------------------/");
        }

        public void DisplayOptions()
        {
            this.LightUpNewGameButton();
        }

        public void LightUpNewGameButton()
        {
            this.DisplayNewGameButton(ConsoleColor.Yellow, true);
            this.DisplayLoadGameButton();
            this.DisplayQuitButton();
        }

        public void LightUpLoadGameButton()
        {
            this.DisplayLoadGameButton(ConsoleColor.Yellow, true);
            this.DisplayQuitButton();
            this.DisplayNewGameButton();
        }       

        public void LightUpQuitButton()
        {
            this.DisplayQuitButton(ConsoleColor.Yellow, true);
            this.DisplayNewGameButton();
            this.DisplayLoadGameButton();
        }

        private void DisplayNewGameButton(ConsoleColor color = ConsoleColor.White, bool showArrows = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(33, 18);
            Console.Write("+------------------+");
            Console.SetCursorPosition(33, 19);
            Console.Write("|{0}NEW GAME{0}|",new string(' ', 5));
            Console.SetCursorPosition(33, 20);
            Console.Write("+------------------+");

            if (showArrows)
            {
                Console.SetCursorPosition(32, 19);
                Console.Write(">");
                Console.SetCursorPosition(53, 19);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(32, 19);
                Console.Write(" ");
                Console.SetCursorPosition(53, 19);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayLoadGameButton(ConsoleColor color = ConsoleColor.White, bool showArrows = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(33, 21);
            Console.Write("+------------------+");
            Console.SetCursorPosition(33, 22);
            Console.Write("|{0}LOAD GAME{1}|", new string(' ', 5), new string(' ', 4));
            Console.SetCursorPosition(33, 23);
            Console.Write("+------------------+");

            if (showArrows)
            {
                Console.SetCursorPosition(32, 22);
                Console.Write(">");
                Console.SetCursorPosition(53, 22);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(32, 22);
                Console.Write(" ");
                Console.SetCursorPosition(53, 22);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayQuitButton(ConsoleColor color = ConsoleColor.White, bool showArrows = false)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(33, 24);
            Console.Write("+------------------+");
            Console.SetCursorPosition(33, 25);
            Console.Write("|{0}QUIT{0}|", new string(' ', 7));
            Console.SetCursorPosition(33, 26);
            Console.Write("+------------------+");

            if (showArrows)
            {
                Console.SetCursorPosition(32, 25);
                Console.Write(">");
                Console.SetCursorPosition(53, 25);
                Console.Write("<");
            }
            else
            {
                Console.SetCursorPosition(32, 25);
                Console.Write(" ");
                Console.SetCursorPosition(53, 25);
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}