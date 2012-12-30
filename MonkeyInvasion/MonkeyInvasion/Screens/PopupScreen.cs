using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonkeyInvasion.GameStateManagement;

namespace MonkeyInvasion.Screens
{
    abstract class PopupScreen : GameScreen
    {

        #region Fields

        string popupTitle;

        #endregion

        #region Properties

        
        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public PopupScreen(string popupTitle)
        {
            this.popupTitle = popupTitle;

            TransitionOnTime = TimeSpan.FromSeconds(0.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Responds to user input
        /// </summary>
        public override void HandleInput(InputState input)
        {
                        
            //TODO

        }


        ///// <summary>
        ///// Handler for when the user has chosen a menu entry.
        ///// </summary>
        //protected virtual void OnSelectEntry(int entryIndex, EventArgs e)
        //{
        //    menuEntries[selectedEntry].OnSelectEntry();
        //}


        #endregion

        #region Update and Draw


        /// <summary>
        /// Updates....
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            //TODO...
        }


        /// <summary>
        /// Draws the popup.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {

                SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
                SpriteFont font = ScreenManager.Font;

                spriteBatch.Begin();

                // Draw each item on the popup...
                //TODO!


                spriteBatch.End();

            }
        }

        #endregion
    
}
