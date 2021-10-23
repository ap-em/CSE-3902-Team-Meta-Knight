using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
// Alex Clayton 09/15/21 modified by Owen Tishenkel 9/28/21
namespace Sprint0
{
    public interface IMario
    {
        // Interface for items that Mario has such as his Sword, arrows, boomerang, bombs, blue candle, etc.
        // These would be like commands in a way, since having it seleceted and pressing A, for example, would cause Mario to attack with his sword, executing the sword attack.
        void Update();
        void Draw(SpriteBatch spritebatch);
        /*Movement Centric code, MoveDirection code changes the facing of Mario and moves him in that direction*/
        void MoveLeft();
        void MoveRight();
        void PrimaryAttack();
        void Jump();
        void TakeDamage();
        void MushroomPower();
        void FireflowerPower();
        void StarPower();
        void OnStateChange();
        void StopMovingHorizontal();
        void StopMovingVertical();
        public void UpBounce(Rectangle rectangle);
        public void DownBounce(Rectangle rectangle);
        public void RightBounce(Rectangle rectangle);
        public void LeftBounce(Rectangle rectangle);
    }
}
