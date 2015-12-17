using System;
using System.Collections;
using System.Collections.Generic;

namespace helloeventsourcingshipping
{
	class Ship
	{
		public void HandleArrival (ArrivalEvent ev) {
			Port = ev.Port;
			Port.HandleArrival (ev);
			foreach (Cargo c in cargo) { 
				c.HandleArrival (ev);
			}
		}

		public void HandleDeparture(DepartureEvent ev) {
			Port = null;
		}

		public Ship(string name) {
			Name = name;
		}

		IList cargo = new List<Cargo>();
		public Port Port { get; set;}
		public string Name { get; private set; }
	}
}

