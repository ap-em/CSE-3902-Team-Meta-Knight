using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactory;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Blocks
{
    class BlueStatueLeftBlockState : IBlockState
    {
        private Block block;

        public BlueStatueLeftBlockState(Block block)
        {
            this.block = block;
            block.SetSprite(SpriteFactory.Instance.GetSprite("BlueStatueLeft"));
        }
        public void PrevBlock()
        {
            block.SetState(new BlueStatueBlockState(block));
        }
        public void NextBlock()
        {
            block.SetState(new GreenStatueLeftBlockState(block));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            block.Draw(spriteBatch);
        }
    }
}
