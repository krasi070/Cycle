namespace Cycle.Models.Areas
{
    using System;
    using System.Collections.Generic;
    using GameFrames;
    using Geometry;
    using Interfaces;

    public class CrossroadArea : IArea
    {
        private readonly IList<IPoint2D> borderCoordinates;
        private readonly IList<IPoint2D> spawningPoints;
        private readonly IList<IPoint2D> shopCoordinates;
        private readonly IList<IPoint2D> savePointCoordinates;
        private readonly IList<IPoint2D> exitAreaPointsUp;
        private readonly IList<IPoint2D> _exitAreaPointsesDown;
        private readonly IList<IPoint2D> exitAreaPointsRight;
        private readonly IList<IPoint2D> _exitAreaPointsesLeft;
        private readonly IList<IPoint2D> playerStartPoints; 

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

        public IList<IPoint2D> SpawningPoints
        {
            get
            {
                return this.spawningPoints;
            }
        }

        public IList<IPoint2D> BorderCoordinates
        {
            get
            {
                return borderCoordinates;
            }
        }

        public IList<IPoint2D> ShopCoordinates
        {
            get
            {
                return this.shopCoordinates;
            }
        }

        public IList<IPoint2D> SavePointCoordinates
        {
            get
            {
                return this.savePointCoordinates;
            }
        }

        public IList<IPoint2D> ExitAreaPointsUp
        {
            get
            {
                return this.exitAreaPointsUp;
            }
        }

        public IList<IPoint2D> ExitAreaPointsDown
        {
            get
            {
                return this._exitAreaPointsesDown;
            }
        }

        public IList<IPoint2D> ExitAreaPointsRight
        {
            get
            {
                return this.exitAreaPointsRight;
            }
        }

        public IList<IPoint2D> ExitAreaPointsLeft
        {
            get
            {
                return this._exitAreaPointsesLeft;
            }
        }

        public IList<IPoint2D> PlayerStartPoints
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

        private IList<IPoint2D> PutBorderCoordinates()
        {
            var coordinates = new List<IPoint2D>()
            {
                new Point2D(MainFrame.StartWidth + 28, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 52, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 28, MainFrame.StartHeight + 2),
                new Point2D(MainFrame.StartWidth + 52, MainFrame.StartHeight + 2),
                new Point2D(MainFrame.StartWidth + 28, MainFrame.StartHeight + 3),
                new Point2D(MainFrame.StartWidth + 52, MainFrame.StartHeight + 3),
                new Point2D(MainFrame.StartWidth + 1, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 2, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 3, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 4, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 5, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 6, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 7, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 8, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 9, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 10, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 11, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 12, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 13, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 14, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 15, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 16, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 17, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 18, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 19, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 20, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 21, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 22, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 23, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 24, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 25, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 26, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 27, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 28, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 52, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 53, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 54, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 55, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 56, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 57, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 58, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 59, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 60, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 61, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 62, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 63, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 64, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 65, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 66, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 67, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 68, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 69, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 70, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 71, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 72, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 73, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 74, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 75, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 76, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 77, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 78, MainFrame.StartHeight + 4),
                new Point2D(MainFrame.StartWidth + 1, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 2, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 3, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 4, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 5, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 6, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 7, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 8, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 9, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 10, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 11, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 12, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 13, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 14, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 15, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 16, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 17, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 18, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 19, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 20, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 21, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 22, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 23, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 24, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 25, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 26, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 27, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 53, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 54, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 55, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 56, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 57, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 58, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 59, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 60, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 61, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 62, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 63, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 64, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 65, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 66, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 67, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 68, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 69, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 70, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 71, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 72, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 73, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 74, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 75, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 76, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 77, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 78, MainFrame.EndHeight - 5),
                new Point2D(MainFrame.StartWidth + 28, MainFrame.EndHeight - 4),
                new Point2D(MainFrame.StartWidth + 52, MainFrame.EndHeight - 4),
                new Point2D(MainFrame.StartWidth + 28, MainFrame.EndHeight - 3),
                new Point2D(MainFrame.StartWidth + 52, MainFrame.EndHeight - 3),
                new Point2D(MainFrame.StartWidth + 28, MainFrame.EndHeight - 2),
                new Point2D(MainFrame.StartWidth + 52, MainFrame.EndHeight - 2),
                new Point2D(MainFrame.StartWidth + 28, MainFrame.EndHeight - 1),
                new Point2D(MainFrame.StartWidth + 52, MainFrame.EndHeight - 1)
            };

            return coordinates;
        }

        private IList<IPoint2D> PutSpawningPoints()
        {
            var points = new List<IPoint2D>()
            {
                new Point2D(50, 12),
                new Point2D(70, 12),
                new Point2D(70, 13),
                new Point2D(50, 8),
                new Point2D(33, 11),
                new Point2D(23, 10),
                new Point2D(21, 13),
                new Point2D(40, 13),
                new Point2D(45, 15),
                new Point2D(70, 10)
            };

            return points;
        }

        private IList<IPoint2D> PutShopCoordinates()
        {
            var coordinates = new List<IPoint2D>()
            {
                new Point2D(44, 9)
            };

            return coordinates;
        }

        private IList<IPoint2D> PutSavePointCoordinates()
        {
            var coordinates = new List<IPoint2D>()
            {
                new Point2D(60, 12),
                new Point2D(46, 12),
                new Point2D(39, 8)
            };

            return coordinates;
        }

        private IList<IPoint2D> PutExitAreaPointsUp()
        {
            var points = new List<IPoint2D>()
            {
                new Point2D(MainFrame.StartWidth + 29, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 30, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 31, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 32, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 33, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 34, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 35, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 36, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 37, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 38, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 39, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 40, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 41, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 42, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 43, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 44, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 45, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 46, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 47, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 48, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 49, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 50, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 51, MainFrame.StartHeight + 1)
            };

            return points;
        }

        private IList<IPoint2D> PutExitAreaPointsDown()
        {
            var points = new List<IPoint2D>()
            {
                new Point2D(MainFrame.StartWidth + 29, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 30, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 31, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 32, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 33, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 34, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 35, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 36, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 37, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 38, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 39, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 40, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 41, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 42, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 43, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 44, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 45, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 46, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 47, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 48, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 49, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 50, MainFrame.StartHeight + 13),
                new Point2D(MainFrame.StartWidth + 51, MainFrame.StartHeight + 13)
            };

            return points;
        }

        private IList<IPoint2D> PutExitAreaPointsRight()
        {
            var points = new List<IPoint2D>()
            {
                new Point2D(MainFrame.StartWidth + 78, MainFrame.StartHeight + 5),
                new Point2D(MainFrame.StartWidth + 78, MainFrame.StartHeight + 6),
                new Point2D(MainFrame.StartWidth + 78, MainFrame.StartHeight + 7),
                new Point2D(MainFrame.StartWidth + 78, MainFrame.StartHeight + 8),
                new Point2D(MainFrame.StartWidth + 78, MainFrame.StartHeight + 9)
            };

            return points;
        }

        private IList<IPoint2D> PutExitAreaPointsLeft()
        {
            var points = new List<IPoint2D>()
            {
                new Point2D(MainFrame.StartWidth + 1, MainFrame.StartHeight + 5),
                new Point2D(MainFrame.StartWidth + 1, MainFrame.StartHeight + 6),
                new Point2D(MainFrame.StartWidth + 1, MainFrame.StartHeight + 7),
                new Point2D(MainFrame.StartWidth + 1, MainFrame.StartHeight + 8),
                new Point2D(MainFrame.StartWidth + 1, MainFrame.StartHeight + 9)
            };

            return points;
        }

        private IList<IPoint2D> PutPlayerStartPoints()
        {
            var points = new List<IPoint2D>()
            {
                new Point2D(46, MainFrame.StartHeight + 2),
                new Point2D(46, MainFrame.EndHeight - 2),
                new Point2D(MainFrame.StartWidth + 77, MainFrame.StartHeight + 7),
                new Point2D(MainFrame.StartWidth + 2, MainFrame.StartHeight + 7)
            };

            return points;
        }
    }
}