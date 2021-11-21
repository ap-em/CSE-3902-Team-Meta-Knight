using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactory;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.UtilityClasses;
using Sprint0.Timers;

/*Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston*/


namespace Sprint0.Blocks
{
    class BlockDebris : IGameObject, IDraw, IUpdate
    {
        private ISprite sprite;
        private String spriteName;
        private Vector2[] locations = new Vector2[4];
        private Vector2[] velocities = new Vector2[4];

        public Vector2 Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ISprite Sprite => throw new NotImplementedException();

        public BlockDebris(String spriteName, Vector2 position)
        {
            //remove debris after 1000 millisecond
            Timer timer = new Timer(1000, RemoveDebris);
            timer.StartTimer();


            //top left debris location
            locations[0] = new Vector2(position.X, position.Y);
            //bottom left debris location
            locations[1] = new Vector2(position.X, position.Y + 16);
            //top right debris location
            locations[2] = new Vector2(position.X + 16, position.Y);
            //bottom right debris location
            locations[3] = new Vector2(position.X + 16, position.Y + 16);

            velocities[0] = new Vector2(-3f, -3f);
            velocities[1] = new Vector2(-3f, -3f);
            velocities[2] = new Vector2(3f, -3f);
            velocities[3] = new Vector2(3f, -3f);


            sprite = SpriteFactory.Instance.GetSprite("BrickDebris");
            this.spriteName = spriteName;
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
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, locations[0]);
            sprite.Draw(spriteBatch, locations[1]);
            sprite.Draw(spriteBatch, locations[2]);
            sprite.Draw(spriteBatch, locations[3]);
        }
        public void Update()
        {
            //move debris chunks in different directions
            for(int i = 0; i < 4; i++)
            {
                velocities[i].Y += 4;
                locations[i] += velocities[i];
            }
        }
        public void RemoveDebris(Object source, System.Timers.ElapsedEventArgs e)
        {
            GameObjectManager.Instance.RemoveFromObjectList(this);
        }
    }
}