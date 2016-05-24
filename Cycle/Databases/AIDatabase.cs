namespace Cycle.Databases
{
    using System.Collections.Generic;
    using Interfaces;
    using Models.AIs;

    public class AIDatabase : IAIDatabase
    {
        private readonly List<IArtificialIntelligence> ais;
        private readonly Dictionary<string, IArtificialIntelligence> aiByName;

        public AIDatabase()
        {
            ais = new List<IArtificialIntelligence>();
            aiByName = new Dictionary<string, IArtificialIntelligence>();
            this.PutAIsInDatabase();
        }

        public IArtificialIntelligence GetAIByName(string name)
        {
            if (aiByName.ContainsKey(name))
            {
                return aiByName[name];
            }

            return null;
        }

        private void PutAIsInDatabase()
        {
            var simpleAI = new SimpleAI();
            ais.Add(simpleAI);
            aiByName.Add("Simple AI", simpleAI);
        }
    }
}