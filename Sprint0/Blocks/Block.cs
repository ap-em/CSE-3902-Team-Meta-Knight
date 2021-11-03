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
using Sprint0.UtilityClasses;


/*Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston*/


namespace Sprint0.Blocks
{
    class Block : IBlock, ICyclable, IGameObject, IStatic
    {
        private ICycleStateMachine stateMachine;
        private ISprite sprite;
        private String spriteName;
        private Vector2 location = new Vector2(GameUtilities.initialBlockPosX, GameUtilities.initialBlockPosY);

        public Vector2 Position { get => location; set => throw new NotImplementedException(); }

        public ISprite Sprite => sprite;

        public Block(String spriteName, Vector2 position)
        {
            stateMachine = new CycleStateMachine(this);
            location = position;
            this.spriteName = spriteName;
            sprite = SpriteFactory.Instance.GetSprite(spriteName);
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

        public void Update()
        {
            sprite.Update();
        }

        public void BreakBlock(IMario mario)
        {
            if(this.GetSpriteName() == "BrickBlock" && mario.GetHealthState() == "Full" || mario.GetHealthState() == "Fire" || mario.GetHealthState() == "Star")
            {
                GameObjectManager.Instance.RemoveFromObjectList(this);
                ISprite block = SpriteFactory.Instance.GetSprite("BrickBlockBreak");
                block.Draw(Game0.Instance.spriteBatch, location);
            }
         }

    }
}