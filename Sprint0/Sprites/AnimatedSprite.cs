using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Threading;
using Sprint0.Interfaces;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
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
        private int waitTime = 2;
        private int currentTime = 0;
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
            //We can't use thread.sleep, it sleeps the entire game making it run slowly, so we need a better system for slowing down animation!
            //Thread.Sleep(5); //get fps equation
            if (currentTime > waitTime)
            {
                currentTime = 0;
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
            }
            else
            {
                currentTime++;
            }
        }
        public void Draw(SpriteBatch _spriteBatch, Vector2 location)
        {
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            Rectangle sourceRectangle = new Rectangle(0, 0,0, 0);
            Rectangle destinationRectangle = new Rectangle(0, 0, 0, 0); 
             sourceRectangle = new Rectangle(Xlist[currentFrame], Ylist[currentFrame], width, height);
             destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width* 2, height*2);
            _spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
