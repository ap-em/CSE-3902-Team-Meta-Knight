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
        private const float moveVelocity= 2f;

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
            //No op
        }

        public void MoveUp()
        {
            link.currentState = new UpFacingMovingLink(link);
            link.OnStateChange();
        }

        public void Update()
        {            
            link.MoveSprite(new Vector2(moveVelocity, 0f));
        }

        public void StopMoving(string sourceDirection)
        {
            if (sourceDirection=="Right")
            {
                link.currentState = new RightFacingStaticLink(link);
                link.OnStateChange();
            }
        }
    }
}
