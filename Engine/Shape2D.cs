using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperFoxEngine.Engine
{
	public class Shape2D
	{
		public Vector2 position;
		public Vector2 scale;
		[Range(0, 360)] public int rotation = 0;
		public string tag = "";
		public Color shapeColor;

		public Shape2D(Vector2 Position, Vector2 Scale, int Rotation, Color Color, string Tag)
		{
			this.position = Position;
			this.scale = Scale;
			this.rotation = Rotation;
			this.shapeColor = Color;
			this.tag = Tag;

			Log.Information($"[SHAPE2D]({tag}) - Has been registered!");
			SuperFoxEngine.RegisterShape(this);
		}

		public void DestroySelf()
		{
			Log.Information($"[SHAPE2D]({tag}) - Has been destroyed.");
			SuperFoxEngine.UnRegisterShape(this);
		}
	}
}
