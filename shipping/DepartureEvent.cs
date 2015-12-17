using System;

namespace helloeventsourcingshipping
{
	class DepartureEvent : DomainEvent
	{
		Port _port;
		Ship _ship;
		internal Port Port  {get { return _port; }}
		internal Ship Ship  {get { return _ship; }}
		internal DepartureEvent(DateTime time, Port port, Ship ship) : base (time)  {
			this._port = port;
			this._ship = ship;
		}

		internal override void Process() {
			Ship.HandleDeparture(this);
		}	
	}
}

