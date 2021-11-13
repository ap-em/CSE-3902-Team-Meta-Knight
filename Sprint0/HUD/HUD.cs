using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Commands;
using Sprint0.Interfaces;
using Sprint0.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0.HUD
{
    public class HUD: IHUD
    {
        private SpriteFont font;
        private Vector2 position;
        private float initialPlayerPosition;
        private float maxPlayerPosition;
        private int initialLives = 3;
        private int lives = 3;
        private int initialScore = 0;
        private int initialCoinCount = 0;
        private int coinCount = 0;
        private int score = 0;
        private int index = 0;
        private int initialTime = 100;
        private float timeLeft = 100;
        private IGameObject gameObject;
        private int counter = 0;
        private int level = 1;
        private double gameOverTime =0;
        public HUD(IGameObject go, int index)
        {
            font = Game0.Instance.Content.Load<SpriteFont>("Font");
            this.index = index;
            gameObject = go;
            maxPlayerPosition = gameObject.Position.X;
            initialPlayerPosition = gameObject.Position.X;
        }

        public int GetIndex()
        {
            return index;
        }

        public Vector2 GetPosition()
        {
            return position;
        }
        public void AddScore(int increment)
        {
            score += increment;
        }
        public void AddCoin(int increment)
        {
            coinCount += increment;
        }
        public void ResetCoin()
        {
            coinCount = initialCoinCount;
        }
        public void ResetLives()
        {
            lives = initialLives;
        }
        public int getCoinCount()
        {
            return coinCount;
        }
        public void AddLife()
        {
            lives++;
        }
        public void RemoveLife()
        {
            lives--;
        }
        public void Reset()
        {
            maxPlayerPosition = initialPlayerPosition;
            timeLeft = initialTime;
            score = initialScore;
            ResetCoin();
        }
        public int GetLives()
        {
            return lives;
        }

        public void Update()
        {
            timeLeft -= (float)Game0.Instance.TargetElapsedTime.TotalSeconds;

            if(gameObject.Position.X > maxPlayerPosition)
            {
                AddScore(1);
                maxPlayerPosition = gameObject.Position.X;
            }
            if (timeLeft == 0 && lives > 0)
            {
                lives--;
                new CReset((IMario)gameObject).Execute();
            }
            if (lives == 0)
            {
                gameOverTime += Game0.Instance.TargetElapsedTime.TotalSeconds;
                if (gameOverTime >= GameUtilities.gameOverTimerFinish)
                {
                    gameOverTime = 0;
                    new CResetGame((IMario)gameObject).Execute();
                }
                
            }
        }
        public void Draw(SpriteBatch spriteBatch, ICamera camera)
        {
            if (lives > 0)
            {
                int time = (int)timeLeft;

                //  draw on top left of screen
                spriteBatch.DrawString(font, "TIME LEFT: " + time.ToString(), new Vector2(camera.GetPosition().X, camera.GetPosition().Y), Color.White);

                // draw on top middle of screen
                spriteBatch.DrawString(font, "LIVES: " + lives.ToString(), new Vector2(camera.GetPosition().X + camera.GetViewport().Width / 2, camera.GetPosition().Y), Color.White);
                spriteBatch.DrawString(font, "LEVEL: " + level.ToString(), new Vector2(camera.GetPosition().X + camera.GetViewport().Width / 2, camera.GetPosition().Y + 20), Color.White);
                spriteBatch.DrawString(font, "COINS: " + coinCount.ToString(), new Vector2(camera.GetPosition().X + camera.GetViewport().Width /2-100, camera.GetPosition().Y), Color.White);

                //draw on top right of screen
                spriteBatch.DrawString(font, "SCORE: " + score.ToString(), new Vector2(camera.GetPosition().X + camera.GetViewport().Width - 100, camera.GetPosition().Y), Color.White);
            }
            else
            {
                spriteBatch.DrawString(font, "GAMEOVER: ", new Vector2(camera.GetPosition().X + camera.GetViewport().Width/ 2, camera.GetPosition().Y + camera.GetViewport().Height / 2), Color.White);
            }
        }

        public int GetLevel()
        {
            return level;
        }

        public void SetLevel(int level)
        {
            this.level = level;
        }
    }
}
