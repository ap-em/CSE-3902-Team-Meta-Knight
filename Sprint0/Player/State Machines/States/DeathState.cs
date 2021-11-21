using Microsoft.Xna.Framework;
using Sprint0.Sprites.SpriteFactory;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.UtilityClasses;
using Sprint0.Interfaces;
using Sprint0.Commands;
using Sprint0.HUD;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0.Concrete_Classes.State_Machines.States
{
    class DeathState : IMarioState
    {
        private int timer = 100;
        private Vector2 velocity;
        Mario mario;

        public string ID => throw new NotImplementedException();

        public DeathState(Mario marioRef)
        {
            velocity = new Vector2(0, -12);
            mario = marioRef;
        }


        public void Attack()
        {

            
        }

        public void Crouch()
        {

        }

        public void Jump()
        {
            
        }
        public void StopJump()
        {

        }
        public void MoveLeft()
        {

        }

        public void MoveRight()
        {

        }
        public void StopMovingHorizontal()
        {

        }
        public void StopMovingVertical()
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
        public void Update()
        {
            velocity = velocity + new Vector2(velocity.X, 30) * Game0.Instance.TargetElapsedTime.Milliseconds / 1000;
            if (velocity.Y >= 16)
                velocity.Y = 16;

            timer -= 1;
            if(timer == 0)
            {
                IHUD hud = HUDManager.Instance.GetHUD((IGameObject)mario);
                hud.SetLives(hud.GetLives() - 1);
                //only reset the level if we have more lives
                if (hud.GetLives() > 0)
                {
                    ICommand reset = new CReset(mario);
                    reset.Execute();
                }
            }

            mario.MoveSprite(velocity);
        }

        public void MarioBounce(Rectangle rectangle)
        {
            
        }
    }
}
