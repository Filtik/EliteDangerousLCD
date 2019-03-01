using EliteAPI.Status;

namespace EliteDangerousLCD.Objects
{
	public class Instance
	{
		public Commander Commander = new Commander();
		public Ranks Ranks = new Ranks();
		public ShipStatus ShipStatus = new ShipStatus();
		public Ship ShipExtra = new Ship();
		public Dock Dock = new Dock();

		public Tab Tab = new Tab();
	}
}
