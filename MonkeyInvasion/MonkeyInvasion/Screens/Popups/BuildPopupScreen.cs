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
using MonkeyInvasion.Controls;
using MonkeyInvasion.EventHandlers;


namespace MonkeyInvasion.Screens.Popups
{
    class BuildPopupScreen : PopupScreen
    {

        BaseGame game;

        List<ClickableObject> objects = new List<ClickableObject>();

        ControlManager controls = new ControlManager();

        public BuildPopupScreen(BaseGame game)
            : base("Build Screen Test")
        {

            this.game = game;
            
            ContentManager content = game.Content;

            // Flag that there is no need for the game to transition
            // off when the build popup is on top of it.
            IsPopup = true;            

            //VARIOUS TEST CONTENT / CONTROLS
            ClickableObject buttonOne = new ClickableObject(game, new Vector2(100, 100), "Sprites/Player/");
            ClickableObject buttonTwo = new ClickableObject(game, new Vector2(250, 100), "Sprites/MonsterA/");

            objects.Add(buttonOne);
            objects.Add(buttonTwo);


            PictureBox pictureBox = new PictureBox(new Vector2(250, 250), content.Load<Texture2D>("TestPictureBox"));
            controls.AddControl("pictureBox", pictureBox);


            //TODO add Font utils helper to easily access fonts and add more fonts to library
            SpriteFont font = content.Load<SpriteFont>("Fonts/gamefont");
            
            Label testLabel = new Label("This is a test label..", new Vector2(250, 400), font);            
            controls.AddControl("testLabel", testLabel);

            Button testButton = new Button(content.Load<Texture2D>("Buttons/TestButton"), null, new Vector2(50, 250), "Button text goes here...");
            testButton.Clicked += MonkeyEvents.TestButtonClickEvent;            

            controls.AddControl("testButton", testButton);

           

        }

        /// <summary>
        /// Updates the state of the game. This method checks the GameScreen.IsActive
        /// property, so the game will stop updating when the pause menu is active,
        /// or if you tab away to a different application.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
                   

            foreach (ClickableObject obj in objects)
            {
                obj.Update(gameTime);
            }

            controls.Update(gameTime);


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
            KeyboardState prevKeyboardState = input.LastKeyboardStates[playerIndex];

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
            else if (keyboardState.IsKeyDown(Keys.P) && !prevKeyboardState.IsKeyDown(Keys.P))
            {
                this.ExitScreen();
            }
            else
            {
                //if (keyboardState.IsKeyDown(Keys.Escape))
                //    this.ExitScreen();           

            }

            controls.UpdateInput(input);

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
            
            foreach (ClickableObject obj in objects)
            {
                obj.Draw(gameTime, spriteBatch);
            }

            controls.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        #endregion

    }
}
