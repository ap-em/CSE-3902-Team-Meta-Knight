using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Levels
{
    sealed class Background
    {
        private static Background instance;
        Texture2D background;
        Rectangle dimensions;
        public static Background Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new Background();

                }
                return instance;
            }
        }

        //Sets 1-1 background as the default
        public Background()
        {
            background = Game0.Instance.Content.Load<Texture2D>("1-1");
            dimensions = new Rectangle(0, 0, 6750, 600);
        }
        //Changes background that is drawn
        public void ChangeBackground(String newBackground, Rectangle dimensions)
        {
            
            background = Game0.Instance.Content.Load<Texture2D>(newBackground);
            this.dimensions = dimensions;
        }
        //Draws background
        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(background,dimensions, Color.White);
        }

    }
}
