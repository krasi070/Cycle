namespace Cycle.Interfaces
{
    public interface INormalAttack : IAttack
    {
        int Kickback { get; }

        string[] ExecuteAttack(IUnit user, IUnit target);
    }
}
