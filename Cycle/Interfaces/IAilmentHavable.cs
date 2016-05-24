namespace Cycle.Interfaces
{
    using Enums;

    public interface IAilmentHavable
    {
        StatusAilment Ailment { get; set; }

        int AilmentDuration { get; set; }

        bool CanActThisTurn { get; set; }

        bool CanUsePhysicalAttack { get; set; }

        bool CanUseMagic { get; set; }

        void ExecuteAilment();
    }
}
