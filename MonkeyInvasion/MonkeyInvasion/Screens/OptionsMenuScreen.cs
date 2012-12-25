using Microsoft.Xna.Framework;
using System;
using MonkeyInvasion.GameStateManagement;

namespace MonkeyInvasion.Screens
{
    class OptionsMenuScreen : MenuScreen
    {

                #region Initialization


        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public OptionsMenuScreen()
            : base("Options Menu")
        {
            // Create our menu entries.
            //MenuEntry donwloadMenuEntry = new MenuEntry("Download now");
            MenuEntry exitMenuEntry = new MenuEntry("Back");

            // Hook up menu event handlers.
            //donwloadMenuEntry.Selected += OnDownload;
            exitMenuEntry.Selected += OnCancel;

            // Add entries to the menu.
            //MenuEntries.Add(donwloadMenuEntry);
            MenuEntries.Add(exitMenuEntry);
        }


        #endregion

        #region Handle Input


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
