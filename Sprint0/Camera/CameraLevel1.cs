
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
    class CameraLevel1 : ICamera
    {
        Vector2 position;
        IGameObject objectToFollow;
        public Matrix viewMatrix;
        public Viewport currentView;
        public int cameraIndex;

        public CameraLevel1(IGameObject go, int index)
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
        public void UpdateCamera2Position()
        {

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

            //clamp to the bottom left of the level
            if (position.X < 0)
                position.X = 0;


            // only move the camera when we are near the top of the screen
            if (objectToFollow.Position.Y > GetViewport().Height / 4)
            {
                position.Y = 0;
            }
            else
            {
                position.Y = objectToFollow.Position.Y - GetViewport().Height / 4;
            }


            viewMatrix = Matrix.CreateScale(new Vector3(1, 1, 0)) *
                Matrix.CreateTranslation(new Vector3(-position, 0));
        }
    }
}

