namespace Cycle.Models.Attacks.NormalAttacks
{
    using System;
    using Interfaces;

    public abstract class NormalAttack : Attack, INormalAttack
    {
        private int kickback;

        protected NormalAttack(string name, int damage, int accuracy, int kickback)
            : base(name, damage, accuracy)
        {
            this.Kickback = kickback;
        }

        public int Kickback
        {
            get
            {
                return this.kickback;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Kickback", "Kickback cannot be negative.");
                }

                this.kickback = value;
            }
        }

        public virtual string[] ExecuteAttack(IUnit user, IUnit target)
        {
            string[] message = new string[2];
            message[0] = string.Format(
                        "{0} used {1} on {2}.",
                        user.Name,
                        this.Name,
                        target.Name);

            int attackAccuracy = (user.Accuracy + this.Accuracy) / 2;
            int attackDamage = (user.Damage + this.Damage) / 2;

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
                user.HP -= this.Kickback;

                if (this.Kickback > 0)
                {
                    message[1] = string.Format(
                        "But {0} lost {1} HP because of the kickback.",
                        user.SubjectPronoun.ToLower(),
                        this.Kickback);
                }

                return message;
            }

            message[1] = string.Format("But {0} missed.", user.Name);

            return message;
        }
    }
}
