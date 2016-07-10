namespace Cycle.Geometry
{
    using System;
    using Interfaces;

    public class Point2D : IPoint2D
    {
        private int x;
        private int y;

        public Point2D(int x, int y)
        {
            this.X = x;
            this.Y = y;
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
    }
}