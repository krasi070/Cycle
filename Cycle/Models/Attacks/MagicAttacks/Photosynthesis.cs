namespace Cycle.Models.Attacks.MagicAttacks
{
    using Interfaces;

    public class Photosynthesis : HealMagic
    {
        public static IMagicAttack Instance = new Photosynthesis();

        private const string PhotosynthesisName = "Photosynthesis";
        private const string PhotosynthesisDescription = "Regain a small amount of health.";
        private const int PhotosynthesisMPCost = 4;
        private const int PhotosynthesisRegeneratedHealth = 20;

        private Photosynthesis()
            : base(
            PhotosynthesisName,
            PhotosynthesisMPCost,
            PhotosynthesisRegeneratedHealth)
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
                    PhotosynthesisDescription
                };

                return description;
            }
        }
    }
}