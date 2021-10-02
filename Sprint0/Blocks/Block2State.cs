using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactory;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Blocks
{
    class BlueBlockState : IBlockState
    {
        private Block block;

        public BlueBlockState(Block block)
        {
            this.block = block;
            block.SetSprite(SpriteFactory.Instance.GetSprite("BlueBlock"));
        }
        public void PrevBlock()
        {
            block.SetState(new OrangeBlockState(block));
        }
        public void NextBlock()
        {
            block.SetState(new BlueStatueBlockState(block));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            block.Draw(spriteBatch);
        }
    }
}
