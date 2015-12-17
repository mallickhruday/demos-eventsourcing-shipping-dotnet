using System;
using NUnit.Framework;
using helloeventsourcingshipping;
using FakeItEasy;

namespace shipping.tests.unit
{
	[TestFixture]
	public class When_rehydrating_events
	{
		Ship _shipKingRoy;
		Port _portOfSanFrancisco; 
		EventProcessor _eventProcessor;
		CustomsEventGateway _customsEventGateway;
		ICustomsApi _customsApi;

		[SetUp]
		public void When() {
			bool isActive = false; 
			_eventProcessor = new EventProcessor(isActive); 
			_shipKingRoy = new Ship("King Roy");

			_customsApi = A.Fake<ICustomsApi> ();
			_customsEventGateway = new CustomsEventGateway(isActive, _customsApi);
			_portOfSanFrancisco = new Port("San Francisco", Country.US, _customsEventGateway);
			ArrivalEvent ev = new ArrivalEvent(new DateTime(2005,11,1), _portOfSanFrancisco, _shipKingRoy);
			_eventProcessor.Process(ev);

		}
		[Test]
		public void Then_the_ships_location_is_at_the_port_of_arrival() {
			Assert.AreEqual(_portOfSanFrancisco, _shipKingRoy.Port);
		}

		[Test]
		public void Then_the_external_customs_notification_api_is_not_called() {
			A.CallTo (() => _customsApi.SendArrivalNotification(A<string>.Ignored)).MustNotHaveHappened();
		}
	}
}
	