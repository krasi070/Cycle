namespace Cycle.Models.Attacks.MagicAttacks
{
    using Interfaces;

    public class SunEnergy : HealMagic
    {
        public static IMagicAttack Instance = new SunEnergy();

        private const string SunEnergyName = "Sun Energy";
        private const string SunEnergyDescription = "Regain a huge amount of health.";
        private const int SunEnergyMPCost = 16;
        private const int SunEnergyRegeneratedHealth = 100;

        private SunEnergy()
            : base(SunEnergyName, SunEnergyMPCost, SunEnergyRegeneratedHealth)
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
                    SunEnergyDescription
                };

                return description;
            }
        }
    }
}