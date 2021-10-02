using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactory;
using Microsoft.Xna.Framework.Graphics;


/*OWEN HUSTON - 9/20/2021 */


namespace Sprint0.Blocks
{
    class Block : IBlock
    {
        private IBlockState state;
        private ISprite sprite;
        private Vector2 location = new Vector2(200, 200);

        public Block()
        {
            state = new OrangeBlockState(this);
            sprite = SpriteFactory.Instance.GetSprite("OrangeBlock");
        }
        public void SetSprite(ISprite sprite)
        {
            this.sprite = sprite;
        }
        public void SetState(IBlockState blockState)
        {
            state = blockState;
        }
        public void PrevBlock()
        {
            state.PrevBlock();
            Debug.WriteLine(state.GetType().Name);
        }
        public void NextBlock()
        {
            state.NextBlock();
            Debug.WriteLine(state.GetType().Name);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}
