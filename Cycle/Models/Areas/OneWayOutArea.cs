namespace Cycle.Models.Areas
{
    using System;
    using System.Collections.Generic;
    using GameFrames;
    using Geometry;
    using Interfaces;

    public class OneWayOutArea : IArea
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

        public OneWayOutArea()
        {
            this.borderCoordinates = this.PutBorderCoordinates();
            this.spawningPoints = this.PutSpawningPoints();
            this.shopCoordinates = this.PutShopCoordinates();
            this.savePointCoordinates = this.PutSavePointCoordinates();
            this.exitAreaPointsUp = this.PutExitAreaPointsUp();
            this._exitAreaPointsesDown = null;
            this.exitAreaPointsRight = null;
            this._exitAreaPointsesLeft = null;
            this.playerStartPoints = this.PutPlayerStartPoints();
        }

        public IList<IPoint2D> BorderCoordinates
        {
            get
            {
                return this.borderCoordinates;
            }
        }

        public IList<IPoint2D> SpawningPoints
        {
            get
            {
                return this.spawningPoints;
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

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(MainFrame.StartWidth + 29, MainFrame.StartHeight + 1);
            Console.Write(new string(' ', 23));
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private IList<IPoint2D> PutBorderCoordinates()
        {
            var borders = new List<IPoint2D>()
            {
                new Point2D(MainFrame.StartWidth + 28, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 52, MainFrame.StartHeight + 1),
                new Point2D(MainFrame.StartWidth + 28, MainFrame.StartHeight + 2),
                new Point2D(MainFrame.StartWidth + 52, MainFrame.StartHeight + 2),
                new Point2D(MainFrame.StartWidth + 28, MainFrame.StartHeight + 3),
                new Point2D(MainFrame.StartWidth + 52, MainFrame.StartHeight + 3),
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
                new Point2D(MainFrame.StartWidth + 10, MainFrame.StartHeight + 5),
                new Point2D(MainFrame.EndWidth - 10, MainFrame.StartHeight + 5),
                new Point2D(MainFrame.StartWidth + 10, MainFrame.StartHeight + 6),
                new Point2D(MainFrame.EndWidth - 10, MainFrame.StartHeight + 6),
                new Point2D(MainFrame.StartWidth + 10, MainFrame.StartHeight + 7),
                new Point2D(MainFrame.EndWidth - 10, MainFrame.StartHeight + 7),
                new Point2D(MainFrame.StartWidth + 10, MainFrame.StartHeight + 8),
                new Point2D(MainFrame.EndWidth - 10, MainFrame.StartHeight + 8),
                new Point2D(MainFrame.StartWidth + 10, MainFrame.StartHeight + 9),
                new Point2D(MainFrame.EndWidth - 10, MainFrame.StartHeight + 9),
                new Point2D(MainFrame.StartWidth + 10, MainFrame.StartHeight + 10),
                new Point2D(MainFrame.EndWidth - 10, MainFrame.StartHeight + 10),
                new Point2D(MainFrame.StartWidth + 10, MainFrame.StartHeight + 11),
                new Point2D(MainFrame.EndWidth - 10, MainFrame.StartHeight + 11),
                new Point2D(MainFrame.StartWidth + 10, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 11, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 12, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 13, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 14, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 15, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 16, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 17, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 18, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 19, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 20, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 21, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 22, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 23, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 24, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 25, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 26, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 27, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 28, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 29, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 30, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 31, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 32, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 33, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 34, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 35, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 36, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 37, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 38, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 39, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 40, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 41, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 42, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 43, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 44, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 45, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 46, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 47, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 48, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 49, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 50, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 51, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 52, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 53, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 54, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 55, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 56, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 57, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 58, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 59, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 60, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 61, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 62, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 63, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 64, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 65, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 66, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 67, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 68, MainFrame.StartHeight + 12),
                new Point2D(MainFrame.StartWidth + 69, MainFrame.StartHeight + 12)
            };  

            return borders;
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

        private IList<IPoint2D> PutPlayerStartPoints()
        {
            var points = new List<IPoint2D>()
            {
                new Point2D(46, MainFrame.StartHeight + 2),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0)
            };

            return points;
        }
    }
}