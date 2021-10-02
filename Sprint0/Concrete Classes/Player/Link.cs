using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Sprites.SpriteFactory;
using Sprint0.Concrete_Classes.State_Machines.States;

namespace Sprint0
{
    public class Link :ILink
    {
        private LinkHealthStateMachine healthStateMachine;
        public ILinkState currentState;
        private int XVelocity = 0;
        private int YVelocity = 0;
        private Vector2 position = new Vector2(100, 100);
        private ISprite currentSprite;
        private ILinkState attack;


        public Link()
        {
            healthStateMachine = new LinkHealthStateMachine();
            currentState = new RightFacingStaticLink(this);
            OnStateChange();
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
            currentSprite = SpriteFactory.Instance.GetSprite(GetSpriteID(healthStateMachine, currentState));
        }

        /*
         * This is used to create the string passsed to sprite factory from links current states.
         * Once SF is implemented this can be done as well.
         */
        private string GetSpriteID(LinkHealthStateMachine healthStateMachine, ILinkState linkState)
        {
            //Right now the health state machine has no impact on the sprite ---but in the future might have a sprite that does need that
            return linkState.ID;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            currentSprite.Draw(spritebatch, position);
        }

        public void Execute()
        {
           throw new NotImplementedException();
        }

        public void Update()
        {
            currentState.Update();
            currentSprite.Update();
        }

        public void MoveSprite(Vector2 change)
        {
            position = new Vector2(position.X + change.X, position.Y + change.Y);
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

        public void PrimaryAttack()
        {
            attack = new AttackLink(currentState, position);
            attack.Attack();
        }
        public void SecondaryAttack(String attackType)
        {
            attack = new SecondaryAttackLink(currentState, position, attackType);
            attack.Attack();
        }

        public void Crouch()
        {
            currentState.Crouch();
        }
        public void StopMoving(string sourceDirection)
        {
            currentState.StopMoving(sourceDirection);
        }
        private int GetXVelocity()
        {
            return XVelocity;
        }
        private void SetXVelocity(int x)
        {
            XVelocity = x;
        }
        private int GetYVelocity()
        {
            return YVelocity;
        }
        private void SetYVelocity(int y)
        {
            YVelocity = y;
        }
    }
}
