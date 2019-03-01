using System.Drawing;
using LogiFrame;
using LogiFrame.Drawing;

namespace EliteDangerousLCD.LCD.Build
{
	public class AlertBoarder : EDLCD
	{
		private static Timer Timer = null;
		private static LCDControl Alert = null;

		public static LCDControl CreateAlert()
		{
			if (!Instance.ShipStatus.InDanger && !Instance.ShipStatus.Overheating)
			{
				StopAlert();
				return null;
			}

			if (Timer != null && Alert != null)
				return Alert;

			var alert = new LCDRectangle
			{
				Location = new Point(0, 0),
				Size = new Size(LCDApp.DefaultSize.Width, LCDApp.DefaultSize.Height),
				Style = RectangleStyle.Bordered,
				MergeMethod = MergeMethods.Transparent
			};

			Timer = new Timer { Interval = 500, Enabled = true };
			Timer.Tick += (sender, args) =>
			{
				if (alert.Visible)
					alert.Hide();
				else
					alert.Show();
			};

			Alert = alert;
			
			return Alert;
		}

		public static void StopAlert()
		{
			if (Timer == null) return;
			Timer.Stop();
			Timer = null;
		}
	}
}
