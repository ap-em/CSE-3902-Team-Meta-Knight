using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Enemies
{
    class ChargeEnemyAttackState : IEnemyState
    {
        private IEnemy enemy;
        private string ID = "ChargeEnemyAttackState";
        private static int attackTime = 600;
        private Vector2 velocity;
        private bool grounded;

        public ChargeEnemyAttackState(IEnemy enemyRef)
        {
            enemy = enemyRef;
        }
        public void BigUpBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void DownBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public bool GetGrounded()
        {
            return grounded;
        }

        public void GetKicked(Rectangle rec)
        {
            throw new NotImplementedException();
        }

        public string GetStateID()
        {
            throw new NotImplementedException();
        }

        public Vector2 GetVelocity()
        {
            return velocity;
        }

        public void LeftBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void MoveLeft()
        {

        }

        public void MoveRight()
        {

        }

        public void RightBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void SetGrounded(bool grounded)
        {
            this.grounded = grounded;
        }

        public void SetXVelocity(float x)
        {
            throw new NotImplementedException();
        }

        public void SetYVelocity(float y)
        {
            throw new NotImplementedException();
        }

        public void TakeDamage()
        {
            throw new NotImplementedException();
        }

        public void UpBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
