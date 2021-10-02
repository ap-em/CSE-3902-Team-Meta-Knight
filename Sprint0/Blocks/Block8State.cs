using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactory;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Blocks
{
    class BlackTileBlockState : IBlockState
    {
        private Block block;

        public BlackTileBlockState(Block block)
        {
            this.block = block;
            block.SetSprite(SpriteFactory.Instance.GetSprite("BlackTile"));
        }
        public void PrevBlock()
        {
            block.SetState(new BlueTileBlockState(block));
        }
        public void NextBlock()
        {
            block.SetState(new StairsBlockState(block));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            block.Draw(spriteBatch);
        }
    }
}
