namespace Cycle.Models.Attacks.MagicAttacks
{
    using System;

    public abstract class DebuffMagic : MagicAttack
    {
        private int debuffAmount;
        private string textAmount;

        protected DebuffMagic(string name, int mpCost, int damage, int accuracy, int debuffAmount, string textAmount)
            : base(name, mpCost, damage, accuracy)
        {
            this.DebuffAmount = debuffAmount;
            this.TextAmount = textAmount;
        }

        public int DebuffAmount
        {
            get
            {
                return this.debuffAmount;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("BuffAmount", "Buff amount must be positive.");
                }

                this.debuffAmount = value;
            }
        }

        public string TextAmount
        {
            get
            {
                return this.textAmount;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("TextAmount", "Text amount cannot be empty or null.");
                }

                this.textAmount = value;
            }
        }
    }
}