namespace Cycle.Models.Units
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using GameFrames;
    using Interfaces;

    public class Player : Unit, IPlayer
    {
        private const int PlayerHP = 23;
        private const int PlayerMP = 10;
        private const int PlayerDamage = 12;
        private const int PlayerDefense = 8;
        private const int PlayerAccuracy = 95;
        private const int PlayerCriticalChance = 2;

        private int magicRobbers;
        private int points;

        public Player(
            int x,
            int y,
            string name, 
            int level,
            int points,
            int magicRobbers,
            IList<INormalAttack> normalAttacks, 
            IList<IMagicAttack> magicAttacks,
            ConsoleColor color = ConsoleColor.White)
            : base(
            name,
            x,
            y, 
            PlayerHP,
            PlayerMP, 
            PlayerDamage, 
            PlayerDefense,
            PlayerAccuracy,
            PlayerCriticalChance,
            level,
            normalAttacks,
            magicAttacks,
            color)
        {
            this.Sprite = this.Name[0].ToString();
            this.Points = points;
            this.MagicRobbers = magicRobbers;
            this.Option = Option.First;
            this.SubjectPronoun = "You";
            this.ReflexivePronoun = "Yourself";
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Points", "Points cannot be negative.");
                }

                this.points = value;
            }
        }

        public int MagicRobbers
        {
            get
            {
                return this.magicRobbers;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("MagicRobbers", "Magic robbers cannot be negative.");
                }

                this.magicRobbers = value;
            }
        }

        public Option Option { get; set; }

        private string Sprite { get; set; }

        public override void Draw()
        {
            Console.ForegroundColor = this.Color;
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(this.Sprite);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void Clear()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(new string(' ', this.Sprite.Length));
        }

        public void Move(ConsoleKey direction)
        {
            if (!this.IsInBattle)
            {
                this.Clear();

                switch (direction)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        this.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        this.MoveDown();
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        this.MoveRight();
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        this.MoveLeft();
                        break;
                }

                this.Draw();
            }
        }

        public void Move(ConsoleKey direction, IList<int> borders)
        {
            if (!this.IsInBattle)
            {
                this.Clear();

                switch (direction)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        this.MoveUp(borders);
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        this.MoveDown(borders);
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        this.MoveRight(borders);
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        this.MoveLeft(borders);
                        break;
                }

                this.Draw();
            }
        }

        private void MoveUp(IList<int> borders = null)
        {
            if (borders != null)
            {
                for (int i = 0; i < borders.Count; i += 2)
                {
                    if (this.X == borders[i] && this.Y - 1 == borders[i + 1])
                    {
                        return;
                    }
                }
            }
                
            if (this.Y > MainFrame.StartHeight + 1)
            {
                this.Y--;
            }
        }

        private void MoveDown(IList<int> borders = null)
        {
            if (borders != null)
            {
                for (int i = 0; i < borders.Count; i += 2)
                {
                    if (this.X == borders[i] && this.Y + 1 == borders[i + 1])
                    {
                        return;
                    }
                }
            }

            if (this.Y < MainFrame.EndHeight - 1)
            {
                this.Y++;
            }
        }

        private void MoveRight(IList<int> borders = null)
        {
            if (borders != null)
            {
                for (int i = 0; i < borders.Count; i += 2)
                {
                    if (this.X + 1 == borders[i] && this.Y == borders[i + 1])
                    {
                        return;
                    }
                }
            }

            if (this.X < MainFrame.EndWidth - this.Sprite.Length)
            {
                this.X++;
            }  
            
        }

        private void MoveLeft(IList<int> borders = null)
        {
            if (borders != null)
            {
                for (int i = 0; i < borders.Count; i += 2)
                {
                    if (this.X - 1 == borders[i] && this.Y == borders[i + 1])
                    {
                        return;
                    }
                }
            }

            if (this.X > MainFrame.StartWidth + 1)
            {
                this.X--;
            }
        }
    }
}