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
    public class HammerBroNormalState : IEnemyState
    {
        private int shootNum = 0;
        private String ID = "HammerBroNormalState";
        private IEnemy enemy;
        public HammerBroNormalState(IEnemy enemy)
        {
            this.enemy = enemy;

            //start throwing after a second
            TimerManager.Instance.AddToTimerList(new Timer(1000, Throw));
        }
        public void Throw()
        {
            if (enemy.GetStateID() == ID)
            {
                // shoot left
                if (enemy.GetDirection() == GameUtilities.left)
                {
                    GameObjectManager.Instance.AddToObjectList(
                            new Projectile(
                              "Hammer", enemy.Position, -GameUtilities.hammerVelocityX, -GameUtilities.hammerVelocityY, GameUtilities.hammerFuse), 1, 1);
                }
                //shoot right
                else
                {
                    GameObjectManager.Instance.AddToObjectList(
                            new Projectile(
                              "Hammer", enemy.Position, GameUtilities.hammerVelocityX, -GameUtilities.hammerVelocityY, GameUtilities.hammerFuse), 1, 1);
                }

                shootNum++;
                //keep shooting till we hit 10 then wait
                if (shootNum < 10)
                {
                    //start throwing after a second
                    TimerManager.Instance.AddToTimerList(new Timer(3000, Throw));
                }
                else
                {
                    shootNum = 0;
                    // wait for a random time between 500 and 2000ms
                    Random rand = new Random();
                    int waitTime = rand.Next(7000, 10000);

                    TimerManager.Instance.AddToTimerList(new Timer(waitTime, Wait));
                }
            }
        }
        public void Wait()
        {
            if(enemy.GetStateID() == ID)
                Throw();
        }
        public String GetStateID()
        {
            return ID;
        }
        public void TakeDamage()
        {
            enemy.SetHealth(enemy.GetHealth() - 1);
            enemy.CurrentState = new KoopaShellState(enemy);
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
            enemy.Grounded = grounded;
        }

        public void Update()
        {
            // always face toward mario
            if(GameObjectManager.Instance.marios[0] != null)
            {
                if(GameObjectManager.Instance.marios[0].Position.X < enemy.Position.X)
                {
                    enemy.SetDirection(GameUtilities.left);
                }
                if (GameObjectManager.Instance.marios[0].Position.X > enemy.Position.X)
                {
                    enemy.SetDirection(GameUtilities.right);
                }
            }
        }
    }
}