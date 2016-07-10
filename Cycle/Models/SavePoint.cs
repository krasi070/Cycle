namespace Cycle.Models
{
    using System;

    public class SavePoint : GameObject
    {
        private const string SavePointName = "Save Point";

        public SavePoint(int x, int y)
            : base(SavePointName, x, y)
        {
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;

            Console.SetCursorPosition(this.X, this.Y);
            Console.Write("S");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}