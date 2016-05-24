namespace Cycle.Models.Attacks.MagicAttacks
{
    using Interfaces;

    public class Harden : DefenseBuffSpell
    {
        public static IMagicAttack Instance = new Harden();

        private const string HardenName = "Harden";
        private const string HardenDescription = "Slightly increase defense.";
        private const string HardenTextAmount = "rose slightly";
        private const int HardenMPCost = 3;
        private const int HardenDefenseBuffAmount = 20;

        private Harden()
            : base(HardenName, HardenMPCost, HardenDefenseBuffAmount, HardenTextAmount)
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
                    HardenDescription
                };

                return description;
            }
        }
    }
}