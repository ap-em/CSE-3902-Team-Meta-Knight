using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;


/*OWEN HUSTON - 9/22/2021 */


namespace Sprint0.Enemies
{
    class Enemy : IEnemy
    {
        public IEnemyStateMachine stateMachine;
        public ISprite sprite;
        private Vector2 location = new Vector2(100, 100);
        private Game0 gameHere;

        public Enemy(Game0 game)
        {
            gameHere = game;
            stateMachine = new E1StateMachine(this);
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
            sprite.Draw(gameHere.spriteBatch, location);
        }
        public void Move(int x, int y)
        {
            location = new Vector2(location.X + x, location.Y + y);
        }
        public void FireProjectile()
        {
            stateMachine.FireProjectile();
            //shoot projectile in x direction
        }
        public void Update()
        {
            stateMachine.Update();

            //update animation on sprite
            sprite.Update();
        }
    }
}
