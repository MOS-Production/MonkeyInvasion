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
    public abstract class BaseGame
    {

        // Game Content.        
        public ContentManager Content
        {
            get { return content; }
            set { content = value; }
        }
        ContentManager content;

        #region Loading

        /// <summary>
        /// Unloads the game content.
        /// </summary>
        public virtual void Dispose()
        {
            Content.Unload();
        }
        #endregion

    }
    
}
