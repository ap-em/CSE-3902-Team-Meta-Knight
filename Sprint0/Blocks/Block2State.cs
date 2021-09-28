﻿using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;
using Sprint0.Sprites;

/*TODO: WORK with Sprite factory to create the sprite*/

namespace Sprint0.Blocks
{
    class Block2State : IBlockState
    {
        private Block block;

        public Block2State(Block block)
        {
            this.block = block;
           // block.sprite = SpriteFactory.CreateBlock2();
        }
        public void PrevBlock()
        {
            block.state = new Block1State(block);
        }
        public void NextBlock()
        {
            block.state = new Block3State(block);
        }
        public void Draw()
        {
            block.Draw();
        }
    }
}