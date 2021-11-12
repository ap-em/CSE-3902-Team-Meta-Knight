using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Player.State_Machines.States.GameStates;
using Sprint0.UtilityClasses;
namespace Sprint0.HUD
{
    public class gameHUD : IHUD
    {
        private int time;
        private bool isGameOver = false;
        private bool timeUp = false;
        private int counter = 0;
       
        public gameHUD()
        {
            Score.marioScore = 0;
            Score.coins = 0;
            time = GameUtilities.startTime;
         

        }
            
        public void draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            
            spriteBatch.DrawString(font, GameUtilities.MARIO + GameUtilities.TAB + GameUtilities.COINS + GameUtilities.TAB + GameUtilities.LIVES + GameUtilities.TAB + GameUtilities.TIME+ GameUtilities.TAB + GameUtilities.WORLD, new Vector2(10, 10), Color.White);

            spriteBatch.DrawString(font, scoreTextFormat(Score.marioScore) + GameUtilities.TAB + coinsTextFormat(Score.coins) + GameUtilities.TAB + GameUtilities.TAB+ livesTextFormat(Score.lives) + GameUtilities.TAB  +GameUtilities.TAB+GameUtilities.TAB+ GameUtilities.TAB + time.ToString() + GameUtilities.TAB+ GameUtilities.TAB + "1-1", new Vector2(10, 25), Color.White);
            // TO DO: Test the format of the HUD

            if (isGameOver)
            {
                // TO DO: draw game over;
                GameOverState.Instance.Draw(spriteBatch);
                GameOverState.Instance.GameOver();
                //spriteBatch.DrawString(font, GameUtilities.GAMEOVER, new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2, GraphicsDeviceManager.DefaultBackBufferHeight / 2), Color.White);
                time = GameUtilities.startTime;
                Score.marioScore = 0;
                Score.coins = 0;
                Score.lives = 3; // eliminate magic number 
            }
            else if (timeUp)
            {
                spriteBatch.DrawString(font, GameUtilities.TIMEUP, new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2, GraphicsDeviceManager.DefaultBackBufferHeight / 2), Color.White);
                time = GameUtilities.startTime;
                Score.marioScore = 0;
                Score.coins = 0;
            }
          
         
        }

        public void Update()
        {
            // count the time 
            counter++;
            if (counter == GameUtilities.FPS)
            {
                time--;
                counter = 0;
            }
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
           
            int gameScore = score;
            String text = "";
            for (int i = 0; i < 6; i++)
            {
                text = (gameScore % 10) + text;
                gameScore /= 10;
            }
            return text;
        }
        private string coinsTextFormat(int coins)
        {
            string text = "";
            if (coins < 10)
            {
                text = "0" + coins.ToString();
            }
            else
            {
                text = coins.ToString();
            }
            return text;
        }
        private string livesTextFormat(int lives)
        {
            string text = "";
            if (lives < 10)
            {
                text = "0" + lives.ToString();
            }
            else
            {
                text = lives.ToString();
            }
          
            return text;
        }
    }
}
