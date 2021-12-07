using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Timers;
using Sprint0.UtilityClasses;

namespace Sprint0.Enemies
{
    class ChargeEnemyAttackState : IEnemyState
    {
        private IEnemy enemy;
        public  string ID = "ChargeEnemyAttackState";
        private Vector2 velocity;
        private static int speed = 5;
        private bool grounded;
        private string direction;
        Timer attackTimer;

        public ChargeEnemyAttackState(IEnemy enemyRef, string directionRef)
        {
            enemy = enemyRef;
            direction = directionRef;
            if (direction==GameUtilities.right)
            {
                velocity = new Vector2(speed, GameUtilities.gravity);
            }
            else
            {
                velocity = new Vector2(-speed, GameUtilities.gravity);
            }
            attackTimer = new Timer(GameUtilities.chargeEnemyAttackTime, EndAttack);
            TimerManager.Instance.AddToTimerList(attackTimer);
        }
        public void EndAttack()
        {
            if (enemy.GetHealth()>0)
            {
                enemy.CurrentState = new ChargeEnemyWanderState(enemy);

            }
        }
        public void BigUpBounce(Rectangle rectangle)
        {
        }

        public void DownBounce(Rectangle rectangle)
        {
        }

        public bool GetGrounded()
        {
            return grounded;
        }

        public void GetKicked(Rectangle rec)
        {
            velocity = new Vector2(0, GameUtilities.gravity);
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
            enemy.Position = new Vector2(enemy.Position.X - rectangle.Width, enemy.Position.Y);

            velocity = new Vector2(0, GameUtilities.gravity);
        }

        public void MoveLeft()
        {

        }

        public void MoveRight()
        {

        }

        public void RightBounce(Rectangle rectangle)
        {
            enemy.Position = new Vector2(enemy.Position.X + rectangle.Width, enemy.Position.Y);

            velocity = new Vector2(0, GameUtilities.gravity);

        }

        public void SetGrounded(bool grounded)
        {
            this.grounded = grounded;
        }

        public void SetXVelocity(float x)
        {

        }

        public void SetYVelocity(float y)
        {
        }

        public void TakeDamage()
        {
            enemy.SetHealth(enemy.GetHealth() - 1);
            enemy.CurrentState = new ChargeEnemySquashedState(enemy);
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
        }
    }
}
