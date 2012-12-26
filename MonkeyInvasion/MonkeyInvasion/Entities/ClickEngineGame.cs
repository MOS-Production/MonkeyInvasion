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
    class ClickEngineGame : BaseGame
    {
        // Entities in the Game.
        public Player Player
        {
            get { return player; }
        }
        Player player;


        private List<ClickableObject> clickableEntities = new List<ClickableObject>();

        private Random random = new Random(354668); // Arbitrary, but constant seed
  

        #region Loading

        //Constructs a new Game
        public ClickEngineGame(IServiceProvider serviceProvider)
        {

            // Create a new content manager to load content used just by this level.
            this.Content = new ContentManager(serviceProvider, "Content");


            //TODO LOAD STUFF! 
            player = new Player(this, new Vector2(250, 250));

            ClickableObject obj = new ClickableObject(this, new Vector2(150, 150), "Sprites/MonsterA/");
            clickableEntities.Add(obj);
            
        }


        #endregion


        #region Update

        /// <summary>
        /// Updates all objects in the world, performs collision between them,
        /// and handles the time limit with scoring.
        /// </summary>
        public void Update(GameTime gameTime)
        {

            //TODO UPDATE!
                Player.Update(gameTime);

                foreach (ClickableObject obj in clickableEntities)
                {
                    obj.Update(gameTime);
                }


        }

        #endregion

        #region Draw

        /// <summary>
        /// Draw everything in the level from background to foreground.
        /// </summary>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            //TODO: DRAW STUFF

            Player.Draw(gameTime, spriteBatch);


            foreach (ClickableObject obj in clickableEntities)
            {
                obj.Draw(gameTime, spriteBatch);
            }
            

        }


        #endregion



    }
}
