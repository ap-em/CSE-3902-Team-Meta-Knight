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
        private IKeyboardController keyboard;
        private IEnemyMovement enemyMovement;
        private ISprite sprite;
        private EnemyHealthStateMachine healthStateMachine;
        public String enemyType = GameUtilities.emptyString;
        private String spriteName = GameUtilities.emptyString;
        private bool firing = false;
        private int firingTimer = 4;
        public int objectRemovalTimer = -1;

        public Vector2 Position { get => enemyMovement.Position; set => enemyMovement.Position = value; }

        public ISprite Sprite => sprite;

        public Enemy(String spriteName, Vector2 position)
        {
            enemyType = spriteName;
            healthStateMachine = new EnemyHealthStateMachine(this);
            enemyMovement = new EnemyMovement(this, position);
            this.spriteName = enemyMovement.GetDirection() + "Idle" + enemyType + healthStateMachine.GetHealth();
            sprite = SpriteFactory.Instance.GetSprite(this.spriteName);
            keyboard = ControllerLoader.Instance.SetUpEnemyKeyboard(this); 
        }
        public void TakeDamage()
        {
            healthStateMachine.TakeDamage();
            SetSprite(enemyType);
        }
        public void InstantDeath()
        {
            GameObjectManager.Instance.RemoveFromObjectList(this);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, enemyMovement.GetLocation());
        }
        public String GetHealth()
        {
            return healthStateMachine.GetHealth();
        }
        public void SetSprite(String enemyType)
        {
            this.enemyType = enemyType;
            bool moving = enemyMovement.GetXVelocity() != 0 || enemyMovement.GetYVelocity() != 0;
            String direction = enemyMovement.GetDirection();
            if(healthStateMachine.GetHealth() == "Dead")
            {
                spriteName = enemyType + healthStateMachine.GetHealth();
            }
            else if (firing)
            {
                // spriteString = enemyMovement.GetDirection() + "Shooting" + enemy.GetEnemyType(); Get to this once we implment an enemy that has a unique attack animation  
            }
            else
            {
                if (moving)
                {
                    spriteName = enemyMovement.GetDirection() + "Moving" + enemyType + healthStateMachine.GetHealth();
                }
                else
                {
                    spriteName = enemyMovement.GetDirection() + "Idle" + enemyType + healthStateMachine.GetHealth();
                }
            }

            sprite = SpriteFactory.Instance.GetSprite(spriteName);
        }
        public String GetSpriteName()
        {
            return enemyType;
        }
        public void FireProjectile()
        {
            if (!firing)
            {
                firing = true;
                ProjectileCreator.Instance.CreateProjectile(enemyType, enemyMovement.GetDirection(), enemyMovement.GetLocation());
            }
        }
        public bool GetFiring()
        {
            return firing;
        }
        public void SetFiring(bool fire)
        {
            firing = fire;
        }

        public void MoveRight()
        {
            enemyMovement.MoveRight();
            SetSprite(enemyType);
        }

        public void MoveLeft()
        {
            enemyMovement.MoveLeft();
            SetSprite(enemyType);
        }

        public void SetXVelocity(float x)
        {
            enemyMovement.SetXVelocity(x);
            SetSprite(enemyType);
        }

        public void SetYVelocity(float y)
        {
            enemyMovement.SetYVelocity(y);
            SetSprite(enemyType);
        }
        public void Update()
        {
            // this is to reset to a different sprite after doing projectil throwing
            // animation after a few frames

            if(firing)
            {
                firingTimer--;
            }
            if (firingTimer < 0)
            {
                firing = false;
                firingTimer = 4;
            }
            if(objectRemovalTimer >= 0)
            {
                objectRemovalTimer--;
            }
            if(objectRemovalTimer == 0)
            {
                GameObjectManager.Instance.RemoveFromObjectList(this);
            }

            enemyMovement.Move();
            sprite.Update();
            keyboard.Update();
        }

        public bool GetGrounded()
        {
            return enemyMovement.GetGrounded();
        }

        public void SetGrounded(bool grounded)
        {
            enemyMovement.SetGrounded(grounded);
        }

        public void UpBounce(Rectangle rectangle)
        {
            SetGrounded(true);
            Position = new Vector2(Position.X, Position.Y - rectangle.Height);
        }

        public void DownBounce(Rectangle rectangle)
        {
            enemyMovement.Position = new Vector2(enemyMovement.Position.X, enemyMovement.Position.Y + rectangle.Height);
            
        }

        public void RightBounce(Rectangle rectangle)
        {
            enemyMovement.Position = new Vector2(enemyMovement.Position.X + rectangle.Width, enemyMovement.Position.Y);
        }

        public void LeftBounce(Rectangle rectangle)
        {
            enemyMovement.Position = new Vector2(enemyMovement.Position.X - rectangle.Width, enemyMovement.Position.Y);
        }

        public void BigUpBounce(Rectangle rectangle)
        {
            enemyMovement.SetYVelocity(-12);
        }

    }
}

