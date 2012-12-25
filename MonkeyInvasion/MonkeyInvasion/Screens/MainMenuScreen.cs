using Microsoft.Xna.Framework;
using System;
using MonkeyInvasion.GameStateManagement;

namespace MonkeyInvasion.Screens
{
    /// <summary>
    /// The main menu screen is the first thing displayed when the game starts up.
    /// </summary>
    class MainMenuScreen : MenuScreen
    {
        #region Initialization


        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public MainMenuScreen()
            : base("Main Menu")
        {
            // Create our menu entries.
            MenuEntry playGameMenuEntry = new MenuEntry("Play Game");
            MenuEntry testBattleEngineMenuEntry = new MenuEntry("Test Battle Engine");
            MenuEntry optionsMenuEntry = new MenuEntry("Options");
            MenuEntry exitMenuEntry = new MenuEntry("Exit");

            // Hook up menu event handlers.
            playGameMenuEntry.Selected += PlayGameMenuEntrySelected;
            testBattleEngineMenuEntry.Selected += BattleEngineMenuEntrySelected;
            optionsMenuEntry.Selected += OptionsMenuEntrySelected;
            exitMenuEntry.Selected += OnCancel;

            // Add entries to the menu.
            MenuEntries.Add(playGameMenuEntry);
            MenuEntries.Add(testBattleEngineMenuEntry);
            MenuEntries.Add(optionsMenuEntry);
            MenuEntries.Add(exitMenuEntry);
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Event handler for when the Play Game menu entry is selected.
        /// </summary>
        void PlayGameMenuEntrySelected(object sender, EventArgs e)
        {
            LoadingScreen.Load(ScreenManager, true, null, new GameplayScreen());
        }

        /// <summary>
        /// Event handler for when the Battle Engine menu entry is selected.
        /// </summary>
        void BattleEngineMenuEntrySelected(object sender, EventArgs e)
        {
            //LoadingScreen.Load(ScreenManager, true, null, new GameplayScreen());
        }


        /// <summary>
        /// Event handler for when the Options menu entry is selected.
        /// </summary>
        void OptionsMenuEntrySelected(object sender, EventArgs e)
        {
            ScreenManager.AddScreen(new BackgroundScreen(), null);
            ScreenManager.AddScreen(new OptionsMenuScreen(), null);

        }


        /// <summary>
        /// When the user cancels the main menu, ask if they want to exit the sample.
        /// </summary>
        /// 
        protected override void OnCancel(object sender, EventArgs e)
        {
            ScreenManager.Game.Exit();
        }


        #endregion
    }
}
