using System.Drawing;
using EliteDangerousLCD.LCD.Build;
using LogiFrame;

namespace EliteDangerousLCD.LCD.Tabs
{
	public class TabLCDStartElite : EDLCD
	{
		public static void Create()
		{
			var tabPage = new LCDContainerControl();

			tabPage.Controls.Add(new LCDLabel
			{
				Location = new Point(0, 0),
				Font = SystemFonts.MessageBoxFont,
				Text = "Welcome to",
				TextAlign = ContentAlignment.BottomCenter,
				Size = new Size(LCDApp.DefaultSize.Width, (LCDApp.DefaultSize.Height / 2) - 5)
			});

			tabPage.Controls.Add(new LCDLabel
			{
				Location = new Point(0, LCDApp.DefaultSize.Height / 2),
				Font = SystemFonts.MessageBoxFont,
				Text = "Elite Dangerous LCD",
				TextAlign = ContentAlignment.TopCenter,
				Size = new Size(LCDApp.DefaultSize.Width, (LCDApp.DefaultSize.Height / 2) + 5)
			});

			BuildLCD.Build(tabPage);

			LCDApp.PushToForeground();

			ButtonsEnabled = false;
		}
	}
}
