namespace Cycle.Interfaces
{
    using System.Collections.Generic;

    public interface IArea : IDrawable
    {
        IList<int> SpawningPoints { get; }

        IList<int> BorderCoordinates { get; }

        IList<int> ShopCoordinates { get; }

        IList<int> SavePointCoordinates { get; }

        IList<int> ExitAreaPointsUp { get; }

        IList<int> ExitAreaPointsDown { get; }

        IList<int> ExitAreaPointsRight { get; }

        IList<int> ExitAreaPointsLeft { get; }

        IList<int> PlayerStartPoints { get; }
    }
}