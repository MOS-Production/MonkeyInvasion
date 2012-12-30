using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonkeyInvasion.GameStateManagement;

namespace MonkeyInvasion.Controls
{
    public class Control
    {

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        string text;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        bool enabled;

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        Color color;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        Vector2 position;

        public Vector2 Size
        {
            get { return size; }
            set { size = value; }
        }
        Vector2 size;

        public SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }
        SpriteFont font;

        public Control() : this(Vector2.Zero)
        {

        }

        public Control(Vector2 position)
        {
            this.Position = position;
            text = " ";
            name = " ";
            enabled = true;
            color = Color.White;                        

        }


        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void UpdateInput(InputState input)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}
