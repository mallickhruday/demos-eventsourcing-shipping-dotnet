using System;

namespace helloeventsourcingshipping
{
	class Cargo
	{
		public Cargo(string name) {
		}

		public bool HasBeenInCanada = false;
		public void HandleArrival(ArrivalEvent ev) {
			if (Country.CANADA == ev.Port.Country) 
				HasBeenInCanada = true;
		}
	}
}

