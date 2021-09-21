using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;


/*OWEN HUSTON - 9/20/2021 */

/*TODO: work with sprite factory to make block created*/


namespace Sprint0.Blocks
{
    class Block : IBlock
    {
        public IBlockState state;
        public ISprite sprite;
        private Vector2 location = new Vector2(200, 200);
        private Game0 gameHere;

        public Block(Game0 game)
        {
            gameHere = game;
            state = new Block1State(this);
            // sprite = SpriteFactory.CreateBlock1();
        }
        public void PrevBlock()
        {
            state.PrevBlock();
        }
        public void NextBlock()
        {
            state.NextBlock();
        }
        public void Draw()
        {
            sprite.Draw(gameHere.spriteBatch, location);
        }
    }
}
