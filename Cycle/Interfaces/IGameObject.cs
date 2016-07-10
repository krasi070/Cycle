namespace Cycle.Interfaces
{
    using System;

    public interface IGameObject : IPoint2D
    {
        string Name { get; }

        ConsoleColor Color { get; set; }
    }
}