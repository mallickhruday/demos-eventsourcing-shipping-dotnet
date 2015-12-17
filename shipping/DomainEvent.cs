using System;

namespace helloeventsourcingshipping
{
	abstract class DomainEvent {
		DateTime _recorded, _occurred;

		internal DomainEvent (DateTime occurred) {
			this._occurred = occurred;
			this._recorded = DateTime.Now;
		}

		internal DateTime Occurred { 
			get { return _occurred; }
		}

		internal DateTime Recorded { 
			get { return _recorded; }
		}

		abstract internal void Process();
	}
}

