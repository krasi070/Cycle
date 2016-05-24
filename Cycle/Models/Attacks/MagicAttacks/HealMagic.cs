namespace Cycle.Models.Attacks.MagicAttacks
{
    using System;

    public abstract class HealMagic : MagicAttack
    {
        private const int HealthRegenerationAccuracy = 100;

        private int regeneratedHealth;

        protected HealMagic(string name, int mpCost, int regeneratedHealth)
            : base(name, mpCost, 0, HealthRegenerationAccuracy)
        {
            this.RegeneratedHealth = regeneratedHealth;
        }

        public int RegeneratedHealth
        {
            get
            {
                return this.regeneratedHealth;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "RegeneratedHealth", 
                        "Regenerated health cannot be negative.");
                }

                this.regeneratedHealth = value;
            }
        }

        public override string[] CastMagic(Interfaces.IUnit user, Interfaces.IUnit target)
        {
            string[] message = new string[2];
            message[0] = this.CheckIfMPIsEnough(user);
            if (message[0] != string.Empty)
            {
                return message;
            }

            message[0] = string.Format("{0} used {1}.", user.Name, this.Name);

            int magicAccuracy = (user.Accuracy + this.Accuracy) / 2;
            bool castCorrectly = Random.Next(1, 101) <= magicAccuracy;
            if (castCorrectly)
            {
                user.HP += this.RegeneratedHealth;
                message[1] = string.Format("{0} regained {1} HP.", user.Name, this.RegeneratedHealth);
            }
            else
            {
                message[1] = string.Format("But {0} messed up and the spell failed.", user.Name);
            }

            return message;
        }
    }
}