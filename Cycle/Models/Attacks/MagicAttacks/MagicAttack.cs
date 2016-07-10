namespace Cycle.Models.Attacks.MagicAttacks
{
    using System;
    using Interfaces;
    using Enums;

    public abstract class MagicAttack : Attack, IMagicAttack
    {
        private const StatusAilment DefaultAilment = StatusAilment.None;

        private int mpCost;
        private int ailmentDuration;

        protected MagicAttack(
            string name,
            int mpCost,
            int damage, 
            int accuracy, 
            StatusAilment ailment = DefaultAilment, 
            int ailmentDuration = 0)
            : base(name, damage, accuracy)
        {
            this.MPCost = mpCost;
            this.Ailment = ailment;
            this.AilmentDuration = ailmentDuration;
        }

        public int MPCost
        {
            get
            {
                return this.mpCost;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("MPCost", "MP cost cannot be negative.");
                }

                this.mpCost = value;
            }
        }

        public StatusAilment Ailment { get; set; }

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

        public override string[] Description
        {
            get
            {
                string[] description = 
                {
                    string.Format("MP Cost: {0}", this.MPCost),
                    base.Description[0],
                    base.Description[1]
                };

                return description;
            }
        }

        public virtual string[] CastMagic(IUnit user, IUnit target)
        {
            string[] message = new string[2];
            message[0] = this.CheckIfMPIsEnough(user);
            if (message[0] != string.Empty)
            {
                return message;
            }

            message[0] = string.Format(
                "{0} used {1} on {2}.",
                user.Name,
                this.Name,
                target.Name);

            int attackAccuracy = (user.Accuracy + this.Accuracy) / 2;
            int attackDamage = this.Damage == 0 ? (user.Damage + this.Damage) / 2 : 0;

            bool hitTarget = Random.Next(1, 101) <= attackAccuracy;
            if (hitTarget)
            {
                bool isCritical = Random.Next(1, 101) <= user.BattleCriticalChance;
                if (isCritical)
                {
                    attackDamage *= (attackDamage * 2) - (attackDamage / 4);

                    message[0] += " Critical hit!!!";
                }

                target.HP = (target.HP + target.Defense) - attackDamage;
            }
            else
            {
                message[1] = string.Format("But {0} missed.", user.Name);
            }

            if (this.Ailment != DefaultAilment)
            {
                target.Ailment = this.Ailment;
                target.AilmentDuration = this.AilmentDuration;
            }

            return message;
        }

        protected virtual string CheckIfMPIsEnough(IUnit user)
        {
            if (this.MPCost > user.MP)
            {
                string message = string.Format("You do not have enough MP to use {0}.", this.Name);

                return message;
            }

            user.MP -= this.MPCost;

            return string.Empty;
        }
    }
}