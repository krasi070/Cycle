namespace Cycle.Models.Attacks
{
    using System;
    using Interfaces;

    public abstract class Attack : IAttack
    {
        private string name;
        private int damage;
        private int accuracy;

        protected Attack(string name, int damage, int accuracy)
        {
            this.Name = name;
            this.Damage = damage;
            this.Accuracy = accuracy;
            Random = new Random();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(
                        "Name",
                        "Attack name cannot be null and cannot conatin only whitespaces.");
                }

                this.name = value;
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Damage", "Damage cannot be negative.");
                }

                this.damage = value;
            }
        }

        public int Accuracy
        {
            get
            {
                return this.accuracy;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Accuracy", "Accuracy cannot be negative.");
                }

                this.accuracy = value;
            }
        }

        public virtual string[] Description
        {
            get
            {
                string[] description = 
                {
                    "Damage: " + this.Damage,
                    "Accuracy: " + this.Accuracy,
                };

                return description;
            }
        }

        protected static Random Random { get; set; }
    }
}