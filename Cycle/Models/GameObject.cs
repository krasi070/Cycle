namespace Cycle.Models
{
    using System;
    using Interfaces;

    public abstract class GameObject : IGameObject
    {
        private const ConsoleColor DefaultColor = ConsoleColor.White;

        private string name;
        private int x;
        private int y;

        protected GameObject(string name, int x, int y, ConsoleColor color = DefaultColor)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.Color = color;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                if (value.Length < 2 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "Name cannot be less than 2 characters long and cannot contain only whitespaces",
                        "Name");
                }

                this.name = value;
            }
        }

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("X", "X coordinate cannot be negative.");
                }

                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Y", "Y coordinate cannot be negative.");
                }

                this.y = value;
            }
        }

        public ConsoleColor Color { get; set; }
    }
}