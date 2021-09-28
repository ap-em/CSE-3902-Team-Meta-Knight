using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class Link :ILink, ILinkState
    {
        private LinkHealthStateMachine healthStateMachine;
        public ILinkState currentState;
        /*
         * TODO: Eventually we should have a GameObject interface/abstract class that has things like position and current sprite;
         */
        private int XVelocity = 0;
        private int YVelocity = 0;
        private Vector2 position = new Vector2(0f, 0f);
        private ISprite currentSprite;


        public Link()
        {
            healthStateMachine = new LinkHealthStateMachine();
            currentState = new RightFacingStaticLink(this);
        }

        /*
         * Does everything needed on a state change
         */
        public void OnStateChange()
        {
            /*
             * This is called to get a new sprite whenever the state changes, so we aren't getting a new
             * sprite from the SF every draw method. This will save performance. 
             * Since the sprite factory will return a texture2d given a unique ID, we 
             */
            //currentSprite = SpriteFactory.GetSprite(GetSpriteID(healthStateMachine, currentState));
        }

        /*
         * This is used to create the string passsed to sprite factory from links current states.
         * Once SF is implemented this can be done as well.
         */
        private string GetSpriteID(LinkHealthStateMachine healthStateMachine, ILinkState linkState)
        {
            return "";
        }
        public void Draw(SpriteBatch spritebatch)
        {
            //currentSprite.Draw(spritebatch, position);
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            currentState.Update();
        }

        public void MoveLeft()
        {
            currentState.MoveLeft();
        }

        public void MoveRight()
        {
            currentState.MoveRight();
        }

        public void MoveUp()
        {
            currentState.MoveUp();
        }

        public void MoveDown()
        {
            currentState.MoveDown();
        }

        public void Jump()
        {
            currentState.Jump();
        }

        public void Attack()
        {
            currentState.Attack();
        }

        public void Crouch()
        {
            currentState.Crouch();
        }
        public int GetXVelocity()
        {
            return XVelocity;
        }
        public void SetXVelocity(int x)
        {
            XVelocity = x;
        }
        public int GetYVelocity()
        {
            return YVelocity;
        }
        public void SetYVelocity(int y)
        {
            YVelocity = y;
        }
    }
}
