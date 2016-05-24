namespace Cycle.Models.Attacks.NormalAttacks
{
    using Interfaces;

    public class Tackle : NormalAttack
    {
        public static INormalAttack Instance = new Tackle();

        private const string TackleName = "Tackle";
        private const int TackleDamage = 25;
        private const int TackleAccuracy = 85;

        private Tackle()
            : base(TackleName, TackleDamage, TackleAccuracy, 0)
        {
        }
    }
}
