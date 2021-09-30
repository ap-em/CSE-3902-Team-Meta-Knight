using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class RightFacingStaticLink : ILinkState
    {
        private Link link;
        public string ID { get; } = "RightIdleLink";

        public RightFacingStaticLink(Link linkRef)
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

        public void Update()
        {
            //No op ?
        }

        public void StopMoving(string sourceDirection)
        {
           // No op
        }
    }
}
