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
    /*Owen Tishenkel, heavily based on Owen Houston's Enemy class
    class star : IItems
    {
        Game0 game;
        public Vector2 position { get; set; }
        String spriteName;
        ISprite sprite;
        public bool IsCollected { get; set; } = false;
        public Vector2 velocity { get; set; }

        public Star(Vector2 location)
        {
            position = location;
            spriteName = "Star";
            velocity = new Vector2(0, -1.0f);

            detectionRec = ((int)position.X, (int)position.Y, width, height); // width and height should from data sheet 
                                                                             // better to create an abstract class in ISprite to create rectangle for objects

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

        public void Collect()
        {

            // need a way to create emptysprite
            IsCollected = true;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.position);
        }
        public void Update()
        {
            this.position = new Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y); 
            Destination = ((int)position.X, (int)position.Y, width, height)// width and height should from data sheet 
            sprite.Update();
        }

    }
}
*/
