using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace MonkeyInvasion.Utilities
{
    public static class DrawingUtils
    {

        public static void DrawCenteredText(SpriteBatch batch, SpriteFont font, Rectangle rectangle, string text, Color color)
        {
            Vector2 size = font.MeasureString(text);
            Vector2 topLeft = Vector2.Subtract(new Vector2(rectangle.Center.X, rectangle.Center.Y), (size * 0.5f));
            batch.DrawString(font, text, topLeft, color);
        }

    }
}
