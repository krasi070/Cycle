namespace Cycle.Models.Attacks.MagicAttacks
{
    using Interfaces;

    public class BulletPunch : AttackBuffSpell
    {
        public static IMagicAttack Instance = new BulletPunch();

        private const string BulletPunchName = "Bullet Punch";
        private const string BulletPunchDescription = "Increase damage.";
        private const string BulletPunchTextAmount = "rose";
        private const int BulletPunchMPCost = 5;
        private const int BulletPunchDamageBuffAmount = 25;

        private BulletPunch()
            : base(BulletPunchName, BulletPunchMPCost, BulletPunchDamageBuffAmount, BulletPunchTextAmount)
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
                    BulletPunchDescription
                };

                return description;
            }
        }
    }
}