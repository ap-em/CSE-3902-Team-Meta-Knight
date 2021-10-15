using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Cycle;
using Sprint0.Sprites.SpriteFactory;
using Microsoft.Xna.Framework.Graphics;


/*Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston*/


namespace Sprint0.Blocks
{
    class Block : IBlock, ICyclable
    {
        private ICycleStateMachine stateMachine;
        private ISprite sprite;
        private String spriteName;
        private Vector2 location = new Vector2(200, 200);

        public Block()
        {
            stateMachine = new CycleStateMachine(this);
            sprite = SpriteFactory.Instance.GetSprite("OrangeBlock");
            spriteName = "OrangeBlock";
        }
        public String GetSpriteName()
        {
            return spriteName;
        }

        public void SetSprite(String spriteName)
        {
            this.spriteName = spriteName;
            this.sprite = SpriteFactory.Instance.GetSprite(spriteName);
        }
        public void PrevSprite()
        {
            stateMachine.PrevSprite();
        }
        public void NextSprite()
        {
            stateMachine.NextSprite();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}
