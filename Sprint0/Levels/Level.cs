using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Blocks;
using Sprint0.Enemies;
using Sprint0.Sprites.SpriteFactory;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection;
using System.IO;
using Sprint0.UtilityClasses;


/*Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston*/


namespace Sprint0
{
    sealed public class Level
    {
        private int maxRowLength = GameUtilities.maxRowLength;
        private int maxNumberOfRows = GameUtilities.maxNumberOfRows;

        private IGameObject[][] gameObjects = new IGameObject[1000][];

        private static Level instance;
        public static Level Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new Level();

                }
                return instance;
            }
        }
        public Level()
        {

        }
        public void CreateObj(Vector2 position, String objType, String spriteName)
        {
            int rowIndex = (int)position.Y;
            int columnIndex = (int)position.X;
            position = BlockToWorldSpace(position);

            Type t = Type.GetType(objType);
            Type[] types = { typeof(string), typeof(Vector2) };
            object[] param = { spriteName, position };

            ConstructorInfo constructorInfoObj = t.GetConstructor(types);

            GameObjectManager.Instance.AddToObjectList((IGameObject)constructorInfoObj.Invoke(param), columnIndex, rowIndex);
            
        }
        public Vector2 WorldToBlockSpace(Vector2 position)
        {
            return new Vector2((int)Math.Round(position.X / GameUtilities.worldSpacesScale), (int)Math.Round(position.Y / GameUtilities.worldSpacesScale));
        }
        public Vector2 BlockToWorldSpace(Vector2 pos)
        {
            return new Vector2(pos.X * GameUtilities.worldSpacesScale, pos.Y *GameUtilities.worldSpacesScale );
        }
    }
}
