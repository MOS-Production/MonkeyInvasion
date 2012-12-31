using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonkeyInvasion.GameStateManagement;

namespace MonkeyInvasion.Controls
{
    public class Label : Control
    {

        public Label(string text, Vector2 position, SpriteFont font)
            : base(position)
        {
            this.Text = text;
            Font = font;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            if (Enabled)
            {

                spriteBatch.DrawString(Font, Text, Position, Color);                

            }

            base.Draw(spriteBatch);

        }

    }
}
