using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Items
{
    /*Owen Tishenkel, heavily based on Owen Houston's Enemy class*/
    class Item : IItems
    {
        Game0 game;
        IItemStateMachine stateMachine;
        ISprite sprite;
        private Vector2 location = new Vector2(100, 200);
        public Item(Game0 game)
        {
            this.game = game;
            stateMachine = new Item1StateMachine(this);
        }

        public void NextItem()
        {
            stateMachine.NextItem();
        }

        public void PrevItem()
        {
            stateMachine.PrevItem();
        }

        public void SetStateMachineSprite()
        {
            stateMachine.SetSprite();
        }

        public void Update()
        {
            sprite.Update();
        }

        public void setSprite(ISprite sprite)
        {
            this.sprite = sprite;
        }
        public void SetStateMachine(IItemStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        public void Move(int x, int y)
        {
            location = new Vector2(x, y);
        }
        public void Draw()
        {
            sprite.Draw(game.spriteBatch, location);
        }
    }
}
