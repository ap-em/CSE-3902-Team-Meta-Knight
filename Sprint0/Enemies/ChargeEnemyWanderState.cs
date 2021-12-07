using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.UtilityClasses;
using Sprint0.Timers;
using System.Diagnostics;

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
        private static Vector2 viewBoxDimensions = new Vector2(300, 100);
        Rectangle viewBox;

        public ChargeEnemyWanderState(IEnemy enemyRef)
        {
            Debug.WriteLine("WANDER STATE INITIALIZED");
            this.enemy = enemyRef;
            direction = GameUtilities.right;
            walkDirectionTimer = new Timer(GameUtilities.chargeEnemyDirectionWait, SwitchDirection);
            TimerManager.Instance.AddToTimerList(walkDirectionTimer);
            velocity = new Vector2(GameUtilities.chargeEnemySpeed, 0);
            
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
            Debug.WriteLine("LEFT BOUNCE");

            enemy.Position = new Vector2(enemy.Position.X - rectangle.Width, enemy.Position.Y);
            direction = GameUtilities.right;
            velocity.X = GameUtilities.chargeEnemySpeed;
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

        private void SwitchDirection()
        {
            Debug.WriteLine("SWITCH DIRECTION");

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
            walkDirectionTimer = new Timer(GameUtilities.chargeEnemyDirectionWait, SwitchDirection);
            TimerManager.Instance.AddToTimerList(walkDirectionTimer);

        }

        public void RightBounce(Rectangle rectangle)
        {
            Debug.WriteLine("RIGHT BOUNCE");

            enemy.Position = new Vector2(enemy.Position.X + rectangle.Width, enemy.Position.Y);
            direction = GameUtilities.left;
            velocity.X = -GameUtilities.chargeEnemySpeed;
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
            //velocity.X = x;
        }

        public void SetYVelocity(float y)
        {
            //velocity.Y = y;
        }

        public void TakeDamage()
        {
            enemy.SetHealth(enemy.GetHealth() - 1);
            enemy.CurrentState=new ChargeEnemySquashedState(enemy);
            enemy.StartRemovalTimer(100);
        }

        public void UpBounce(Rectangle rectangle)
        {
            grounded = true;
            enemy.Position = new Vector2(enemy.Position.X, enemy.Position.Y - rectangle.Height);
        }

        public void Update()
        {
            enemy.Move(velocity);
            int directionAdjust;
            //Should the width be negative if the enemy is facing left? This is easy to solve, if direction is left, make the width negative.
            directionAdjust = (direction == GameUtilities.left) ? 1 : 0;

            viewBox = new Rectangle((int)(enemy.Position.X-(directionAdjust*viewBoxDimensions.X)), (int)enemy.Position.Y-GameUtilities.chargeEnemyVerticalSightAdjust, (int)viewBoxDimensions.X, (int)viewBoxDimensions.Y);
            foreach (IMario mario in GameObjectManager.Instance.marios)
            {
                if (viewBox.Contains(mario.Position))
                {

                    enemy.CurrentState=new ChargeEnemyChargeState(enemy, direction);
  
                }
            }
        }
    }
}
