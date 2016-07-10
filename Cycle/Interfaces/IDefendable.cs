namespace Cycle.Interfaces
{
    public interface IDefendable
    {
        int Defense { get; }

        int MaxDefense { get; set; }

        int BattleDefense { get; set; }
    }
}
