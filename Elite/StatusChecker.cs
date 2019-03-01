using System;
using System.Threading;
using System.Threading.Tasks;
using EliteAPI.Status;
using EliteDangerousLCD.Objects;
using EliteDangerousLCD.Objects.Enum;

namespace EliteDangerousLCD.Elite
{
	public class StatusChecker : EliteInit
	{
		private static ShipStatus Status;
		private static Task StatusCheck;

		public static void StartChecker()
		{
			StatusCheck = Task.Run(() =>
			{
				while (EliteAPI.IsRunning)
				{
					if (Status == EliteAPI.Status)
					{
						Thread.Sleep(1000);
						continue;
					}

					Status = EliteAPI.Status;
					
					if (Status?.Fuel?.FuelMain != null)
					{
						EDLCD.Instance.ShipExtra.FuelCurrent = Convert.ToDouble(Status.Fuel.FuelMain);
						EDLCD.Instance.ShipExtra.FuelProcent = Convert.ToInt32(100 / EDLCD.Instance.ShipExtra.FuelMax * EDLCD.Instance.ShipExtra.FuelCurrent);
					}

					EDLCD.Instance.Tab.Refresh(EDLCD.Instance.Tab.Current);

					//if (EDLCD.Instance.Ship != Ship)
					//{
					//	SetNewCheck();
					//	if (EDLCD.Instance.LCDTab.Current == 2)
					//		EDLCD.Instance.LCDTab.Refresh();
					//}
				}
			});
		}

		//public static void SetNewCheck()
		//{
		//	EDLCD.Instance.Ship.CargoScoop = Status.CargoScoop;
		//	EDLCD.Instance.Ship.MassLocked = Status.MassLocked;
		//	EDLCD.Instance.Ship.Gear = Status.Gear;
		//	EDLCD.Instance.Ship.Docked = Status.Docked;

		//	if (Status?.Fuel?.FuelMain != null && EDLCD.Instance.Ship.FuelMax != 0 && EDLCD.Instance.Ship.FuelCurrent != Convert.ToInt32(Status.Fuel.FuelMain))
		//	{
		//		EDLCD.Instance.Ship.FuelCurrent = Status.Fuel.FuelMain;
		//		EDLCD.Instance.Ship.FuelProcent = Convert.ToInt32(100 / EDLCD.Instance.Ship.FuelMax * EDLCD.Instance.Ship.FuelCurrent);
		//	}

		//	Ship = EDLCD.Instance.Ship;
		//}
	}
}
