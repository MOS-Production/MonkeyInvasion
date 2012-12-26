using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonkeyInvasion.Graphics;
using MonkeyInvasion.Utilities;

namespace MonkeyInvasion.Entities
{
    class ClickableObject
    {

        // Animations
        private Animation idleAnimation;
        private Animation hoverAnimation;
        private Animation clickAnimation;        
        private SpriteEffects flip = SpriteEffects.None;
        private AnimationPlayer sprite;

        private bool clicked = false;
        private bool hover = false;

        public BaseGame Game
        {
            get { return game; }
        }
        BaseGame game;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        Vector2 position;

        private Rectangle localBounds;
        /// <summary>
        /// Gets a rectangle which bounds this entity in world space.
        /// </summary>
        public Rectangle BoundingRectangle
        {
            get
            {
                int left = (int)Math.Round(Position.X - sprite.Origin.X) + localBounds.X;
                int top = (int)Math.Round(Position.Y - sprite.Origin.Y) + localBounds.Y;

                return new Rectangle(left, top, localBounds.Width, localBounds.Height);
            }
        }

                /// <summary>
        /// Constructors a new player.
        /// </summary>
        public ClickableObject(BaseGame game, Vector2 position, String spriteSet)
        {
            this.game = game;
            LoadContent(spriteSet);
            Reset(position);
        }

        /// <summary>
        /// Loads the object sprite sheet.
        /// </summary>
        public void LoadContent(String spriteSet)
        {

            // Load animated textures.
            idleAnimation = new Animation(Game.Content.Load<Texture2D>(spriteSet+"Idle"), 0.1f, true);
            hoverAnimation = new Animation(Game.Content.Load<Texture2D>(spriteSet + "Run"), 0.1f, true);
            clickAnimation = new Animation(Game.Content.Load<Texture2D>(spriteSet + "Die"), 0.1f, true);

            // Calculate bounds within texture size.            
            int width = (int)(idleAnimation.FrameWidth * 0.4);
            int left = (idleAnimation.FrameWidth - width) / 2;
            int height = (int)(idleAnimation.FrameWidth * 0.8);
            int top = idleAnimation.FrameHeight - height;
            localBounds = new Rectangle(left, top, width, height);


        }

        /// <summary>
        /// Resets the objecte.
        /// </summary>
        /// <param name="position">The position to come appear at.</param>
        public void Reset(Vector2 position)
        {
            Position = position;
            sprite.PlayAnimation(idleAnimation);
        }


        /// <summary>
        /// Handles input, performs physics, and animates the player sprite.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            GetInput();            

                if (clicked)
                {
                    sprite.PlayAnimation(clickAnimation);

                }
                else  if (hover)
                {
                    sprite.PlayAnimation(hoverAnimation);
                }
                else
                {
                    sprite.PlayAnimation(idleAnimation);
                }            

            // Clear input.
                clicked = false;
                hover = false;

        }

        /// <summary>
        /// Gets player horizontal movement and jump commands from input.
        /// </summary>
        private void GetInput()
        {
            // Get input state.
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();


            //get mouse pointer position
            int mouseX = mouseState.X;
            int mouseY = mouseState.Y;

            //first, check for collisions
            bool mouseOver = false;

            if ((mouseX >= BoundingRectangle.Left && mouseX <= BoundingRectangle.Right) && (mouseY >= BoundingRectangle.Top && mouseY <= BoundingRectangle.Bottom))
            {
                mouseOver = true;
            }

            //then, if mouse over, check for button states
            if(mouseOver){
                if(mouseState.LeftButton.Equals(ButtonState.Pressed)){
                    clicked = true;
                }else{
                    hover = true;
                    //clicked = false;
                }                               

            }                      


        }


            /// <summary>
        /// Draws the object.
        /// </summary>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {         

            // Draw that sprite.
            sprite.Draw(gameTime, spriteBatch, Position, flip);
        }




    }
}
