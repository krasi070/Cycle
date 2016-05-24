namespace Cycle.Interfaces
{
    public interface IMainFrame : IFrame
    {
        void ShowStatus(IPlayer player, IOptionsFrame optionsFrame);

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
