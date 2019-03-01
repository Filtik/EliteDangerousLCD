using System;
using EliteDangerousLCD.Elite;
using EliteDangerousLCD.LCD.Tabs;
using EliteDangerousLCD.Objects.Enum;

namespace EliteDangerousLCD.Objects
{
	public class Tab
	{
		private static LCDTab _last { get; set; } = LCDTab.None;
		private static LCDTab _current { get; set; } = LCDTab.None;
		public LCDTab Last { get => _last; }
		public LCDTab Current { get => _current; }

		public void Set(LCDTab tab)
		{
			 if (_current != LCDTab.Dock && tab != LCDTab.Dock) _last = _current;
			_current = tab;

			Set();
		}

		public void SetForce(LCDTab tab)
		{
			_current = tab;

			Set();
		}

		private void Set()
		{
			switch (_current)
			{
				case LCDTab.Commander:
					TabLCDCommander.Create();
					break;

				case LCDTab.Rank:
					TabLCDRank.Create();
					break;

				case LCDTab.Ship:
					TabLCDShip.Create();
					break;

				case LCDTab.Dock:
					TabLCDDocked.Create();
					break;

				default:
					TabLCDStartElite.Create();
					break;
			}
		}

		public void Refresh(LCDTab tab)
		{
			if (_current != tab)
				return;

			EDLCD.Instance.ShipStatus = EliteInit.EliteAPI.Status;

			Set(tab);
		}
	}
}
