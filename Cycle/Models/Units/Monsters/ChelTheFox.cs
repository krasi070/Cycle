namespace Cycle.Models.Units.Monsters
{
    using System;
    using System.Collections.Generic;
    using GameFrames;
    using Interfaces;

    public class ChelTheFox : Monster
    {
        private const string ChelTheFoxName = "Chel The Fox";
        private const int ChelTheFoxPointsReward = 3;

        public ChelTheFox(int x, int y, int level)
            : base(ChelTheFoxName, x, y, 0, 0, 0, 0, 0, 0, 0, PutNormalAttacks(),
                PutMagicAttack(), ChelTheFoxPointsReward, MakeInBattleSprite())
        {
            this.SetStatsForAppropriateLevel();
        }

        public override void Draw()
        {
            if (this.IsInBattle)
            {
                int startWidth = MainFrame.StartWidth + 22;
                int startHeight = MainFrame.StartHeight + 3;
                for (int i = startHeight; i < startHeight + this.InBattleSprite.Length; i++)
                {
                    Console.SetCursorPosition(startWidth, i);
                    Console.Write(this.InBattleSprite[i - startHeight]);
                }
            }
            else
            {
                Console.SetCursorPosition(this.X, this.Y);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write(this.OutOfBattleSprite);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static string[] MakeInBattleSprite()
        {
            string[] sprite =
            {
                " /\\   /\\",
                "//\\_//\\     ____",
                "\\_     _/    /   /",
                " / * * \\    /^^^]",
                " \\_\\o/_/    [   ]",
                "  /   \\_    [   /",
                "  \\     \\_  /  /",
                "  [ [  /  \\/ _/",
                " _[ [  \\  /_/"
            };

            return sprite;
        }

        private static IList<INormalAttack> PutNormalAttacks()
        {
            var normalAttacks = new List<INormalAttack>()
            {

            };

            return normalAttacks;
        }

        private static IList<IMagicAttack> PutMagicAttack()
        {
            var magicAttacks = new List<IMagicAttack>()
            {

            };

            return magicAttacks;
        }

        protected override void SetStatsForAppropriateLevel()
        {
            throw new System.NotImplementedException();
        }
    }
}