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
            mario.currentState = new LeftFacingJumpingMario(mario, new Vector2(-2,velocity.Y), jumpTimer, jumpHold);
            mario.OnStateChange();
        }

        public void MoveRight()
        {
            velocity.X = 2;
        }
        public void StopMovingHorizontal()
        {
            velocity.X = 0;
        }
        public void StopMovingVertical()
        {
            mario.currentState = new RightFacingStaticMario(mario);
            mario.OnStateChange();
        }
        public void Bounce(string direction)
        {
            switch (direction)
            {
                case "up":
                    velocity = new Vector2(velocity.X, 0);
                    break;
                case "down":
                    mario.currentState = new RightFacingStaticMario(mario);
                    mario.OnStateChange();
                    break;
                case "left":
                    break;
                case "right":
                    velocity = new Vector2(velocity.X * -1, velocity.Y);
                    break;
                default:
                    break;
            }
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
                Debug.WriteLine("velocity: " + velocity);
            }
            mario.MoveSprite(velocity);

        }
    }
}
