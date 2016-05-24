namespace Cycle.Models.Attacks.MagicAttacks
{
    using Interfaces;

    public class GigaPunch : AttackBuffSpell
    {
        public static IMagicAttack Instance = new GigaPunch();

        private const string GigaPunchName = "Giga Punch";
        private const string GigaPunchDescription = "Greatly increase damage.";
        private const string GigaPunchTextAmount = "rose greatly";
        private const int GigaPunchMPCost = 12;
        private const int GigaPunchDamageBuffAmount = 80;

        private GigaPunch()
            : base(GigaPunchName, GigaPunchMPCost, GigaPunchDamageBuffAmount, GigaPunchTextAmount)
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
                    GigaPunchDescription
                };

                return description;
            }
        }
    }
}