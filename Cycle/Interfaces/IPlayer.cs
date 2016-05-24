namespace Cycle.Interfaces
{
    using Enums;

    public interface IPlayer : IUnit, IMagicStealer, IMovable, IPointHavable
    {
        Option Option { get; set; }
    }
}
