namespace Cycle.GameFrames
{
    using System;
    using Interfaces;

    public class MonsterStatusFrame : SimpleGameFrame, IStatusFrame
    {
        public static int StartWidth = 48;
        public static int EndWidth = 82;
        public static int Width = EndWidth - StartWidth;
        public static int StartHeight = 14;
        public static int EndHeight = 17;
        public static int Height = EndHeight - StartHeight;

        public MonsterStatusFrame()
            : base(StartWidth, EndWidth, StartHeight, EndHeight)
        {
        }

        public void Update(IUnit monster)
        {
            this.Draw();

            Console.SetCursorPosition(StartWidth + 1, StartHeight + 1);
            Console.Write(
                "{0}{1}Lv{2}",
                monster.Name,
                new string(' ', Width - monster.Name.Length - (monster.Level > 9 ? 5 : 4)),
                monster.Level);

            if (monster.HP > monster.MaxHP / 10 * 6)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (monster.HP > monster.MaxHP / 4)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            this.ClearHealth();

            double partOfHealth = 1.0 * monster.MaxHP / (Width - 1);
            int numberOfHealthSticks = 
                monster.HP != 0 && monster.HP < partOfHealth ? 
                1 : (int)(monster.HP / partOfHealth);

            Console.SetCursorPosition(StartWidth + 1, StartHeight + 2);
            Console.Write("{0}", new string('|', numberOfHealthSticks));

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void ClearHealth()
        {
            Console.SetCursorPosition(StartWidth + 1, EndHeight - 1);
            Console.Write(new string(' ', Width - 1));
        }
    }
}