namespace Cycle.Models.Attacks.MagicAttacks
{
    using Interfaces;

    public class Spectacle : AccuracyBuffSpell
    {
        public static IMagicAttack Instance = new Spectacle();

        private const string SpectacleName = "Spectacle";
        private const string SpectacleDescription = "Slightly increase accuracy.";
        private const string SpectacleTextAmount = "rose slightly";
        private const int SpectacleMPCost = 3;
        private const int SpectacleBuffAmount = 8;

        private Spectacle() 
            : base(SpectacleName, SpectacleMPCost, SpectacleBuffAmount, SpectacleTextAmount)
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
                    SpectacleDescription
                };

                return description;
            }
        }
    }
}