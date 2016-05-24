namespace Cycle.Models.Units.Monsters
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using GameFrames;

    public class KingOfSmiles : Monster
    {
        private const string KingOfSmilesName = "The King of Smiles(and lips)";
        private const int KingOfSmilesHealth = 80;
        private const int KingOfSmilesMP = 35;
        private const int KingOfSmilesDamage = 20;
        private const int KingOfSmilesDefense = 16;
        private const int KingOfSmilesAccuracy = 89;
        private const int KingOfSmilesCriticalChance = 7;
        private const int KingOfSmilesEXPReward = 40;

        // // TODO: Add specific normal and magic attacks to KingOfSmiles
        public KingOfSmiles(
            int x,
            int y,
            int level,
            IList<INormalAttack> normalAttacks,
            IList<IMagicAttack> magicAttacks)
            : base(
                KingOfSmilesName,
                x,
                y,
                KingOfSmilesHealth,
                KingOfSmilesMP,
                KingOfSmilesDamage,
                KingOfSmilesDefense,
                KingOfSmilesAccuracy,
                KingOfSmilesCriticalChance,
                level,
                normalAttacks,
                magicAttacks,
                KingOfSmilesEXPReward,
                MakeInBattleSprite())
        {
            this.SubjectPronoun = "He";
            this.ReflexivePronoun = "Himself";
        }

        public override void Draw()
        {
            if (this.IsInBattle)
            {
                int startWidth = MainFrame.StartWidth + 23;
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
            string[] kingOfSmiles = new string[13];
            kingOfSmiles[0] = "o        o       o";
            kingOfSmiles[1] = "|\\      /\\      /|";
            kingOfSmiles[2] = "| \\    /  \\    / |";
            kingOfSmiles[3] = "|  \\  /    \\  /  |";
            kingOfSmiles[4] = "|   \\/      \\/   |";
            kingOfSmiles[5] = "|________________|";
            kingOfSmiles[6] = "  ***        ***  ";
            kingOfSmiles[7] = " * . *      * . * ";
            kingOfSmiles[8] = "  ***        ***  ";
            kingOfSmiles[9] = "|\\              /|";
            kingOfSmiles[10] = "| \\____________/ |";
            kingOfSmiles[11] = "|\\______________/|";
            kingOfSmiles[12] = " \\______________/ ";

            return kingOfSmiles;
        }
    }
}
