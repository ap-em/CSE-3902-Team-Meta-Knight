using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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
    public class RightFacingJumpingMario : IMarioState
    {
        public string ID { get; } = "RightJumpingMario";
        private Vector2 velocity;
        private int jumpTimer;
        private bool jumpHold;

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
                if (jumpTimer > 0)
                {
                    jumpHold = true;
                }
                else
                {
                    jumpHold = false;
                }
            }
        }
        public void MoveLeft()
        {
            mario.currentState = new LeftFacingJumpingMario(mario, new Vector2(-4,velocity.Y), jumpTimer, jumpHold);
            mario.OnStateChange();
        }

        public void MoveRight()
        {
            velocity.X = 4;
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
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - rectangle.Height);
            mario.SetGrounded(true);
            StopMovingVertical();
        }
        public void DownBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + rectangle.Height);
            velocity = new Vector2(velocity.X, 2f);
        }
        public void RightBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X - rectangle.Width, mario.Position.Y);
            StopMovingHorizontal();
        }
        public void LeftBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X + rectangle.Width, mario.Position.Y);
            StopMovingHorizontal();
        }
        public void Update()
        {
            // if timer is up player can no longer hold key down
            if (jumpTimer == 0)
            {
                jumpHold = false;
            }
            else
            {
                jumpTimer--;
            }

            // TODO: .15 should be changed to delta time
            // only apply gravity if done holding
            if (!jumpHold)
            {
                velocity = velocity + new Vector2(0, 5) * .15f;
            }
            mario.MoveSprite(velocity);

        }
    }
}
