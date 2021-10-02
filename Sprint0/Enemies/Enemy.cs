using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Enemies;
using Microsoft.Xna.Framework.Graphics;


/*OWEN HUSTON - 9/22/2021 */


namespace Sprint0
{
    public class Enemy : IEnemy
    {
        private IEnemyMovement enemyMovement;
        private IEnemyStateMachine stateMachine;
        private ISprite sprite;
        private String enemyType = "Octorok";
        private bool firing = false;
        private int firingTimer = 4;


        public Enemy()
        {
            enemyMovement = new EnemyMovement(this, new Vector2(300,300));
            stateMachine = new EnemyStateMachine(this, enemyMovement);
        }
        public void PrevEnemy()
        {
            stateMachine.PrevEnemy();
            SetStateMachineSprite();
        }
        public void NextEnemy()
        {
            stateMachine.NextEnemy();
            SetStateMachineSprite();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, enemyMovement.GetLocation());
        }
        public void SetSprite(ISprite sprite)
        {
            this.sprite = sprite;
        }
        public void SetStateMachineSprite()
        {
            stateMachine.SetSprite();
        }
        public void FireProjectile()
        {
            if (!firing)
            {
                stateMachine.FireProjectile();
                firing = true;
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
        public void SetEnemyType(string enemyType)
        {
             this.enemyType = enemyType;
             SetStateMachineSprite();
        }

        public string GetEnemyType()
        {
            return enemyType;
        }

        public void MoveRight()
        {
            enemyMovement.MoveRight();
            SetStateMachineSprite();
        }

        public void MoveLeft()
        {
            enemyMovement.MoveLeft();
            SetStateMachineSprite();
        }

        public void MoveUp()
        {
            enemyMovement.MoveUp();
            SetStateMachineSprite();
        }

        public void MoveDown()
        {
            enemyMovement.MoveDown();
            SetStateMachineSprite();
        }

        public void SetXVelocity(int x)
        {
            enemyMovement.SetXVelocity(x);
            SetStateMachineSprite();
        }

        public void SetYVelocity(int y)
        {
            enemyMovement.SetYVelocity(y);
            SetStateMachineSprite();
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

            enemyMovement.Move();
            sprite.Update();
        }
    }
}
