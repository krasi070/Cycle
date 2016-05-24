namespace Cycle.Interfaces
{
    public interface IAttackable
    {
        int MaxHP { get; }

        // Hit(Health) Points
        int HP { get; set; }

        bool IsAlive { get; }
    }
}
