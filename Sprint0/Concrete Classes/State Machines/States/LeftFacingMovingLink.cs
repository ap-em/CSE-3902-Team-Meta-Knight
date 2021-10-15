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
    public class LeftFacingMovingLink : ILinkState
    {
        public string ID { get; } = "LeftMovingLink";
        private const float moveVelocity = 2f;

        private Link link;

        public LeftFacingMovingLink(Link linkRef)
        {
            link = linkRef;
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
            link.currentState = new LeftFacingJumpingLink(link, new Vector2(-2, -5), 15, true);
            link.OnStateChange();
        }

        public void MoveDown()
        {
            link.currentState = new DownFacingMovingLink(link);
            link.OnStateChange();
        }

        public void MoveLeft()
        {
            //No op
        }

        public void MoveRight()
        {
            link.currentState = new RightFacingMovingLink(link);
            link.OnStateChange();
        }

        public void MoveUp()
        {
            link.currentState = new UpFacingMovingLink(link);
            link.OnStateChange();
        }

        public void StopMoving(string sourceDirection)
        {
            if (sourceDirection=="Left")
            {
                link.currentState = new LeftFacingStaticLink(link);
                link.OnStateChange();
            }
        }

        public void Update()
        {
            link.MoveSprite(new Vector2(-1 * moveVelocity, 0f));
        }
    }
}
