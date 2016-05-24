namespace Cycle.Models.AIs
{
    using System;
    using Interfaces;

    public abstract class AI : IArtificialIntelligence
    {
        protected static Random Random = new Random();

        public abstract string[] Act(IUnit aiUser, IUnit target);
    }
}
