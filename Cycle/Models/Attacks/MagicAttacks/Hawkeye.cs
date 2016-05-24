namespace Cycle.Models.Attacks.MagicAttacks
{
    using Interfaces;

    public class Hawkeye : AccuracyBuffSpell
    {
        public static IMagicAttack Instance = new Hawkeye();

        private const string HawkeyeName = "Hawkeye";
        private const string HawkeyeDescription = "Greatly increase accuracy";
        private const string HawkeyeTextAmount = "rose greatly";
        private const int HawkeyeMPCost = 10;
        private const int HawkeyeBuffAmount = 35;

        private Hawkeye()
            : base(HawkeyeName, HawkeyeMPCost, HawkeyeBuffAmount, HawkeyeTextAmount)
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
                    HawkeyeDescription
                };

                return description;
            }
        }
    }
}