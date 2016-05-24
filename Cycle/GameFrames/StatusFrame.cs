namespace Cycle.GameFrames
{
    using System;
    using Interfaces;

    public class StatusFrame : SimpleGameFrame, IStatusFrame
    {
        public static int StartWidth = 5;
        public static int EndWidth = 84;
        public static int Width = EndWidth - StartWidth;
        public static int StartHeight = 1;
        public static int EndHeight = 5;
        public static int Height = EndHeight - StartHeight;

        public StatusFrame()
            : base(StartWidth, EndWidth, StartHeight, EndHeight)
        {
        }

        public void Update(IUnit player)
        {
            Console.SetCursorPosition(StartWidth + 1, StartHeight + 2);
            Console.WriteLine(new string(' ', Width - 1));

            Console.SetCursorPosition(StartWidth + 1, StartHeight + 2);
            Console.Write(
                "{0}Name: {1}{0}Level: {2}{0}HP: {3}/{4}{0}MP: {5}/{6}",
                new string(' ', 8),
                player.Name,
                player.Level, 
                player.HP, 
                player.MaxHP, 
                player.MP, 
                player.MaxMP);
        }
    }
}