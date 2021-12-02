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
using Sprint0.Timers;


/*Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston*/


namespace Sprint0.Blocks
{
    class MushroomBlock : IBlock, IGameObject, IUpdate, IDraw, ICollidable, IDynamicBlock
    {
        private bool hit = false;
        private ISprite sprite;
        private String spriteName;
        private SoundInfo soundInfo;
        private Vector2 location = new Vector2(GameUtilities.initialBlockPosX, GameUtilities.initialBlockPosY);

        public Vector2 Position { get => location; set => location = value; }

        public ISprite Sprite => sprite;

        public MushroomBlock(String spriteName, Vector2 position)
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
            BounceUp();

            // bounce back down after 50 milliseconds
            Timer bounceDownTimer = new Timer(50, BounceDown);
            bounceDownTimer.StartTimer();

            //only hit if we haven't hit before
            if (!hit)
            {
                soundInfo.PlaySound("itemblock", false);
                GameObjectManager.Instance.AddToObjectList(new Item("Mushroom", new Vector2(Position.X, Position.Y - 32)), 0, 0);
                SetSprite("UsedItemBlock");
                hit = true;
            }
        }
        public void BounceUp()
        {
            Position = new Vector2(Position.X, Position.Y - 5);
        }
        public void BounceDown(Object source, System.Timers.ElapsedEventArgs e)
        {
            Position = new Vector2(Position.X, Position.Y + 5);
        }
    }
}