using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SuperFoxEngine.Engine
{
	//===========================================================
	// SuperFoxEngine
	//=========================================================== 

	public abstract class SuperFoxEngine
	{
		private Vector2 ScreenSize = new Vector2();
		private string Title;
		private Canvas GameWindow = null;
		private Thread GameLoopThread = null;
		private static List<Shape2D> RegisteredShapes = new List<Shape2D>();
		private static List<Sprite2D> RegisteredSprites = new List<Sprite2D>();

		public Color BackgroundColor = Color.Black;

		internal Canvas GameWindow1 { get => GameWindow; set => GameWindow = value; }

		public SuperFoxEngine(Vector2 _ScreenSize, string _Title)
		{
			this.ScreenSize = _ScreenSize;
			this.Title = _Title;

			//Init game window
			CreateGameWindow();

			//Init gameloop
			StartGameLoop();

			//Start application
			Application.Run(GameWindow);
		}

		private void CreateGameWindow()
		{
			GameWindow = new Canvas();
			GameWindow.Size = new Size((int)ScreenSize.x, (int)ScreenSize.y);
			GameWindow.Text = this.Title;
			GameWindow.Paint += Renderer;
		}

		private void StartGameLoop()
		{
			GameLoopThread = new Thread(GameLoop);
			GameLoopThread.Start();
		}

		//Manage registry of primite shapes.
		public static void RegisterShape(Shape2D _Shape)
		{
			RegisteredShapes.Add(_Shape);
		}

		public static void UnRegisterShape(Shape2D _Shape)
		{
			RegisteredShapes.Remove(_Shape);
		}

		//Manage registry of game sprites
		public static void RegisterSprite(Sprite2D _Sprite)
		{
			RegisteredSprites.Add(_Sprite);
			Log.Information($"[SPRITE2D] - {_Sprite.Tag} is registered!");
		}

		public static void UnRegisterSprite(Sprite2D _Sprite)
		{
			RegisteredSprites.Remove(_Sprite);
			Log.Warning($"[SPRITE2D] - {_Sprite.Tag} is unregistered.");
		}

		//The loop that runs the game time and refreshes the windows
		void GameLoop()
		{
			OnLoad();
			OnStart();
			while (GameLoopThread.IsAlive)
			{
				try
				{
					//Draw next frame first
					OnDraw();
					//Break windows! :D
					//Refresh form while GameLoopThread is active.
					GameWindow.BeginInvoke((MethodInvoker)delegate { GameWindow.Refresh(); });
					//Execute functions after things have been drawn
					OnUpdate();
					//Delay to prevent weirdness
					Thread.Sleep(10);
				}
				catch
				{
					Log.Error("Game Window not found...");
					OnUnload();
				}
				//If quit, return out or break;
			}
			//Execute OnUnLoad
			OnUnload();
		}

		//The drawing for the game window
		private void Renderer(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			//"Skybox" to be drawn first
			g.Clear(BackgroundColor);

			//Draw shapes and sprites
			foreach(Shape2D shape in RegisteredShapes)
			{
				g.FillRectangle(new SolidBrush(shape.shapeColor), shape.position.x, shape.position.y, shape.scale.x, shape.scale.y);
			}
			foreach (Sprite2D sprite in RegisteredSprites)
			{
				g.DrawImage(sprite.Sprite, sprite.Position.x, sprite.Position.y, sprite.Scale.x, sprite.Scale.x);
			}
		}

		//Onload is for loading things before an application starts, such as sprites, sounds, etc.
		public abstract void OnLoad();
		//Renders objects to draw to window.
		public abstract void OnStart();
		//Like Unity's Update() method, called once every 'frame'.
		public abstract void OnDraw();
		//Like Unity's Start() method. Called once an object is loaded in a window.
		public abstract void OnUpdate();
		//Unload function to dictate the unloading of assets when the game is stopped or ended.
		public abstract void OnUnload();

	}
}
