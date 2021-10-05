using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactory;
using System;
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
    /*Owen Tishenkel, heavily based on Owen Houston's Enemy class*/
    class Item : IItems
    {
        Game0 game;
        IItemStateMachine stateMachine;
        ISprite sprite;
        private Vector2 location = new Vector2(100, 200);
        String itemType;
        public Item(Game0 game)
        {
            this.game = game;
            stateMachine = new ItemStateMachine(this);
            itemType = "HealHeart";
            this.setSprite();
            
        }

        public void NextItem()
        {
            stateMachine.NextItem();
        }

        public void PrevItem()
        {
            stateMachine.PrevItem();
        }

        public void Update()
        {
            sprite.Update();
        }

        public void setSprite()
        {
            this.sprite = SpriteFactory.Instance.GetSprite(this.getItemType());
        }
        public void Move(int x, int y)
        {
            location = new Vector2(x, y);
        }
        public void Draw()
        {
            sprite.Draw(game.spriteBatch, location);
        }
        /*Sets item type*/
        public void setItemType(String itemType)
        {
            this.itemType = itemType;
        }
        /*Sets item type*/
        public string getItemType()
        {
            return itemType;
        }
    }
}
