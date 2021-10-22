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
    public class LeftFacingJumpingMario : IMarioState
    {
        public string ID { get; } = "LeftJumpingMario";
        private Vector2 velocity;
        private int jumpTimer;
        private bool jumpHold;

        private Mario mario;

        public LeftFacingJumpingMario(Mario marioRef, Vector2 velocity, int jumpTimer, bool jumpHold)
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

        public void MoveDown()
        {

        }

        public void MoveLeft()
        {
            velocity.X = -4;
        }

        public void MoveRight()
        {
            mario.currentState = new RightFacingJumpingMario(mario, new Vector2(4, velocity.Y), jumpTimer, jumpHold);
            mario.OnStateChange();
        }

        public void MoveUp()
        {

        }

        public void StopMovingHorizontal()
        {
            velocity.X = 0;
        }
        public void StopMovingVertical()
        {
            mario.currentState = new LeftFacingStaticMario(mario);
            mario.OnStateChange();
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
