namespace Cycle.Interfaces
{
    using System;
    using Enums;

    public interface IMenuHandler
    {
        void ChooseBattleOption(ConsoleKey pressedKey, IPlayer player);

        void MoveInStatusOption(ConsoleKey pressedKey, IPlayer player);

        void ChooseNormalAttack(ConsoleKey pressedKey, IPlayer player);

        void UpdateMonsterStatus(IUnit unit);

        void ChooseMagicAttack(ConsoleKey pressedKey, IPlayer player);

        void DisplayBattleOptions();

        void DisplayBattleNormalAttacks(IPlayer player);

        void DisplayBattleMagicAttacks(IPlayer player);

        void DisplayStatusScreen(IPlayer player);

        void DisplayMagicToRob(IPlayer player, IUnit monster);

        void ShowMonster(IMonster monster);

        void ShowArea(IArea area, IPlayer player, IMonster monster = null);

        void UpdatePlayerStatus(IPlayer player);

        void WriteText(params string[] text);

        void WriteTextSlowly(int timeInMilliseconds, params string[] text);

        void ChooseMagicToRob(ConsoleKey pressedKey, IPlayer player, IUnit monster);

        void DisplayYesAndNo();

        void ChooseYesOrNo(ConsoleKey pressedKey, IPlayer player);

        void ShowMainMenu();

        Option ChooseMainMenuOption(ConsoleKey pressedKey);

        void DisplayGameFrame();

        void DisplayPlayerStatusFrame();

        void DisplayOptionsBox();
    }
}