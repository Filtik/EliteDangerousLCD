using System.Drawing;
using EliteDangerousLCD.LCD.Build;
using LogiFrame;
using LogiFrame.Drawing;

namespace EliteDangerousLCD.LCD.Tabs
{
	public class TabLCDShip : EDLCD
	{
		public static LCDContainerControl tabPage = new LCDContainerControl();
		public static Point labelLocation = new Point(5, LCDApp.DefaultSize.Height / 2 - 5);
		public static Size labelSize = new Size(LCDApp.DefaultSize.Width / 3 * 2, 15);

		public static void Create()
		{
			tabPage = new LCDContainerControl();

			var label = new CreateLabel();
			label.Location = new Point(1, 1);
			label.TitleText = "Ship: ";
			label.TextText = Instance.ShipExtra.Name != "" ? Instance.ShipExtra.Name : Instance.ShipExtra.Type;
			label.TextFont = PixelFonts.Small;
			label.BuildLabel().ForEach(x => tabPage.Controls.Add(x));

			label = new CreateLabel();
			label.Location = new Point(1, 7);
			label.TitleText = "Shiptype: ";
			label.TextText = Instance.ShipExtra.Type;
			label.TextFont = PixelFonts.Small;
			label.BuildLabel().ForEach(x => tabPage.Controls.Add(x));


			Bars();

			BottonLines();

			ExtraLines();

			TextInfo();

			BuildLCD.Build(tabPage);
		}

		#region BottonLines

		private static void BottonLines()
		{
			#region Shield

			var shieldRectangle = new LCDRectangle
			{
				Location = new Point(108, LCDApp.DefaultSize.Height - 11),
				Size = new Size(28, 10),
				Style = Instance.ShipStatus.Shields ? RectangleStyle.Filled : RectangleStyle.Bordered,

			};
			tabPage.Controls.Add(shieldRectangle);

			var shieldLabel = new LCDLabel
			{
				Location = new Point(109, LCDApp.DefaultSize.Height - 10),
				Text = "Shield",
				Size = new Size(28, 9),
				TextAlign = ContentAlignment.MiddleCenter,
				MergeMethod = Instance.ShipStatus.Shields ? MergeMethods.Invert : MergeMethods.Transparent
			};
			tabPage.Controls.Add(shieldLabel);

			LCDApp.MergeMethod.Merge(shieldRectangle.Bitmap, shieldLabel.Bitmap, new Point());

			#endregion


			#region Docked

			if (Instance.ShipStatus.Docked)
			{
				var dockedRectangle = new LCDRectangle
				{
					Location = new Point(1, LCDApp.DefaultSize.Height - 11),
					Size = new Size(106, 10),
					Style = RectangleStyle.Filled
				};
				tabPage.Controls.Add(dockedRectangle);

				var dockedLabel = new LCDLabel
				{
					Location = new Point(2, LCDApp.DefaultSize.Height - 11),
					Text = "DOCKED",
					Size = new Size(106, 9),
					TextAlign = ContentAlignment.MiddleCenter,
					Font = PixelFonts.Title,
					MergeMethod = MergeMethods.Invert
				};
				tabPage.Controls.Add(dockedLabel);

				LCDApp.MergeMethod.Merge(dockedRectangle.Bitmap, dockedLabel.Bitmap, new Point());

				BuildLCD.Build(tabPage);

				return;
			}

			#endregion


			#region Gear

			var gearRectangle = new LCDRectangle
			{
				Location = new Point(1, LCDApp.DefaultSize.Height - 11),
				Size = new Size(24, 10),
				Style = Instance.ShipStatus.Gear ? RectangleStyle.Filled : RectangleStyle.Bordered,

			};
			tabPage.Controls.Add(gearRectangle);

			var gearLabel = new LCDLabel
			{
				Location = new Point(2, LCDApp.DefaultSize.Height - 10),
				Text = "Gear",
				Size = new Size(24, 9),
				TextAlign = ContentAlignment.MiddleCenter,
				MergeMethod = Instance.ShipStatus.Gear ? MergeMethods.Invert : MergeMethods.Transparent
			};
			tabPage.Controls.Add(gearLabel);

			LCDApp.MergeMethod.Merge(gearRectangle.Bitmap, gearLabel.Bitmap, new Point());

			#endregion


			#region CargoScoop

			var scoopRectangle = new LCDRectangle
			{
				Location = new Point(26, LCDApp.DefaultSize.Height - 11),
				Size = new Size(52, 10),
				Style = Instance.ShipStatus.CargoScoop ? RectangleStyle.Filled : RectangleStyle.Bordered,

			};
			tabPage.Controls.Add(scoopRectangle);

			var scoopLabel = new LCDLabel
			{
				Location = new Point(27, LCDApp.DefaultSize.Height - 10),
				Text = "Cargoscoop",
				Size = new Size(52, 9),
				TextAlign = ContentAlignment.MiddleCenter,
				MergeMethod = Instance.ShipStatus.CargoScoop ? MergeMethods.Invert : MergeMethods.Transparent
			};
			tabPage.Controls.Add(scoopLabel);

			LCDApp.MergeMethod.Merge(scoopRectangle.Bitmap, scoopLabel.Bitmap, new Point());

			#endregion


			#region Mass

			var massRectangle = new LCDRectangle
			{
				Location = new Point(79, LCDApp.DefaultSize.Height - 11),
				Size = new Size(28, 10),
				Style = Instance.ShipStatus.MassLocked ? RectangleStyle.Filled : RectangleStyle.Bordered,

			};
			tabPage.Controls.Add(massRectangle);

			var massLabel = new LCDLabel
			{
				Location = new Point(80, LCDApp.DefaultSize.Height - 10),
				Text = "Mass",
				Size = new Size(28, 9),
				TextAlign = ContentAlignment.MiddleCenter,
				MergeMethod = Instance.ShipStatus.MassLocked ? MergeMethods.Invert : MergeMethods.Transparent
			};
			tabPage.Controls.Add(massLabel);

			LCDApp.MergeMethod.Merge(massRectangle.Bitmap, massLabel.Bitmap, new Point());

			#endregion
		}

		#endregion

		#region ExtraLines

		private static void ExtraLines()
		{
			#region Light

			var lightRectangle = new LCDRectangle
			{
				Location = new Point(128, LCDApp.DefaultSize.Height - 22),
				Size = new Size(8, 9),
				Style = Instance.ShipStatus.Lights ? RectangleStyle.Filled : RectangleStyle.Bordered,

			};
			tabPage.Controls.Add(lightRectangle);

			var lightLabel = new LCDLabel
			{
				Location = new Point(129, LCDApp.DefaultSize.Height - 21),
				Text = "L",
				Size = new Size(8, 8),
				TextAlign = ContentAlignment.MiddleCenter,
				MergeMethod = Instance.ShipStatus.Lights ? MergeMethods.Invert : MergeMethods.Transparent
			};
			tabPage.Controls.Add(lightLabel);

			LCDApp.MergeMethod.Merge(lightRectangle.Bitmap, lightLabel.Bitmap, new Point());

			#endregion

			#region Night

			var nightRectangle = new LCDRectangle
			{
				Location = new Point(128, LCDApp.DefaultSize.Height - 33),
				Size = new Size(8, 9),
				Style = Instance.ShipStatus.NightVision ? RectangleStyle.Filled : RectangleStyle.Bordered,

			};
			tabPage.Controls.Add(nightRectangle);

			var nightLabel = new LCDLabel
			{
				Location = new Point(129, LCDApp.DefaultSize.Height - 32),
				Text = "N",
				Size = new Size(8, 8),
				TextAlign = ContentAlignment.MiddleCenter,
				MergeMethod = Instance.ShipStatus.NightVision ? MergeMethods.Invert : MergeMethods.Transparent
			};
			tabPage.Controls.Add(nightLabel);

			LCDApp.MergeMethod.Merge(nightRectangle.Bitmap, nightLabel.Bitmap, new Point());

			#endregion
		}

		#endregion

		#region Bars

		private static void Bars()
		{
			if (Instance.ShipStatus.InSRV)
			{
				tabPage.Controls.Add(new LCDLabel
				{
					Location = new Point(LCDApp.DefaultSize.Width - 15, 0),
					Font = SystemFonts.DefaultFont,
					Text = "S",
					AutoSize = true,
				});
				tabPage.Controls.Add(new LCDLabel
				{
					Location = new Point(LCDApp.DefaultSize.Width - 15, 15),
					Font = SystemFonts.DefaultFont,
					Text = "R",
					AutoSize = true,
				});
				tabPage.Controls.Add(new LCDLabel
				{
					Location = new Point(LCDApp.DefaultSize.Width - 15, 30),
					Font = SystemFonts.DefaultFont,
					Text = "V",
					AutoSize = true,
				});
				return;
			}

			#region Fuel

			tabPage.Controls.Add(new LCDLabel
			{
				Location = new Point(LCDApp.DefaultSize.Width - 19, 1),
				Font = PixelFonts.Small,
				Text = "Fuel",
				AutoSize = true,
			});

			tabPage.Controls.Add(new LCDLabel
			{
				Location = new Point(LCDApp.DefaultSize.Width - 19, LCDApp.DefaultSize.Height - 7),
				Font = PixelFonts.Small,
				Text = $"{Instance.ShipExtra.FuelProcent}%",
				Size = new Size(21, 6),
				TextAlign = ContentAlignment.MiddleRight
			});

			tabPage.Controls.Add(new LCDProgressBar
			{
				Location = new Point(LCDApp.DefaultSize.Width - 15, 9),
				Size = new Size(10, LCDApp.DefaultSize.Height - 18),
				Style = BorderStyle.Border,
				Direction = ProgressBarDirection.Up,
				Value = Instance.ShipExtra.FuelProcent
			});

			#endregion

			#region Hull

			//tabPage.Controls.Add(new LCDLabel
			//{
			//	Location = new Point(LCDApp.DefaultSize.Width - 38, 0),
			//	Font = PixelFonts.Small,
			//	Text = "Hull",
			//	AutoSize = true,
			//});

			//tabPage.Controls.Add(new LCDLabel
			//{
			//	Location = new Point(LCDApp.DefaultSize.Width - 38, LCDApp.DefaultSize.Height - 6),
			//	Font = PixelFonts.Small,
			//	Text = $"{Instance.ShipExtra.HullHealth}%",
			//	Size = new Size(19, 6),
			//	TextAlign = ContentAlignment.MiddleCenter
			//});

			//tabPage.Controls.Add(new LCDProgressBar
			//{
			//	Location = new Point(LCDApp.DefaultSize.Width - 35, 8),
			//	Size = new Size(10, LCDApp.DefaultSize.Height - 16),
			//	Style = BorderStyle.Border,
			//	Direction = ProgressBarDirection.Up,
			//	Value = Instance.ShipExtra.HullHealth
			//});

			#endregion
		}

		#endregion

		#region TextInfo

		private static void TextInfo()
		{
			FSD();

			Docking();
		}

		private static void Docking()
		{
			if (Instance.ShipExtra.AutomaticDocking)
			{
				var autodockLabel = new LCDLabel
				{
					Location = labelLocation,
					Text = "Automatic docking",
					//Size = labelSize,
					TextAlign = ContentAlignment.MiddleCenter,
					Font = SystemFonts.DialogFont,
					AutoSize = true
				};
				tabPage.Controls.Add(autodockLabel);
			}
		}

		private static void FSD()
		{

			if (Instance.ShipStatus.FsdCooldown)
			{
				var fsdCooldownLabel = new LCDLabel
				{
					Location = labelLocation,
					Text = "FSD cooldown",
					//Size = labelSize,
					TextAlign = ContentAlignment.MiddleCenter,
					Font = SystemFonts.DialogFont,
					AutoSize = true
				};
				tabPage.Controls.Add(fsdCooldownLabel);
				return;
			}

			if (Instance.ShipStatus.FsdCharging)
			{
				var fsdLabel = new LCDLabel
				{
					Location = labelLocation,
					Text = "FSD Charging",
					//Size = labelSize,
					TextAlign = ContentAlignment.MiddleCenter,
					Font = SystemFonts.DialogFont,
					AutoSize = true
				};
				tabPage.Controls.Add(fsdLabel);

				if (Instance.ShipExtra.StartJump)
				{
					if (Instance.ShipExtra.JumpType == "Supercruise")
						return;

					var fsdJumpLabel = new LCDLabel
					{
						Location = labelLocation,
						Text = "Jump to: " + Instance.ShipExtra.JumpTo,
						//Size = labelSize,
						TextAlign = ContentAlignment.MiddleCenter,
						Font = SystemFonts.DialogFont,
						AutoSize = true
					};
					tabPage.Controls.Add(fsdJumpLabel);
				}
			}
		}

		#endregion
	}
}
