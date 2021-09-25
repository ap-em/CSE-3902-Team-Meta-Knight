using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;
using Sprint0.Sprites;

/*TODO: WORK with Sprite factory to create the sprite*/

namespace Sprint0.Blocks
{
    class Block6State : IBlockState
    {
        private Block block;

        public Block6State(Block block)
        {
            this.block = block;
            //block.SetSprite(SpriteFactory.Instance.CreateNewSprite("block6"));
        }
        public void PrevBlock()
        {
            block.SetState(new Block5State(block));
        }
        public void NextBlock()
        {
            block.SetState(new Block7State(block));
        }
        public void Draw()
        {
            block.Draw();
        }
    }
}
