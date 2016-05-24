namespace Cycle.Models.Attacks.MagicAttacks
{
    using Interfaces;

    public class ZoomPunch : AttackBuffSpell
    {
        public static IMagicAttack Instance = new ZoomPunch();

        private const string ZoomPunchName = "Zoom Punch";
        private const string ZoomPunchDescription = "Slightly increase damage.";
        private const string ZoomPunchTextAmount = "rose slightly";
        private const int ZoomPunchMPCost = 3;
        private const int ZoomPunchDamageBuffAmount = 10;

        private ZoomPunch()
            : base(ZoomPunchName, ZoomPunchMPCost, ZoomPunchDamageBuffAmount, ZoomPunchTextAmount)
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
                    ZoomPunchDescription
                };

                return description;
            }
        }
    }
}