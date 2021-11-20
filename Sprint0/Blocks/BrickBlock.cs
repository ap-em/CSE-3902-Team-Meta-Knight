using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactory;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.UtilityClasses;
using Sprint0.Items;
using Sprint0.HUD;


/*Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston*/


namespace Sprint0.Blocks
{
    class BrickBlock : IBlock, IGameObject, IUpdate, IDraw, ICollidable, IDynamicBlock
    {
        private int breakBlockTimer = -1;
        private int bounceBackTimer = -1;
        private ISprite sprite;
        private String spriteName;
        private SoundInfo soundInfo;
        private Vector2 location = new Vector2(GameUtilities.initialBlockPosX, GameUtilities.initialBlockPosY);

        public Vector2 Position { get => location; set => location = value; }

        public ISprite Sprite => sprite;

        public BrickBlock(String spriteName, Vector2 position)
        {
            soundInfo = new SoundInfo();
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
            sprite = SpriteFactory.Instance.GetSprite(spriteName);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Update()
        {
            if(bounceBackTimer >= 0)
            {
                bounceBackTimer--;
            }
            if(bounceBackTimer == 0)
            {
                Position = new Vector2(Position.X, Position.Y + 5);
            }
            if(breakBlockTimer >= 0)
            {
                breakBlockTimer--;
            }
            if(breakBlockTimer == 0)
            {
                GameObjectManager.Instance.RemoveFromObjectList(this);
            }
            sprite.Update();
        }
        public void BreakBlock(IMario mario)
        {
            if (bounceBackTimer < 0 && breakBlockTimer < 0)
            {
                bounceBackTimer = 2;
                Position = new Vector2(Position.X, Position.Y - 5);
            }
            if (GetSpriteName() == "BrickBlock" && (mario.GetHealthState() == "Full" || mario.GetHealthState() == "Fire" || mario.GetHealthState() == "Star"))
            {
                soundInfo.PlaySound("brickbreak", false);
                //only set the timer if we havent already set the timer
                if (breakBlockTimer < 0)
                {
                    GameObjectManager.Instance.AddToObjectList(new BlockDebris("BrickDebris", Position), 0, 0);
                    breakBlockTimer = 2;
                }
                IHUD hud = HUDManager.Instance.GetHUD((IGameObject)mario);
                hud.SetScore(hud.GetScore() + 10);
            }
        }
    }
}