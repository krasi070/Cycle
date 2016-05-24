namespace Cycle.Models.Attacks.MagicAttacks
{
    using Interfaces;

    public class MrInjection : HealMagic
    {
        public static IMagicAttack Instance = new MrInjection();

        private const string MrInjectionName = "Mr. Injection";
        private const string MrInjectionDescription = "Regain some health.";
        private const int MrInjectionMPCost = 10;
        private const int MrInjectionRegeneratedHealth = 50;

        private MrInjection()
            : base(
            MrInjectionName,
            MrInjectionMPCost,
            MrInjectionRegeneratedHealth)
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
                    MrInjectionDescription
                };

                return description;
            }
        }
    }
}