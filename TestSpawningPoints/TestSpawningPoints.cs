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
            Draw();
            string[] sprite =
            {
                " /\\   /\\",
                "//\\\\_//\\\\     ____",
                "\\_     _/    /   /",
                " / * * \\    /^^^]",
                " \\_\\o/_/    [   ]",
                "  /   \\_    [   /",
                "  \\     \\_  /  /",
                "  [ [  /  \\/ _/",
                " _[ [  \\  /_/"
            };

            int startWidth = MainFrame.StartWidth + 22;
            int startHeight = MainFrame.StartHeight + 3;
            for (int i = startHeight; i < startHeight + sprite.Length; i++)
            {
                Console.SetCursorPosition(startWidth, i);
                Console.Write(sprite[i - startHeight]);
            }

            while (true)
            {
                
            }
        }

        private static void Draw()
        {
            var main = new MainFrame();
            main.Draw();
            var status = new MonsterStatusFrame();
            status.Draw();
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