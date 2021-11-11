
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
    class Camera : ICamera
    {
        IGameObject objectToFollow;
        public Matrix viewMatrix;
        public Viewport currentView;
        public int cameraIndex;

        public Camera(IGameObject go, int index)
        {
            cameraIndex = index;
            objectToFollow = go;
            currentView = CameraManager.Instance.GetViewport(cameraIndex);
        }
        public int GetIndex()
        {
            return cameraIndex;
        }
        public Matrix GetMatrix()
        {
            return viewMatrix;
        }
        public void SetMatrix(Matrix matrix)
        {
            viewMatrix = matrix;
        }
        public Viewport GetViewport()
        {
            return currentView;
        }
        public void SetViewport(Viewport view)
        {
            currentView = view;
        }

        public void Update()
        {
            Vector2 position = CameraManager.Instance.GetCameraPosition(objectToFollow.Position);

            viewMatrix = Matrix.CreateScale(new Vector3(1, 1, 0)) *
                Matrix.CreateTranslation(new Vector3(-position, 0));
        }
    }
}

