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
// Alex Clayton 09/15/21 modified by Owen Tishenkel 9/28/21
namespace Sprint0
{
    public interface ILink
    {
        // Interface for items that link has such as his Sword, arrows, boomerang, bombs, blue candle, etc.
        // These would be like commands in a way, since having it seleceted and pressing A, for example, would cause Link to attack with his sword, executing the sword attack.
        void Update();
        void Execute();
        void Draw(SpriteBatch spritebatch);
        /*Movement Centric code, MoveDirection code changes the facing of Link and moves him in that direction*/
        void MoveLeft();
        void MoveRight();
        void MoveUp();
        void MoveDown();
        void StopMoving(string sourceDirection);
        void PrimaryAttack();
        void Jump();

        void SecondaryAttack(String attackType);
        void TakeDamage();
        void OnStateChange();
    }
}
