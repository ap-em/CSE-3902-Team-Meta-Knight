using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    class MovingStaticSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private int moveY;
    public MovingStaticSprite(Texture2D texture, int rows, int columns)
        {
            //   ISprite mySprite = SpriteController.Instance.CreateGoldDoggo();
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            moveY = 0;
        }

        public void Draw(SpriteBatch spritebatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;
            
            if (location.Y > height || location.Y < 0) { location.Y = height; }

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X , (int) location.Y + moveY, width, height);

            spritebatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            // Moving sprite but without animation.
            //  currentFrame++;
            moveY++;
        //    if (currentframe == totalframes)
          //  {
            //    currentframe = 0;
            //}
        }

    }

    }

