namespace Cycle.Models
{
    using System;
    using Geometry;
    using Interfaces;

    public abstract class GameObject : Point2D, IGameObject
    {
        private const ConsoleColor DefaultColor = ConsoleColor.White;

        private string name;
        private int x;
        private int y;

        protected GameObject(string name, int x, int y, ConsoleColor color = DefaultColor)
            : base(x, y)
        {
            this.Name = name;
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

        public ConsoleColor Color { get; set; }
    }
}