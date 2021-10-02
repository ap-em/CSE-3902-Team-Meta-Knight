using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactory;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Blocks
{
    class BlueStatueBlockState : IBlockState
    {
        private Block block;

        public BlueStatueBlockState(Block block)
        {
            this.block = block;
            block.SetSprite(SpriteFactory.Instance.GetSprite("BlueStatueRight"));
        }
        public void PrevBlock()
        {
            block.SetState(new BlueBlockState(block));
        }
        public void NextBlock()
        {
            block.SetState(new BlueStatueLeftBlockState(block));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            block.Draw(spriteBatch);
        }
    }
}
