using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperFoxEngine.Engine
{
	//Allows the usage of Sprites and Images.
	public class Sprite2D
	{
		//Variables
		public Vector2 Position;
		public Vector2 Scale;
		[Range(0, 360)] public int Rotation = 0;
		public string Tag = "";
		public string Directory = "";
		public Bitmap Sprite = null;

		//Constructor
		public Sprite2D(Vector2 _Position, Vector2 _Scale, int _Rotation, string _Tag, string _Directory)
		{
			this.Position = _Position;
			this.Scale = _Scale;
			this.Rotation = _Rotation;
			this.Tag = _Tag;
			this.Directory = _Directory;

			//Set the image from a directory
			Image temp = Image.FromFile($"Assets/Sprites/{_Directory}.png");
			Bitmap sprite = new Bitmap(temp, new Size(temp.Width, temp.Height));
			this.Sprite = sprite;

			SuperFoxEngine.RegisterSprite(this);
		}

		public void DestroySelf()
		{
			SuperFoxEngine.UnRegisterSprite(this);
		}
	}
}
