using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LeftFacingMovingLink : ILinkState
    {
        public string ID { get; } = "RightIdleLink";
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
            throw new NotImplementedException();
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
