namespace Cycle.Models.AIs
{
    using System.Linq;
    using Interfaces;
    using Attacks.MagicAttacks;

    public class SimpleAI : AI
    {
        public static IArtificialIntelligence Instance = new SimpleAI();

        public override string[] Act(IUnit aiUser, IUnit target)
        {
            int randomPercentage = Random.Next(1, 101);
            if (randomPercentage <= 80)
            {
                return this.TryNormalAttack(aiUser, target);
            }
            else
            {
                return this.TryMagicAttack(aiUser, target);
            }
        }

        private string[] TryNormalAttack(IUnit aiUser, IUnit target)
        {
            string[] message = new string[6];
            int maxKickback = 0;
            INormalAttack chosenAttack = aiUser.NormalAttacks[0];
            foreach (var normalAttack in aiUser.NormalAttacks)
            {
                if (normalAttack.Kickback >= maxKickback && normalAttack.Kickback < aiUser.HP)
                {
                    maxKickback = normalAttack.Kickback;
                    chosenAttack = normalAttack;
                }
            }

            if (chosenAttack.Kickback >= aiUser.HP)
            {
                var magicAttacks = aiUser.MagicAttacks
                    .Where(m => m is BuffMagic || m is DebuffMagic)
                    .Where(m => m.MPCost <= aiUser.MP)
                    .ToList();

                if (magicAttacks.Count > 0)
                {
                    IMagicAttack randomMagicAttack = magicAttacks[Random.Next(0, magicAttacks.Count)];
                    message = randomMagicAttack.CastMagic(aiUser, target);
                }
                else
                {
                    message = chosenAttack.ExecuteAttack(aiUser, target);
                }
            }
            else
            {
                message = chosenAttack.ExecuteAttack(aiUser, target);
            }

            return message;
        }

        private string[] TryMagicAttack(IUnit aiUser, IUnit target)
        {
            string[] message = new string[6];
            var magicAttacks = aiUser.MagicAttacks
                        .Where(m => m is BuffMagic || m is DebuffMagic)
                        .Where(m => m.MPCost <= aiUser.MP)
                        .ToList();

            if (magicAttacks.Count > 0)
            {
                IMagicAttack randomMagicAttack = magicAttacks[Random.Next(0, magicAttacks.Count)];
                message = randomMagicAttack.CastMagic(aiUser, target);
            }
            else
            {
                INormalAttack randomAttack =
                    aiUser.NormalAttacks.FirstOrDefault(a => a.Kickback < aiUser.HP);
                if (randomAttack == null)
                {
                    message =
                        aiUser.NormalAttacks[Random.Next(0, aiUser.NormalAttacks.Count)].ExecuteAttack(aiUser, target);
                }
                else
                {
                    message = randomAttack.ExecuteAttack(aiUser, target);
                }
            }

            return message;
        }
    }
}