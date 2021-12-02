using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controllers;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactory;
using Sprint0.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Blocks
{
    class NoInteract :  IGameObject, IDraw
    {
        private ISprite sprite;
        private String spriteName;
        private SoundInfo soundInfo;
        private Vector2 location = new Vector2(GameUtilities.initialBlockPosX, GameUtilities.initialBlockPosY);
        public Vector2 Position { get => location; set => location = value; }
        public ISprite Sprite => sprite;
        private static int basePoints = 10;
        IKeyboardController keyboard;

        public NoInteract(string spriteName, Vector2 position)
        {
            location = position;
            this.spriteName = spriteName;
            sprite = SpriteFactory.Instance.GetSprite(spriteName);
            soundInfo = new SoundInfo();
        }

        

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
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
    }
}
