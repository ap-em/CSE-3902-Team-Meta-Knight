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
    class BomberNormalState : IEnemyState
    {
        private IEnemy enemy;
        private Vector2 velocity;
        private string direction;
        private Timer bombTimer;
        private Timer directionTimer;
        private static string ID = "BomberNormalState";
        private bool isSquished = false;

        public BomberNormalState(IEnemy enemyRef)
        {
            enemy = enemyRef;
            velocity = new Vector2(-GameUtilities.bomberSpeed, GameUtilities.gravity);
            direction = GameUtilities.left;
            bombTimer = new Timer(GameUtilities.bomberAtackInterval, DropBomb);
            directionTimer = new Timer(GameUtilities.bomberDirectionChangeInterval, SwitchDirection);
            TimerManager.Instance.AddToTimerList(bombTimer);
            TimerManager.Instance.AddToTimerList(directionTimer);
            enemy.Grounded = true;

        }
        private void DropBomb()
        {
            if (enemy.GetHealth()>0 && !isSquished)
            {
                GameObjectManager.Instance.AddToObjectList(
                            new Projectile(
                              "Hammer", enemy.Position, 0, 0, GameUtilities.hammerFuse), 1, 1);
                bombTimer = new Timer(GameUtilities.bomberAtackInterval, DropBomb);
                TimerManager.Instance.AddToTimerList(bombTimer);
            }

        }
        private void SwitchDirection()
        {
            Debug.WriteLine("SwitchDirection");
            if (direction == GameUtilities.right)
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
            directionTimer = new Timer(GameUtilities.bomberDirectionChangeInterval, SwitchDirection);
            TimerManager.Instance.AddToTimerList(directionTimer);
        }
        public void BigUpBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void DownBounce(Rectangle rectangle)
        {
            enemy.Position = new Vector2(enemy.Position.X, enemy.Position.Y + rectangle.Height);

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
            enemy.Position = new Vector2(enemy.Position.X + rectangle.Width, enemy.Position.Y);
            direction = GameUtilities.left;
            velocity.X = -GameUtilities.bomberSpeed;
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
            direction = GameUtilities.right;
            velocity.X = GameUtilities.bomberSpeed;
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
            velocity.X = 1;
            enemy.Grounded = false;
            enemy.SetHealth(0);
            enemy.StartRemovalTimer(3000);
            isSquished = true;
        }

        public void UpBounce(Rectangle rectangle)
        {
            enemy.Position = new Vector2(enemy.Position.X, enemy.Position.Y - rectangle.Height);

        }

        public void Update()
        {
            
            enemy.Move(velocity);
        }
    }
}
