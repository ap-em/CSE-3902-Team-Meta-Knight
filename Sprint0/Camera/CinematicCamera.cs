
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
    class CinematicCamera : ICamera
    {
        Vector2 position;
        IGameObject objectToFollow;
        public Matrix viewMatrix;
        public Viewport currentView;
        public int cameraIndex;

        public CinematicCamera(IGameObject go, int index)
        {
            cameraIndex = index;
            objectToFollow = go;
            position = CameraManager.Instance.GetCameraPosition(objectToFollow.Position);
            currentView = CameraManager.Instance.GetViewport(cameraIndex);
        }
        public int GetIndex()
        {
            return cameraIndex;
        }
        public Vector2 GetPosition()
        {
            return position;
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
        public void Reset()
        {

        }

        public void Update()
        {
            position = CameraManager.Instance.GetCameraPosition(objectToFollow.Position);

            Debug.WriteLine("cinematicCamPos: " + position);

            viewMatrix = Matrix.CreateScale(new Vector3(1, 1, 0)) *
                Matrix.CreateTranslation(new Vector3(-position, 0));
        }
    }
}

