namespace Cycle.Interfaces
{
    public interface IMonsterDatabase
    {
        void RemoveMonster(IMonster monster);

        IMonster GetMonsterByNameAndLevel(string name, int level);

        IMonster GetRandomMonster();

        IMonster GetRandomMonsterByLevel(int level);
    }
}
