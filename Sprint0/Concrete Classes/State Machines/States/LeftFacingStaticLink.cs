using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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
    public class LeftFacingStaticLink : ILinkState
    {
        private Link link;
        public string ID { get; } = "LeftIdleLink";

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
            link.currentState = new LeftFacingJumpingLink(link, new Vector2(0, -5), 15, true);
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

        public void StopMovingHorizontal()
        {
            // no op
        }
        public void StopMovingVertical()
        {
            // no op
        }

        public void Update()
        {
            //No op?
        }
    }
}
