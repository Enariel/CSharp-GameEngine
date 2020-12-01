using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperFoxEngine.Engine;

namespace SuperFoxEngine.Crawler
{
	public class DungeonCrawler : Engine.SuperFoxEngine
	{
		public DungeonCrawler() : base(new Vector2(768, 512), "SuperFox Dungeon Crawler") { }

		//Private Engine Variables
		private int frameCount;
		//Private Game Variables
		private Sprite2D playerSprite;

		//Public Variables

		//Main Functions
		public override void OnLoad()
		{
			Log.Information("Game Window Loading...");
			//Add player sprite
			playerSprite = new Sprite2D(new Vector2(16, 16), new Vector2(16, 16), 0, "Player_Sprite", "Player_Yellow");
			//Initialize Game
			Log.Information("Game Initialized.");
		}

		public override void OnStart()
		{

		}

		public override void OnDraw()
		{

		}

		public override void OnUpdate()
		{
		}

		public override void OnUnload()
		{
			this.GameWindow1.Close();
		}

		//Game functions
		private void FrameCounter()
		{
			Log.Normal($"[Frame] - {frameCount}");
			frameCount += 1;
		}
	}
}
