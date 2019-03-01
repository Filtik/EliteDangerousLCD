using System;
using System.Drawing;
using System.IO;
using EliteDangerousLCD.LCD.Build;
using EliteDangerousLCD.Properties;
using LogiFrame;
using LogiFrame.Drawing;

namespace EliteDangerousLCD.LCD.Tabs
{
	public class TabLCDDocked : EDLCD
	{
		public static LCDContainerControl tabPage = new LCDContainerControl();

		public static void Create()
		{
			tabPage = new LCDContainerControl();

			if (!Instance.ShipStatus.Docked)
			{
				tabPage.Controls.Add(new LCDLabel
				{
					Location = new Point(0, 0),
					Font = SystemFonts.DefaultFont,
					Text = "No docking data available",
					TextAlign = ContentAlignment.MiddleCenter,
					Size = new Size(LCDApp.DefaultSize.Width, LCDApp.DefaultSize.Height)
				});

				BuildLCD.Build(tabPage);
				return;
			}

			var label = new CreateLabel();
			label.Location = new Point(0, 0);
			label.TitleText = "Name: ";
			label.TextText = Instance.Dock.Name;
			label.TextFont = PixelFonts.Small;
			label.BuildLabel().ForEach(x => tabPage.Controls.Add(x));

			label = new CreateLabel();
			label.Location = new Point(0,6);
			label.TitleText = "System: ";
			label.TextText = Instance.Dock.System;
			label.TextFont = PixelFonts.Small;
			label.BuildLabel().ForEach(x => tabPage.Controls.Add(x));

			label = new CreateLabel();
			label.Location = new Point(0, 12);
			label.TitleText = "Landingpad: ";
			label.TextText = Instance.Dock.LandingPad != -1 ? Instance.Dock.LandingPad.ToString() : "-";
			label.TextFont = PixelFonts.Small;
			label.BuildLabel().ForEach(x => tabPage.Controls.Add(x));

			label = new CreateLabel();
			label.Location = new Point(0, 18);
			label.TitleText = "Stationtype: ";
			label.TextText = Instance.Dock.Type;
			label.TextFont = PixelFonts.Small;
			label.BuildLabel().ForEach(x => tabPage.Controls.Add(x));

			label = new CreateLabel();
			label.Location = new Point(0, 24);
			label.TitleText = "Government: ";
			label.TextText = Instance.Dock.Government;
			label.TextFont = PixelFonts.Small;
			label.BuildLabel().ForEach(x => tabPage.Controls.Add(x));

			label = new CreateLabel();
			label.Location = new Point(0, 30);
			label.TitleText = "Allegiance: ";
			label.TextText = Instance.Dock.Allegiance;
			label.TextFont = PixelFonts.Small;
			label.BuildLabel().ForEach(x => tabPage.Controls.Add(x));

			tabPage.Controls.Add(new LCDMarquee
			{
				Text = "Services: " + Instance.Dock.Services,
				Size = new Size(LCDApp.DefaultSize.Width - 2, 10),
				Location = new Point(0, 36),
				Interval = 200
			});

			tabPage.Controls.Add(new LCDPicture
			{
				Location = new Point(LCDApp.DefaultSize.Width - Resources.orbis.Size.Width, (LCDApp.DefaultSize.Height - Resources.orbis.Size.Height) / 2),
				Size = Resources.orbis.Size,
				Image = GetImage(Instance.Dock.Type),
				MergeMethod = MergeMethods.Transparent
			});

			BuildLCD.Build(tabPage);
		}

		public static Bitmap GetImage(string type)
		{
			type = type.ToLower();

			switch (type)
			{
				case "coriolis":
					return Resources.coriolis;

				case "orbis":
					return Resources.orbis;

				case "outpost":
					return Resources.outpost;

				case "planetstation":
					return Resources.planetstation;

				default:
					return Resources.orbis;
			}
		}
	}
}
