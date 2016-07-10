namespace Cycle.Interfaces
{
    using System.Collections.Generic;

    public interface IArea : IDrawable
    {
        IList<IPoint2D> SpawningPoints { get; }

        IList<IPoint2D> BorderCoordinates { get; }

        IList<IPoint2D> ShopCoordinates { get; }

        IList<IPoint2D> SavePointCoordinates { get; }

        IList<IPoint2D> ExitAreaPointsUp { get; }

        IList<IPoint2D> ExitAreaPointsDown { get; }

        IList<IPoint2D> ExitAreaPointsRight { get; }

        IList<IPoint2D> ExitAreaPointsLeft { get; }

        IList<IPoint2D> PlayerStartPoints { get; }
    }
}