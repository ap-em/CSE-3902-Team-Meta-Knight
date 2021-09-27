using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
namespace Sprint0.Sprites
{
    class AnimatedFixedSprite : ISprite
    {


        private Texture2D _texture;
        private Vector2 position = new Vector2(350, 175);
        public float Speed = 2f;
        public float EndOfScreen = -150f;
        public float BeginningOfScreen = 500f;
        private AnimatedSprite animatedSprite;

        public  AnimatedFixedSprite(Texture2D texture, int row, int column)
        {
            _texture = texture;
            animatedSprite = new AnimatedSprite(_texture, row, column);
        }
        public void Update()
        {
        animatedSprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            animatedSprite.Draw(spriteBatch, position);
        }


    }
}