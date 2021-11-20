using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactory;
using System;
using Sprint0.UtilityClasses;
using Sprint0.HUD;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0.Items
{
    class Item : IItem, IDraw, IMovable, ICollidable, IUpdate
    {
        private String ItemName;
        private ISprite ItemSprite;
        private bool grounded = false;
        private SoundInfo soundInfo;

        private Vector2 location = new Vector2(GameUtilities.itemPosX, GameUtilities.itemPosY);
        public ISprite Sprite => ItemSprite;

        public Vector2 Position { get => location; set => throw new NotImplementedException(); }

        public Item(String itemName, Vector2 position) // Should I just use the gameobject manager? Items will probably include mushroom, star, coin
        {
            soundInfo = new SoundInfo();
            SetItem(itemName);
            location = position;
            ItemName = itemName;
        }

        public void SetItem(String spriteName)
        {
            ItemName = spriteName;
            ItemSprite = SpriteFactory.Instance.GetSprite(spriteName);
        }
        public bool GetGrounded()
        {
            return grounded;
        }
        public void SetGrounded(bool grounded)
        {
            this.grounded = grounded;
        }
        public string GetItemName()
        {
            return ItemName;
        }
        public void Move(int x, int y)
        {
            location = new Vector2(x, y);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, location);
        }
        public void Update()
        {
            Sprite.Update(); // Will have to wire this to work as intended
        }
        public void ItemCollision(IMario mario)
        {
            switch (ItemName)
            {
                case "Fireflower":
                    soundInfo.PlaySound("smb_powerup", false);
                    mario.FireflowerPower();
                    GameObjectManager.Instance.RemoveFromObjectList(this);
                    break;
                case "Mushroom":
                    soundInfo.PlaySound("smb_powerup", false);
                    mario.MushroomPower();
                    GameObjectManager.Instance.RemoveFromObjectList(this);
                    break;
                case "Star":
                    // this isn't stopping the background music for some reason? i think that StopLoopedSound() needs to be fixed as it's returning false here
                    soundInfo.StopLoopedSound(LevelFactory.Instance.currentSoundtrack);
                    soundInfo.PlaySound("smb_star", false);
                    mario.StarPower();
                    GameObjectManager.Instance.RemoveFromObjectList(this);
                    break;
                case "Coin":
                    soundInfo.PlaySound("smb_coin", false);
                    IGameObject go  = (IGameObject)mario;
                    IHUD hud = HUDManager.Instance.GetHUD(go);
                    hud.SetCoin(hud.GetCoins() + 1);
                    GameObjectManager.Instance.RemoveFromObjectList(this);
                    break;
            }
        }
    }
}