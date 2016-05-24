namespace Cycle.Models.Attacks.NormalAttacks
{
    using Interfaces;

    public class Punch : NormalAttack
    {
        public static INormalAttack Instance = new Punch();

        private const string PunchName = "Punch";
        private const int PunchDamage = 44;
        private const int PunchAccuracy = 82;
        private const int PunchKickback = 1;

        private Punch()
            : base(PunchName, PunchDamage, PunchAccuracy, PunchKickback)
        { 
        }
    }
}
