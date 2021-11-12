using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Managers
{

    sealed public class CollisionManager
    {
        private static GameObjectManager instance;
        public static GameObjectManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObjectManager();
                }
                return instance;
            }
        }
    }
}
