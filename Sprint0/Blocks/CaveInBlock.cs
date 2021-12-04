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
using Sprint0.Timers;


/*Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston*/


namespace Sprint0.Blocks
{
    class CaveInBlock : IBlock, IGameObject, IUpdate, IDraw, ICollidable, IDynamicBlock
    {
        private ISprite sprite;
        private String spriteName;
        private SoundInfo soundInfo;
        private Vector2 location = new Vector2(GameUtilities.initialBlockPosX, GameUtilities.initialBlockPosY);

        public Vector2 Position { get => location; set => location = value; }

        public ISprite Sprite => sprite;

        public CaveInBlock(String spriteName, Vector2 position)
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
            sprite.Update();
        }
        public void BreakBlock(IMario mario)
        {
            // bounce up
            BounceUp();

            // bounce back down after 50 milliseconds
            TimerManager.Instance.AddToTimerList(new Timer(50, BounceDown));

            
            soundInfo.PlaySound("brickbreak", false);

            // break block after 60 milliseconds
            TimerManager.Instance.AddToTimerList(new Timer(60, BreakBlock));

                
            
        }
        public void BounceUp()
        {
            Position = new Vector2(Position.X, Position.Y - 5);
        }
        public void BounceDown()
        {
            Position = new Vector2(Position.X, Position.Y + 5);
        }
        public void BreakBlock()
        {
            GameObjectManager.Instance.AddToObjectList(new BlockDebris("BrickDebris", Position), 0, 0);
            GameObjectManager.Instance.RemoveFromObjectList(this);
        }
    }
}