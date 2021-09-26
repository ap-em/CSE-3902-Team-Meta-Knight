using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class RightFacingStaticLink : ILinkState
    {
        private Link link;

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
            link.currentState = new DownFacingStaticLink(link);
            link.OnStateChange();
        }

        public void MoveLeft()
        {
            link.currentState = new LeftFacingStaticLink(link);
            link.OnStateChange();
        }

        public void MoveRight()
        {
            //No op
        }

        public void MoveUp()
        {
            link.currentState = new UpFacingStaticLink(link);
            link.OnStateChange();
        }

        public void Update()
        {
            //No op ?
        }
    }
}
