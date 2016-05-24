namespace Cycle.Models.Attacks.MagicAttacks
{
    using Interfaces;

    public class SelfRegeneration : HealMagic
    {
        public static IMagicAttack Instance = new SelfRegeneration();

        private const string SelfRegenerationName = "Self Regen";
        private const string SelfRegenerationDescription = "Regain all health.";
        private const int SelfRegenerationMPCost = 22;
        private const int SelfRegenerationRegeneratedHealth = 1000;

        private SelfRegeneration()
            : base(
            SelfRegenerationName,
            SelfRegenerationMPCost,
            SelfRegenerationRegeneratedHealth)
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
                    SelfRegenerationDescription
                };

                return description;
            }
        }
    }
}