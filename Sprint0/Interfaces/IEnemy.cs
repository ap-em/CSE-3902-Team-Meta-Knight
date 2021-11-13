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
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; }
        void Update();
        void SetSprite(String spriteName);
        String GetSpriteName();
        void MoveRight();
        void MoveLeft();
        void SetXVelocity(float x);
        void SetYVelocity(float y);
        Vector2 GetVelocity();
        String GetDirection();
        void Draw(SpriteBatch spriteBatch);
        void TakeDamage();
        void InstantDeath();
        int GetHealth();
        void SetHealth(int health);
        void SetCurrentState(IEnemyState enemyState);
        void SetGrounded(bool grounded);
        void SetRemovalTimer(int timer);
    }
}
