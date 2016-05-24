namespace Cycle
{
    using System;
    using Interfaces;
    using GameFrames;
    using Handlers;
    using Databases;
    using Core;

    public class Program
    {
        public static void Main()
        {
            ResetBuffer();
            Console.CursorVisible = false;
            IMainFrame mainFrame = new MainFrame();
            IMainMenu mainMenu = new MainMenu();
            IStatusFrame monsterStatusFrame = new MonsterStatusFrame();
            IOptionsFrame optionsFrame = new OptionsFrame();
            IStatusFrame statusFrame = new StatusFrame();
            IMenuHandler menuHandler = new MenuHandler(mainMenu, mainFrame, optionsFrame, statusFrame, monsterStatusFrame);
            IMonsterDatabase monsterDatabase = new MonsterDatabase();
            IAreaDatabase areaDatabase = new AreaDatabase();
            IAIDatabase aiDatabase = new AIDatabase();
            IEngine engine = new Engine(menuHandler, monsterDatabase, areaDatabase, aiDatabase);
            engine.Run();
        }

        private static void ResetBuffer ()
        {
            Console.BufferHeight = Console.WindowHeight = 30;
            Console.BufferWidth = Console.WindowWidth = 90;
        }
    }
}