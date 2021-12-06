using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Timers;

namespace Sprint0.Enemies
{
    class BomberNormalState : IEnemyState
    {
        private IEnemy enemy;
        private Vector2 velocity;


        public BomberNormalState(IEnemy enemyRef)
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
            throw new NotImplementedException();
        }

        public void LeftBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public void MoveRight()
        {
            throw new NotImplementedException();
        }

        public void RightBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void SetGrounded(bool grounded)
        {
            throw new NotImplementedException();
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
            
        }
    }
}
