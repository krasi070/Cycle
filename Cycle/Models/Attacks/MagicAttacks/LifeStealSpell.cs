namespace Cycle.Models.Attacks.MagicAttacks
{
    using System;
    using Interfaces;

    public abstract class LifeStealSpell : MagicAttack
    {
        protected LifeStealSpell(string name, int mpCost, int damage, int accuracy)
            : base(name,  mpCost, damage, accuracy)
        {
        }

        public override string[] CastMagic(IUnit user, IUnit target)
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

            int attackDamage = (user.Damage + this.Damage) / 2;
            int attackAccuracy = (user.Accuracy + this.Accuracy) / 2;

            bool hitTarget = Random.Next(1, 101) <= attackAccuracy;
            if (hitTarget)
            {
                bool isCritical = Random.Next(1, 101) <= user.BattleCriticalChance;
                if (isCritical)
                {
                    attackDamage *= (attackDamage * 2) - (attackDamage / 4);
                    message[0] += " Critical hit!!!";
                }

                int damageTaken = attackDamage - target.Defense;
                int lifeSteal = Math.Min(Math.Max(1, damageTaken), target.HP);
                target.HP -= damageTaken;
                user.HP += lifeSteal;

                message[1] = string.Format("{0} regained {1} HP.", user.Name, lifeSteal);
            }
            else
            {
                message[1] = string.Format("But {0} missed.", user.Name);
            }

            return message;
        }
    }
}