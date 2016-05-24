namespace Cycle.Interfaces
{
    public interface IAccuracyHavable : IAccuracyUsable
    {
        int BattleAccuracy { get; set; }

        int MaxAccuracy { get; }
    }
}
