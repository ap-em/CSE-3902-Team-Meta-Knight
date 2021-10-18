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
    public class RightFacingJumpingLink : ILinkState
    {
        public string ID { get; } = "RightJumpingMario";
        private Vector2 velocity;
        private int jumpTimer;
        private bool jumpHold;

        private Link link;

        public RightFacingJumpingLink(Link linkRef, Vector2 velocity, int jumpTimer, bool jumpHold)
        {
            link = linkRef;
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
            link.currentState = new LeftFacingJumpingLink(link, new Vector2(-2,velocity.Y), jumpTimer, jumpHold);
            link.OnStateChange();
        }

        public void MoveRight()
        {
            velocity.X = 2;
        }

        public void MoveUp()
        {

        }

        public void StopMoving(string sourceDirection)
        {

            if (sourceDirection=="Left" || sourceDirection == "Right")
            {
                velocity.X = 0;
            }
            else if(sourceDirection == "Down")
            {
                link.currentState = new RightFacingStaticLink(link);
                link.OnStateChange();
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
            }
            link.MoveSprite(velocity);

        }
    }
}
