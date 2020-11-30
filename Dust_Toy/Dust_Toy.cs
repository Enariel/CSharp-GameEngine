using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperFoxEngine.Engine;

namespace SuperFoxEngine
{
	//New class for Dust Toy game.
	class Dust_Toy : Engine.SuperFoxEngine
	{
		public Dust_Toy() : base(new Vector2(768, 512), "SuperFox Dust Toy") { }
		private int frameCount = 0;

		public override void OnLoad()
		{
			Log.Information("Game is Starting... ");
			//Load player
			Shape2D player = new Shape2D(new Vector2(10, 10), new Vector2(5, 5), 0, Color.Cyan, "Test Shape");
			Log.Information("Loading complete.");
		}

		public override void OnStart()
		{
		}

		public override void OnUnload()
		{
		}

		public override void OnDraw()
		{
		}

		public override void OnUpdate()
		{
		}

		private void FrameCounter()
		{
			Log.Information($"[FRAME] {frameCount}");
			frameCount += 1;
		}
	}
}
