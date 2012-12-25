using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.IO.IsolatedStorage;
using MonkeyInvasion.Graphics;
using MonkeyInvasion.Utilities;
using Microsoft.Xna.Framework.Media;


namespace MonkeyInvasion.Entities
{
    class MainGame
    {
        // Entities in the Game.

        //players, enemies etc etc etc...


        private Random random = new Random(354668); // Arbitrary, but constant seed

        // Game Content.        
        public ContentManager Content
        {
            get { return content; }
        }
        ContentManager content;

        #region Loading

        //Constructs a new Game
        public MainGame(IServiceProvider serviceProvider)
        {

            // Create a new content manager to load content used just by this level.
            content = new ContentManager(serviceProvider, "Content");


            //TODO LOAD STUFF! 

            //players, enemies etc etc...            

        }

        /// <summary>
        /// Unloads the game content.
        /// </summary>
        public void Dispose()
        {
            Content.Unload();
        }

        #endregion


        #region Update

        /// <summary>
        /// Updates all objects in the world, performs collision between them,
        /// and handles the time limit with scoring.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            //update stuff, players, enemies etc etc...


        }

        #endregion

        #region Draw

        /// <summary>
        /// Draw everything in the level from background to foreground.
        /// </summary>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {


            //DRAW STUFF, players, enemies etc etc...

        }


        #endregion



    }
}
