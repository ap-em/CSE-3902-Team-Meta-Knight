using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    class RightFacingMovingLink : ILinkState
    {
        public string ID  { get; }="RightMovingLink";
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
            link.currentState = new RightFacingJumpingLink(link, new Vector2(2, -5), 15, true);
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
        public void StopMovingHorizontal()
        {
            link.currentState = new RightFacingStaticLink(link);
            link.OnStateChange();
        }
        public void StopMovingVertical()
        {
            // no op
        }
        public void Update()
        {            
            link.MoveSprite(new Vector2(moveVelocity, 0f));
        }
    }
}
