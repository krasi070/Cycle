namespace Cycle.Interfaces
{
    public interface IOptionsFrame : IFrame
    {
        void DisplayOptions();

        void LightUpAttackOption();

        void LightUpMagicOption();

        void LightUpMagicRobberOption();

        void LightUpStatusOption();

        void WriteText(params string[] text);

        void WriteTextSlowly(int timeInMilliseconds, params string[] text);

        void DisplayNormalAttackOptions(IPlayer player);

        void LightUpFirstNormalAttack(IPlayer player);

        void LightUpSecondNormalAttack(IPlayer player);

        void LightUpThirdNormalAttack(IPlayer player);

        void LightUpFourthNormalAttack(IPlayer player);

        void LightUpBattleNormalBackButton(IPlayer player);

        void LightUpBattleMagicBackButton(IPlayer player);

        void DisplayMagicAttackOptions(IPlayer player);

        void LightUpFirstMagicAttack(IPlayer player);
        
        void LightUpSecondMagicAttack(IPlayer player);
        
        void LightUpThirdMagicAttack(IPlayer player);
        
        void LightUpFourthMagicAttack(IPlayer player);
        
        void LightUpFifthMagicAttack(IPlayer player);

        void LightUpSixthMagicAttack(IPlayer player);

        void DisplayBinaryChoice();

        void LightUpNoButton();

        void LightUpYesButton();
    }
}
