using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Timers;
using Sprint0.UtilityClasses;

namespace Sprint0.Enemies 
{
    class ChargeEnemyWanderState : IEnemyState
    {
        private string ID = "ChargeEnemyWanderState";
        private IEnemy enemy;
        private Vector2 velocity;
        private string direction;
        private Timer walkDirectionTimer;
        private bool grounded;
        private static int waitTime = 2000;
        private static Vector2 viewBoxDimensions = new Vector2(200, 50);
        Rectangle viewBox;

        public ChargeEnemyWanderState(IEnemy enemyRef)
        {
            this.enemy = enemyRef;
            direction = GameUtilities.right;
            walkDirectionTimer = new Timer(waitTime, SwitchDirection);
            walkDirectionTimer.StartTimer();
            
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
            throw new NotImplementedException();
        }

        public void GetKicked(Rectangle rec)
        {
            throw new NotImplementedException();
        }

        public string GetStateID()
        {
            return ID;
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
           // enemy.SetDirection(GameUtilities.left);
           // velocity.X = -GameUtilities.chargeEnemySpeed;
        }

        public void MoveRight()
        {
            //enemy.SetDirection(GameUtilities.right);
            //velocity.X = GameUtilities.chargeEnemySpeed;
        }

        private void SwitchDirection(Object Source, System.Timers.ElapsedEventArgs e)
        {
            if (direction==GameUtilities.right)
            {
                direction = GameUtilities.left;
                velocity.X = -GameUtilities.chargeEnemySpeed;
                enemy.SetDirection(direction);
            }
            else
            {
                direction = GameUtilities.right;
                velocity.X = GameUtilities.chargeEnemySpeed;
                enemy.SetDirection(direction);
            }
            walkDirectionTimer = new Timer(waitTime, SwitchDirection);
            walkDirectionTimer.StartTimer();
        }

        public void RightBounce(Rectangle rectangle)
        {
            enemy.Position = new Vector2(enemy.Position.X + rectangle.Width, enemy.Position.Y);
            velocity.X = GameUtilities.chargeEnemySpeed;
        }

        public void SetGrounded(bool grounded)
        {
            if (grounded == false)
                velocity.Y = GameUtilities.gravity;
            else
                velocity.Y = 0;
            this.grounded = grounded;
        }

        public void SetXVelocity(float x)
        {
            velocity.X = x;
        }

        public void SetYVelocity(float y)
        {
            velocity.Y = y;
        }

        public void TakeDamage()
        {
            enemy.SetHealth(enemy.GetHealth() - 1);
            enemy.SetCurrentState(new ChargeEnemySquashedState());
            enemy.StartRemovalTimer();
        }

        public void UpBounce(Rectangle rectangle)
        {
            grounded = true;
            enemy.Position = new Vector2(enemy.Position.X, enemy.Position.Y - rectangle.Height);
        }

        public void Update()
        {
            enemy.Move(velocity);
            //Should the width be negative if the enemy is facing left? This is easy to solve, if direction is left, make the width negative.
            viewBox = new Rectangle((int)enemy.Position.X, (int)enemy.Position.Y, viewBox.Width, viewBox.Height);
            foreach (IMario mario in GameObjectManager.Instance.marios)
            {
                if (viewBox.Contains(mario.Position))
                {
                    enemy.SetCurrentState(new ChargeEnemyChargeState(enemy));
                }
            }
        }
    }
}
