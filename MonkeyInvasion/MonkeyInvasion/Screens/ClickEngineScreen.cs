using System;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.IO.IsolatedStorage;
using MonkeyInvasion.GameStateManagement;
using MonkeyInvasion.Entities;
using MonkeyInvasion.Screens.Popups;


namespace MonkeyInvasion.Screens
{
    /// <summary>
    /// This screen implements the actual game logic...
    /// </summary>
    class ClickEngineScreen : GameScreen
    {
        #region Fields

        ContentManager content;
        SpriteFont gameFont;

        Vector2 playerPosition = new Vector2(100, 100);        

        // Global content.        
        //private Texture2D winOverlay;        

        // Meta-level game state.

        private ClickEngineGame game;

        private bool wasContinuePressed;

        private const int TargetFrameRate = 30;
        private const int BackBufferWidth = 1280;
        private const int BackBufferHeight = 720;
        private const Buttons ContinueButton = Buttons.B;

        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public ClickEngineScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
        }


        /// <summary>
        /// Load graphics content for the game.
        /// </summary>
        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(ScreenManager.GraphicsDevice);

            // Load fonts
            gameFont = content.Load<SpriteFont>("Fonts/gamefont");            

            // Load overlay textures
            //winOverlay = content.Load<Texture2D>("Overlays/you_win");


            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(content.Load<Song>("Sounds/Music"));

            //LOAD THE GAME!
            LoadNewGame();

            // A real game would probably have more content than this sample, so
            // it would take longer to load. We simulate that by delaying for a
            // while, giving you a chance to admire the beautiful loading screen.
            Thread.Sleep(1000);

            // once the load has finished, we use ResetElapsedTime to tell the game's
            // timing mechanism that we have just finished a very long frame, and that
            // it should not try to catch up.
            ScreenManager.Game.ResetElapsedTime();
        }

        private void LoadNewGame()
        {
            //TODO LOAD THE GAME CONTENT HERE....
            game = new ClickEngineGame(ScreenManager.Game.Services);

        }



        private void ReloadCurrentLevel()
        {      
            LoadNewGame();
        }


        /// <summary>
        /// Unload graphics content used by the game.
        /// </summary>
        public override void UnloadContent()
        {
            content.Unload();
        }


        #endregion

        #region Update and Draw


        /// <summary>
        /// Updates the state of the game. This method checks the GameScreen.IsActive
        /// property, so the game will stop updating when the pause menu is active,
        /// or if you tab away to a different application.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {

            //HandleInput();

            // TODO: Add your update logic here            
            game.Update(gameTime);                       

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        //private void HandleInput()
        //{
        //    KeyboardState keyboardState = Keyboard.GetState();
        //    GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);

        //    bool buttonTouched = false;

        //    bool continuePressed =
        //            keyboardState.IsKeyDown(Keys.Space) ||
        //            gamepadState.IsButtonDown(ContinueButton) || buttonTouched;

        //    // Perform the appropriate action to advance the game and
        //    // to get the player back to playing.
        //    if (!wasContinuePressed && continuePressed)
        //    {
        //        if (!game.Player.IsAlive)
        //        {
        //            LoadNewGame();
        //        }                

        //        //ReloadCurrentLevel();
        //    }

        //    wasContinuePressed = continuePressed;
        //}

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
            else if (keyboardState.IsKeyDown(Keys.P) && !prevKeyboardState.IsKeyDown(Keys.P)){

                ScreenManager.AddScreen(new BuildPopupScreen(game), ControllingPlayer);
            }
            else
            {
                // Otherwise move the player position, etc etc...

                Vector2 movement = Vector2.Zero;

                if (keyboardState.IsKeyDown(Keys.Left))
                    movement.X--;

                if (keyboardState.IsKeyDown(Keys.Right))
                    movement.X++;

                if (keyboardState.IsKeyDown(Keys.Up))
                    movement.Y--;

                if (keyboardState.IsKeyDown(Keys.Down))
                    movement.Y++;

                Vector2 thumbstick = gamePadState.ThumbSticks.Left;

                movement.X += thumbstick.X;
                movement.Y -= thumbstick.Y;

                if (movement.Length() > 1)
                    movement.Normalize();

                playerPosition += movement * 2;
            }
        }


        /// <summary>
        /// Draws the gameplay screen.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            ScreenManager.GraphicsDevice.Clear(Color.CornflowerBlue);            
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();

            game.Draw(gameTime, spriteBatch);

            DrawHud();

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawHud()
        {
            Rectangle titleSafeArea = ScreenManager.GraphicsDevice.Viewport.TitleSafeArea;
            Vector2 hudLocation = new Vector2(titleSafeArea.X, titleSafeArea.Y);
            Vector2 center = new Vector2(titleSafeArea.X + titleSafeArea.Width / 2.0f,
                                         titleSafeArea.Y + titleSafeArea.Height / 2.0f);

            
            //DrawShadowedString(hudFont, timeString, hudLocation, timeColor);
            //DrawShadowedString(hudFont, "SCORE: " + level.Score.ToString(), hudLocation + new Vector2(0.0f, timeHeight * 1.2f), Color.Yellow);

            //TODO DRAW STATUS OVERLAY MESSAGE(s)

    
        }

        private void DrawShadowedString(SpriteFont font, string value, Vector2 position, Color color)
        {
            ScreenManager.SpriteBatch.DrawString(font, value, position + new Vector2(1.0f, 1.0f), Color.Black);
            ScreenManager.SpriteBatch.DrawString(font, value, position, color);
        }

        #endregion
    }
}
