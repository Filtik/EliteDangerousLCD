using System;
using System.Drawing;
using EliteDangerousLCD.LCD.Build;
using EliteDangerousLCD.Objects.Enum;
using LogiFrame;

namespace EliteDangerousLCD.LCD.Tabs
{
	public class TabLCDRank : EDLCD
	{
		public static LCDContainerControl tabPage = new LCDContainerControl();

		public static void Create()
		{
			tabPage = new LCDContainerControl();

			var label = new CreateLabel();
			label.Location = new Point(0, 0);
			label.TitleText = "Federation: ";
			label.TextText = Instance.Ranks.FederationReputation + "%";
			label.TextFont = PixelFonts.Small;
			label.BuildLabel().ForEach(x => tabPage.Controls.Add(x));

			tabPage.Controls.Add(new LCDLabel
			{
				Location = new Point(5, 6),
				Font = PixelFonts.Small,
				Text = Enum.GetName(typeof(EliteRanks.Federation), Instance.Ranks.Federation).Replace("_", " ") + " " + Instance.Ranks.FederationProgress + "%",
				AutoSize = true,
			});



			label = new CreateLabel();
			label.Location = new Point(0, 12);
			label.TitleText = "Empire: ";
			label.TextText = Instance.Ranks.EmpireReputation + "%";
			label.TextFont = PixelFonts.Small;
			label.BuildLabel().ForEach(x => tabPage.Controls.Add(x));

			tabPage.Controls.Add(new LCDLabel
			{
				Location = new Point(5, 18),
				Font = PixelFonts.Small,
				Text = Enum.GetName(typeof(EliteRanks.Empire), Instance.Ranks.Empire).Replace("_", " ") + " " + Instance.Ranks.EmpireProgress + "%",
				AutoSize = true,
			});



			label = new CreateLabel();
			label.Location = new Point(0, 24);
			label.TitleText = "Alliance: ";
			label.TextText = Instance.Ranks.AllianceReputation + "%";
			label.TextFont = PixelFonts.Small;
			label.BuildLabel().ForEach(x => tabPage.Controls.Add(x));

			tabPage.Controls.Add(new LCDLine
			{
				Start = new Point(LCDApp.DefaultSize.Width / 2 + 3, 0),
				End = new Point(LCDApp.DefaultSize.Width / 2 + 3, LCDApp.DefaultSize.Height - 10)
			});
			tabPage.Controls.Add(new LCDLine
			{
				Start = new Point(0, LCDApp.DefaultSize.Height - 10),
				End = new Point(LCDApp.DefaultSize.Width / 2 + 3, LCDApp.DefaultSize.Height - 10)
			});

			tabPage.Controls.Add(new LCDLabel
			{
				Location = new Point(LCDApp.DefaultSize.Width / 2 + 5, 0),
				Font = PixelFonts.Title,
				Text = "Combat:",
				AutoSize = true,
			});
			tabPage.Controls.Add(new LCDLabel
			{
				Location = new Point(LCDApp.DefaultSize.Width / 2 + 10, 6),
				Font = PixelFonts.Small,
				Text = Enum.GetName(typeof(EliteRanks.Combat), Instance.Ranks.Combat).Replace("_", " ") + " " + Instance.Ranks.CombatProgress + "%",
				AutoSize = true,
			});

			tabPage.Controls.Add(new LCDLabel
			{
				Location = new Point(LCDApp.DefaultSize.Width / 2 + 5, 12),
				Font = PixelFonts.Title,
				Text = "Trade:",
				AutoSize = true,
			});
			tabPage.Controls.Add(new LCDLabel
			{
				Location = new Point(LCDApp.DefaultSize.Width / 2 + 10, 18),
				Font = PixelFonts.Small,
				Text = Enum.GetName(typeof(EliteRanks.Trade), Instance.Ranks.Trade).Replace("_", " ") + " " + Instance.Ranks.TradeProgress + "%",
				AutoSize = true,
			});

			tabPage.Controls.Add(new LCDLabel
			{
				Location = new Point(LCDApp.DefaultSize.Width / 2 + 5, 24),
				Font = PixelFonts.Title,
				Text = "Explorer:",
				AutoSize = true,
			});
			tabPage.Controls.Add(new LCDLabel
			{
				Location = new Point(LCDApp.DefaultSize.Width / 2 + 10, 30),
				Font = PixelFonts.Small,
				Text = Enum.GetName(typeof(EliteRanks.Explorer), Instance.Ranks.Explore).Replace("_", " ") + " " + Instance.Ranks.ExploreProgress + "%",
				AutoSize = true,
			});


			label = new CreateLabel();
			label.Location = new Point(0, 35);
			label.TitleText = "CQC: ";
			label.TextText = Enum.GetName(typeof(EliteRanks.CQC), Instance.Ranks.CQC).Replace("_", " ") + " " + Instance.Ranks.CQCProgress + "%";
			label.TextFont = PixelFonts.Small;
			label.BuildLabel().ForEach(x => tabPage.Controls.Add(x));

			BuildLCD.Build(tabPage);
		}
	}
}
