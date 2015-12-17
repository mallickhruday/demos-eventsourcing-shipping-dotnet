using System;
using System.Collections;

namespace helloeventsourcingshipping
{
	class EventProcessor {

		IList log = new ArrayList();  

		public void Process(DomainEvent e) {
			e.Process();
			log.Add(e);
		}

		public EventProcessor(bool isActive) {
			IsActive = isActive;
		}

		public bool IsActive { get; private set;}
	}
}
