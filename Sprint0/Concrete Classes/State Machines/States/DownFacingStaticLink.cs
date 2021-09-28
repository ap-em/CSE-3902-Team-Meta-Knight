using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class DownFacingStaticLink : ILinkState
    {
        private Link link;

        public DownFacingStaticLink(Link linkRef)
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
            link.currentState = new UpFacingStaticLink(link);
            link.OnStateChange();
        }

        public void Update()
        {
            //No op?
        }
    }
}
