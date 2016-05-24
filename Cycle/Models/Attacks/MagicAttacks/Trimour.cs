namespace Cycle.Models.Attacks.MagicAttacks
{
    using Interfaces;

    public class Trimour : DefenseBuffSpell
    {
        public static IMagicAttack Instance = new Trimour();

        private const string TrimourName = "Trimourr";
        private const string TrimourDescription = "Greatly increase defense.";
        private const string TrimourTextAmount = "greatly rose";
        private const int TrimourMPCost = 15;
        private const int TrimourDefenseBuffAmount = 115;

        private Trimour()
            : base(TrimourName, TrimourMPCost, TrimourDefenseBuffAmount, TrimourTextAmount)
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
                    TrimourDescription
                };

                return description;
            }
        }
    }
}