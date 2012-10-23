using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using MonkeyInvasion.Tiles;

namespace MonkeyInvasion
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TileMap myMap = new TileMap();
        int squaresAcross = 15;
        int squaresDown = 15;

        Texture2D mControllerDetectScreenBackground;

        bool mIsControllerDetectScreenShown;
        bool mIsTitleScreenShown;

        PlayerIndex mPlayerOne;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Changes the resolutin of the window
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            
            //Set this for fullscreen
            //graphics.IsFullScreen = true;

            //Applys the changes
            graphics.ApplyChanges();

        }



        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }



        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Tile.TileSetTexture = Content.Load<Texture2D>(@"Textures/part1_tileset");

            mControllerDetectScreenBackground = Content.Load<Texture2D>("ControllerDetectScreen");

            mIsTitleScreenShown = false;
            mIsControllerDetectScreenShown = true;

            // TODO: use this.Content to load your game content here
        }



        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }



        protected override void Update(GameTime gameTime)
        {
            //Gets the state of the keyboard and gamepad
            KeyboardState ks = Keyboard.GetState();
            GamePadState gs = GamePad.GetState(PlayerIndex.One);

            // Allows the game to exit
            if (gs.Buttons.Back == ButtonState.Pressed || ks.IsKeyDown(Keys.Escape))
                this.Exit();


            if (mIsControllerDetectScreenShown)
            {
                UpdateControllerDetectScreen();
            }
            else
            {
                UpdateTileMap(ks);
            }

            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //DisplayTileMap();

            if (mIsControllerDetectScreenShown)
            {
                DrawControllerDetectScreen();
            }
            else 
            {
                DisplayTileMap();
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }



        private void UpdateControllerDetectScreen()
        {
            for (int aPlayer = 0; aPlayer < 4; aPlayer++)
            {
                if (GamePad.GetState((PlayerIndex)aPlayer).Buttons.A == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.A) == true)
                {
                    mPlayerOne = (PlayerIndex)aPlayer;
                    mIsControllerDetectScreenShown = false;
                    return;
                }
            }
        }



        private void UpdateTileMap(KeyboardState ks)
        {
            if (GamePad.GetState(mPlayerOne).Buttons.A == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.B) == true)
            {
                mIsControllerDetectScreenShown = true;
                return;
            }

            if (ks.IsKeyDown(Keys.Left))
            {
                Camera.Location.X = MathHelper.Clamp(Camera.Location.X - 2, 0, (myMap.MapWidth - squaresAcross) * 32);
            }

            if (ks.IsKeyDown(Keys.Right))
            {
                Camera.Location.X = MathHelper.Clamp(Camera.Location.X + 2, 0, (myMap.MapWidth - squaresAcross) * 32);
            }

            if (ks.IsKeyDown(Keys.Up))
            {
                Camera.Location.Y = MathHelper.Clamp(Camera.Location.Y - 2, 0, (myMap.MapHeight - squaresDown) * 32);
            }

            if (ks.IsKeyDown(Keys.Down))
            {
                Camera.Location.Y = MathHelper.Clamp(Camera.Location.Y + 2, 0, (myMap.MapHeight - squaresDown) * 32);
            }

        }


        private void DrawControllerDetectScreen()
        {
            spriteBatch.Draw(mControllerDetectScreenBackground, Vector2.Zero, Color.White);
        }


        private void DisplayTileMap()
        {
            Vector2 firstSquare = new Vector2(Camera.Location.X / 32, Camera.Location.Y / 32);
            int firstX = (int)firstSquare.X;
            int firstY = (int)firstSquare.Y;

            Vector2 squareOffset = new Vector2(Camera.Location.X % 32, Camera.Location.Y % 32);
            int offsetX = (int)squareOffset.X;
            int offsetY = (int)squareOffset.Y;

            for (int y = 0; y < squaresDown; y++)
            {
                for (int x = 0; x < squaresAcross; x++)
                {
                    spriteBatch.Draw(
                        Tile.TileSetTexture,
                        new Rectangle((x * 32) - offsetX, (y * 32) - offsetY, 32, 32),
                        Tile.GetSourceRectangle(myMap.Rows[y + firstY].Columns[x + firstX].TileID),
                        Color.White);
                }
            }
        }

    }
}
