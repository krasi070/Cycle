namespace Cycle.Interfaces
{
    public interface IMonster : IUnit
    {
        int PointsReward { get; }

        string OutOfBattleSprite { get; }

        string[] InBattleSprite { get; } 
    }
}
