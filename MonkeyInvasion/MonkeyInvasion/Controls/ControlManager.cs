using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

using MonkeyInvasion.GameStateManagement;

namespace MonkeyInvasion.Controls
{
    public class ControlManager
    {

        Dictionary<string, Control> controls;

        public ControlManager()
        {

            controls = new Dictionary<string, Control>();

        }


        public void Update(GameTime gameTime)
        {

            foreach (var control in controls)
            {

                control.Value.Update(gameTime);

            }

        }

        public void UpdateInput(InputState input)
        {

            foreach (var control in controls)
            {

                control.Value.UpdateInput(input);

            }

        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {

            foreach (var control in controls)
            {                
                control.Value.Draw(spriteBatch);
            }

        }



        public Control GetControl(string key)
        {

            return controls[key];

        }

        public void AddControl(string key, Control value)
        {

            controls.Add(key, value);

        }

        public void RemoveControl(string key)
        {

            controls.Remove(key);

        }
    }
}
