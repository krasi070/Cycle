namespace Cycle.Models.Attacks.MagicAttacks
{
    using Interfaces;

    public class Bloodsucker : LifeStealSpell
    {
        public static IMagicAttack Instance = new Bloodsucker();

        private const string BloodsuckerName = "Bloodsucker";
        private const string BloodsuckerDescription = "Steals some of the enemy's health and adds it to your health.";
        private const int BloodsuckerMPCost = 20;
        private const int BloodsuckerDamage = 60;
        private const int BloodsuckerAccuracy = 95;

        private Bloodsucker()
            : base(BloodsuckerName, BloodsuckerMPCost, BloodsuckerDamage, BloodsuckerAccuracy)
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
                    BloodsuckerDescription
                };

                return description;
            }
        }
    }
}