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
    class Flag : IBlock, IGameObject, IDraw, ICollidable, IFlag
    {
        private ISprite sprite;
        private String spriteName;
        private SoundInfo soundInfo;
        private Vector2 location = new Vector2(GameUtilities.initialBlockPosX, GameUtilities.initialBlockPosY);
        public Vector2 Position { get => location; set => location = value; }
        public ISprite Sprite => sprite;
        private static int basePoints = 10;
        KeyboardController keyboard = KeyboardController.Instance;

        public Flag(string spriteName, Vector2 position)
        {
            location = position;
            this.spriteName = spriteName;
            sprite = SpriteFactory.Instance.GetSprite(spriteName);

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

        public void Win(IMario mario)
        {
            //prevents unlimited points and allows for sliding down flagpole
            if (keyboard.lockInput == false)
            {
                keyboard.lockInput = true;
                //Send this to wherever points are managed.
                int points = ((int)Math.Round(mario.Position.Y)) * basePoints;
            }
           
           

        }
    }
}
