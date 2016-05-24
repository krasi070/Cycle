namespace Cycle.Models.Attacks.MagicAttacks
{
    using Interfaces;

    public class LifeSteal : LifeStealSpell
    {
        public static IMagicAttack Instance = new LifeSteal();

        private const string LifeStealName = "Life Steal";

        private const string LifeStealDescription =
            "Steals a small amount of the enemy's health and adds it to your health.";
        private const int LifeStealMPCost = 9;
        private const int LifeStealDamage = 22;
        private const int LifeStealAccuracy = 95;

        private LifeSteal()
            : base(LifeStealName, LifeStealMPCost, LifeStealDamage, LifeStealAccuracy)
        {
        }

        public override string[] Description
        {
            get
            {
                string[] description = 
                {
                    base.Description[0],
                    base.Description[1],
                    base.Description[2],
                    LifeStealDescription
                };

                return description;
            }
        }
    }
}