using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Enemies
{
    class ChargeEnemySquashedState : IEnemyState
    {
        IEnemy enemy;
        private string ID = "ChargeEnemySquashedState";
        public ChargeEnemySquashedState(IEnemy enemyRef)
        {
            enemy = enemyRef;
        }
        public void BigUpBounce(Rectangle rectangle)
        {
        }

        public void DownBounce(Rectangle rectangle)
        {
        }

        public bool GetGrounded()
        {
            return false;
        }

        public void GetKicked(Rectangle rec)
        {
        }

        public string GetStateID()
        {
            return ID;
        }

        public Vector2 GetVelocity()
        {
            return Vector2.Zero;
        }

        public void LeftBounce(Rectangle rectangle)
        {
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }

        public void RightBounce(Rectangle rectangle)
        {
        }

        public void SetGrounded(bool grounded)
        {
        }

        public void SetXVelocity(float x)
        {
        }

        public void SetYVelocity(float y)
        {
        }

        public void TakeDamage()
        {
        }

        public void UpBounce(Rectangle rectangle)
        {
        }

        public void Update()
        {
        }
    }
}
