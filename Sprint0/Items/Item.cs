using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Cycle;
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
    class Item : IItems, ICyclable
    {
        Game0 game;
        ICycleStateMachine stateMachine;
        String spriteName;
        ISprite sprite;
        private Vector2 location = new Vector2(100, 200);

        public Item(Game0 game)
        {
            this.game = game;
            stateMachine = new CycleStateMachine(this);
            spriteName = "HealHeart";
            this.SetSprite(spriteName);
            
        }

        public void NextSprite()
        {
            stateMachine.NextSprite();
        }

        public void PrevSprite()
        {
            stateMachine.PrevSprite();
        }

        public void SetSprite(String spriteName)
        {
            this.spriteName = spriteName;
            this.sprite = SpriteFactory.Instance.GetSprite(spriteName);
        }
        public string GetSpriteName()
        {
            return spriteName;
        }
        public void Move(int x, int y)
        {
            location = new Vector2(x, y);
        }
        public void Draw()
        {
            sprite.Draw(game.spriteBatch, location);
        }
        public void Update()
        {
            sprite.Update();
        }
    }
}
