using System;
using EliteAPI.Events;
using EliteDangerousLCD.LCD.Tabs;
using EliteDangerousLCD.Objects;
using EliteDangerousLCD.Objects.Enum;

namespace EliteDangerousLCD.Elite
{
	public class EventHandler : EliteInit
	{
		public EventHandler()
		{
			EliteAPI.Events.ShutdownEvent += Event_Shutdown;
			EliteAPI.Events.CommanderEvent += Event_Commander;
			EliteAPI.Events.FileheaderEvent += Events_FileheaderEvent;
			EliteAPI.Events.MusicEvent += Events_MusicEvent;
			EliteAPI.Events.LoadGameEvent += Events_LoadGameEvent;
			EliteAPI.Events.LoadoutEvent += Events_LoadoutEvent;
			EliteAPI.Events.RankEvent += Events_RankEvent;
			EliteAPI.Events.ProgressEvent += Events_ProgressEvent;
			EliteAPI.Events.ReputationEvent += Events_ReputationEvent;
			EliteAPI.Events.ShieldStateEvent += Events_ShieldStateEvent;
			EliteAPI.Events.RefuelAllEvent += Events_RefuelAllEvent;
			EliteAPI.Events.FSDJumpEvent += Events_FSDJumpEvent;
			EliteAPI.Events.StartJumpEvent += Events_StartJumpEvent;
			EliteAPI.Events.SupercruiseExitEvent += Events_SupercruiseExitEvent;
			EliteAPI.Events.DockedEvent += Events_DockedEvent;
			EliteAPI.Events.DockingGrantedEvent += Events_DockingGrantedEvent;
			EliteAPI.Events.UndockedEvent += Events_UndockedEvent;
			//EliteAPI.Events.HullDamageEvent += Events_HullDamageEvent;
			EliteAPI.Events.RepairAllEvent += Events_RepairAllEvent;
			EliteAPI.Events.RepairEvent += Events_RepairEvent;
			EliteAPI.Events.StatisticsEvent += Events_StatisticsEvent;
			EliteAPI.Events.BuyAmmoEvent += Events_BuyAmmoEvent;
			EliteAPI.Events.BuyDronesEvent += Events_BuyDronesEvent;
			EliteAPI.Events.BuyExplorationDataEvent += Events_BuyExplorationDataEvent;
			EliteAPI.Events.BuyTradeDataEvent += Events_BuyTradeDataEvent;

			//EliteAPI.Events.StatusDockedEvent += Events_StatusEvent;
		}

		private static void Events_BuyTradeDataEvent(object sender, BuyTradeDataInfo e)
		{
			EDLCD.Instance.Commander.Credits = EDLCD.Instance.Commander.Credits - Convert.ToUInt32(e.Cost);
			EDLCD.Instance.Tab.Refresh(LCDTab.Commander);
		}

		private static void Events_BuyExplorationDataEvent(object sender, BuyExplorationDataInfo e)
		{
			EDLCD.Instance.Commander.Credits = EDLCD.Instance.Commander.Credits - Convert.ToUInt32(e.Cost);
			EDLCD.Instance.Tab.Refresh(LCDTab.Commander);
		}

		private static void Events_BuyDronesEvent(object sender, BuyDronesInfo e)
		{
			EDLCD.Instance.Commander.Credits = EDLCD.Instance.Commander.Credits - Convert.ToUInt32(e.TotalCost);
			EDLCD.Instance.Tab.Refresh(LCDTab.Commander);
		}

		private static void Events_BuyAmmoEvent(object sender, BuyAmmoInfo e)
		{
			EDLCD.Instance.Commander.Credits = EDLCD.Instance.Commander.Credits - Convert.ToUInt32(e.Cost);
			EDLCD.Instance.Tab.Refresh(LCDTab.Commander);
		}

		private static void Events_StatisticsEvent(object sender, StatisticsInfo e)
		{
			EDLCD.Instance.Tab.Refresh(LCDTab.Commander);
		}

		private static void Events_SupercruiseExitEvent(object sender, SupercruiseExitInfo e)
		{
			EDLCD.Instance.ShipExtra.StartJump = false;
			EDLCD.Instance.ShipExtra.JumpTo = "";
			EDLCD.Instance.Tab.Refresh(LCDTab.Ship);
		}

		private static void Events_UndockedEvent(object sender, UndockedInfo e)
		{
			var dockName = EDLCD.Instance.Dock.Name;
			EDLCD.Instance.ShipExtra.Docked = false;
			EDLCD.Instance.Dock = new Dock();
			EDLCD.Instance.Tab.Set(EDLCD.Instance.Tab.Last);
		}

		private static void Events_DockingGrantedEvent(object sender, DockingGrantedInfo e)
		{
			EDLCD.Instance.Dock.LandingPad = Convert.ToInt32(e.LandingPad);
			EDLCD.Instance.Tab.Refresh(LCDTab.Ship);
		}

		private static void Events_DockedEvent(object sender, DockedInfo e)
		{
			EDLCD.Instance.ShipExtra.AutomaticDocking = false;
			EDLCD.Instance.ShipExtra.Docked = true;
			EDLCD.Instance.Dock.Name = e.StationName;
			EDLCD.Instance.Dock.System = e.StarSystem;
			EDLCD.Instance.Dock.Type = e.StationType;
			EDLCD.Instance.Dock.Government = e.StationGovernmentLocalised;
			EDLCD.Instance.Dock.Allegiance = e.StationAllegiance;
			EDLCD.Instance.Dock.Services = string.Join(", ", e.StationServices.ToArray());
			EDLCD.Instance.Tab.Set(LCDTab.Dock);
		}

		private static void Events_RepairAllEvent(object sender, RepairAllInfo e)
		{
			EDLCD.Instance.Commander.Credits = EDLCD.Instance.Commander.Credits - Convert.ToUInt32(e.Cost);
			EDLCD.Instance.Tab.Refresh(LCDTab.Commander);
		}

		private static void Events_RepairEvent(object sender, RepairInfo e)
		{
			EDLCD.Instance.Commander.Credits = EDLCD.Instance.Commander.Credits - Convert.ToUInt32(e.Cost);
			EDLCD.Instance.Tab.Refresh(LCDTab.Ship);
			EDLCD.Instance.Tab.Refresh(LCDTab.Commander);
		}

		//private static void Events_HullDamageEvent(object sender, HullDamageInfo e)
		//{
		//	EDLCD.Instance.ShipExtra.HullHealth = Convert.ToInt32(e.Health);
		//	EDLCD.Instance.Tab.Refresh(LCDTab.Ship);
		//}

		private static void Events_StartJumpEvent(object sender, StartJumpInfo e)
		{
			EDLCD.Instance.ShipExtra.FuelProcent = Convert.ToInt32(100 / EDLCD.Instance.ShipExtra.FuelMax * EDLCD.Instance.ShipExtra.FuelCurrent);
			EDLCD.Instance.ShipExtra.StartJump = true;
			EDLCD.Instance.ShipExtra.JumpTo = e.StarSystem;
			EDLCD.Instance.ShipExtra.JumpType = e.JumpType;
			EDLCD.Instance.Tab.Refresh(LCDTab.Ship);
		}

		private static void Events_FSDJumpEvent(object sender, FSDJumpInfo e)
		{
			EDLCD.Instance.ShipExtra.FuelCurrent = e.FuelLevel;
			EDLCD.Instance.ShipExtra.FuelProcent = Convert.ToInt32(100 / EDLCD.Instance.ShipExtra.FuelMax * EDLCD.Instance.ShipExtra.FuelCurrent);
			EDLCD.Instance.ShipExtra.StartJump = false;
			EDLCD.Instance.ShipExtra.JumpTo = "";
			EDLCD.Instance.Tab.Refresh(LCDTab.Ship);
		}

		private static void Events_RefuelAllEvent(object sender, RefuelAllInfo e)
		{
			EDLCD.Instance.Commander.Credits = EDLCD.Instance.Commander.Credits - Convert.ToUInt32(e.Cost);
			EDLCD.Instance.Tab.Refresh(LCDTab.Ship);
			EDLCD.Instance.Tab.Refresh(LCDTab.Commander);
		}

		private static void Events_LoadoutEvent(object sender, LoadoutInfo e)
		{
			//EDLCD.Instance.ShipExtra.HullHealth = Convert.ToInt32(e.HullHealth) * 100;
			EDLCD.Instance.ShipExtra.Name = e.ShipName;
			EDLCD.Instance.ShipExtra.Type = e.Ship;
			EDLCD.Instance.Tab.Refresh(LCDTab.Ship);
			EDLCD.Instance.Tab.Refresh(LCDTab.Commander);
		}

		private static void Events_ShieldStateEvent(object sender, ShieldStateInfo e)
		{
			EDLCD.Instance.ShipExtra.Shield = e.ShieldsUp;
			EDLCD.Instance.Tab.Refresh(LCDTab.Ship);
		}

		private static void Events_ReputationEvent(object sender, ReputationInfo e)
		{
			EDLCD.Instance.Ranks.FederationReputation = Convert.ToInt32(e.Federation);
			EDLCD.Instance.Ranks.EmpireReputation = Convert.ToInt32(e.Empire);
			EDLCD.Instance.Ranks.AllianceReputation = Convert.ToInt32(e.Alliance);
			EDLCD.Instance.Tab.Refresh(LCDTab.Commander);
		}

		private static void Events_ProgressEvent(object sender, ProgressInfo e)
		{
			EDLCD.Instance.Ranks.FederationProgress = Convert.ToInt32(e.Federation);
			EDLCD.Instance.Ranks.EmpireProgress = Convert.ToInt32(e.Empire);
			EDLCD.Instance.Ranks.CombatProgress = Convert.ToInt32(e.Combat);
			EDLCD.Instance.Ranks.TradeProgress = Convert.ToInt32(e.Trade);
			EDLCD.Instance.Ranks.ExploreProgress = Convert.ToInt32(e.Explore);
			EDLCD.Instance.Ranks.CQCProgress = Convert.ToInt32(e.Cqc);
		}

		private static void Events_RankEvent(object sender, RankInfo e)
		{
			EDLCD.Instance.Ranks.Federation = Convert.ToInt32(e.Federation);
			EDLCD.Instance.Ranks.Empire = Convert.ToInt32(e.Empire);
			EDLCD.Instance.Ranks.Combat = Convert.ToInt32(e.Combat);
			EDLCD.Instance.Ranks.Trade = Convert.ToInt32(e.Trade);
			EDLCD.Instance.Ranks.Explore = Convert.ToInt32(e.Explore);
			EDLCD.Instance.Ranks.CQC = Convert.ToInt32(e.Cqc);
		}

		private static void Events_LoadGameEvent(object sender, LoadGameInfo e)
		{
			EDLCD.Instance.Commander.Name = e.Commander;
			EDLCD.Instance.ShipExtra.Name = e.ShipName;
			EDLCD.Instance.ShipExtra.Type = e.Ship;
			EDLCD.Instance.ShipExtra.FuelCurrent = Convert.ToInt32(e.FuelLevel);
			EDLCD.Instance.ShipExtra.FuelMax = Convert.ToInt32(e.FuelCapacity);
			EDLCD.Instance.ShipExtra.FuelProcent = Convert.ToInt32(100 / EDLCD.Instance.ShipExtra.FuelMax * EDLCD.Instance.ShipExtra.FuelCurrent);
			EDLCD.Instance.Commander.Credits = Convert.ToUInt32(e.Credits);
			EDLCD.Instance.Tab.Refresh(LCDTab.Commander);
		}

		private static void Events_MusicEvent(object sender, MusicInfo e)
		{
			switch (e.MusicTrack)
			{
				case "MainMenu":
					TabLCDStartElite.Create();
					break;

				case "DockingComputer":
					EDLCD.Instance.ShipExtra.AutomaticDocking = true;
					EDLCD.Instance.Tab.Refresh(LCDTab.Ship);
					break;

				case "NoTrack":
					if (EDLCD.Instance.ShipExtra.AutomaticDocking)
					{
						EDLCD.Instance.ShipExtra.AutomaticDocking = false;
						EDLCD.Instance.Tab.Refresh(LCDTab.Ship);
					}
					break;

				default:
					return;
			}
		}

		private static void Events_FileheaderEvent(object sender, FileheaderInfo e)
		{
			TabLCDStartElite.Create();
		}

		private static void Event_Shutdown(object sender, ShutdownInfo e)
		{
			EDLCD.Instance = new Instance();
			TabLCDStartup.Create();
		}

		private static void Event_Commander(object sender, CommanderInfo e)
		{
			EDLCD.Instance.Commander.Name = e.Name;
			EDLCD.Instance.Tab.Set(LCDTab.Commander);
			EDLCD.ButtonsEnabled = true;
		}

		private static void Events_StatusEvent(object sender, bool e)
		{
			EDLCD.Instance.Tab.Refresh(LCDTab.Ship);
			EDLCD.Instance.Tab.Refresh(LCDTab.Dock);
		}
	}
}
