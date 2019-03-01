using System.Collections.Generic;
using System.Drawing;
using LogiFrame;

namespace EliteDangerousLCD.LCD.Build
{
	public class CreateLabel
	{
		private static List<LCDLabel> newController = new List<LCDLabel>();

		public Point Location { get; set; } = new Point();

		public Font TitleFont { get; set; } = PixelFonts.Title;
		public string TitleText { get; set; } = "";
		
		public Font TextFont { get; set; } = PixelFonts.Title;
		public string TextText { get; set; } = "";

		public List<LCDLabel> BuildLabel()
		{
			newController.Clear();

			var title = new LCDLabel();
			title.Font = TitleFont;
			title.Location = Location;
			title.Text = TitleText;
			title.AutoSize = true;

			newController.Add(title);

			var text = new LCDLabel();
			text.Font = TextFont;
			text.Location = new Point(title.Size.Width + 2, Location.Y);
			text.Text = TextText;
			text.AutoSize = true;

			newController.Add(text);

			return newController;
		}
	}
}
