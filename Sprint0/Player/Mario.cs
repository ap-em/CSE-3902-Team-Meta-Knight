using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Sprites.SpriteFactory;
using Sprint0.Concrete_Classes.State_Machines.States;
using Sprint0.Interfaces;
using Sprint0.Controllers;
using Sprint0.UtilityClasses;
using System.Diagnostics;
using Sprint0.HUD;
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
    public class Mario :IMario, IGameObject, IMovable, IUpdate,IDraw, ICollidable, IBounce
    {
        private MarioHealthStateMachine healthStateMachine;
        public IMarioState currentState;
        private Vector2 position = new Vector2(GameUtilities.initialPosX, GameUtilities.initialPosY);
        private ISprite currentSprite;
        private IMarioState attack;
        private bool isGrounded;
        public bool isJumping = false;
        public SoundInfo soundInfo;
        public Vector2 Position { get => position; set => position = value; }

        public ISprite Sprite => currentSprite;

        public Mario(String spriteName, Vector2 position)
        {
            CameraManager.Instance.CreateCamera(this);
            PlayerKeyboardManager.Instance.CreateKeyboard(this);
            HUDManager.Instance.CreateHUD(this);
            healthStateMachine = new MarioHealthStateMachine(this);
            this.position = position;
            currentState = new RightFacingStaticMario(this);
            OnStateChange();
            soundInfo = new SoundInfo();
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
         * This is used to create the string passsed to sprite factory from marios current states.
         * Once SF is implemented this can be done as well.
         */
        private string GetSpriteID(MarioHealthStateMachine healthStateMachine, IMarioState marioState)
        {

            return marioState.ID + healthStateMachine.GetHealth();
        }
        public bool GetGrounded()
        {
            return isGrounded;
        }
        public void SetGrounded(bool grounded)
        {
            isGrounded = grounded;
        }
        public bool IsJumping()
        {
            return isJumping;
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
            isJumping = true;
            Debug.WriteLine("isJumping true");
        }
        public void StopJump()
        {
            currentState.StopJump();
            isJumping = false;
            Debug.WriteLine("isJumping false");
        }
        public void TakeDamage()
        {
            healthStateMachine.TakeDamage();
        }
        public void MushroomPower()
        {
            healthStateMachine.MushroomPower();
        }
        public void FireflowerPower()
        {
            healthStateMachine.FirePower();
        }
        public void StarPower()
        {
            healthStateMachine.StarPower();
        }

        public void PrimaryAttack()
        {
            if (healthStateMachine.GetHealth().Equals("Fire"))
            {
                attack = new AttackMario(this, currentState, position);
                attack.Attack();
            }
        }
        public void UpBounce(Rectangle rectangle)
        {
            currentState.UpBounce(rectangle);
        }
        public void DownBounce(Rectangle rectangle)
        {
            currentState.DownBounce(rectangle);
        }
        public void RightBounce(Rectangle rectangle)
        {
            currentState.RightBounce(rectangle);
        }
        public void LeftBounce(Rectangle rectangle)
        {
            currentState.LeftBounce(rectangle);
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
        public String GetHealthState()
        {
            return healthStateMachine.GetHealth();
        }

        public void BigUpBounce(Rectangle rectangle)
        {
            currentState.MarioBounce(rectangle);
        }
    }
}
