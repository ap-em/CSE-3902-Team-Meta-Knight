using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Sprites.SpriteFactory;
using Sprint0.Concrete_Classes.State_Machines.States;
using Sprint0.Interfaces;
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
    public class Link :ILink, IGameObject
    {
        private IKeyboardController keyboard;
        private LinkHealthStateMachine healthStateMachine;
        public ILinkState currentState;
        private Vector2 position = new Vector2(100, 100);
        private ISprite currentSprite;
        private ILinkState attack;

        public Vector2 Position { get => position; set => throw new NotImplementedException(); }

        public ISprite Sprite => currentSprite;

        public Link(String spriteName, Vector2 position)
        {
            healthStateMachine = new LinkHealthStateMachine(this);

            this.position = position;
            currentState = new RightFacingStaticLink(this);
            OnStateChange();
            keyboard = Game0.Instance.SetUpPlayerKeyboard(this);
            GameObjectManager.Instance.AddToObjectList(this);
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

            return linkState.ID + healthStateMachine.GetHealth();
        }
        public void Draw(SpriteBatch spritebatch)
        {
            currentSprite.Draw(spritebatch, position);
        }

        public void Update()
        {
            healthStateMachine.Update();
            currentState.Update();
            currentSprite.Update();
            keyboard.Update();
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
        public void Jump()
        {
            currentState.Jump();
        }
        public void TakeDamage()
        {
            healthStateMachine.TakeDamage();
        }
        public void StarPower()
        {
            healthStateMachine.StarPower();
        }

        public void PrimaryAttack()
        {
            attack = new AttackLink(currentState, position);
            attack.Attack();
        }

        public void Crouch()
        {
            currentState.Crouch();
        }
        public void StopMovingHorizontal()
        {
            currentState.StopMovingHorizontal();
        }
        public void StopMovingVertical()
        {
            currentState.StopMovingVertical();
        }
    }
}
