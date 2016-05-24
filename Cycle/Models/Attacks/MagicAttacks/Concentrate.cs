namespace Cycle.Models.Attacks.MagicAttacks
{
    using Interfaces;

    public class Concentrate : AccuracyBuffSpell
    {
        public static IMagicAttack Instance = new Concentrate();

        private const string ConcentrateName = "Concentrate";
        private const string ConcentrateDescription = "Increase accuracy.";
        private const string ConcentrateTextAmount = "rose";
        private const int ConcentrateMPCost = 5;
        private const int ConcentrateBuffAmount = 20;

        private Concentrate()
            : base(ConcentrateName, ConcentrateMPCost, ConcentrateBuffAmount, ConcentrateTextAmount)
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
                    ConcentrateDescription
                };

                return description;
            }
        }
    }
}