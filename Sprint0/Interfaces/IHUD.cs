using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/

/*
 * Alexander Clayton CSE 3902 09/15/2021
 */
namespace Sprint0.Interfaces
{
    /*
     * This interface can be used for all blocks, which should just involve replacing the texture.
     */
    public interface IHUD
    {
        public void TogglePause();
        public void SetScore(int score);
        public int GetScore();
        public void SetTimeLeft(float time);
        public void SetMaxPlayerPosition(float position);
        public float GetMaxPlayerPosition();
        public float GetTimeLeft();
        public void SetCoin(int coin);
        public int GetCoins();
        public void SetLives(int lives);
        public int GetLives();
        public void ResetLevel();
        public void ResetGame();
        public void Update();
        public void Draw(SpriteBatch spriteBatch, ICamera camera);
        public void WinGame();
    }

}