namespace Cycle.Models.Attacks.MagicAttacks
{
    using Interfaces;

    public class WallMaker : DefenseBuffSpell
    {
        public static IMagicAttack Instance = new WallMaker();

        private const string WallMakerName = "Wall Maker";
        private const string WallMakerDescription = "Increase defense.";
        private const string WallMakerTextAmount = "rose";
        private const int WallMakerMPCost = 9;
        private const int WallMakerDefenseBuffAmount = 60;

        private WallMaker()
            : base(WallMakerName, WallMakerMPCost, WallMakerDefenseBuffAmount, WallMakerTextAmount)
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
                    WallMakerDescription
                };

                return description;
            }
        }
    }
}