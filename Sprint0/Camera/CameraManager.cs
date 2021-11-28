
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

        public void CreateLevel1Camera(IGameObject go)
        {
            ICamera camera = new CameraLevel1(go, cameras.Count);
            cameras.Add(go, camera);
            SetViewports();
        }
        public void CreateLevel2Camera(IGameObject go)
        {
            ICamera camera = new CameraLevel2(go, cameras.Count);
            cameras.Add(go, camera);
            SetViewports();
        }
        public void CinematicCamera(IGameObject go)
        {
            ICamera camera = new CinematicCamera(go, cameras.Count);
            cameras.Add(go, camera);
            SetViewports();
        }
        public void ResetCamera(IGameObject go)
        {
            cameras.GetValueOrDefault(go).Reset();
        }
        public void RemoveCamera(IGameObject go)
        {
            cameras.Remove(go);
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
            position = new Vector2(playerPosition.X - GraphicsDeviceManager.DefaultBackBufferWidth / 2,
                playerPosition.Y - 3 * GraphicsDeviceManager.DefaultBackBufferHeight / 5);
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

