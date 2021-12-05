using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.UtilityClasses;
using Sprint0.Controllers;
using Sprint0.Interfaces;
using Sprint0.HUD;
using Sprint0.Commands;
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
    class RightFacingFlagMario : IMarioState
    {
        private Mario mario;
        public string ID { get; } = "RightClimbMario";
        private Vector2 velocity = new Vector2(0, 0);
       

        public RightFacingFlagMario(Mario marioRef)
        {

            mario = marioRef;

            mario.HealthStateMachine.Invincibility = true;

            if (!CameraManager.Instance.cameras.ContainsKey(mario))
            {
                CameraManager.Instance.CinematicCamera(mario);
            }
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
            mario.soundInfo.PlaySound("smb2_jump", false);
            mario.currentState = new RightFacingJumpingMario(mario, new Vector2(velocity.X, -10), 0, true);
            mario.OnStateChange();
        }
        public void StopJump()
        {

        }

        public void MoveLeft()
        {
            mario.currentState = new LeftFacingMovingMario(mario);
            mario.OnStateChange();
        }

        public void MoveRight()
        {
            mario.currentState = new RightFacingMovingMario(mario);
            mario.OnStateChange();
        }
        public void StopMovingHorizontal()
        {
            velocity.X = 0;
        }
        public void StopMovingVertical()
        {
            velocity.Y = 0;
        }
        public void UpBounce(Rectangle rectangle)
        {
            mario.SetGrounded(true);
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - rectangle.Height);
            //Debug.WriteLine("Nudge Static up: " + rectangle.Height);
            StopMovingVertical();
        }
        public void DownBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + rectangle.Height);
            velocity = new Vector2(velocity.X, 2f);
        }
        public void RightBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X + rectangle.Width, mario.Position.Y);
           //StopMovingHorizontal();
        }
        public void LeftBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X - rectangle.Width, mario.Position.Y);
            //StopMovingHorizontal();
        }
        public void Update()
        {
            //If mario is below what the camera can see then swap level
            if (mario.Position.Y > CameraManager.Instance.GetCamera(mario).GetViewport().Height+ CameraManager.Instance.GetCamera(mario).GetPosition().Y && HUDManager.Instance.GetHUD((IGameObject)mario).GetLevel() == 1)
            {
                int newLevel = HUDManager.Instance.GetHUD((IGameObject)mario).GetLevel() + 1;
                HUDManager.Instance.GetHUD((IGameObject)mario).SetLevel(newLevel);
                ICommand reset = new CReset(mario);
                reset.Execute();
                
            }
            
            //Player regains control when mario lands on bottom of level 2
            if (mario.GetGrounded())
            {
                mario.HealthStateMachine.Invincibility = false;
                CameraManager.Instance.RemoveCamera(mario);
                if (LevelFactory.Instance.currentLevel == 1)
                {
                    CameraManager.Instance.CreateLevel1Camera(mario);
                }
                else
                {
                    CameraManager.Instance.CreateLevel2Camera(mario);
                }
                

                velocity = new Vector2(0f, 0f);
                mario.Position = new Vector2(mario.Position.X + GameUtilities.bias, mario.Position.Y);
                IKeyboardController keyboard = PlayerKeyboardManager.Instance.GetKeyboard((IGameObject)mario);
                keyboard.SetLockInput(false);
                mario.currentState = new RightFacingStaticMario(mario);
                
                mario.OnStateChange();

            }
            else 
            {
                //Otherwise he keeps sliding down
                velocity = new Vector2(0, GameUtilities.gravity);
            }
            
            mario.MoveSprite(velocity);
        }

        public void MarioBounce(Rectangle rectangle)
        {
            velocity.Y = -12f;
        }
    }
}
