namespace Cycle.Interfaces
{
    public interface ICritHavable
    {
        int CriticalChance { get; }

        int BattleCriticalChance { get; set; }
    }
}
