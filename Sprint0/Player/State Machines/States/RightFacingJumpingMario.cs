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
    public class RightFacingJumpingMario : IMarioState
    {
        public string ID { get; } = "RightJumpingMario";
        private Vector2 velocity;
        private int jumpTimer = 0;
        private bool jumpHold;
        private int currentMaxJumpTime = GameUtilities.currentMaxJumpTime;
        private int maxJumpTime = GameUtilities.maxJumpTime;
        private Mario mario;

        public RightFacingJumpingMario(Mario marioRef, Vector2 velocity, int jumpTimer, bool jumpHold)
        {
            mario = marioRef;
            mario.SetGrounded(false);
            this.velocity = velocity;
            this.jumpTimer = jumpTimer;
            this.jumpHold = jumpHold;
        }

        public void Attack()
        {
            
        }

        public void Crouch()
        {
            
        }
        public void Jump()
        {
            // if(jumpHold) prevents us from pressing letting go then holding jump
            if (jumpHold)
            {
                //if we are still allowed to jump
                if (jumpTimer < currentMaxJumpTime)
                {
                    // if we are holding jump we want to increase jump time
                    if (currentMaxJumpTime < maxJumpTime)
                    {
                        currentMaxJumpTime++;
                    }
                    jumpHold = true;
                }
                else
                {
                    jumpHold = false;
                }
            }
        }
        public void StopJump()
        {
            jumpHold = false;
        }
        public void MoveLeft()
        {
            mario.currentState = new LeftFacingJumpingMario(mario, new Vector2(-4,velocity.Y), jumpTimer, jumpHold);
            mario.OnStateChange();
        }

        public void MoveRight()
        {
            velocity.X = GameUtilities.Vx;
        }
        public void StopMovingHorizontal()
        {
            velocity.X = 0;
        }
        public void StopMovingVertical()
        {
            if(velocity.X > 0)
            {
                mario.currentState = new RightFacingMovingMario(mario);
            }
            else
            {
                mario.currentState = new RightFacingStaticMario(mario);
            }
            mario.OnStateChange();
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
            Debug.WriteLine("DOWN BOUNCE");
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + rectangle.Height);
            jumpHold = true;
            velocity = new Vector2(velocity.X, 4f);

        }
        public void RightBounce(Rectangle rectangle)
        {
            Debug.WriteLine("RIGHT BOUNCE");
            mario.Position = new Vector2(mario.Position.X + rectangle.Width, mario.Position.Y);
           // StopMovingHorizontal();
        }
        public void LeftBounce(Rectangle rectangle)
        {
            Debug.WriteLine("LEFT BOUNCE");
            mario.Position = new Vector2(mario.Position.X - rectangle.Width, mario.Position.Y);
           // StopMovingHorizontal();
        }
        public void MarioBounce(Rectangle rectangle)
        {
            velocity.Y = -12f;
        }
        public void Update()
        {

            // if timer is up player can no longer hold key down
            if (jumpTimer > currentMaxJumpTime)
            {
                jumpHold = false;
            }
            else
            {
                jumpTimer++;
            }

            // TODO: .15 should be changed to delta time
            // only apply gravity if done holding
            if (!jumpHold && !mario.GetGrounded())
            {
                velocity = velocity + new Vector2(0, 30) * Game0.Instance.TargetElapsedTime.Milliseconds / 1000;
                if (velocity.Y >= 16) velocity.Y = 16;
            }
            mario.MoveSprite(velocity);

        }
    }
}
