namespace Cycle.Interfaces
{
    public interface IAttackable
    {
        int MaxHP { get; set; }

        // Hit(Health) Points
        int HP { get; set; }

        bool IsAlive { get; }
    }
}
