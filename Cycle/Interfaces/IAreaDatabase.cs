namespace Cycle.Interfaces
{
    public interface IAreaDatabase
    {
        IArea GetAreaByName(string name);

        IArea GetRandomAreaWithDownEntrance();

        IArea GetRandomAreaWithUpEntrance();

        IArea GetRandomAreaWithLeftEntrance();

        IArea GetRandomAreaWithRightEntrance();
    }
}