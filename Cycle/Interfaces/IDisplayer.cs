namespace Cycle.Interfaces
{
    public interface IDisplayer
    {
        void DisplayBattleOptions();

        void DisplayBattleNormalAttacks(IPlayer player);

        void DisplayBattleMagicAttacks(IPlayer player);

        void DisplayStatusScreen(IPlayer player);

        void DisplayIncreaseStatusScreen(IPlayer player);

        void DisplayMagicToRob(IPlayer player, IUnit monster);

        void DisplayMonster(IMonster monster);

        void DisplayArea(IArea area, IPlayer player, IMonster monster = null);

        void DisplayYesAndNo();

        void DisplayMainMenu();

        void DisplayGameFrame();

        void DisplayPlayerStatusFrame();

        void DisplayOptionsBox();
    }
}