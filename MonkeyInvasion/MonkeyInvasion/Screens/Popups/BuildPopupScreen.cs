using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MonkeyInvasion.GameStateManagement;
using MonkeyInvasion.Entities;


namespace MonkeyInvasion.Screens.Popups
{
    class BuildPopupScreen : PopupScreen
    {

        BaseGame game;

        List<ClickableObject> objects = new List<ClickableObject>();

        public BuildPopupScreen(BaseGame game)
            : base("Build Screen Test")
        {

            this.game = game;

            // Flag that there is no need for the game to transition
            // off when the build popup is on top of it.
            IsPopup = true;


            //TODO add content...
            ClickableObject buttonOne = new ClickableObject(game, new Vector2(100, 100), "Sprites/Player/");
            ClickableObject buttonTwo = new ClickableObject(game, new Vector2(250, 100), "Sprites/MonsterA/");

            objects.Add(buttonOne);
            objects.Add(buttonTwo);

        }

        /// <summary>
        /// Updates the state of the game. This method checks the GameScreen.IsActive
        /// property, so the game will stop updating when the pause menu is active,
        /// or if you tab away to a different application.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
     
            // TODO: Add your update logic here            

            foreach (ClickableObject obj in objects)
            {
                obj.Update(gameTime);
            }


            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }
     
        /// <summary>
        /// Lets the game respond to player input. Unlike the Update method,
        /// this will only be called when the gameplay screen is active.
        /// </summary>
        public override void HandleInput(InputState input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            // Look up inputs for the active player profile.
            int playerIndex = 0;

            KeyboardState keyboardState = input.CurrentKeyboardStates[playerIndex];
            GamePadState gamePadState = input.CurrentGamePadStates[playerIndex];

            // The game pauses either if the user presses the pause button, or if
            // they unplug the active gamepad. This requires us to keep track of
            // whether a gamepad was ever plugged in, because we don't want to pause
            // on PC if they are playing with a keyboard and have no gamepad at all!
            bool gamePadDisconnected = !gamePadState.IsConnected &&
                                       input.GamePadWasConnected[playerIndex];

            if (input.IsPauseGame(ControllingPlayer) || gamePadDisconnected)
            {
                ScreenManager.AddScreen(new PauseMenuScreen(), ControllingPlayer);
            }
            else if (keyboardState.IsKeyDown(Keys.P))
            {

                this.ExitScreen();
            }
            else
            {

                //if (keyboardState.IsKeyDown(Keys.Escape))
                //    this.ExitScreen();

           
            }
        }



        #region Draw

        /// <summary>
        /// Draws the pause menu screen. This darkens down the gameplay screen
        /// that is underneath us, and then chains to the base MenuScreen.Draw.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            ScreenManager.FadeBackBufferToBlack(TransitionAlpha * 2 / 3);
            
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();

            // TODO DRAW STUFF ON SCREEN!
            foreach (ClickableObject obj in objects)
            {
                obj.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        #endregion

    }
}
