using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonkeyInvasion.GameStateManagement;

namespace MonkeyInvasion.Screens
{
    /// <summary>
    /// Base class for screens that contain a menu of options. The user can
    /// move up and down to select an entry, or cancel to back out of the screen.
    /// </summary>
    abstract class MenuScreen : GameScreen
    {
        #region Fields

        List<MenuEntry> menuEntries = new List<MenuEntry>();
        int selectedEntry = 0;
        string menuTitle;

        #endregion

        #region Properties


        /// <summary>
        /// Gets the list of menu entries, so derived classes can add
        /// or change the menu contents.
        /// </summary>
        protected IList<MenuEntry> MenuEntries
        {
            get { return menuEntries; }
        }


        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public MenuScreen(string menuTitle)
        {
            this.menuTitle = menuTitle;

            TransitionOnTime = TimeSpan.FromSeconds(0.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Responds to user input, changing the selected entry and accepting
        /// or cancelling the menu.
        /// </summary>
        public override void HandleInput(InputState input)
        {
            
            // Move to the previous menu entry?
            if (input.IsMenuUp(ControllingPlayer))
            {
                selectedEntry--;

                if (selectedEntry < 0)
                    selectedEntry = menuEntries.Count - 1;
            }

            // Move to the next menu entry?
            if (input.IsMenuDown(ControllingPlayer))
            {
                selectedEntry++;

                if (selectedEntry >= menuEntries.Count)
                    selectedEntry = 0;
            }

            // Accept or cancel the menu? We pass in our ControllingPlayer, which may
            // either be null (to accept input from any player) or a specific index.
            // If we pass a null controlling player, the InputState helper returns to
            // us which player actually provided the input. We pass that through to
            // OnSelectEntry and OnCancel, so they can tell which player triggered them.
            PlayerIndex playerIndex;

            if (input.IsMenuSelect(ControllingPlayer, out playerIndex))
            {
                OnSelectEntry(selectedEntry, EventArgs.Empty);
            }
            else if (input.IsMenuCancel(ControllingPlayer, out playerIndex))
            {
                OnCancel(EventArgs.Empty);
            }
        }


        /// <summary>
        /// Handler for when the user has chosen a menu entry.
        /// </summary>
        protected virtual void OnSelectEntry(int entryIndex, EventArgs e)
        {
            menuEntries[selectedEntry].OnSelectEntry();
        }


        /// <summary>
        /// Handler for when the user has cancelled the menu.
        /// </summary>
        protected void OnCancel(EventArgs e)
        {
            ExitScreen();
        }


        /// <summary>
        /// Helper overload makes it easy to use OnCancel as a MenuEntry event handler.
        /// </summary>
        protected virtual void OnCancel(object sender, EventArgs e)
        {
            OnCancel(EventArgs.Empty);
        }


        #endregion

        #region Update and Draw


        /// <summary>
        /// Updates the menu.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            // Update each nested MenuEntry object.
            for (int i = 0; i < menuEntries.Count; i++)
            {
                bool isSelected = IsActive && (i == selectedEntry);

                menuEntries[i].Update(this, isSelected, gameTime);
            }
        }


        /// <summary>
        /// Draws the menu.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            if (menuEntries.Count > 0)
            {
                SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
                SpriteFont font = ScreenManager.Font;

                //Vector2 position = new Vector2(/*40*/60, /*290*/550 - menuEntries[0].GetHeight(this));

                //TODO: GET VIEWPORT WIDTH AND HEIGH...
                
                //Vector2 position = new Vector2((1280/2), 720 - (menuEntries[0].GetHeight(this)*(menuEntries.Count)));
                Vector2 position = new Vector2((1280 / 2), (menuEntries[0].GetHeight(this)*3));

                // Make the menu slide into place during transitions, using a
                // power curve to make things look more interesting (this makes
                // the movement slow down as it nears the end).
                float transitionOffset = (float)Math.Pow(TransitionPosition, 2);

                position.Y += transitionOffset * 400;

                spriteBatch.Begin();

                // Draw each menu entry in turn.
                //for (int i = menuEntries.Count - 1; i >= 0; --i)
                for (int i = 0; i < menuEntries.Count; i++)
                {
                    MenuEntry menuEntry = menuEntries[i];

                    bool isSelected = IsActive && (i == selectedEntry);

                    //position.X = /*120*/240 - font.MeasureString(menuEntry.Text).X /*/ 2*/;
                    position.X = (1280 / 2) - (font.MeasureString(menuEntry.Text).X);
                    menuEntry.Draw(this, position, isSelected, gameTime);
                    
                    position.Y += menuEntry.GetHeight(this) + 90;
                }

                spriteBatch.End();

            }
        }


        #endregion
    }
}
