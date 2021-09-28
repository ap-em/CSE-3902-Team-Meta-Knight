using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;


/*OWEN HUSTON - 9/20/2021 */

/*TODO: work with sprite factory to make block created*/


namespace Sprint0.Blocks
{
    class Block : IBlock
    {
        private IBlockState state;
        private ISprite sprite;
        private Vector2 location = new Vector2(200, 200);
        public Game0 gameHere;

        public Block()
        {
            state = new Block1State(this);
            // sprite = SpriteFactory.Instance.CreateNewSprite("block1");
        }
        public void SetSprite(ISprite sprite)
        {
            this.sprite = sprite;
        }
        public void SetState(IBlockState blockState)
        {
            state = blockState;
        }
        public void PrevBlock()
        {
            state.PrevBlock();
            Debug.WriteLine(state.GetType().Name);
        }
        public void NextBlock()
        {
            state.NextBlock();
            Debug.WriteLine(state.GetType().Name);
        }
        public void Draw()
        {
            sprite.Draw(gameHere.spriteBatch, location);
        }
    }
}
