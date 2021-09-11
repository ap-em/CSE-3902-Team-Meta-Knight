using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    class AnimatedFixedSprite : ISprite
    {


        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        public AnimatedFixedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }

        public void Draw(SpriteBatch spritebatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;


            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);  // Source rectangle is the sprite taken off the sprite sheet
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height); // Destnation rectangle is where you want to put the sprite.

            spritebatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame > 1)
            {
                currentFrame = 0;
            }
        }


    }
}
