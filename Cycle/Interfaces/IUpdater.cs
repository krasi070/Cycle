namespace Cycle.Interfaces
{
    public interface IUpdater
    {
        void UpdateMonsterStatus(IUnit unit);

        void UpdatePointsInIncreaseScreen(IPlayer player);

        void UpdateHPBarInIncreaseScreen(IPlayer player);

        void UpdateMPBarInIncreaseScreen(IPlayer player);

        void UpdateAttackBarInIncreaseScreen(IPlayer player);

        void UpdateDefenseBarInIncreaseScreen(IPlayer player);

        void UpdateAccuracyBarInIncreaseScreen(IPlayer player);

        void UpdateCritChanceBarInIncreaseScreen(IPlayer player);

        void UpdatePlayerStatus(IPlayer player);
    }
}