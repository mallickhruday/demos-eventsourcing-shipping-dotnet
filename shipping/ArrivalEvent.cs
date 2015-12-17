using System;

namespace helloeventsourcingshipping
{
	class ArrivalEvent : DomainEvent
	{
		Port _port;
		Ship _ship; 
		internal ArrivalEvent (DateTime occurred, Port port, Ship ship) : base (occurred) {
			this._port = port;
			this._ship = ship;
		} 
		internal Port Port {get {return _port;}}
		internal Ship Ship {get{return _ship;}}

		internal override void Process() {
			Ship.HandleArrival(this);
		}
	}
}

