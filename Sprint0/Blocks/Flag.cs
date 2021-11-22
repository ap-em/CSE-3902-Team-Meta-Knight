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
        IKeyboardController keyboard;

        public Flag(string spriteName, Vector2 position)
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

        public void Win(IMario mario)
        {
            //prevents unlimited points and allows for sliding down flagpole
            keyboard = PlayerKeyboardManager.Instance.GetKeyboard((IGameObject)mario);
            if (keyboard.GetLockInput() == false)
            {
                keyboard.SetLockInput(true);
                LevelFactory.Instance.StopTheme();
                soundInfo.PlaySound("smb_stage_clear", false);
                //Send this to wherever points are managed.
                int points = ((int)Math.Round(mario.Position.Y)) * basePoints;
            }
           
           

        }
    }
}
