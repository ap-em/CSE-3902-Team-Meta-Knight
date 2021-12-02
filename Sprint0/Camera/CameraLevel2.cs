
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
    class CameraLevel2 : ICamera
    {

        Vector2 position;
        IGameObject objectToFollow;
        public Matrix viewMatrix;
        public Viewport currentView;
        public int cameraIndex;
        private float maxPlayerYPosition;

        public CameraLevel2(IGameObject go, int index)
        {
            cameraIndex = index;
            objectToFollow = go;
            position = CameraManager.Instance.GetCameraPosition(objectToFollow.Position);
            maxPlayerYPosition = go.Position.Y;
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
            position = CameraManager.Instance.GetCameraPosition(objectToFollow.Position);
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
            maxPlayerYPosition = objectToFollow.Position.Y;
            Vector2 newCameraPosition = CameraManager.Instance.GetCameraPosition(objectToFollow.Position);
            position.Y = newCameraPosition.Y;
        }
        public void Update()
        {
            /*
            Vector2 newCameraPosition = CameraManager.Instance.GetCameraPosition(objectToFollow.Position);

            //only update Y position if we are at a new highest point
            if (objectToFollow.Position.Y <= maxPlayerYPosition)
            {
                maxPlayerYPosition = objectToFollow.Position.Y;
                position.Y = newCameraPosition.Y;
            }
            position.X = newCameraPosition.X;
            */

            viewMatrix = Matrix.CreateScale(new Vector3(1, 1, 0)) *
                Matrix.CreateTranslation(new Vector3(-position, 0));

            // if mario is below screen kill mario
            if(objectToFollow is IMario && objectToFollow.Position.Y > position.Y + GetViewport().Height)
            {
                IMario mario = (IMario)objectToFollow;
                mario.InstantDeath();
            }
        }
    }
}

