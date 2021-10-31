
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
        Vector2 position;
        Matrix viewMatrix;
        Viewport currentView;
        Viewport defaultView;
        Viewport leftView;
        Viewport rightView;
        Viewport bottomLeftView;
        Viewport bottomRightView;
        int cameraIndex;
        int numOfCameras;
        public Matrix ViewMatrix { get => viewMatrix; set => throw new NotImplementedException(); }
        public Viewport ViewPort{ get => currentView; set => throw new NotImplementedException(); }

        public Camera(int cameraIndex)
        {
            defaultView = Game0.Instance.GraphicsDevice.Viewport;
            leftView = defaultView;
            rightView = defaultView;
            bottomLeftView = defaultView;
            bottomRightView = defaultView;
            this.cameraIndex = cameraIndex;
        }
        public void SetIndex(int cameraIndex)
        {
            this.cameraIndex = cameraIndex;
        }
        public void SetCurrentView()
        {
            if (cameraIndex == 0)
            {
                currentView = leftView;
            }
            else if (cameraIndex == 1)
            {
                currentView = rightView;
            }
            else if (cameraIndex == 2)
            {
                currentView = bottomLeftView;
            }
            else if (cameraIndex == 3)
            {
                currentView = bottomRightView;
            }
        }
        public void UpdateViews(int numOfCameras)
        {
            if (numOfCameras == 1)
            {
                leftView = defaultView;
            }
            else if(numOfCameras == 2)
            {
                leftView = defaultView;
                rightView = defaultView;
                leftView.Width = leftView.Width / 2;
                rightView.Width = rightView.Width / 2;
                rightView.X = leftView.Width;
            }
            else if(numOfCameras == 3 || numOfCameras == 4)
            {
                leftView = defaultView;
                rightView = defaultView;
                bottomLeftView = defaultView;
                bottomRightView = defaultView;
                leftView.Width /= 2;
                leftView.Height /= 2;
                rightView.Width /= 2;
                rightView.Height /= 2;
                rightView.X = leftView.Width;
                bottomLeftView.Width /= 2;
                bottomLeftView.Height /= 2;
                bottomLeftView.Y = leftView.Height;
                bottomRightView.Width /= 2;
                bottomRightView.Height /= 2;
                bottomRightView.Y = rightView.Height;
                bottomRightView.X = bottomLeftView.Width;

            }
            this.numOfCameras = numOfCameras;
            SetCurrentView();
        }

        public void Update(Vector2 playerPosition)
        {
            if(numOfCameras == 1)
            {
                position = new Vector2(playerPosition.X - GraphicsDeviceManager.DefaultBackBufferWidth / 2,
                    playerPosition.Y - GraphicsDeviceManager.DefaultBackBufferHeight / 2);
                if (position.X < 0)
                {
                    position.X = 0;
                }
                if (position.Y > 0)
                {
                    position.Y = 0;
                }
            }
            else if(numOfCameras == 2)
            {
                position = new Vector2(playerPosition.X - GraphicsDeviceManager.DefaultBackBufferWidth / 4,
                    playerPosition.Y - GraphicsDeviceManager.DefaultBackBufferHeight / 2);
                if (position.X < 0)
                {
                    position.X = 0;
                }
                if (position.Y > 0)
                {
                    position.Y = 0;
                }
            }
            else
            {
                position = new Vector2(playerPosition.X - GraphicsDeviceManager.DefaultBackBufferWidth / 4,
                       playerPosition.Y - GraphicsDeviceManager.DefaultBackBufferHeight / 4);
                if (position.X < 0)
                {
                    position.X = 0;
                }
            }

            viewMatrix = Matrix.CreateScale(new Vector3(1, 1, 0)) *
                Matrix.CreateTranslation(new Vector3(-position, 0));
        }
    }
}

