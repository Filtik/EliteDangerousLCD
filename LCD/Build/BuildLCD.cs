using System;
using System.Drawing;
using LogiFrame;

namespace EliteDangerousLCD.LCD.Build
{
	public class BuildLCD : EDLCD
	{
		public static void Build(LCDContainerControl containerControl)
		{
			var tabPage = new LCDTabPage();

			foreach (var item in containerControl.Controls)
				tabPage.Controls.Add(item);

			var alert = AlertBoarder.CreateAlert();
			if (alert != null)
			{
				tabPage.Controls.Add(alert);
				LCDApp.MergeMethod.Merge(LCDApp.Bitmap, alert.Bitmap, new Point());
			}


			var tabControl = new LCDTabControl();
			tabControl.TabPages.Add(tabPage);
			tabControl.SelectedTab = tabPage;

			if (LCDApp.Controls.Contains(tabControl))
				return;
			
			LCDApp.Controls.Add(tabControl);

			if (LCDApp.Controls.Count >= 2)
				LCDApp.Controls.RemoveAt(0);
		}
	}
}
