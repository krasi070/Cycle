namespace Cycle.GameFrames
{
    using System;
    using Interfaces;

    public abstract class SimpleGameFrame : IFrame
    {
        private int startWidth;
        private int endWidth;
        private int startHeight;
        private int endHeight;

        protected SimpleGameFrame(int startWidth, int endWidth, int startHeight, int endHeight)
        {
            this.FrameStartWidth = startWidth;
            this.FrameEndWidth = endWidth;
            this.FrameStartHeight = startHeight;
            this.FrameEndHeight = endHeight;
        }

        public int FrameStartWidth
        {
            get
            {
                return this.startWidth;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("StartWidth", "Start width cannot be negative.");
                }

                this.startWidth = value;
            }
        }

        public int FrameEndWidth
        {
            get
            {
                return this.endWidth;
            }

            set
            {
                if (value < this.FrameStartWidth)
                {
                    throw new ArgumentOutOfRangeException("EndWidth", "End width cannot be lower than start width.");
                }
                else if (value > Console.WindowWidth - 1)
                {
                    throw new ArgumentOutOfRangeException("EndWidth", "End width must be lower than console width.");
                }

                this.endWidth = value;
            }
        }

        public int FrameWidth
        {
            get
            {
                return this.FrameEndWidth - this.FrameStartWidth;
            }
        }

        public int FrameStartHeight
        {
            get
            {
                return this.startHeight;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("StartHeight", "Start height cannot be negative.");
                }

                this.startHeight = value;
            }
        }

        public int FrameEndHeight
        {
            get
            {
                return this.endHeight;
            }

            set
            {
                if (value < this.FrameStartHeight)
                {
                    throw new ArgumentOutOfRangeException("EndHeight", "End height cannot be lower than start height.");
                }
                else if (value > Console.WindowHeight - 1)
                {
                    throw new ArgumentOutOfRangeException("EndHeight", "End height must be lower than console height.");
                }

                this.endHeight = value;
            }
        }

        public int FrameHeight
        {
            get
            {
                return this.FrameEndHeight - this.FrameStartHeight;
            }
        }
               
        public void Draw()
        {
            Console.SetCursorPosition(this.FrameStartWidth, this.FrameStartHeight);
            Console.Write("{0}{1}{0}", "+", new string('-', this.FrameWidth - 1));
            for (int i = this.FrameStartHeight + 1; i < this.FrameEndHeight; i++)
            {
                Console.SetCursorPosition(this.FrameStartWidth, i);
                Console.Write("|");
                Console.SetCursorPosition(this.FrameEndWidth, i);
                Console.Write("|");
            }

            Console.SetCursorPosition(this.FrameStartWidth, this.FrameEndHeight);
            Console.WriteLine("{0}{1}{0}", "+", new string('-', this.FrameWidth - 1));
        }
               
        public void Clear()
        {
            for (int currRow = this.FrameStartHeight; currRow <= this.FrameEndHeight; currRow++)
            {
                Console.SetCursorPosition(this.FrameStartWidth, currRow);
                Console.Write(new string(' ', this.FrameWidth + 1));
            }
        }

        public void ClearInside()
        {
            for (int currRow = this.FrameStartHeight + 1; currRow < this.FrameEndHeight; currRow++)
            {
                Console.SetCursorPosition(this.FrameStartWidth + 1, currRow);
                Console.Write(new string(' ', this.FrameWidth - 1));
            }
        }
    }
}