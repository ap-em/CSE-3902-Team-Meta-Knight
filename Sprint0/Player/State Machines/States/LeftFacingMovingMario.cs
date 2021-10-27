using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
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
    public class LeftFacingMovingMario : IMarioState
    {
        public string ID { get; } = "LeftMovingMario";
        private Vector2 velocity = new Vector2(-6f, 0);

        private Mario mario;

        public LeftFacingMovingMario(Mario marioRef)
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
            mario.currentState = new LeftFacingJumpingMario(mario, new Vector2(-6, -10), 0, true);
            mario.OnStateChange();
        }
        public void StopJump()
        {

        }

        public void MoveLeft()
        {
            //No op
        }

        public void MoveRight()
        {
            mario.currentState = new RightFacingMovingMario(mario);
            mario.OnStateChange();
        }

        public void StopMovingHorizontal()
        {
            mario.currentState = new LeftFacingStaticMario(mario);
            mario.OnStateChange();
        }
        public void StopMovingVertical()
        {
            // no op
        }
        public void UpBounce(Rectangle rectangle)
        {
            if (!mario.GetGrounded())
            {
                mario.SetGrounded(true);
                mario.Position = new Vector2(mario.Position.X, mario.Position.Y - rectangle.Height);
                //Debug.WriteLine("Nudge Moving up: " + rectangle.Height);
                StopMovingVertical();
            }
        }
        public void DownBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + rectangle.Height);
            //velocity = new Vector2(velocity.X, 2f);
        }
        public void RightBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X + rectangle.Width, mario.Position.Y);
            //StopMovingHorizontal();
        }
        public void LeftBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X - rectangle.Width, mario.Position.Y);
            StopMovingHorizontal();
        }
        public void Update()
        {
            if (mario.GetGrounded())
            {
                velocity = new Vector2(-4f, 0f);
            }
            else
            {
                velocity = new Vector2(-4f, 9.8f);
            }
            mario.MoveSprite(velocity);
        }
    }
}
