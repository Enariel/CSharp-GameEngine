using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperFoxEngine.Engine
{
	public class Sprite2D
	{
		public Vector2 position;
		public Vector2 scale;
		[Range(0, 360)] public int rotation = 0;
		public string tag = "";
		public string directory = "";
	}
}
