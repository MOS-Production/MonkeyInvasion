using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using MonkeyInvasion.GameStateManagement;
using MonkeyInvasion.Utilities;

namespace MonkeyInvasion.Controls
{

    public enum ButtonStatus
    {
        Idle,
        Down,
        Clicked,
        Hover
    }


    public class Button : Control
    {

        //TODO - extend this to be animations instead!
        Texture2D texture;

        //TODO - extend this to be animations instead!
        Texture2D touchOverlay;

        //TODO add animations for hover, press etc

        Rectangle bounds;

        ButtonStatus Status = ButtonStatus.Idle;

        public event EventHandler Clicked;

        public event EventHandler Down;


        public new Vector2 Position
        {
            get { return base.Position; }
            set
            {
                base.Position = value;
                bounds = new Rectangle((int)base.Position.X, (int)base.Position.Y, texture.Width, texture.Height);
            }
        }

        public Button(Texture2D texture, Texture2D touchedOverlay, Vector2 position, string text)
            : base(position)
        {

            base.Text = text;
            this.texture = texture;
            this.touchOverlay = touchedOverlay; //TODO change this one..
            bounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

        }


        public override void UpdateInput(InputState input)
        {
            if (Enabled)
            {               
                //KeyboardState keyboardState = input.CurrentKeyboardStates[0];
             
                MouseState mouseState = Mouse.GetState();

                    if (ContainsPos(new Vector2(mouseState.X, mouseState.Y)))
                    {

                        //TODO handle down etc..
                        
                        if(mouseState.LeftButton.Equals(ButtonState.Pressed)){

                            Status = ButtonStatus.Clicked;                            
                            if(Clicked != null){
                                //fire  click event!                               
                                Clicked(this, EventArgs.Empty);
                            }

                        }else{
                            Status = ButtonStatus.Hover;

                        }

                    }else{
                        Status = ButtonStatus.Idle;

                    }

             }

        }

        protected bool ContainsPos(Vector2 pos)
        {
            return bounds.Contains((int)pos.X, (int)pos.Y);
        }


        public override void Draw(SpriteBatch spriteBatch)
        {

            if (Enabled)
            {

                spriteBatch.Draw(texture, bounds, Color);

                if (Status == ButtonStatus.Hover)
                {
                    if (touchOverlay != null)
                    {
                        spriteBatch.Draw(touchOverlay, bounds, Color);
                    }

                }

                if (Font != null)
                {                   
                    DrawingUtils.DrawCenteredText(spriteBatch, Font, bounds, Text, Color);
                }

                //Status = ButtonStatus.Up;

            }

        }





    }
}
