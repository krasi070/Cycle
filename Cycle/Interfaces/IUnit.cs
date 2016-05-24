namespace Cycle.Interfaces
{
    public interface IUnit : IAttackable, IAttacker, IAccuracyHavable, ICritHavable, IDefendable,
        IGameObject, ILevelUpable, IMagicUser, IAilmentHavable, IDrawable, IClearable
    {
        bool IsInBattle { get; set; }

        string SubjectPronoun { get; }

        string ReflexivePronoun { get; }
    }
}
