namespace TestSpawningPoints
{
    using System;
    using Cycle.GameFrames;

    public class TestSpawningPoints
    {
        public static void Main()
        {
            ResetBuffer();
            Console.CursorVisible = false;
            DrawCrossroad();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(50, 12);
            Console.Write("S");
            Console.SetCursorPosition(70, 12);
            Console.Write("S");
            Console.SetCursorPosition(70, 13);
            Console.Write("S");
            Console.SetCursorPosition(50, 8);
            Console.Write("S");
            Console.SetCursorPosition(33, 11);
            Console.Write("S");
            Console.SetCursorPosition(23, 10);
            Console.Write("S");
            Console.SetCursorPosition(21, 13);
            Console.Write("S");
            Console.SetCursorPosition(40, 13);
            Console.Write("S");
            Console.SetCursorPosition(45, 15);
            Console.Write("S");
            Console.SetCursorPosition(70, 10);
            Console.Write("S");
            // 44 9
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(44, 9);
            Console.Write("shop");
            // 60 12
            Console.SetCursorPosition(60, 12);
            Console.Write("S");
            Console.SetCursorPosition(46, 12);
            Console.Write("S");
            Console.SetCursorPosition(39, 8);
            Console.Write("S");

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(MainFrame.StartWidth + 29, MainFrame.StartHeight + 1);
            Console.Write(new string(' ', 23));
            
            Console.SetCursorPosition(MainFrame.StartWidth + 29, MainFrame.StartHeight + 13);
            Console.Write(new string(' ', 23));
            Console.SetCursorPosition(MainFrame.StartWidth + 1, MainFrame.StartHeight + 5);
            Console.Write(" ");
            Console.SetCursorPosition(MainFrame.StartWidth + 1, MainFrame.StartHeight + 6);
            Console.Write(" ");
            Console.SetCursorPosition(MainFrame.StartWidth + 1, MainFrame.StartHeight + 7);
            Console.Write(" ");
            Console.SetCursorPosition(MainFrame.StartWidth + 1, MainFrame.StartHeight + 8);
            Console.Write(" ");
            Console.SetCursorPosition(MainFrame.StartWidth + 1, MainFrame.StartHeight + 9);
            Console.Write(" ");
            Console.SetCursorPosition(MainFrame.StartWidth + 78, MainFrame.StartHeight + 5);
            Console.Write(" ");
            Console.SetCursorPosition(MainFrame.StartWidth + 78, MainFrame.StartHeight + 6);
            Console.Write(" ");
            Console.SetCursorPosition(MainFrame.StartWidth + 78, MainFrame.StartHeight + 7);
            Console.Write(" ");
            Console.SetCursorPosition(MainFrame.StartWidth + 78, MainFrame.StartHeight + 8);
            Console.Write(" ");
            Console.SetCursorPosition(MainFrame.StartWidth + 78, MainFrame.StartHeight + 9);
            Console.Write(" ");

            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(46, MainFrame.StartHeight + 2);
            Console.Write(" ");
            Console.SetCursorPosition(46, MainFrame.EndHeight - 2);
            Console.Write(" ");
            Console.SetCursorPosition(MainFrame.StartWidth + 77, MainFrame.StartHeight + 7);
            Console.Write(" ");
            Console.SetCursorPosition(MainFrame.StartWidth + 2, MainFrame.StartHeight + 7);
            Console.Write(" ");

            while (true)
            {
                
            }
        }

        private static void DrawOneWayOut()
        {
            int startX = MainFrame.StartWidth + 28;
            int startY = MainFrame.StartHeight + 1;
            for (int i = startY; i < startY + 3; i++)
            {
                Console.SetCursorPosition(startX, i);
                Console.Write("|");
                Console.SetCursorPosition(startX + 24, i);
                Console.Write("|");
            }

            startX = MainFrame.StartWidth + 11;
            startY = startY + 3;

            Console.SetCursorPosition(startX, startY);
            Console.Write("{0}|{1}|{2}",
                new string('_', 17),
                new string(' ', 23),
                new string('_', 16));

            startX = MainFrame.StartWidth + 10;
            int endX = MainFrame.EndWidth - 10;
            startY++;

            for (int i = startY; i < MainFrame.EndHeight - 1; i++)
            {
                Console.SetCursorPosition(startX, i);
                Console.Write("|");
                Console.SetCursorPosition(endX, i);
                Console.Write("|");
            }

            Console.SetCursorPosition(startX + 1, MainFrame.EndHeight - 2);
            Console.Write(new string('_', 58));
        }

        private static void DrawCrossroad()
        {
            int startX = MainFrame.StartWidth + 28;
            int startY = MainFrame.StartHeight + 1;
            for (int i = startY; i < startY + 3; i++)
            {
                Console.SetCursorPosition(startX, i);
                Console.Write("|");
                Console.SetCursorPosition(startX + 24, i);
                Console.Write("|");
            }

            startX = MainFrame.StartWidth + 1;
            startY = startY + 3;
            Console.SetCursorPosition(startX, startY);
            Console.Write("{0}|{1}|{2}", new string('_', 27), new string(' ', 23), new string('_', 26));

            startY = MainFrame.EndHeight - 5;
            Console.SetCursorPosition(startX, startY);
            Console.Write("{0}{1}{2}", new string('_', 27), new string(' ', 25), new string('_', 26));

            startX = MainFrame.StartWidth + 28;
            startY = startY + 1;
            for (int i = startY; i < MainFrame.EndHeight; i++)
            {
                Console.SetCursorPosition(startX, i);
                Console.Write("|");
                Console.SetCursorPosition(startX + 24, i);
                Console.Write("|");
            }
        }

        private static void ResetBuffer()
        {
            Console.BufferHeight = Console.WindowHeight = 30;
            Console.BufferWidth = Console.WindowWidth = 90;
        }
    }
}