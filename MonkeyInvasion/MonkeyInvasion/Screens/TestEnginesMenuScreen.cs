using Microsoft.Xna.Framework;
using System;
using MonkeyInvasion.GameStateManagement;

namespace MonkeyInvasion.Screens
{
    class TestEnginesMenuScreen : MenuScreen
    {

        #region Initialization


        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public TestEnginesMenuScreen()
            : base("Test Engines Menu")
        {
            // Create our menu entries.            
            MenuEntry battleEngineMenuEntry = new MenuEntry("Battle Engine");
            MenuEntry platformerEngineMenuEntry = new MenuEntry("Platformer Style Engine");
            MenuEntry clickEngineMenuEntry = new MenuEntry("Point and Click Engine");            
            MenuEntry exitMenuEntry = new MenuEntry("Back");

            // Hook up menu event handlers.
            battleEngineMenuEntry.Selected += OnBattleEngine;
            platformerEngineMenuEntry.Selected += OnPlatformerEngine;
            clickEngineMenuEntry.Selected += OnClickEngine;
            exitMenuEntry.Selected += OnCancel;

            // Add entries to the menu.
            MenuEntries.Add(battleEngineMenuEntry);
            MenuEntries.Add(platformerEngineMenuEntry);
            MenuEntries.Add(clickEngineMenuEntry);
            MenuEntries.Add(exitMenuEntry);
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Event handler for when the Battle Engine menu entry is selected.
        /// </summary>
        void OnBattleEngine(object sender, EventArgs e)
        {
            //LoadingScreen.Load(ScreenManager, true, null, new GameplayScreen());
        }

        /// <summary>
        /// Event handler for when the PlatformerEngine menu entry is selected.
        /// </summary>
        void OnPlatformerEngine(object sender, EventArgs e)
        {
            LoadingScreen.Load(ScreenManager, true, null, new PlatformerEngineScreen());
        }

        /// <summary>
        /// Event handler for when the Play Game menu entry is selected.
        /// </summary>
        void OnClickEngine(object sender, EventArgs e)
        {
            LoadingScreen.Load(ScreenManager, true, null, new ClickEngineScreen());
        }

        /// <summary>
        /// When the user cancels the main menu, ask if they want to exit the menu.
        /// </summary>
        /// 
        protected override void OnCancel(object sender, EventArgs e)
        {
            ScreenManager.AddScreen(new BackgroundScreen(), null);
            ScreenManager.AddScreen(new MainMenuScreen(), null);
        }  

        #endregion

    }
}
