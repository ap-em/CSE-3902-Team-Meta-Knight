using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0.HUD
{
    public class HUD: IHUD
    {
        private Vector2 position;
        private float maxPlayerPosition;
        private int lives = 3;
        private int score = 0;
        private int index = 0;
        private IGameObject gameObject;
        public HUD(IGameObject go, int index)
        {
            this.index = index;
            gameObject = go;
            maxPlayerPosition = gameObject.Position.X;
        }

        public int GetIndex()
        {
            return index;
        }

        public Vector2 GetPosition()
        {
            return position;
        }
        public void AddScore(int increment)
        {
            score += increment;
            Debug.WriteLine("SCORE: " + score);
        }
        public void RemoveLife()
        {
            lives--;
        }

        public void Update()
        {
            if(gameObject.Position.X > maxPlayerPosition)
            {
                AddScore(1);
                maxPlayerPosition = gameObject.Position.X;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
