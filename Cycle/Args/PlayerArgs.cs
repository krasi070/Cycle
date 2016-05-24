namespace Cycle.Args
{
    using System.Collections.Generic;

    public class PlayerArgs
    {
        public PlayerArgs(string name, int lvl, int points, int magicRobbers, int maxHp, int hp, int maxMp, int mp,
            int damage, int defense, int accuracy, int crirChance, IList<string> nAttacks, IList<string> mAttacks)
        {
            this.Name = name;
            this.Level = lvl;
            this.Points = points;
            this.MagicRobbers = magicRobbers;
            this.MaxHP = maxHp;
            this.HP = hp;
            this.MaxMP = maxMp;
            this.MP = mp;
            this.Damage = damage;
            this.Defense = defense;
            this.Accuracy = accuracy;
            this.CriticalChance = crirChance;
            this.NormalAttacks = nAttacks;
            this.MagicAttacks = mAttacks;
        }

        public string Name { get; set; }

        public int Level { get; set; }

        public int Points { get; set; }

        public int MagicRobbers { get; set; }

        public int MaxHP { get; set; }

        public int HP { get; set; }

        public int MaxMP { get; set; }

        public int MP { get; set; }

        public int Damage { get; set; }

        public int Defense { get; set; }

        public int Accuracy { get; set; }

        public int CriticalChance { get; set; }

        public IList<string> NormalAttacks { get; set; }

        public IList<string> MagicAttacks { get; set; }
    }
}