using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;
using Sprint0.Sprites;

/*TODO: WORK with Sprite factory to create the sprite*/

namespace Sprint0.Blocks
{
    class Block3State : IBlockState
    {
        private Block block;

        public Block3State(Block block)
        {
            this.block = block;
           // block.sprite = SpriteFactory.CreateBlock3();
        }
        public void PrevBlock()
        {
            block.state = new Block2State(block);
        }
        public void NextBlock()
        {
            block.state = new Block1State(block);
        }
        public void Draw()
        {
            block.Draw();
        }
    }
}
