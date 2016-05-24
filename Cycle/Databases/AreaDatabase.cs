namespace Cycle.Databases
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Models.Areas;

    public class AreaDatabase : IAreaDatabase
    {
        private readonly Random Random = new Random();

        private readonly List<IArea> areas;
        private readonly List<IArea> areasWithDownEntrance; 
        private readonly List<IArea> areasWithUpEntrance; 
        private readonly List<IArea> areasWithLeftEntrance; 
        private readonly List<IArea> areasWithRightEntrance; 
        private readonly Dictionary<string, IArea> areasByName;

        public AreaDatabase()
        {
            this.areas = new List<IArea>();
            this.areasByName = new Dictionary<string, IArea>();
            this.areasWithDownEntrance = new List<IArea>();
            this.areasWithUpEntrance = new List<IArea>();
            this.areasWithLeftEntrance = new List<IArea>();
            this.areasWithRightEntrance = new List<IArea>();
            this.PutAreas();
        }

        public IArea GetAreaByName(string name)
        {
            if (areasByName.ContainsKey(name))
            {
                return areasByName[name];
            }

            return null;
        }

        public IArea GetRandomAreaWithDownEntrance()
        {
            int randomIndex = Random.Next(0, this.areasWithDownEntrance.Count);

            return this.areasWithDownEntrance[randomIndex];
        }

        public IArea GetRandomAreaWithUpEntrance()
        {
            int randomIndex = Random.Next(0, this.areasWithUpEntrance.Count);

            return this.areasWithUpEntrance[randomIndex];
        }

        public IArea GetRandomAreaWithLeftEntrance()
        {
            int randomIndex = Random.Next(0, this.areasWithLeftEntrance.Count);

            return this.areasWithLeftEntrance[randomIndex];
        }

        public IArea GetRandomAreaWithRightEntrance()
        {
            int randomIndex = Random.Next(0, this.areasWithRightEntrance.Count);

            return this.areasWithRightEntrance[randomIndex];
        }

        private void PutAreas()
        {
            var oneWayOutArea = new OneWayOutArea();
            var crossroadArea = new CrossroadArea();
            this.areas.Add(crossroadArea);
            this.areas.Add(oneWayOutArea);
            this.areasByName.Add("One Way Out Area", oneWayOutArea);
            this.areasByName.Add("Crossroad Area", crossroadArea);
            this.areasWithDownEntrance.Add(crossroadArea);
            this.areasWithUpEntrance.Add(crossroadArea);
            this.areasWithUpEntrance.Add(oneWayOutArea);
            this.areasWithLeftEntrance.Add(crossroadArea);
            this.areasWithRightEntrance.Add(crossroadArea);
        }
    }
}