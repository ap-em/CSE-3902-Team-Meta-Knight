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
using Sprint0.HUD;

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
    public class BowserNormalState : IEnemyState
    {
        private String ID = "BowserNormalState";
        private int health = 3;
        private IEnemy enemy;
        private Vector2 velocity = new Vector2(2,0);
        public BowserNormalState(IEnemy enemy)
        {
            this.enemy = enemy;


            TimerManager.Instance.AddToTimerList(new Timer(500, Throw));
            TimerManager.Instance.AddToTimerList(new Timer(5000, SwitchDirection));
        }
        public void Throw()
        {
            if (enemy.GetStateID() == "BowserNormalState")
            {
                // shoot left
                if (enemy.GetDirection() == GameUtilities.left)
                {
                    GameObjectManager.Instance.AddToObjectList(
                            new Projectile(
                              "Bowser_Fire", enemy.Position + GameUtilities.fireBallPosition, -GameUtilities.bowserFireballX, 0, GameUtilities.hammerFuse), 1, 1);
                }
                //shoot right
                else
                {
                    GameObjectManager.Instance.AddToObjectList(
                            new Projectile(
                              "Bowser_Fire", enemy.Position + GameUtilities.fireBallPosition, GameUtilities.bowserFireballX, 0, GameUtilities.hammerFuse), 1, 1);
                }

                TimerManager.Instance.AddToTimerList(new Timer(1000, Throw));
            }
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
            health--;
            if (health == 0)
            {
                ID = "BowserDead";
                enemy.StartRemovalTimer(50);
                HUDManager.Instance.GetHUD((IGameObject)GameObjectManager.Instance.marios[0]).WinGame();
            }
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

        public bool GetGrounded()
        {
            return false;
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