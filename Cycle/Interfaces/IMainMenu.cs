namespace Cycle.Interfaces
{
    using Enums;

    public interface IMainMenu
    {
        Option CurrentOption { get; set; }

        void DisplayTitle();

        void DisplayOptions();

        void LightUpNewGameButton();

        void LightUpLoadGameButton();

        void LightUpQuitButton();
    }
}
