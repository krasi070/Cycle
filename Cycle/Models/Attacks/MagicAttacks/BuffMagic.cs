namespace Cycle.Models.Attacks.MagicAttacks
{
    using System;

    public abstract class BuffMagic : MagicAttack
    {
        private const int BuffMagicAccuracy = 100;

        private int buffAmount;
        private string textAmount;

        protected BuffMagic(string name, int mpCost, int buffAmount, string textAmount)
            : base(name, mpCost, 0, BuffMagicAccuracy)
        {
            this.BuffAmount = buffAmount;
            this.TextAmount = textAmount;
        }

        public int BuffAmount
        {
            get
            {
                return this.buffAmount;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("BuffAmount", "Buff amount must be positive.");
                }

                this.buffAmount = value;
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