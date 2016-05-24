namespace Cycle.Interfaces
{
    using Enums;

    public interface IMagicAttack : IAttack
    {
        StatusAilment Ailment { get; }

        int AilmentDuration { get; }
        
        int MPCost { get; }

        string[] CastMagic(IUnit user, IUnit target);
    }
}
