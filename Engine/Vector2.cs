namespace SuperFoxEngine.Engine
{
	//===========================================================
	// Vector2
	//-----------------------------------------------------------
	//		Vector2 is for finding, setting, or otherwise 
	//		changing any X or Y coordinate.
	//=========================================================== 
	public class Vector2
	{
		public float x { get; set; }
		public float y { get; set; }

		//Constructors
		public Vector2()
		{
			x = Zero().x;
			y = Zero().y;
		}
		public Vector2(float X, float Y)
		{
			this.x = X;
			this.y = Y;
		}

		//Return x and y as zero
		public static Vector2 Zero()
		{
			return new Vector2(0f, 0f);
		}
	}
}
