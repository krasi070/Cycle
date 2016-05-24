namespace Cycle.Interfaces
{
    using Args;

    public interface INewGameOptions
    {
        void PrintMessage();

        NewGameOptionsArgs GetGameOptionsArgs();
    }
}
