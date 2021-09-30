using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0
{
    class RightFacingMovingLink : ILinkState
    {
        public string ID  { get; }="RightIdleLink";
        private Link link;

        public RightFacingMovingLink(Link linkRef)
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
            throw new NotImplementedException();
        }

        public void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public void MoveRight()
        {
            //No op
        }

        public void MoveUp()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            Debug.WriteLine("Right facing moving state update");
            
            link.MoveSprite(new Vector2(2f, 0f));
        }

        public void StopMoving()
        {
            link.currentState = new RightFacingStaticLink(link);
            link.OnStateChange();
        }
    }
}
