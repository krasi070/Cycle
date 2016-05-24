namespace Cycle.Args
{
    public class MonsterArgs
    {
        public MonsterArgs(string name, int level)
        {
            this.Name = name;
            this.Level = level;
        }

        public string Name { get; set; }

        public int Level { get; set; }
    }
}
