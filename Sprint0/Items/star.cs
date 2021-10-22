using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
/*
 * namespace Sprint0.Items
{
   
    class star : IItems
    {
        Game0 game;
        public Vector2 Position { get; set; }
        String spriteName;
        public ISprite Sprite { get; }
        public bool isCollected { get; set; } = false;
        public Vector2 Velocity { get; set; }
        public Rectangle detectionRec;

        public star(Vector2 location)
        {
            Position = location;
            spriteName = "Star";
            Velocity = new Vector2(0, -1.0f);

            detectionRec = new Rectangle((int)Position.X, (int)Position.Y, 16, 16); // width and height should from data sheet 
                                                                             // better to create an abstract class in ISprite to create rectangle for objects

        }


        public void collect()
        {

            // need a way to create emptysprite
            isCollected = true;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, this.Position);
        }
        public void Update()
        {
            this.Position = new Vector2(this.Position.X + this.Velocity.X, this.Position.Y + this.Velocity.Y);
            detectionRec = new Rectangle((int)Position.X, (int)Position.Y, 16, 16);// width and height should from data sheet 
            Sprite.Update();
        }

    }
}
*/
