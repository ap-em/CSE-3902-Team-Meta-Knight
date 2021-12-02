using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.UtilityClasses;
using Sprint0.Controllers;
using Sprint0.Commands;
using Sprint0.Interfaces;
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
    class RightFacingStaticMario : IMarioState
    {
        private Mario mario;
        public string ID { get; } = "RightIdleMario";
        private Vector2 velocity = new Vector2(0, 0);

        public RightFacingStaticMario(Mario marioRef)
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
            mario.currentState = new RightFacingMovingMario(mario);
            mario.OnStateChange();
        }
        public void StopMovingHorizontal()
        {
            velocity.X = 0;
        }
        public void StopMovingVertical()
        {
            velocity.Y = 0;
        }
        public void UpBounce(Rectangle rectangle)
        {
            if (!mario.GetGrounded())
            {
                mario.SetGrounded(true);
                mario.Position = new Vector2(mario.Position.X, mario.Position.Y - rectangle.Height);
                StopMovingVertical();
            }
        }
        public void DownBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + rectangle.Height);
            velocity = new Vector2(velocity.X, 2f);
        }
        public void RightBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X + rectangle.Width, mario.Position.Y);
           //StopMovingHorizontal();
        }
        public void LeftBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X - rectangle.Width, mario.Position.Y);
            //StopMovingHorizontal();
        }
        public void Update()
        {
            if (mario.GetGrounded())
            {
                velocity = new Vector2(0f, 0f);
            }
            else 
            {
                velocity = new Vector2(0, GameUtilities.gravity);
            }
            /*IKeyboardController keyboard = PlayerKeyboardManager.Instance.GetKeyboard(mario);
            if (keyboard != null && keyboard.GetLockInput())
            {
                mario.currentState = new RightFacingFlagMario(mario);
                mario.OnStateChange();
                new CMovePlayerRight(mario).Execute();
                
            }*/
            
            mario.MoveSprite(velocity);
        }

        public void MarioBounce(Rectangle rectangle)
        {
            velocity.Y = -12f;
        }
    }
}
