using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Sprint0.UtilityClasses;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0
{
    class RightFacingMovingMario : IMarioState
    {
        public string ID  { get; }= "RightMovingMario";
        private Mario mario;
        private Vector2 velocity= new Vector2(GameUtilities.VairX, 0);

        public RightFacingMovingMario(Mario marioRef)
        {
            mario = marioRef;
        }

        public void Attack()
        {
            throw new NotImplementedException();
        }

        public void Crouch()
        {
            throw new NotImplementedException();
        }

        public void Jump()
        {
            mario.soundInfo.PlaySound("smb2_jump", false);
            mario.currentState = new RightFacingJumpingMario(mario, new Vector2(velocity.X, -10), 0, true);
            mario.OnStateChange();
        }
        public void StopJump()
        {

        }
        public void MoveLeft()
        {
            mario.currentState = new LeftFacingMovingMario(mario);
            mario.OnStateChange();
        }

        public void MoveRight()
        {
            //No op
        }
        public void StopMovingHorizontal()
        {
            mario.currentState = new RightFacingStaticMario(mario);
            mario.OnStateChange();
        }
        public void StopMovingVertical()
        {
            // no op
        }
        public void UpBounce(Rectangle rectangle)
        {
            if (!mario.GetGrounded() && rectangle.Width>velocity.X)
            {
                mario.SetGrounded(true);
                mario.Position = new Vector2(mario.Position.X, mario.Position.Y - rectangle.Height);
               StopMovingVertical();
            }
        }
        public void DownBounce(Rectangle rectangle)
        {
            if (!mario.GetGrounded() && rectangle.Width > velocity.X)
            {
                mario.Position = new Vector2(mario.Position.X, mario.Position.Y + rectangle.Height);
                velocity = new Vector2(velocity.X, 2f);
            }
            
                
        }
        public void RightBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X + rectangle.Width, mario.Position.Y);
           // StopMovingHorizontal();
        }
        public void LeftBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X - rectangle.Width, mario.Position.Y);
           // StopMovingHorizontal();
        }
        public void Update()
        {
            if (mario.GetGrounded())
            {
                velocity = new Vector2(GameUtilities.VairX, 0f);
            }
            else
            {
                velocity = new Vector2(GameUtilities.VairX, GameUtilities.gravity);
            }

            mario.MoveSprite(velocity);
        }

        public void MarioBounce(Rectangle rectangle)
        {
            velocity.Y = -12f;
        }
    }
}
