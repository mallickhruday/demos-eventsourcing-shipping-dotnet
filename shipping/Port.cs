using System;

namespace helloeventsourcingshipping
{
	class Port
	{
		public Port(string name, Country country, CustomsEventGateway customs) {
			_customs = customs;
			Country = country;
		}

		public void HandleArrival (ArrivalEvent ev) {
			ev.Ship.Port = this;
			_customs.Notify(ev.Occurred, ev.Ship, ev.Port);
		}

		public Country Country { get; private set;}
		private CustomsEventGateway _customs;
	}
}
