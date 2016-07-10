namespace Cycle.Interfaces
{
    using System.Collections.Generic;

    public interface IAttacker : IDamageDoable
    {
        int MaxDamage { get; set; }

        int BattleDamage { get; set; }

        IList<INormalAttack> NormalAttacks { get; set; }

        void AddNormalAttack(INormalAttack normalAttack);

        void RemoveNormalAttack(INormalAttack normalAttack);

        void ReplaceNormalAttack(INormalAttack attackToRemove, INormalAttack attackToAdd);
    }
}
