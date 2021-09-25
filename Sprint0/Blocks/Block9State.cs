using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;
using Sprint0.Sprites;

/*TODO: WORK with Sprite factory to create the sprite*/

namespace Sprint0.Blocks
{
    class Block9State : IBlockState
    {
        private Block block;

        public Block9State(Block block)
        {
            this.block = block;
            //block.SetSprite(SpriteFactory.Instance.CreateNewSprite("block9"));
        }
        public void PrevBlock()
        {
            block.SetState(new Block8State(block));
        }
        public void NextBlock()
        {
            block.SetState(new Block1State(block));
        }
        public void Draw()
        {
            block.Draw();
        }
    }
}
