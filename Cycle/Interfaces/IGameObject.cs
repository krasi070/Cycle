namespace Cycle.Interfaces
{
    using System;

    public interface IGameObject
    {
        string Name { get; }

        int X { get; set; }

        int Y { get; set; }

        ConsoleColor Color { get; set; }
    }
}
