using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Threading;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    // Alex Contreras
    class AnimatedSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private int width;
        private int height;
        private int[] Xlist;
        private int[] Ylist;
        public AnimatedSprite(Texture2D texture, int[] x, int[] y, int w, int h, int rows, int columns) 
        {
            width = w;
            height = h;
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            Xlist = x;
            Ylist = y;
        }
        public void Update()
        {
            Thread.Sleep(54); //get fps equation
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }
        public void Draw(SpriteBatch _spriteBatch, Vector2 location)
        {
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            Rectangle sourceRectangle = new Rectangle(0, 0,0, 0);
            Rectangle destinationRectangle = new Rectangle(0, 0, 0, 0); 
             sourceRectangle = new Rectangle(Xlist[currentFrame], Ylist[currentFrame], width, height);
             destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width* 5, height*5);
            _spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
