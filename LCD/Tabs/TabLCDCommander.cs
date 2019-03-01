using System;
using System.Drawing;
using System.Globalization;
using EliteDangerousLCD.LCD.Build;
using EliteDangerousLCD.Objects.Enum;
using LogiFrame;

namespace EliteDangerousLCD.LCD.Tabs
{
	public class TabLCDCommander : EDLCD
	{
		public static void Create()
		{
			var tabPage = new LCDContainerControl();

			var label = new CreateLabel();
			label.TitleText = "Commander: ";
			label.TextText = Instance.Commander.Name;
			label.TextFont = PixelFonts.Small;
			label.BuildLabel().ForEach(x => tabPage.Controls.Add(x));

			label = new CreateLabel();
			label.Location = new Point(0, 8);
			label.TitleText = "Ship: ";
			label.TextText = Instance.ShipExtra.Name != "" ? Instance.ShipExtra.Name : Instance.ShipExtra.Type;
			label.TextFont = PixelFonts.Small;
			label.BuildLabel().ForEach(x => tabPage.Controls.Add(x));

			label = new CreateLabel();
			label.Location = new Point(0, 16);
			label.TitleText = "Credits: ";
			label.TextText = Instance.Commander.Credits.ToString("N0") + " CR";
			label.TextFont = PixelFonts.Small;
			label.BuildLabel().ForEach(x => tabPage.Controls.Add(x));

			//label = new CreateLabel();
			//label.Location = new Point(0, 27);
			//label.TitleText = "Empire: ";
			//label.TextText = Enum.GetName(typeof(EliteRanks.Empire), Instance.Ranks.Federation).Replace("_", " ");
			//label.TextFont = PixelFonts.Small;
			//label.BuildLabel().ForEach(x => tabPage.Controls.Add(x));

			BuildLCD.Build(tabPage);
		}
	}
}
