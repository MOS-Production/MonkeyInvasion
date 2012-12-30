using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonkeyInvasion.GameStateManagement;

namespace MonkeyInvasion.Controls
{
    public class PictureBox : Control
    {
        
        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        Texture2D texture;

        public PictureBox(Vector2 position, Texture2D texture) : base(position)
        {
            this.Texture = texture;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            if (Enabled)
            {
                if (Size.Equals(Vector2.Zero))
                {
                    Size = Vector2.One;
                }
                spriteBatch.Draw(Texture, Position, null, Color, 0.0f, Vector2.Zero, Size, SpriteEffects.None, 0.0f);
                //spriteBatch.Draw(Texture, Position, Color);
                

            }

            base.Draw(spriteBatch);

        }
    }
}
