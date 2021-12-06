using Sprint0.Enemies;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Sprint0.Commands
{
    class CDamageEnemy : ICommand
    {
        private IEnemy enemy;
        private ICollidable collided;
        public CDamageEnemy(IEnemy enemyRefernce, ICollidable collided, Rectangle rec)
        {
            this.collided = collided;
            enemy = enemyRefernce;
        }
        public void Execute()
        {

            if(collided is IEnemy)
            {
                IEnemy collidedEnemy = (IEnemy)collided;

                //moving koopa shells hurt enemies
                if (collidedEnemy.GetStateID() == "KoopaShell" && enemy.GetVelocity() != new Vector2(0, 0))
                {
                    
                    enemy.TakeDamage();
                }
            }
            else if(collided is IMario)
            {
                enemy.TakeDamage();
            }
            else if(collided is IProjectile)
            {
                IProjectile projectile = (IProjectile)collided;

                if(projectile.SpriteName == "fireball")
                {
                    enemy.TakeDamage();
                    GameObjectManager.Instance.RemoveFromObjectList((IGameObject)collided);
                }
            }
        }
    }
}
