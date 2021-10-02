﻿using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactory;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Blocks
{
    class BlueTileBlockState : IBlockState
    {
        private Block block;

        public BlueTileBlockState(Block block)
        {
            this.block = block;
            block.SetSprite(SpriteFactory.Instance.GetSprite("BlueTile"));
        }
        public void PrevBlock()
        {
            block.SetState(new GreenTileBlockState(block));
        }
        public void NextBlock()
        {
            block.SetState(new BlackTileBlockState(block));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            block.Draw(spriteBatch);
        }
    }
}
