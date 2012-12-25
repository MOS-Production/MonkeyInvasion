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
    /// <summary>
    /// A uniform grid of tiles with collections of gems and enemies.
    /// The level owns the player and controls the game's win and lose
    /// conditions as well as scoring.
    /// </summary>
    class Level : IDisposable
    {        
        // Physical structure of the level.
        //private Tile[,] tiles;
        private Texture2D[] layers;
        // The layer which entities are drawn on top of.
        private const int EntityLayer = 2;

        // Entities in the level.
        public Player Player
        {
            get { return player; }
        }
        Player player;

        private List<Enemy> enemies = new List<Enemy>();

        private Random random = new Random(354668); // Arbitrary, but constant seed

        // Level content.        
        public ContentManager Content
        {
            get { return content; }
        }
        ContentManager content;


        #region Loading

        /// <summary>
        /// Constructs a new level.
        /// </summary>
        /// <param name="serviceProvider">
        /// The service provider that will be used to construct a ContentManager.
        /// </param>
        /// <param name="path">
        /// The absolute path to the level file to be loaded.
        /// </param>
        public Level(IServiceProvider serviceProvider, string path)
        {
            // Create a new content manager to load content used just by this level.
            content = new ContentManager(serviceProvider, "Content");
           

            //TODO LOAD STUFF!
            

            // Load background layer textures. For now, all levels must
            // use the same backgrounds and only use the left-most part of them.
            //layers = new Texture2D[3];
            //for (int i = 0; i < layers.Length; ++i)
            //{
            //    // Choose a random segment if each background layer for level variety.
            //    int segmentIndex = random.Next(3);
            //    layers[i] = Content.Load<Texture2D>("Backgrounds/Layer" + i + "_" + segmentIndex);
            //}


        }    

 
        /// <summary>
        /// Unloads the level content.
        /// </summary>
        public void Dispose()
        {
            Content.Unload();
        }

        #endregion

        #region Bounds and collision



        #endregion

        #region Update

        /// <summary>
        /// Updates all objects in the world, performs collision between them,
        /// and handles the time limit with scoring.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            // Pause while the player is dead or time is expired.
            if (!Player.IsAlive)
            {
                // Still want to perform physics on the player.
                Player.ApplyPhysics(gameTime);
            }      
            else
            {                

                Player.Update(gameTime);

                UpdateEnemies(gameTime);


            }

        }

        /// <summary>
        /// Animates each enemy and allow them to kill the player.
        /// </summary>
        private void UpdateEnemies(GameTime gameTime)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Update(gameTime);

                // Touching an enemy instantly kills the player
                if (enemy.BoundingRectangle.Intersects(Player.BoundingRectangle))
                {
                    OnPlayerKilled(enemy);
                }
            }
        }

 
        /// <summary>
        /// Called when the player is killed.
        /// </summary>
        /// <param name="killedBy">
        /// The enemy who killed the player. This is null if the player was not killed by an
        /// enemy, such as when a player falls into a hole.
        /// </param>
        private void OnPlayerKilled(Enemy killedBy)
        {
            Player.OnKilled(killedBy);
        }
   

        /// <summary>
        /// Restores the player to the starting point to try the level again.
        /// </summary>
        public void StartNewLife()
        {
            //Player.Reset(start);
        }

        #endregion

        #region Draw

        /// <summary>
        /// Draw everything in the level from background to foreground.
        /// </summary>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int i = 0; i <= EntityLayer; ++i)
                spriteBatch.Draw(layers[i], Vector2.Zero, Color.White);

            
            //foreach (Gem gem in gems)
            //    gem.Draw(gameTime, spriteBatch);

            Player.Draw(gameTime, spriteBatch);

            foreach (Enemy enemy in enemies)
                enemy.Draw(gameTime, spriteBatch);

            for (int i = EntityLayer + 1; i < layers.Length; ++i)
                spriteBatch.Draw(layers[i], Vector2.Zero, Color.White);
        }


        #endregion
    }
}
