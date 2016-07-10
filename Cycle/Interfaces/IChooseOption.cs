namespace Cycle.Interfaces
{
    using Enums;

    public interface IChooseOption
    {
        Option ChooseBattleOption();

        Option ChooseStatusOption(IPlayer player);

        Option ChooseNormalAttack(IPlayer player);

        Option ChooseMagicAttack(IPlayer player);

        Option ChooseOptionInStatusIncreaseScreen(IPlayer player, Option currOption = Option.First);

        Option ChooseMagicToRob(IUnit monster);

        Option ChooseYesOrNo();

        Option ChooseMainMenuOption();
    }
}