namespace Cycle.Interfaces
{
    public interface IMenuHandler : IUpdater, IDisplayer, IChooseOption
    {
        void WriteText(params string[] text);

        void WriteTextSlowly(int timeInMilliseconds, params string[] text);
    }
}