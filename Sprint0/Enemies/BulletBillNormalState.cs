using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.SpriteFactory;
using Sprint0.Controllers;
using Sprint0.UtilityClasses;
using Sprint0.Timers;

/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
/*OWEN HUSTON - 9/22/2021 */


namespace Sprint0.Enemies
{
    public class BulletBillNormalState : IEnemyState
    {
        private String ID = "BulletBillNormalState";
        private IEnemy enemy;
        private Vector2 velocity = new Vector2(-5, GameUtilities.gravity);
        public BulletBillNormalState(IEnemy enemy)
        {
            
            this.enemy = enemy;
            enemy.Grounded = true;
            enemy.SetDirection(GameUtilities.left);
            //start throwing after a second
            TimerManager.Instance.AddToTimerList(new Timer(8000, SwitchDirection));
        }
        public void SwitchDirection()
        {
            if (enemy.GetDirection() == GameUtilities.left)
            {
                velocity = new Vector2(-velocity.X, velocity.Y);
                enemy.SetDirection(GameUtilities.right);
            }
            else
            {
                velocity = new Vector2(-velocity.X, velocity.Y);
                enemy.SetDirection(GameUtilities.left);
            }
            
            TimerManager.Instance.AddToTimerList(new Timer(8000, SwitchDirection));
        }
        public String GetStateID()
        {
            return ID;
        }
        public void TakeDamage()
        {
            velocity.X = 1;
            enemy.Grounded = false;
            enemy.StartRemovalTimer(3000);
        }
        public void GetKicked(Rectangle rec)
        {

        }

        public void MoveRight()
        {

        }

        public void MoveLeft()
        {
            
        }


        public void UpBounce(Rectangle rectangle)
        {

        }

        public void DownBounce(Rectangle rectangle)
        {

        }
        public void RightBounce(Rectangle rectangle)
        {

        }

        public void LeftBounce(Rectangle rectangle)
        {

        }

        public void BigUpBounce(Rectangle rectangle)
        {

        }

        public void SetXVelocity(float x)
        {
            
        }

        public void SetYVelocity(float y)
        {
            
        }

        public Vector2 GetVelocity()
        {
            return new Vector2(0, 0);
        }

        public void SetGrounded(bool grounded)
        {

        }

        public void Update()
        {
            enemy.Move(velocity);
        }
    }
}