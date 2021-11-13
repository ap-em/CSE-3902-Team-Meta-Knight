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

        private Vector2 location = new Vector2(GameUtilities.itemPosX, GameUtilities.itemPosY);
        public ISprite Sprite => ItemSprite;

        public Vector2 Position { get => location; set => throw new NotImplementedException(); }

        public Item(String itemName, Vector2 position) // Should I just use the gameobject manager? Items will probably include mushroom, star, coin
        {
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
                    mario.FireflowerPower();
                    GameObjectManager.Instance.RemoveFromObjectList(this);
                    break;
                case "Mushroom":
                    mario.MushroomPower();
                    GameObjectManager.Instance.RemoveFromObjectList(this);
                    break;
                case "Star":
                    mario.StarPower();
                    GameObjectManager.Instance.RemoveFromObjectList(this);
                    break;
                case "Coin":
                    HUDManager.Instance.GetHUD((IGameObject)mario).AddScore(GameUtilities.coinVal);
                    HUDManager.Instance.GetHUD((IGameObject)mario).AddCoin(1);
                    if (HUDManager.Instance.GetHUD((IGameObject)mario).getCoinCount() == GameUtilities.coinVal)
                    {
                        HUDManager.Instance.GetHUD((IGameObject)mario).ResetCoin();
                        HUDManager.Instance.GetHUD((IGameObject)mario).AddLife();
                    }
                    GameObjectManager.Instance.RemoveFromObjectList(this);
                    break;
            }
        }
    }
}