namespace Cycle.Models.Units.Monsters
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using GameFrames;
    using Attacks.NormalAttacks;
    using Attacks.MagicAttacks;

    public class TheSmallFacedCat : Monster
    {
        private const string TheSmallFacedCatName = "Meow-san the Small-Faced Cat";
        private const int TheSmallFacedCatHealth = 38;
        private const int TheSmallFacedCatMP = 0;
        private const int TheSmallFacedCatDamage = 5;
        private const int TheSmallFacedCatDefense = 1;
        private const int TheSmallFacedCatAccuracy = 90;
        private const int TheSmallFacedCatCriticalChance = 10;
        private const int TheSmallFacedCatPointsReward = 1;

        public TheSmallFacedCat(
            int x, 
            int y,
            int level)
            : base(
            TheSmallFacedCatName,
            x,
            y, 
            TheSmallFacedCatHealth, 
            TheSmallFacedCatMP,
            TheSmallFacedCatDamage,
            TheSmallFacedCatDefense, 
            TheSmallFacedCatAccuracy,
            TheSmallFacedCatCriticalChance, 
            level,
            PutNormalAttacks(),
            PutMagicAttacks(),
            TheSmallFacedCatPointsReward,
            MakeInBattleSprite())
        {
            this.SubjectPronoun = "It";
            this.ReflexivePronoun = "Itself";
        }

        public override void Draw()
        {
            if (this.IsInBattle)
            {
                int startWidth = MainFrame.StartWidth + 26;
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
            string[] catFaces = 
            {
                "=^.^=",
                ">'o'<",
                ">'.'<",
                "=^_^="
            };

            string catFace = catFaces[Random.Next(0, 4)];

            string[] cat = new string[8];
            cat[0] = "  |\\        /|  ";
            cat[1] = "  | \\______/ |  ";
            cat[2] = " /            \\ ";
            cat[3] = "/              \\";
            cat[4] = "|              |";
            cat[5] = string.Format("|     {0}    |", catFace);
            cat[6] = "|              |";
            cat[7] = "\\______________/";

            return cat;
        }

        private static IList<INormalAttack> PutNormalAttacks()
        {
            var normalAttacks = new List<INormalAttack>()
            {
                Tackle.Instance,
                FierceBite.Instance
            };

            return normalAttacks;
        }

        // TODO: Add three more magicAttacks
        private static IList<IMagicAttack> PutMagicAttacks()
        {
            var magicAttacks = new List<IMagicAttack>()
            {
                ZoomPunch.Instance
            };

            return magicAttacks;
        }
    }
}