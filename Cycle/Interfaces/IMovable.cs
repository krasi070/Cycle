namespace Cycle.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IMovable
    {
        void Move(ConsoleKey direction);

        void Move(ConsoleKey direction, IList<int> borders);
    }
}
