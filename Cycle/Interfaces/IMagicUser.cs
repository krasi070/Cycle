namespace Cycle.Interfaces
{
    using System.Collections.Generic;

    public interface IMagicUser
    {
        // Magic(Mana) Points
        int MP { get; set; }

        int MaxMP { get; set; }

        IList<IMagicAttack> MagicAttacks { get; }

        void AddMagicAttack(IMagicAttack magicAttack);

        void RemoveMagicAttack(IMagicAttack magicAttack);

        void ReplaceMagicAttack(IMagicAttack attackToRemove, IMagicAttack attackToAdd);
    }
}
