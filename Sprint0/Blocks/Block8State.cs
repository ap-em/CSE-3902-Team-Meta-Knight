using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;
using Sprint0.Sprites;

/*TODO: WORK with Sprite factory to create the sprite*/

namespace Sprint0.Blocks
{
    class Block8State : IBlockState
    {
        private Block block;

        public Block8State(Block block)
        {
            this.block = block;
            //block.SetSprite(SpriteFactory.Instance.CreateNewSprite("block8"));
        }
        public void PrevBlock()
        {
            block.SetState(new Block7State(block));
        }
        public void NextBlock()
        {
            block.SetState(new Block9State(block));
        }
        public void Draw()
        {
            block.Draw();
        }
    }
}
