namespace Cycle.Interfaces
{
    using System;

    public interface IMainFrame : IFrame
    {
        void ShowStatus(IPlayer player, IOptionsFrame optionsFrame);

        void ShowIncreaseStatusScreen(IPlayer player);

        void UpdatePointCounter(IPlayer player);

        void UpdateHPBar(IPlayer player, ConsoleColor color = ConsoleColor.White, bool showNewValue = false);

        void UpdateMPBar(IPlayer player, ConsoleColor color = ConsoleColor.White, bool showNewValue = false);

        void UpdateAttackBar(IPlayer player, ConsoleColor color = ConsoleColor.White, bool showNewValue = false);

        void UpdateDefenseBar(IPlayer player, ConsoleColor color = ConsoleColor.White, bool showNewValue = false);

        void UpdateAccuracyBar(IPlayer player, ConsoleColor color = ConsoleColor.White, bool showNewValue = false);

        void UpdateCriticalChanceBar(IPlayer player, ConsoleColor color = ConsoleColor.White, bool showNewValue = false);

        void LightUpHPBar(IPlayer player);

        void LightUpMPBar(IPlayer player);

        void LightUpAttackBar(IPlayer player);

        void LightUpDefenseBar(IPlayer player);

        void LightUpAccuracyBar(IPlayer player);

        void LightUpCriticalChanceBar(IPlayer player);

        void LightUpBackButtonInIncreaseStatusScreen(IPlayer player);

        void LightUpBackButton(IPlayer player);

        void LightUpFirstNormalAttack(IPlayer player);

        void LightUpSecondNormalAttack(IPlayer player);

        void LightUpThirdNormalAttack(IPlayer player);

        void LightUpFourthNormalAttack(IPlayer player);

        void LightUpFirstMagicAttack(IPlayer player);

        void LightUpSecondMagicAttack(IPlayer player);

        void LightUpThirdMagicAttack(IPlayer player);

        void LightUpFourthMagicAttack(IPlayer player);

        void LightUpFifthMagicAttack(IPlayer player);

        void LightUpSixthMagicAttack(IPlayer player);

        void ShowMagicChoiceMenu(IUnit monster);

        void LightUpFirstMagicToRob(IUnit monster);

        void LightUpSecondMagicToRob(IUnit monster);

        void LightUpThirdMagicToRob(IUnit monster);

        void LightUpFourthMagicToRob(IUnit monster);

        void LightUpFifthMagicToRob(IUnit monster);

        void LightUpSixthMagicToRob(IUnit monster);
    }
}