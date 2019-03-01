using System;
using System.Collections.Generic;
using System.Drawing;
using LogiFrame;
using LogiFrame.Drawing;

namespace EliteDangerousLCD.LCD.Build
{
	public class FSDJump : EDLCD
	{
		private static Timer Timer = null;
		private static List<LCDControl> Jump = new List<LCDControl>();

		public static List<LCDControl> CreateJump()
		{
			if (!Instance.ShipExtra.StartJump)
			{
				StopJump();
				return Jump;
			}

			if (Timer != null && Jump != new List<LCDControl>())
				return Jump;

			var graphup = new LCDSimpleGraph
			{
				Location = new Point(LCDApp.DefaultSize.Width / 4, LCDApp.DefaultSize.Height / 3),
				Size = new Size(LCDApp.DefaultSize.Width / 2, LCDApp.DefaultSize.Height / 3),
				Style = BorderStyle.BorderWithPadding
			};

			Timer = new Timer { Interval = 500, Enabled = true };
			Timer.Tick += (sender, args) =>
			{
				var rnd = new Random().Next(0, 100);
				graphup.PushValue(rnd);
			};

			Jump.Add(graphup);
			
			return Jump;
		}

		public static void StopJump()
		{
			if (Timer == null) return;
			Timer.Stop();
			Timer = null;
			Jump = new List<LCDControl>();
		}
	}
}
