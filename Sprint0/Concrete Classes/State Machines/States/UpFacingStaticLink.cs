using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class UpFacingStaticLink : ILinkState
    {
        private Link link;

        public UpFacingStaticLink(Link linkRef)
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
            link.currentState = new RightFacingStaticLink(link);
            link.OnStateChange();
        }

        public void MoveUp()
        {
            //No op
        }

        public void Update()
        {
            //No op ?
        }
    }
}
