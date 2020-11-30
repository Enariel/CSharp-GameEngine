using System.Windows.Forms;

namespace SuperFoxEngine.Engine
{
	class Canvas : Form
	{
		public Canvas()
		{
			//Prevent flickering with form refreshing
			this.DoubleBuffered = true; 
		}
	}
}
