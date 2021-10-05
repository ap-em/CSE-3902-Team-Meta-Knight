using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactory;
using Microsoft.Xna.Framework.Graphics;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0.Blocks
{
    class GreenTileBlockState : IBlockState
    {
        private Block block;

        public GreenTileBlockState(Block block)
        {
            this.block = block;
            block.SetSprite(SpriteFactory.Instance.GetSprite("GreenTile"));
        }
        public void PrevBlock()
        {
            block.SetState(new GreenStatueLeftBlockState(block));
        }
        public void NextBlock()
        {
            block.SetState(new BlueTileBlockState(block));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            block.Draw(spriteBatch);
        }
    }
}
