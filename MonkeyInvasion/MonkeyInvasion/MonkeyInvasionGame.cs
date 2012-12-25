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
using MonkeyInvasion.GameStateManagement;
using MonkeyInvasion.Screens;

namespace MonkeyInvasion
{

    public class MonkeyInvasionGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        ScreenManager screenManager; 

        public MonkeyInvasionGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Changes the resolutin of the window
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            
            //Set this for fullscreen
            //graphics.IsFullScreen = true;

            IsMouseVisible = true;

            //this.Window.AllowUserResizing = true;
            //this.Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);

            //Applys the changes
            graphics.ApplyChanges();

            // Create the screen manager component.
            screenManager = new ScreenManager(this);

            Components.Add(screenManager);

            // Activate the first screens.
            screenManager.AddScreen(new BackgroundScreen(), null);
            screenManager.AddScreen(new MainMenuScreen(), null);


        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);

            // The real drawing happens inside the screen manager component.
            base.Draw(gameTime);
        }


        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            // TODO: HANDLE Make changes to handle the new window size.            
        }


    }
}
