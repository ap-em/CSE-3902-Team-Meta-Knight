using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Sprint0.Sprites.EnemySprites;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework.Content;

namespace Sprint0.Sprites
{
    public class SpriteFactory
    {
        GraphicsDeviceManager GraphicsDeviceManager;

        //private SpriteBatch spriteBatch;


        //  private NMStaticSprite ssGoldDoggo; // Static Sprite gold doggo

        //private ContentManager content;

        private Texture2D goldDoggo;
        private Texture2D mario;
        private Texture2D smiley;
        private Texture2D link;
        private Texture2D enemies;

        private static SpriteFactory instance = new SpriteFactory();

        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public SpriteFactory()//GraphicsDeviceManager graphicsDeviceManager) // : (base.graphicsDeviceManager)
        {
            //  GraphicsDeviceManager = graphicsDeviceManager;
        }

        public void LoadAllTextures(ContentManager content)
        {
            goldDoggo = content.Load<Texture2D>("GoldDoggo"); // Static non-moving Sprite
            mario = content.Load<Texture2D>("Mario");
            smiley = content.Load<Texture2D>("SmileyWalk"); // Animated fixed sprite
            link = content.Load<Texture2D>("Link");

            enemies = content.Load<Texture2D>("Enemies");
        }

        public ISprite CreateGoldDoggo()
        {
            return new GoldDoggo(goldDoggo, 1, 1); // texture / rows / columns

        }
        public ISprite CreateAnimatedFixedSprite()
        {
            return new AnimatedFixedSprite(smiley, 4, 4); 
        }

        public ISprite CreateMovingStaticSprite()
        {
            return new MovingStaticSprite(link, 1, 6);
        }
        public ISprite CreateAnimatedMovingSprite()
        {
            return new AnimatedMovingSprite(link, 1, 6);
        }

        public ISprite CreateE1IdleLeft()
        {
            return new E1IdleLeftSprite(enemies, 2, 1);
        }
        public ISprite CreateE2IdleLeft()
        {
            return new E2IdleLeftSprite(enemies, 2, 1);
        }
        public ISprite CreateE3IdleLeft()
        {
            return new E3IdleLeftSprite(enemies, 2, 1);
        }
        /*
        public ISprite CreateE1ShootLeft()
        {
            return new E1ShootLeftSprite(enemies, 2, 1);
        }
        public ISprite CreateE2ShootLeft()
        {
            return new E2ShootLeftSprite(enemies, 2, 1);
        }
        public ISprite CreateE3ShootLeft()
        {
            return new E3ShootLeftSprite(enemies, 2, 1);
        }
        public ISprite CreateE1MoveLeft()
        {
            return new E1MoveLeftSprite(enemies, 2, 1);
        }
        public ISprite CreateE2MoveLeft()
        {
            return new E2MoveLeftSprite(enemies, 2, 1);
        }
        public ISprite CreateE3MoveLeft()
        {
            return new E3MoveLeftSprite(enemies, 2, 1);
        }
        public ISprite CreateE1ShootLeft()
        {
            return new E1ShootLeftSprite(enemies, 2, 1);
        }
        public ISprite CreateE2ShootLeft()
        {
            return new E2ShootLeftSprite(enemies, 2, 1);
        }
        public ISprite CreateE3ShootLeft()
        {
            return new E3ShootLeftSprite(enemies, 2, 1);
        }
        public ISprite CreateE1IdleRight()
        {
            return new E1IdleRightSprite(enemies, 2, 1);
        }
        public ISprite CreateE2IdleRight()
        {
            return new E2IdleRightSprite(enemies, 2, 1);
        }
        public ISprite CreateE3IdleRight()
        {
            return new E3IdleRightSprite(enemies, 2, 1);
        }
        public ISprite CreateE1MoveRight()
        {
            return new E1MoveRightSprite(enemies, 2, 1);
        }
        public ISprite CreateE2MoveRight()
        {
            return new E2MoveRightSprite(enemies, 2, 1);
        }
        public ISprite CreateE3MoveRight()
        {
            return new E3MoveRightSprite(enemies, 2, 1);
        }

        public ISprite CreateE1ShootLeft()
        {
            return new E1ShootLeftSprite(enemies, 2, 1);
        }
        public ISprite CreateE2ShootLeft()
        {
            return new E2ShootLeftSprite(enemies, 2, 1);
        }
        public ISprite CreateE3ShootLeft()
        {
            return new E3ShootLeftSprite(enemies, 2, 1);
        }

        public ISprite CreateE1IdleUp()
        {
            return new E1IdleUpSprite(enemies, 2, 1);
        }
        public ISprite CreateE2IdleUp()
        {
            return new E2IdleUpSprite(enemies, 2, 1);
        }
        public ISprite CreateE3IdleUp()
        {
            return new E3IdleUpSprite(enemies, 2, 1);
        }
        public ISprite CreateE1MoveUp()
        {
            return new E1MoveUpSprite(enemies, 2, 1);
        }
        public ISprite CreateE2MoveUp()
        {
            return new E2MoveUpSprite(enemies, 2, 1);
        }
        public ISprite CreateE3MoveUp()
        {
            return new E3MoveUpSprite(enemies, 2, 1);
        }

        public ISprite CreateE1ShootDown()
        {
            return new E1ShootDownSprite(enemies, 2, 1);
        }
        public ISprite CreateE2ShootDown()
        {
            return new E2ShootDownSprite(enemies, 2, 1);
        }
        public ISprite CreateE3ShootDown()
        {
            return new E3ShootDownSprite(enemies, 2, 1);
        }

        public ISprite CreateE1IdleDown()
        {
            return new E1IdleDownSprite(enemies, 2, 1);
        }
        public ISprite CreateE2IdleDown()
        {
            return new E2IdleDownSprite(enemies, 2, 1);
        }
        public ISprite CreateE3IdleDown()
        {
            return new E3IdleDownSprite(enemies, 2, 1);
        }
        public ISprite CreateE1MoveDown()
        {
            return new E1MoveDownSprite(enemies, 2, 1);
        }
        public ISprite CreateE2MoveDown()
        {
            return new E2MoveDownSprite(enemies, 2, 1);
        }
        public ISprite CreateE3MoveDown()
        {
            return new E3MoveDownSprite(enemies, 2, 1);
        }
        */
    }
}