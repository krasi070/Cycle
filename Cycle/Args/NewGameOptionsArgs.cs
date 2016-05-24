namespace Cycle.Args
{
    using System;

    public class NewGameOptionsArgs
    {
        public NewGameOptionsArgs(string name, ConsoleColor color, int textSpeed)
        {
            this.Name = name;
            this.Color = color;
            this.TextSpeed = textSpeed;
        }

        public string Name { get; set; }

        public ConsoleColor Color { get; set; }

        public int TextSpeed { get; set; }
    }
}
