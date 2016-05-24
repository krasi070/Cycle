namespace Cycle.Models.Attacks.NormalAttacks
{
    using Interfaces;

    public class FierceBite : NormalAttack
    {
        public static INormalAttack Instance = new FierceBite();

        private const string FierceBiteName = "Fierce Bite";
        private const int FierceBiteDamage = 50;
        private const int FierceBiteAccuracy = 75;

        private FierceBite()
            : base(FierceBiteName, FierceBiteDamage, FierceBiteAccuracy, 0)
        {       
        }
    }
}
