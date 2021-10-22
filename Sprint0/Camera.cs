using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Sprint0;
namespace Sprint0.Cameras
{
	public class Camera
	{
		public Matrix transform { get; private set; }
		Viewport View; // where the camera is looking at
		Vector2 center; // center of the camera
		
	
		public Camera(Viewport newView)
		{
			View = newView;

		}
		public void Update(GameTime gameTime, Game0 game)
		{



			center = new Vector2(game.mario.Position.X + 32 / 2 - Game0.screenWidth / 2, game.mario.Position.Y + 16 / 2 - Game0.screenHeight / 2); // link position + linkSpriteWidth/2 - half screenWidth
																																				   //link position + linkSpriteHeight/2 - half screenHeight
			transform = Matrix.CreateScale(new Vector3(1, 1, 0))
				* Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
		}
	}
}