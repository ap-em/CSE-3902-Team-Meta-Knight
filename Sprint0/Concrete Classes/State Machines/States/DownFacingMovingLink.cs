using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class DownFacingMovingLink : ILinkState
    {
        public string ID { get; } = "DownIdleLink";
        private Link link;
        private const float moveVelocity = 2f;

        public DownFacingMovingLink(Link linkRef)
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
            //No op
        }

        public void MoveLeft()
        {
            link.currentState = new LeftFacingMovingLink(link);
            link.OnStateChange();
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
            if (sourceDirection=="Down")
            {
                link.currentState = new DownFacingStaticLink(link);
                link.OnStateChange();
            }
        }

        public void Update()
        {
            link.MoveSprite(new Vector2(0f, moveVelocity));
        }
    }
}
