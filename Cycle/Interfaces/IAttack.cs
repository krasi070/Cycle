namespace Cycle.Interfaces
{
    public interface IAttack : IDamageDoable, IAccuracyUsable
    {
        string Name { get; }

        string[] Description { get; }
    }
}
