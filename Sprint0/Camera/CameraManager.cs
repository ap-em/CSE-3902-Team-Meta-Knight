
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Sprint0.UtilityClasses;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    sealed class CameraManager
    {
        Vector2 position;
        Viewport defaultView;
        public Dictionary<IGameObject, ICamera> cameras = new Dictionary<IGameObject, ICamera>();
        private static CameraManager instance;
        public static CameraManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CameraManager();
                }
                return instance;
            }
        }

        public CameraManager()
        {
            defaultView = Game0.Instance.GraphicsDevice.Viewport;
        }

        public void CreateCamera(IGameObject go)
        {
            ICamera camera = new Camera(go, cameras.Count);
            cameras.Add(go, camera);
            SetViewports();
        }
        public void CreateLevel2Camera(IGameObject go)
        {
            ICamera camera = new CameraLevel2(go, cameras.Count);
            cameras.Add(go, camera);
            SetViewports();
        }
        public void SetViewports()
        {
            
            foreach (ICamera camera in cameras.Values)
            {
                Debug.WriteLine("CAMERA: " + camera.GetIndex());
                camera.SetViewport(GetViewport(camera.GetIndex()));
            }
            
        } 
        public Viewport GetViewport(int CameraIndex)
        {
            Viewport viewport = defaultView;
            
            //split screens up according to the amount of cameras
            if (cameras.Count == 1)
            {
                viewport = defaultView;
            }
            else if (cameras.Count == 2)
            {
                viewport.Width = defaultView.Width / 2;
                viewport.Height = defaultView.Height;
            }
            else
            {
                viewport.Width = defaultView.Width / 2;
                viewport.Height = defaultView.Height / 2;
            }

            // view port 0 and 2 align on the left side of the screen
            if(CameraIndex == 0 || CameraIndex == 2)
            {
                viewport.X = defaultView.X;
            }
            // view port 1 and 3 align on the right side of the screen
            else
            {
                viewport.X = defaultView.Width / 2;
            }
            
            return viewport;
        }
        public ICamera GetCamera(IGameObject gameObject)
        {
            return cameras.GetValueOrDefault(gameObject);
        }
        public Vector2 GetCameraPosition(Vector2 playerPosition)
        {
            //position camera based on how many cameras there are
            if (cameras.Count == 1)
            {
                position = new Vector2(playerPosition.X - GraphicsDeviceManager.DefaultBackBufferWidth / 2,
    playerPosition.Y - GraphicsDeviceManager.DefaultBackBufferHeight / 2);
            }
            else if(cameras.Count == 2)
            {
                position = new Vector2(playerPosition.X - GraphicsDeviceManager.DefaultBackBufferWidth / 4,
    playerPosition.Y - GraphicsDeviceManager.DefaultBackBufferHeight / 2);
            }
            else
            {
                position = new Vector2(playerPosition.X - GraphicsDeviceManager.DefaultBackBufferWidth / 4,
       playerPosition.Y - GraphicsDeviceManager.DefaultBackBufferHeight / 4);
            }
            if (position.X < 0)
            {
                position.X = 0;
            }
            if (position.Y > 0)
            {
                position.Y = 0;
            }
            return position;
        }

        public void Update()
        {
            foreach (ICamera camera in cameras.Values)
            {
                camera.Update();
            }
        }
    }
}

