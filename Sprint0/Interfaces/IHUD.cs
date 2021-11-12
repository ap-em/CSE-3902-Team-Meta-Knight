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
        public void Update();
        public int GetIndex();
        public Vector2 GetPosition();
        public void Draw(SpriteBatch spriteBatch, ICamera camera);
        public void AddScore(int increment);
        public void AddCoin(int increment);
        public int getCoinCount();
        public void ResetCoin();
        public void AddLife();
        public void RemoveLife();
        public int GetLives();
        public int GetLevel();
        public void SetLevel(int level);
        public void Reset();

    }

}