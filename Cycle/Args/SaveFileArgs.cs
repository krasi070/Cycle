namespace Cycle.Args
{
    public class SaveFileArgs
    {
        public SaveFileArgs(bool isUsed)
            : this(isUsed, null, 0)
        {
        }

        public SaveFileArgs(bool isUsed, string playerName, int playerLevel)
        {
            this.IsUsed = isUsed;
            this.PlayerName = playerName;
            this.PlayerLevel = playerLevel;
        }

        public bool IsUsed { get; set; }

        public string PlayerName { get; set; }

        public int PlayerLevel { get; set; }
    }
}
