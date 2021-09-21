using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;
using Sprint0.Sprites;

/*TODO: WORK with Sprite factory to create the sprite*/

namespace Sprint0.Blocks
{
    class Block1State : IBlockState
    {
        private Block block;

        public Block1State(Block block)
        {
            this.block = block;
            //block.sprite = SpriteFactory.CreateBlock1();
        }
        public void PrevBlock()
        {
            block.state = new Block3State(block);
        }
        public void NextBlock()
        {
            block.state = new Block2State(block);
        }
        public void Draw()
        {
            block.Draw();
        }
    }
}
