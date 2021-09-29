using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Enemies;


/*OWEN HUSTON - 9/22/2021 */


namespace Sprint0
{
    public class Enemy : IEnemy
    {
        public IEnemyMovement enemyMovement;
        public IEnemyStateMachine stateMachine;
        private ISprite sprite;
        private String enemyType = "Enemy1";
        private int firingTimer = 10;
        private bool firing = false;
        private Game0 game;

        public Enemy(Game0 game)
        {
            this.game = game;
            enemyMovement = new EnemyMovement(this, game, new Vector2(100,100));
            stateMachine = new EnemyStateMachine(this, game, enemyMovement);
        }
        public void PrevEnemy()
        {
            stateMachine.PrevEnemy();
        }
        public void NextEnemy()
        {
            stateMachine.NextEnemy();
        }
        public void Draw()
        {
           // sprite.Draw(gameHere.spriteBatch, enemyMovement.GetLocation);
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
                SetFiring(true);
            }
        }
        public bool GetFiring()
        {
            return firing;
        }
        public void SetFiring(bool fire)
        {
            firing = fire;
            //reset timer if firing
            if (fire) firingTimer = 30;
        }
        public void SetEnemyType(string enemyType)
        {
            this.enemyType = enemyType;
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
            enemyMovement.Move();
            // this is to reset to a different sprite after doing projectil throwing
            // animation after a few frames
            if (firing)
            {
                firingTimer--;
            }
            if(firingTimer < 0)
            {
                firing = false;
                SetStateMachineSprite();
            }
            //update animation on sprite
           // sprite.Update();
        }
    }
}
