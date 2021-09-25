using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LeftFacingStaticLink : ILinkState
    {
        private Link link;

        public LeftFacingStaticLink(Link linkRef)
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
            link.currentState = new DownFacingStaticLink(link);
            link.OnStateChange();
        }

        public void MoveLeft()
        {
            //No op
        }

        public void MoveRight()
        {
            link.currentState = new RightFacingStaticLink(link);
            link.OnStateChange();
        }

        public void MoveUp()
        {
            link.currentState = new UpFacingStaticLink(link);
            link.OnStateChange();
        }

        public void Update()
        {
            //No op?
        }
    }
}
