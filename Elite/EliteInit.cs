using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EliteAPI;
using EliteAPI.Status;
using Newtonsoft.Json;

namespace EliteDangerousLCD.Elite
{
	public class EliteInit
	{
		public EliteInit() { }
		
		public static EliteDangerousAPI EliteAPI;
		private static readonly List<EliteInit> _loadedScripts = new List<EliteInit>();
		public static event NoArgumentsEventHandler Including;
		private static ShipStatus Status = new ShipStatus();

		public static void Start()
		{
			EliteAPI = new EliteDangerousAPI(EliteDangerousAPI.StandardDirectory, false);

			EliteAPI.Events.AllEvent += EliteAPI_DockingGrantedEvent;
			EliteAPI.Logger.Log += (sender, arg) => Console.WriteLine(arg.Message);


			// Load all scripts.
			foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
			{
				if (type.IsSubclassOf(typeof(EliteInit)) && !type.IsAbstract)
				{
					Console.WriteLine($"Loading class {type.Name}");
					if (Activator.CreateInstance(type) is EliteInit script) _loadedScripts.Add(script);
				}

			}

			Including?.Invoke();

			_loadedScripts.ToList().ForEach(x => x.MemberwiseClone());

			EliteAPI.Start();

			Task.Run(() =>
			{
				if (Status != EliteAPI.Status)
					Status = EliteAPI.Status;


				Thread.Sleep(500);
			});
		}

		private static void EliteAPI_DockingGrantedEvent(object sender, dynamic e)
		{
			Console.WriteLine(JsonConvert.SerializeObject(e));
		}
	}
}
