namespace Cycle.Interfaces
{
    public interface IDefendable
    {
        int Defense { get; }

        int MaxDefense { get; }

        int BattleDefense { get; set; }
    }
}
