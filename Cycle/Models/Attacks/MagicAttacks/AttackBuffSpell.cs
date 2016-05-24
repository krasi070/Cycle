namespace Cycle.Models.Attacks.MagicAttacks
{
    using Interfaces;

    public abstract class AttackBuffSpell : BuffMagic
    {
        protected AttackBuffSpell(string name, int mpCost, int buffAmount, string textAmount) 
            : base(name, mpCost, buffAmount, textAmount)
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

            message[0] = string.Format("{0} used {1}.", user.Name, this.Name);

            int attackAccuracy = (user.Accuracy + this.Accuracy) / 2;
            bool hitTarget = Random.Next(1, 101) <= attackAccuracy;
            if (hitTarget)
            {
                int buffedAmount = user.BattleDamage;
                user.BattleDamage += this.BuffAmount;
                buffedAmount = user.BattleDamage - buffedAmount;
                if (buffedAmount > 0)
                {
                    message[1] = string.Format("{0}'s damage {1}.", this.Name, this.TextAmount);
                }
                else
                {
                    message[1] = string.Format("{0} can't increase his damage anymore.", this.Name);
                }
            }
            else
            {
                message[1] = string.Format("But {0} messed up and the spell failed.", user.Name);
            }

            return message;
        }
    }
}