using EliteDangerousLCD.LCD.Build;

namespace EliteDangerousLCD.Objects
{
	public class Ship
	{
		public string Name { get; set; } = "";
		public string Type { get; set; } = "";
		public int HullHealth { get; set; } = 0;
		public double FuelCurrent { get; set; } = 0;
		public double FuelMax { get; set; } = 0;
		public int FuelProcent { get; set; } = 0;
		public bool Docked { get; set; } = false;
		public bool AutomaticDocking { get; set; } = false;
		public bool Light { get; set; } = false;
		public bool Gear { get; set; } = false;
		public bool NightVision { get; set; } = false;
		public bool MassLocked { get; set; } = false;
		public bool SilentRunning { get; set; } = false;
		public bool Shield { get; set; } = false;
		public bool CargoScoop { get; set; } = false;
		public bool StartJump { get; set; } = false;
		public string JumpType { get; set; } = "";
		public string JumpTo { get; set; } = "";
	}
}