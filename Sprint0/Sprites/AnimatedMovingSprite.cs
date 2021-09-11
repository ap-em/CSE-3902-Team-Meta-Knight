using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    class AnimatedMovingSprite : ISprite
    {


        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        public AnimatedMovingSprite(Texture2D texture, int rows, int columns)
        {
            //   ISprite mySprite = SpriteController.Instance.CreateGoldDoggo();
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            //totalFrames = 2; // There are only two frames for each direction.
        }

        public void Draw(SpriteBatch spritebatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            //int width = 16;
            //int height = 16;


            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);  // Source rectangle is the sprite taken off the sprite sheet
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height); // Destnation rectangle is where you want to put the sprite.

            spritebatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        }


    }
}
