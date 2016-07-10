namespace Cycle.Models.Units
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Enums;

    public abstract class Unit : GameObject, IUnit
    {
        private const int MaxPossibleAccuracy = 200;
        private const int MaxPossibleCriticalChance = 100;
        private const StatusAilment DefaultAilment = StatusAilment.None;

        private static readonly Random Random = new Random();

        private int hp;
        private int maxHP;
        private int damage;
        private int battleDamage;
        private int maxDamage;
        private int mp;
        private int maxMP;
        private int defense;
        private int battleDefense;
        private int maxDefense;
        private int accuracy;
        private int battleAccuracy;
        private int maxAccuracy;
        private int criticalChance;
        private int battleCriticalChance;
        private int ailmentDuration;
        private int level;

        protected Unit(
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
            ConsoleColor color = ConsoleColor.White,
            StatusAilment statusAilment = DefaultAilment,
            int ailmentDuration = 0)
            : base(name, x, y, color)
        {
            this.MaxHP = hitPoints;
            this.MaxMP = magicPoints;
            this.MaxDamage = damage;
            this.MaxDefense = defense;
            this.MaxAccuracy = accuracy;
            this.CriticalChance = criticalChance;
            this.Level = level;
            this.NormalAttacks = normalAttacks;
            this.MagicAttacks = magicAttacks;
            this.Ailment = statusAilment;
            this.AilmentDuration = ailmentDuration;
            this.CanActThisTurn = true;
            this.CanUseMagic = true;
            this.CanUsePhysicalAttack = true;
        }

        public int Level
        {
            get
            {
                return this.level;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Level", "Level cannot be negative.");
                }

                this.level = value;
            }
        }

        public int MaxHP
        {
            get
            {
                return this.maxHP;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("MaxHP", "Max HP cannot be negative.");
                }

                this.maxHP = value;
                this.HP = value;
            }
        }

        public int HP
        {
            get
            {
                return this.hp;
            }

            set
            {
                if (value < 0)
                {
                    this.hp = 0;
                }
                else if (value > this.MaxHP)
                {
                    this.hp = this.MaxHP;
                }
                else
                {
                    this.hp = value;
                }
            }
        }

        public bool IsAlive
        {
            get
            {
                return this.HP > 0;
            }
        }

        public int MaxMP
        {
            get
            {
                return this.maxMP;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("MaxMP", "Max MP cannot be negative.");
                }

                this.maxMP = value;
                this.MP = value;
            }
        }

        public int MP
        {
            get
            {
                return this.mp;
            }

            set
            {
                if (value < 0)
                {
                    this.mp = 0;
                }
                else if (value > this.MaxMP)
                {
                    this.mp = this.MaxMP;
                }
                else
                {
                    this.mp = value;
                }
            }
        }

        public int MaxDamage
        {
            get
            {
                return this.maxDamage;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("MaxDamage", "Max damage cannot be negative.");
                }

                this.maxDamage = value;
                this.BattleDamage = value;
                this.Damage = value;
            }
        }

        public int BattleDamage
        {
            get
            {
                return this.battleDamage;
            }

            set
            {
                if (value < this.MaxDamage / 4)
                {
                    this.battleDamage = this.MaxDamage / 4;
                }
                else if (value > this.MaxDamage * 3)
                {
                    this.battleDamage = this.MaxDamage * 3;
                }

                this.battleDamage = value;
            }
        }

        public int Damage
        {
            get
            {
                return Random.Next(Math.Max(0, this.BattleDamage - 5), this.BattleDamage + 1);
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Damage", "Damage cannot be negative.");
                }
                else if (value > this.MaxDamage)
                {
                    throw new ArgumentOutOfRangeException(
                        "Damage",
                        "Damage cannot be higher than max damage.");
                }

                this.damage = value;
            }
        }

        public int MaxDefense
        {
            get
            {
                return this.maxDefense;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("MaxDefense", "Max defense cannot be negative.");
                }

                this.maxDefense = value;
                this.BattleDefense = value;
                this.Defense = value;
            }
        }

        public int BattleDefense
        {
            get
            {
                return this.battleDefense;
            }

            set
            {
                if (value < this.MaxDefense / 3)
                {
                    this.battleDefense = this.MaxDefense  /3;
                }
                else if (value > this.MaxDefense * 2)
                {
                    this.battleDefense = this.MaxDefense * 2;
                }

                this.battleDefense = value;
            }
        }

        public int Defense
        {
            get
            {
                return Random.Next(Math.Max(0, this.BattleDefense - 5), this.BattleDefense + 1);
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Defense", "Defense cannot be negative.");
                }
                else if (value > this.MaxDefense)
                {
                    throw new ArgumentOutOfRangeException(
                        "Defense",
                        "Defense cannot be higher than max defense.");
                }

                this.defense = value;
            }
        }

        public int MaxAccuracy
        {
            get
            {
                return this.maxAccuracy;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("MaxAccuracy", "Max accuracy cannot be negative.");
                }
                else if (value > MaxPossibleAccuracy)
                {
                    value = MaxPossibleAccuracy;
                }

                this.maxAccuracy = value;
                this.BattleAccuracy = value;
                this.Accuracy = value;
            }
        }

        public int BattleAccuracy
        {
            get
            {
                return this.battleAccuracy;
            }

            set
            {
                if (value < this.MaxAccuracy / 2)
                {
                    this.battleAccuracy = this.MaxAccuracy / 2;
                }
                else if (value > MaxPossibleAccuracy)
                {
                    this.battleAccuracy = MaxPossibleAccuracy;
                }

                this.battleAccuracy = value;
            }
        }

        public int Accuracy
        {
            get
            {
                return Random.Next(
                    Math.Max(0, this.BattleAccuracy - 5),
                    Math.Min(MaxPossibleAccuracy + 1, this.BattleAccuracy + 1));
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Accuracy", "Accuracy cannot be negative.");
                }
                else if (value > this.MaxAccuracy)
                {
                    throw new ArgumentOutOfRangeException(
                        "Accuracy",
                        "Accuracy cannot be higher than max accuracy.");
                }

                this.accuracy = value;
            }
        }

        public int CriticalChance
        {
            get
            {
                return this.criticalChance;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "CriticalChance",
                        "Critical cahnce cannot be negative.");
                }
                else if (value > MaxPossibleCriticalChance)
                {
                    value = MaxPossibleCriticalChance;
                }

                this.criticalChance = value;
                this.BattleCriticalChance = value;
            }
        }

        public int BattleCriticalChance
        {
            get
            {
                return this.battleCriticalChance;
            }

            set
            {
                if (value < 0)
                {
                    this.battleCriticalChance = 0;
                }
                else if (value > MaxPossibleCriticalChance)
                {
                    this.battleCriticalChance = MaxPossibleCriticalChance;
                }

                this.battleCriticalChance = value;
            }
        }

        public StatusAilment Ailment { get; set; }

        public bool IsInBattle { get; set; }

        public bool CanActThisTurn { get; set; }

        public bool CanUsePhysicalAttack { get; set; }

        public bool CanUseMagic { get; set; }

        public int AilmentDuration
        {
            get
            {
                return this.ailmentDuration;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("AilmentDuration", "Ailment duration cannot be negative.");
                }

                this.ailmentDuration = value;
            }
        }

        public IList<INormalAttack> NormalAttacks { get; set; }

        public IList<IMagicAttack> MagicAttacks { get; set; }

        public abstract void Draw();

        public abstract void Clear();

        public void AddNormalAttack(INormalAttack normalAttack)
        {
            this.NormalAttacks.Add(normalAttack);
        }

        public void RemoveNormalAttack(INormalAttack normalAttack)
        {
            this.NormalAttacks.Remove(normalAttack);
        }

        public void ReplaceNormalAttack(INormalAttack attackToRemove, INormalAttack attackToAdd)
        {
            int indexOfAttackToRemove = this.NormalAttacks.IndexOf(attackToRemove);
            this.NormalAttacks.Remove(attackToRemove);
            this.NormalAttacks.Insert(indexOfAttackToRemove, attackToAdd);
        }

        public void AddMagicAttack(IMagicAttack magicAttack)
        {
            this.MagicAttacks.Add(magicAttack);
        }

        public void RemoveMagicAttack(IMagicAttack magicAttack)
        {
            this.MagicAttacks.Remove(magicAttack);
        }

        public void ReplaceMagicAttack(IMagicAttack attackToRemove, IMagicAttack attackToAdd)
        {
            int indexOfAttackToRemove = this.MagicAttacks.IndexOf(attackToRemove);
            this.MagicAttacks.Remove(attackToRemove);
            this.MagicAttacks.Insert(indexOfAttackToRemove, attackToAdd);
        }

        public void ExecuteAilment()
        {
            if (this.Ailment != DefaultAilment)
            {
                switch (this.Ailment)
                {
                    case StatusAilment.Poison:
                        this.ExecutePoisonEffect();
                        break;
                    case StatusAilment.Sleep:
                        this.ExecuteSleepEffect();
                        break;
                    case StatusAilment.Confused:
                        this.ExecuteConfusedEffect();
                        break;
                    case StatusAilment.Blinded:
                        this.ExecuteBlindedEffect();
                        break;
                    case StatusAilment.Tired:
                        this.ExecuteTiredEffect();
                        break;
                }

                this.AilmentDuration--;
                if (this.AilmentDuration == 0)
                {
                    this.Ailment = DefaultAilment;
                }
            }
            else
            {
                this.CanActThisTurn = true;
                this.CanUseMagic = true;
                this.CanUsePhysicalAttack = true;
            }
        }

        private void ExecutePoisonEffect()
        {
            this.HP -= this.MaxHP / 9;
        }

        private void ExecuteSleepEffect()
        {
            this.CanActThisTurn = false;
        }

        private void ExecuteConfusedEffect()
        {
            if (Random.Next(1, 3) == 1)
            {
                this.HP -= this.MaxHP / 5;
                this.CanActThisTurn = false;
            }
        }

        private void ExecuteBlindedEffect()
        {
            this.CanUseMagic = false;
        }

        private void ExecuteTiredEffect()
        {
            this.CanUsePhysicalAttack = false;
        }
    }
}