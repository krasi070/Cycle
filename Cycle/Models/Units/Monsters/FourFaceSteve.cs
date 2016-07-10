namespace Cycle.Models.Units.Monsters
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using GameFrames;

    public class FourFaceSteve : Monster
    {
        private const string FourFaceSteveName = "Four Face Steve";
        private const int FourFaceSteveHealth = 50;
        private const int FourFaceSteveMP = 24;
        private const int FourFaceSteveDamage = 10;
        private const int FourFaceSteveDefense = 9;
        private const int FourFaceSteveAccuracy = 88;
        private const int FourFaceSteveCriticalChance = 6;
        private const int FourFaceSteveEXPReward = 25;

        // TODO: Add specific normal and magic attacks to FourFaceSteve
        public FourFaceSteve(
            int x,
            int y,
            int level,
            IList<INormalAttack> normalAttacks,
            IList<IMagicAttack> magicAttacks)
            : base(
                FourFaceSteveName,
                x,
                y,
                FourFaceSteveHealth,
                FourFaceSteveMP,
                FourFaceSteveDamage,
                FourFaceSteveDefense,
                FourFaceSteveAccuracy,
                FourFaceSteveCriticalChance,
                level,
                normalAttacks,
                magicAttacks,
                FourFaceSteveEXPReward,
                MakeInBattleSprite())
        {
            this.SetStatsForAppropriateLevel();
        }

        public override void Draw()
        {
            if (this.IsInBattle)
            {
                int startWidth = MainFrame.StartWidth + 16;
                int startHeight = MainFrame.StartHeight + 1;

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
            string[] steve = new string[12];
            steve[0] = " ________                 ";
            steve[1] = "/        \\    ___         ";
            steve[2] = "|   Hi!  | __/___\\__ \\ | /";
            steve[3] = "\\_______ | \\_______/  \\|/ ";
            steve[4] = "        \\|   |._.|     |  ";
            steve[5] = "             |---|     |  ";
            steve[6] = "             |._.|     |  ";
            steve[7] = "             |---|     |  ";
            steve[8] = "             |._.|     /  ";
            steve[9] = "             |---|    /   ";
            steve[10] = "             |._.|   /    ";
            steve[11] = "             |---|  /     ";

            return steve;
        }

        protected override void SetStatsForAppropriateLevel()
        {
            throw new NotImplementedException();
        }
    }
}