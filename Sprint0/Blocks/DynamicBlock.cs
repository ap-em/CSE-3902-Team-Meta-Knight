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
    class DynamicBlock : IGameObject, IUpdate, IDraw, ICollidable, IDynamicBlock
    {
        private ISprite sprite;
        private String spriteName;
        private Vector2 location = new Vector2(GameUtilities.initialBlockPosX, GameUtilities.initialBlockPosY);

        public Vector2 Position { get => location; set => throw new NotImplementedException(); }

        public ISprite Sprite => sprite;

        public DynamicBlock(String spriteName, Vector2 position)
        {
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
            Debug.WriteLine("working");
            if(GetSpriteName() == "BrickBlock" && (mario.GetHealthState() == "Full" || mario.GetHealthState() == "Fire" || mario.GetHealthState() == "Star"))
            {
                Debug.WriteLine(GetSpriteName());
                GameObjectManager.Instance.RemoveFromObjectList(this);
            }
        }
    }
}