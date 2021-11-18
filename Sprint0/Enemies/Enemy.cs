using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.SpriteFactory;
using Sprint0.Controllers;
using Sprint0.UtilityClasses;

/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
/*OWEN HUSTON - 9/22/2021 */


namespace Sprint0.Enemies
{
    public class Enemy : IEnemy, IGameObject, IMovable, IUpdate, IDraw, ICollidable, IBounce
    {
        private String soundString;
        private SoundInfo soundInfo;
        private String direction = GameUtilities.right;
        private Vector2 position;
        private IEnemyState currentState; 
        private IKeyboardController keyboard;
        private ISprite sprite;
        private EnemyHealthStateMachine healthStateMachine;
        public String enemyType = GameUtilities.emptyString;
        private String spriteName = GameUtilities.emptyString;
        public int objectRemovalTimer = -1;

        public Vector2 Position { get => position; set => position = value; }

        public ISprite Sprite => sprite;

        public Enemy(String spriteName, Vector2 position)
        {
            this.position = position;
            enemyType = spriteName;
            healthStateMachine = new EnemyHealthStateMachine(NameToStateMapping.Instance.GetHealth(spriteName));
            keyboard = ControllerLoader.Instance.SetUpEnemyKeyboard(this);
            this.spriteName = direction + "Idle" + enemyType + healthStateMachine.GetHealth() + "Health";
            sprite = SpriteFactory.Instance.GetSprite(this.spriteName);

            soundInfo = new SoundInfo();
            soundString = NameToStateMapping.Instance.GetSound(spriteName);

            currentState = NameToStateMapping.Instance.GetState(spriteName, this);
        }
        public String GetStateID()
        {
            return currentState.GetStateID();
        }
        public void SetRemovalTimer(int timer)
        {
            objectRemovalTimer = timer;
        }
        public void TakeDamage()
        {
            soundInfo.PlaySound(soundString, false);
            currentState.TakeDamage();
            SetSprite(enemyType);
        }
        public void GetKicked(Rectangle rec)
        {
            currentState.GetKicked(rec);
            SetSprite(enemyType);
        }
        public void InstantDeath()
        {
            GameObjectManager.Instance.RemoveFromObjectList(this);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }
        public int GetHealth()
        {
            return healthStateMachine.GetHealth();
        }
        public void SetHealth(int health)
        {
            healthStateMachine.SetHealth(health);
        }
        public void SetSprite(String enemyType)
        {
            this.enemyType = enemyType;

            // create spriteName based on enemy direction, movement, type, health
            if(healthStateMachine.GetHealth() == 0)
            {
                spriteName = enemyType + healthStateMachine.GetHealth();
            }
            else
            {
                String isMoving = (currentState.GetVelocity().X != 0 || currentState.GetVelocity().Y != 0) ? "Moving" : "Idle";
                spriteName = direction + isMoving + enemyType + healthStateMachine.GetHealth();
                spriteName = direction + isMoving + enemyType + healthStateMachine.GetHealth();
            }

            sprite = SpriteFactory.Instance.GetSprite(spriteName + "Health");
        }
        public String GetSpriteName()
        {
            return enemyType;
        }

        public void MoveRight()
        {
            direction = GameUtilities.right;
            currentState.MoveRight();
            SetSprite(enemyType);
        }

        public void MoveLeft()
        {
            direction = GameUtilities.left;
            currentState.MoveLeft();
            SetSprite(enemyType);
        }
        public void Move(Vector2 velocity)
        {
            position = new Vector2(position.X + velocity.X, position.Y + velocity.Y);
        }

        public void SetXVelocity(float x)
        {
            currentState.SetXVelocity(x);
            SetSprite(enemyType);
        }

        public void SetYVelocity(float y)
        {
            currentState.SetXVelocity(y);
            SetSprite(enemyType);
        }
        public Vector2 GetVelocity()
        {
            return currentState.GetVelocity();
        }
        public String GetDirection()
        {
            return direction;
        }
        public void SetDirection(String direction)
        {
            this.direction = direction;
        }
        public void SetCurrentState(IEnemyState enemyState)
        {
            currentState = enemyState;
        }
        public void Update()
        {
            if(objectRemovalTimer >= 0)
            {
                objectRemovalTimer--;
            }
            if(objectRemovalTimer == 0)
            {
                GameObjectManager.Instance.RemoveFromObjectList(this);
            }
            
            keyboard.Update();
            currentState.Update();
            sprite.Update();
        }

        public bool GetGrounded()
        {
            return currentState.GetGrounded();
        }

        public void SetGrounded(bool grounded)
        {
            currentState.SetGrounded(grounded);
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

        public void BigUpBounce(Rectangle rectangle)
        {
            currentState.BigUpBounce(rectangle);
        }

    }
}

