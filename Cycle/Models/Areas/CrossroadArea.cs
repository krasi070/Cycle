namespace Cycle.Models.Areas
{
    using System;
    using System.Collections.Generic;
    using GameFrames;
    using Interfaces;

    public class CrossroadArea : IArea
    {
        private readonly IList<int> borderCoordinates;
        private readonly IList<int> spawningPoints;
        private readonly IList<int> shopCoordinates;
        private readonly IList<int> savePointCoordinates;
        private readonly IList<int> exitAreaPointsUp;
        private readonly IList<int> _exitAreaPointsesDown;
        private readonly IList<int> exitAreaPointsRight;
        private readonly IList<int> _exitAreaPointsesLeft;
        private readonly IList<int> playerStartPoints; 

        public CrossroadArea()
        {
            this.borderCoordinates = this.PutBorderCoordinates();
            this.spawningPoints = this.PutSpawningPoints();
            this.shopCoordinates = this.PutShopCoordinates();
            this.savePointCoordinates = this.PutSavePointCoordinates();
            this.exitAreaPointsUp = this.PutExitAreaPointsUp();
            this._exitAreaPointsesDown = this.PutExitAreaPointsDown();
            this.exitAreaPointsRight = this.PutExitAreaPointsRight();
            this._exitAreaPointsesLeft = this.PutExitAreaPointsLeft();
            this.playerStartPoints = this.PutPlayerStartPoints(); // [0,1]-up;[2,3]-down;[4,5]-right;[6,7]-left
        }

        public IList<int> SpawningPoints
        {
            get
            {
                return this.spawningPoints;
            }
        }

        public IList<int> BorderCoordinates
        {
            get
            {
                return borderCoordinates;
            }
        }

        public IList<int> ShopCoordinates
        {
            get
            {
                return this.shopCoordinates;
            }
        }

        public IList<int> SavePointCoordinates
        {
            get
            {
                return this.savePointCoordinates;
            }
        }

        public IList<int> ExitAreaPointsUp
        {
            get
            {
                return this.exitAreaPointsUp;
            }
        }

        public IList<int> ExitAreaPointsDown
        {
            get
            {
                return this._exitAreaPointsesDown;
            }
        }

        public IList<int> ExitAreaPointsRight
        {
            get
            {
                return this.exitAreaPointsRight;
            }
        }

        public IList<int> ExitAreaPointsLeft
        {
            get
            {
                return this._exitAreaPointsesLeft;
            }
        }

        public IList<int> PlayerStartPoints
        {
            get
            {
                return this.playerStartPoints;
            }
        }

        public void Draw()
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
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private IList<int> PutBorderCoordinates()
        {
            var coordinates = new List<int>()
            {
                MainFrame.StartWidth + 28, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 52, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 28, MainFrame.StartHeight + 2,
                MainFrame.StartWidth + 52, MainFrame.StartHeight + 2,
                MainFrame.StartWidth + 28, MainFrame.StartHeight + 3,
                MainFrame.StartWidth + 52, MainFrame.StartHeight + 3,
                MainFrame.StartWidth + 1, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 2, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 3, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 4, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 5, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 6, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 7, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 8, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 9, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 10, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 11, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 12, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 13, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 14, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 15, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 16, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 17, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 18, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 19, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 20, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 21, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 22, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 23, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 24, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 25, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 26, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 27, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 28, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 52, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 53, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 54, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 55, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 56, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 57, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 58, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 59, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 60, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 61, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 62, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 63, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 64, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 65, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 66, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 67, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 68, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 69, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 70, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 71, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 72, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 73, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 74, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 75, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 76, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 77, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 78, MainFrame.StartHeight + 4,
                MainFrame.StartWidth + 1, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 2, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 3, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 4, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 5, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 6, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 7, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 8, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 9, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 10, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 11, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 12, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 13, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 14, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 15, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 16, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 17, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 18, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 19, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 20, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 21, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 22, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 23, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 24, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 25, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 26, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 27, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 53, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 54, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 55, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 56, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 57, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 58, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 59, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 60, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 61, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 62, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 63, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 64, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 65, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 66, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 67, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 68, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 69, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 70, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 71, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 72, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 73, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 74, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 75, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 76, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 77, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 78, MainFrame.EndHeight - 5,
                MainFrame.StartWidth + 28, MainFrame.EndHeight - 4,
                MainFrame.StartWidth + 52, MainFrame.EndHeight - 4,
                MainFrame.StartWidth + 28, MainFrame.EndHeight - 3,
                MainFrame.StartWidth + 52, MainFrame.EndHeight - 3,
                MainFrame.StartWidth + 28, MainFrame.EndHeight - 2,
                MainFrame.StartWidth + 52, MainFrame.EndHeight - 2,
                MainFrame.StartWidth + 28, MainFrame.EndHeight - 1,
                MainFrame.StartWidth + 52, MainFrame.EndHeight - 1
            };

            return coordinates;
        }

        private IList<int> PutSpawningPoints()
        {
            var points = new List<int>()
            {
                50, 12,
                70, 12,
                70, 13,
                50, 8,
                33, 11,
                23, 10,
                21, 13,
                40, 13,
                45, 15,
                70, 10
            };

            return points;
        }

        private IList<int> PutShopCoordinates()
        {
            var coordinates = new List<int>()
            {
                44, 9
            };

            return coordinates;
        }

        private IList<int> PutSavePointCoordinates()
        {
            var coordinates = new List<int>()
            {
                60, 12,
                46, 12,
                39, 8
            };

            return coordinates;
        }

        private IList<int> PutExitAreaPointsUp()
        {
            var points = new List<int>()
            {
                MainFrame.StartWidth + 29, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 30, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 31, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 32, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 33, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 34, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 35, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 36, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 37, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 38, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 39, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 40, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 41, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 42, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 43, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 44, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 45, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 46, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 47, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 48, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 49, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 50, MainFrame.StartHeight + 1,
                MainFrame.StartWidth + 51, MainFrame.StartHeight + 1
            };

            return points;
        }

        private IList<int> PutExitAreaPointsDown()
        {
            var points = new List<int>()
            {
                MainFrame.StartWidth + 29, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 30, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 31, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 32, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 33, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 34, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 35, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 36, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 37, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 38, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 39, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 40, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 41, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 42, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 43, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 44, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 45, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 46, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 47, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 48, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 49, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 50, MainFrame.StartHeight + 13,
                MainFrame.StartWidth + 51, MainFrame.StartHeight + 13
            };

            return points;
        }

        private IList<int> PutExitAreaPointsRight()
        {
            var points = new List<int>()
            {
                MainFrame.StartWidth + 78, MainFrame.StartHeight + 5,
                MainFrame.StartWidth + 78, MainFrame.StartHeight + 6,
                MainFrame.StartWidth + 78, MainFrame.StartHeight + 7,
                MainFrame.StartWidth + 78, MainFrame.StartHeight + 8,
                MainFrame.StartWidth + 78, MainFrame.StartHeight + 9
            };

            return points;
        }

        private IList<int> PutExitAreaPointsLeft()
        {
            var points = new List<int>()
            {
                MainFrame.StartWidth + 1, MainFrame.StartHeight + 5,
                MainFrame.StartWidth + 1, MainFrame.StartHeight + 6,
                MainFrame.StartWidth + 1, MainFrame.StartHeight + 7,
                MainFrame.StartWidth + 1, MainFrame.StartHeight + 8,
                MainFrame.StartWidth + 1, MainFrame.StartHeight + 9
            };

            return points;
        }

        private IList<int> PutPlayerStartPoints()
        {
            var points = new List<int>()
            {
                46, MainFrame.StartHeight + 2,
                46, MainFrame.EndHeight - 2,
                MainFrame.StartWidth + 77, MainFrame.StartHeight + 7,
                MainFrame.StartWidth + 2, MainFrame.StartHeight + 7
            };

            return points;
        }
    }
}