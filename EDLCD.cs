using EliteDangerousLCD.Elite;
using EliteDangerousLCD.LCD.Tabs;
using EliteDangerousLCD.Objects;
using EliteDangerousLCD.Objects.Enum;
using LogiFrame;

namespace EliteDangerousLCD
{
	public delegate void NoArgumentsEventHandler();

	public class EDLCD
	{
		public static LCDApp LCDApp = new LCDApp("Elite Dangerous LCD", true, false, false);
		public static Instance Instance = new Instance();
		public static bool ButtonsEnabled = false;

		public static void Main()
		{
			TabLCDStartup.Create();

			EliteInit.Start();
			StatusChecker.StartChecker();

			LCDApp.ButtonDown += LCDApp_ButtonDown;

			LCDApp.WaitForClose();
		}

		private static void LCDApp_ButtonDown(object sender, ButtonEventArgs e)
		{
			if (!ButtonsEnabled) return;

			Instance.Tab.Set((LCDTab)e.Button);
		}
	}
}
