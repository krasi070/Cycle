namespace Cycle.Models.Units.Monsters
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public abstract class Monster : Unit, IMonster
    {
        private const string DefaultOutOfBattleSprite = "m";

        protected static readonly Random Random = new Random();

        private int pointsReward;
        private string outOfBattleSprite;

        protected Monster(
            string name,
            int x,
            int y,
            int hitPoints,
            int magicPoints,
            int damage,
            int defense,
            int accuracy,
            int criticalChance,
            int level,
            IList<INormalAttack> normalAttacks,
            IList<IMagicAttack> magicAttacks,
            int pointsReward,
            string[] inBattleSprite)
            : base(
            name,
            x,
            y, 
            hitPoints,
            magicPoints, 
            damage, 
            defense, 
            accuracy,
            criticalChance,
            level, 
            normalAttacks, 
            magicAttacks)
        {
            this.IncreaseStatusForAppropriateLevel(1, level);
            this.PointsReward = pointsReward;
            this.OutOfBattleSprite = DefaultOutOfBattleSprite;
            this.InBattleSprite = inBattleSprite;
        }

        public int PointsReward
        {
            get
            {
                return this.pointsReward + (this.pointsReward * this.Level / 2);
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("PointsReward", "Points reward cannot be negative.");
                }

                this.pointsReward = value;
            }
        }

        public string OutOfBattleSprite
        {
            get
            {
                return this.outOfBattleSprite;
            }

            set
            {
                if (value.Length != 1 || value == " ")
                {
                    throw new ArgumentOutOfRangeException(
                        "OutOfBattleSprite",
                        "Out of battle sprite must be only one character and that character cannot be a space.");
                }

                this.outOfBattleSprite = value;
            }
        }

        public string[] InBattleSprite { get; set; }

        public override void Clear()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(" ");
        }
    }
}