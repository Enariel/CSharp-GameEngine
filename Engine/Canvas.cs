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

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// Canvas
			// 
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Name = "Canvas";
			this.Load += new System.EventHandler(this.Canvas_Load);
			this.ResumeLayout(false);

		}

		private void Canvas_Load(object sender, System.EventArgs e)
		{
			return;
		}
	}
}
