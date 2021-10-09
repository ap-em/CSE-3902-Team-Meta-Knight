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
namespace Sprint0.Interfaces
{
    public interface IEnemy
    {

        void Update();
        void FireProjectile();
        void SetEnemyType(String enemyType);
        String GetEnemyType();
        void SetStateMachineSprite();
        void MoveRight();
        void MoveLeft();
        void MoveUp();
        void MoveDown();
        void SetXVelocity(int x);
        void SetYVelocity(int y);
        void NextEnemy();
        void PrevEnemy();
        void SetKeyboard(IKeyboardController keyboard);
        IKeyboardController GetKeyboard();
        void Draw(SpriteBatch spriteBatch);
    }
}
