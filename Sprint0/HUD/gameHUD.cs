using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.UtilityClasses;
namespace Sprint0.HUD
{
    public class gameHUD : IHUD
    {
        private int time;
        private bool isGameOver = false;
        private bool timeUp = false;
        public gameHUD(Mario mario)
        {
            Score.marioScore = 0;
            Score.coins = 0;
            time = GameUtilities.startTime;

        }
            
        public void draw(SpriteBatch batch, SpriteFont font)
        {
             batch.Begin();
            batch.DrawString(font, GameUtilities.MARIO + GameUtilities.TAB + GameUtilities.COINS + GameUtilities.TAB + GameUtilities.LIVES + GameUtilities.TAB + GameUtilities.TIME+ GameUtilities.TAB + GameUtilities.WORLD, new Vector2(10, 10), Color.White);

            batch.DrawString(font, Score.marioScore.ToString() + GameUtilities.TAB +Score.coins.ToString() + GameUtilities.TAB +Score.lives.ToString() + GameUtilities.TAB + time.ToString() + GameUtilities.TAB + "1-1", new Vector2(10, 25), Color.White);
            // TO DO: Test the format of the HUD

            if (isGameOver)
            {
                // TO DO: draw game over;
                batch.DrawString(font, GameUtilities.GAMEOVER, new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2, GraphicsDeviceManager.DefaultBackBufferHeight / 2), Color.White);
                time = GameUtilities.startTime;
                Score.marioScore = 0;
                Score.coins = 0;
                Score.lives = 3; // eliminate magic number 
            }
            else if (timeUp)
            {
                batch.DrawString(font, GameUtilities.TIMEUP, new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2, GraphicsDeviceManager.DefaultBackBufferHeight / 2), Color.White);
                time = GameUtilities.startTime;
                Score.marioScore = 0;
                Score.coins = 0;
            }
            // TO DO: game complete
        }

        public void update()
        {
            if(time < 60)
            {
                // play hurry sound
            }
            if (time == 0 )
            {
                Score.lives--;
                timeUp = true;
                // TO DO: draw death state
            }
           else if (Score.lives == 0)
            {
                //TO DO: game over state;
                isGameOver = true;
            }
            else
            {
                timeUp = false;
            }


        }
       private string  scoreTextFormat(int score) {
            string text = "";
            return text;
        }
        private string coinsTextFormat(int coins)
        {
            string text = "";
            return text;
        }
        private string livesTextFormat(int lives)
        {
            string text = "";
            return text;
        }
    }
}
