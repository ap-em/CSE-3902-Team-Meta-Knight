using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.HUD
{
    sealed public class HUDManager
    {
        private static HUDManager instance;
        public static HUDManager Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new HUDManager();

                }
            return instance;
            }
        }

        public Dictionary<IGameObject, IHUD> HUDList = new Dictionary<IGameObject, IHUD>();
        public HUDManager()
        {

        }
        public void CreateHUD(IGameObject gameObject)
        {
            IHUD HUD = new HUD(gameObject, HUDList.Count);
            HUDList.Add(gameObject,HUD);
        }
        public IHUD GetHUD(IGameObject go)
        {
            return HUDList.GetValueOrDefault(go);
        }
        public void Update()
        {
            foreach(IHUD HUD in HUDList.Values)
            {
                HUD.Update();
            }
        }
        public void Draw(SpriteBatch spriteBatch, ICamera camera)
        {
            foreach (IHUD HUD in HUDList.Values)
            {
                HUD.Draw(spriteBatch, camera);
            }
        }
    }
}
