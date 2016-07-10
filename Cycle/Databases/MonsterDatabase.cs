namespace Cycle.Databases
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Models.Units.Monsters;

    public class MonsterDatabase : IMonsterDatabase
    {
        private Random random = new Random();

        private readonly List<IMonster> monsters;
        private readonly Dictionary<string, Dictionary<int, IMonster>> monstersByNameAndLevel;
        private readonly Dictionary<int, List<IMonster>> monstersByLevel;

        public MonsterDatabase()
        {
            this.monsters = new List<IMonster>();
            this.monstersByNameAndLevel = new Dictionary<string, Dictionary<int, IMonster>>();
            this.monstersByLevel = new Dictionary<int, List<IMonster>>();
            this.AddMonsters();
        }

        public void RemoveMonster(IMonster monster)
        {
            if (monsters.Contains(monster))
            {
                monsters.Remove(monster);
                monstersByNameAndLevel[monster.Name].Remove(monster.Level);
                monstersByLevel[monster.Level].Remove(monster);
            }
        }

        public IMonster GetMonsterByNameAndLevel(string name, int level)
        {
            if (monstersByNameAndLevel.ContainsKey(name))
            {
                if (monstersByNameAndLevel[name].ContainsKey(level))
                {
                    return monstersByNameAndLevel[name][level];
                }
            }

            return null;
        }

        public IMonster GetRandomMonster()
        {
            if (monsters.Count > 0)
            {
                int randomIndex = random.Next(0, monsters.Count);

                return monsters[randomIndex];
            }

            return null;
        }

        public IMonster GetRandomMonsterByLevel(int level)
        {
            if (monstersByLevel.ContainsKey(level) && monstersByLevel[level].Count > 0)
            {
                int randomIndex = random.Next(0, monstersByLevel[level].Count);

                return monstersByLevel[level][randomIndex];
            }

            return null;
        }

        // TODO: Add all available monsters
        private void AddMonsters()
        {
            for (int i = 1; i < 3; i++)
            {
                this.monstersByLevel.Add(i, new List<IMonster>());
                var smallFacedCat = new TheSmallFacedCat(0, 0, i);
                this.monsters.Add(smallFacedCat);
                this.monstersByLevel[i].Add(smallFacedCat);
                if (!this.monstersByNameAndLevel.ContainsKey(smallFacedCat.Name))
                {
                    this.monstersByNameAndLevel.Add(smallFacedCat.Name, new Dictionary<int, IMonster>());
                }

                this.monstersByNameAndLevel[smallFacedCat.Name].Add(i, smallFacedCat);
            }
        }
    }
}