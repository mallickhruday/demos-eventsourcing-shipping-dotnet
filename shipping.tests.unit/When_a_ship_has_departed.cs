using NUnit.Framework;
using System;
using helloeventsourcingshipping;
using FakeItEasy;

namespace shipping.tests.unit
{
	[TestFixture ()]
	public class When_a_ship_has_departed
	{
		Ship _shipKingRoy;
		Port _portOfSanFrancisco; 
		Port _portOfLosAngeles;
		EventProcessor _eventProcessor;

		[SetUp]
		public void When() {
			bool isActive = true;
			_eventProcessor = new EventProcessor(isActive); 
			_shipKingRoy = new Ship("King Roy");
			var customsApi = A.Fake<ICustomsApi> ();
			CustomsEventGateway customsEventGateway = new CustomsEventGateway(isActive, customsApi);
			_portOfSanFrancisco = new Port("San Francisco", Country.US, customsEventGateway);
			_portOfLosAngeles = new Port("Los Angeles", Country.US, customsEventGateway);
			_eventProcessor.Process(new ArrivalEvent(new DateTime(2005,10,1), _portOfLosAngeles, _shipKingRoy));
			_eventProcessor.Process(new ArrivalEvent(new DateTime(2005,11,1), _portOfSanFrancisco, _shipKingRoy));
			_eventProcessor.Process(new DepartureEvent(new DateTime(2005,11,1), _portOfSanFrancisco, _shipKingRoy));
		}

		[Test]
		public void Then_the_ship_is_at_sea() {
			Assert.AreEqual(null, _shipKingRoy.Port);    
		}
	}

}