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
        private IHUDState hudState;
        private float initialPlayerPosition;
        private float maxPlayerPosition;
        private int initialLives = 3;
        private int lives = 3;
        private int initialScore = 0;
        private int initialCoinCount = 0;
        private int coinCount = 0;
        private int score = 0;
        private int initialTime = 100;
        private float timeLeft = 100;
        private IGameObject gameObject;
        private int level = 1;
        private bool paused = false;
        private IHUDState previousState;
        public HUD(IGameObject go)
        {
            hudState = new DefaultHUD(go, this);
            gameObject = go;
            maxPlayerPosition = gameObject.Position.X;
            initialPlayerPosition = gameObject.Position.X;
        }
        public void TogglePause()
        {
            paused = !paused;

            // when we click pause save the previous state
            // and display the pause menu
            if (paused)
            {
                Game0.Instance.isPaused = true;
                previousState = hudState;
                hudState = new PauseScreen();
            }
            else
            {
                Game0.Instance.isPaused = false;
                hudState = previousState;
            }
        }
        public float GetTimeLeft()
        {
            return timeLeft;
        }
        public void SetTimeLeft(float time)
        {
            timeLeft = time;
        }
        public int GetScore()
        {
            return score;
        }
        public void SetScore(int score)
        {
            this.score = score;
        }
        public void SetCoin(int coin)
        {
            score += GameUtilities.coinVal;
            // coin = coin count add a life and reset coins
            if (coinCount == GameUtilities.coinVal)
            {
                coinCount = 0;
                lives += 1;
            }
            else
            {
                coinCount = coin;
            }
        }
        public int GetCoins()
        {
            return coinCount;
        }
        public void SetLives(int lives)
        {
            this.lives = lives;
            if (this.lives == 0)
                hudState = new GameOverScreen(gameObject, this);
        }
        public int GetLives()
        {
            return lives;
        }
        public void ResetLevel()
        {
            maxPlayerPosition = initialPlayerPosition;
            timeLeft = initialTime;
            score = initialScore;
            coinCount = initialCoinCount;
            hudState = new DefaultHUD(gameObject, this);
        }
        public void ResetGame()
        {
            ResetLevel();
            lives = initialLives;
            hudState = new DefaultHUD(gameObject, this);

        }
        public void WinGame()
        {
            hudState = new WinScreen(gameObject, this);
        }
        public void SetMaxPlayerPosition(float position)
        {
            maxPlayerPosition = position;
        }

        public float GetMaxPlayerPosition()
        {
            return maxPlayerPosition;
        }
        public void Update()
        {
            hudState.Update();
        }
        public void Draw(SpriteBatch spriteBatch, ICamera camera)
        {
            hudState.Draw(spriteBatch, camera);
        }
    }
}
