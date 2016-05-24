namespace Cycle.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Args;
    using Interfaces;

    public static class SaveFileHandler
    {
        // TODO: Make SaveGame method better (add shop, ...)
        public static void SaveGame(
            string path, 
            IPlayer player,
            IArea area,
            int savePointX,
            int savePointY,
            IMonster monster = null)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(player.Name); 
                writer.WriteLine(player.Level);
                writer.WriteLine(player.Points);
                writer.WriteLine(player.MagicRobbers);
                writer.Write(player.X);
                writer.WriteLine(player.Y);
                writer.WriteLine(player.MaxHP); 
                writer.WriteLine(player.HP);
                writer.WriteLine(player.MaxMP);
                writer.WriteLine(player.MP); 
                writer.WriteLine(player.MaxDamage); 
                writer.WriteLine(player.MaxDefense); 
                writer.WriteLine(player.MaxAccuracy); 
                writer.WriteLine(player.CriticalChance);
                writer.WriteLine(player.NormalAttacks.Count > 0 ? player.NormalAttacks[0].GetType().Name : "-");
                writer.WriteLine(player.NormalAttacks.Count > 1 ? player.NormalAttacks[1].GetType().Name : "-");
                writer.WriteLine(player.NormalAttacks.Count > 2 ? player.NormalAttacks[2].GetType().Name : "-");
                writer.WriteLine(player.NormalAttacks.Count > 3 ? player.NormalAttacks[3].GetType().Name : "-");
                writer.WriteLine(player.MagicAttacks.Count > 0 ? player.MagicAttacks[0].GetType().Name : "-");
                writer.WriteLine(player.MagicAttacks.Count > 1 ? player.MagicAttacks[1].GetType().Name : "-");
                writer.WriteLine(player.MagicAttacks.Count > 2 ? player.MagicAttacks[2].GetType().Name : "-");
                writer.WriteLine(player.MagicAttacks.Count > 3 ? player.MagicAttacks[3].GetType().Name : "-");
                writer.WriteLine(player.MagicAttacks.Count > 4 ? player.MagicAttacks[4].GetType().Name : "-");
                writer.WriteLine(player.MagicAttacks.Count > 5 ? player.MagicAttacks[5].GetType().Name : "-");
                writer.WriteLine(area.GetType().Name);
                writer.Write(savePointX);
                writer.Write(savePointY);
                if (monster != null)
                {
                    writer.WriteLine("true");
                    writer.WriteLine(monster.Name);
                    writer.WriteLine(monster.Level);
                }
                else
                {
                    writer.WriteLine("false");
                }
            }
        }

        public static PlayerArgs GetPlayerArgsPlayer(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string name = reader.ReadLine();
                if (name == null)
                {
                    return null;
                }

                int level = int.Parse(reader.ReadLine());
                int points = int.Parse(reader.ReadLine());
                int magicRobbers = int.Parse(reader.ReadLine());
                int x = int.Parse(reader.ReadLine());
                int y = int.Parse(reader.ReadLine());
                int maxHP = int.Parse(reader.ReadLine());
                int hp = int.Parse(reader.ReadLine());
                int maxMP = int.Parse(reader.ReadLine());
                int mp = int.Parse(reader.ReadLine());
                int damage = int.Parse(reader.ReadLine());
                int defense = int.Parse(reader.ReadLine());
                int accuracy = int.Parse(reader.ReadLine());
                int critChance = int.Parse(reader.ReadLine());
                var normalAttacks = new List<string>();
                normalAttacks.Add(reader.ReadLine());
                normalAttacks.Add(reader.ReadLine());
                normalAttacks.Add(reader.ReadLine());
                normalAttacks.Add(reader.ReadLine());
                var magicAttacks = new List<string>();
                magicAttacks.Add(reader.ReadLine());
                magicAttacks.Add(reader.ReadLine());
                magicAttacks.Add(reader.ReadLine());
                magicAttacks.Add(reader.ReadLine());
                magicAttacks.Add(reader.ReadLine());
                magicAttacks.Add(reader.ReadLine());
                var args = new PlayerArgs(name, level, points, magicRobbers, maxHP, hp, maxMP, mp, damage, defense, 
                    accuracy, critChance, normalAttacks, magicAttacks);

                return args;
            }
        }

        public static AreaArgs GetAreaArgs(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string str = reader.ReadLine();
                if (str == null)
                {
                    return null;
                }

                for (int i = 0; i < 23; i++)
                {
                    reader.ReadLine();
                }

                string areaName = reader.ReadLine();
                var args = new AreaArgs(areaName);

                return args;
            }
        }

        public static SavePointArgs GetSavePointArgs(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string str = reader.ReadLine();
                if (str == null)
                {
                    return null;
                }

                for (int i = 0; i < 24; i++)
                {
                    reader.ReadLine();
                }

                int x = int.Parse(reader.ReadLine());
                int y = int.Parse(reader.ReadLine());
                var args = new SavePointArgs(x, y);

                return args;
            }
        }

        public static MonsterArgs GetMonsterArgs(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string str = reader.ReadLine();
                if (str == null)
                {
                    return null;
                }

                for (int i = 0; i < 26; i++)
                {
                    reader.ReadLine();
                }

                bool hasMonsterArgs = Convert.ToBoolean(reader.ReadLine());
                if (hasMonsterArgs)
                {
                    string name = reader.ReadLine();
                    int level = int.Parse(reader.ReadLine());
                    var args = new MonsterArgs(name, level);

                    return args;
                }

                return null;
            }
        }

        public static SaveFileArgs GetSaveFileArgs(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string name = reader.ReadLine();
                if (name == null)
                {
                    return new SaveFileArgs(false);
                }

                int level = int.Parse(reader.ReadLine());

                var args = new SaveFileArgs(true, name, level);

                return args;
            }
        }
    }
}