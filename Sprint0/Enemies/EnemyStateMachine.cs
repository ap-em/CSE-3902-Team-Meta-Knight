using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.SpriteFactory;

/*Owen Huston 9/22/21 */

namespace Sprint0.Enemies
{
    class EnemyStateMachine : IEnemyStateMachine
    { 
        private Enemy enemy;
        private int projectileXVelocity;
        private int projectileYVelocity;
        private int fuseTime = 30;
        private ISprite sprite;
        private String spriteString;
        private IEnemyMovement enemyMovement;

        public EnemyStateMachine(Enemy enemy, IEnemyMovement enemyMovement)
        {
            this.enemy = enemy;
            this.enemyMovement = enemyMovement;
            SetSprite();
        }
        public void SetSprite()
        {
            bool moving = enemyMovement.GetXVelocity() != 0 || enemyMovement.GetYVelocity() != 0;

            if(enemy.GetFiring())
            {
                spriteString = enemyMovement.GetDirection() + "Shooting" + enemy.GetEnemyType();
            }
            else 
            { 
                if(moving)
                {
                    spriteString = enemyMovement.GetDirection() + "Moving" + enemy.GetEnemyType();
                }
                else
                {
                    spriteString = enemyMovement.GetDirection() + "Idle" + enemy.GetEnemyType();
                }
            }
            //            Debug.WriteLine(spriteString);
            enemy.SetSprite(SpriteFactory.Instance.GetSprite(spriteString));
        }

        public void PrevEnemy()
        {
            String enemyType = enemy.GetEnemyType();
            switch (enemyType)
            {
                case "Enemy1":
                    enemy.SetEnemyType("Enemy3");
                    break;

                case "Enemy2":
                    enemy.SetEnemyType("Enemy1");
                    break;

                case "Enemy3":
                    enemy.SetEnemyType("Enemy2");
                    break;

                default:
                    enemy.SetEnemyType("Enemy1");
                    break;
            }
        }
        public void NextEnemy()
        {
            String enemyType = enemy.GetEnemyType();
            switch (enemyType)
            {
                case "Enemy1":
                    enemy.SetEnemyType("Enemy2");
                    break;

                case "Enemy2":
                    enemy.SetEnemyType("Enemy3");
                    break;

                case "Enemy3":
                    enemy.SetEnemyType("Enemy1");
                    break;

                default:
                    enemy.SetEnemyType("Enemy1");
                    break;
            }
        }
        public void FireProjectile()
        {
            String direction = enemyMovement.GetDirection();
            switch (direction)
            {
                case "Left":
                    projectileXVelocity = -4;
                    projectileYVelocity = 0;
                    break;

                case "Right":
                    projectileXVelocity = 4;
                    projectileYVelocity = 0;
                    break;

                case "Up":
                    projectileXVelocity = 0;
                    projectileYVelocity = -4;
                    break;

                case "Down":
                    projectileXVelocity = 0;
                    projectileYVelocity = 4;
                    break;

                default:
                    projectileXVelocity = -4;
                    projectileYVelocity = 0;
                    break;
            }
                    ProjectileController.Instance.AddProjectile(
                        new Projectile(SpriteFactory.Instance.GetSprite("Bomb"),
          enemyMovement.GetLocation(), projectileXVelocity, projectileYVelocity, fuseTime));
        }
        public void Update()
        {

        }
    }
}
