using NUnit.Framework;
using System;
using helloeventsourcingshipping;
using FakeItEasy;

namespace shipping.tests.unit
{
	[TestFixture ()]
	public class When_a_ship_arrives_at_a_port
	{
		Ship _shipKingRoy;
		Port _portOfSanFrancisco; 
		EventProcessor _eventProcessor;
		CustomsEventGateway _customsEventGateway;
		ICustomsApi _customsApi;

		[SetUp]
		public void When() {
			bool isActive = true;
			_eventProcessor = new EventProcessor(isActive); 
			_shipKingRoy = new Ship("King Roy");
			_customsApi = A.Fake<ICustomsApi> ();

			_customsEventGateway = new CustomsEventGateway (true, _customsApi);
			_portOfSanFrancisco = new Port("San Francisco", Country.US, _customsEventGateway);
			ArrivalEvent ev = new ArrivalEvent(new DateTime(2005,11,1), _portOfSanFrancisco, _shipKingRoy);
			_eventProcessor.Process(ev);

		}
		[Test]
		public void Then_the_ships_location_is_that_port() {
			Assert.AreEqual(_portOfSanFrancisco, _shipKingRoy.Port);
		}

		[Test]
		public void Then_customs_have_been_notified() {
			A.CallTo (() => _customsApi.SendArrivalNotification (A<string>.That.IsEqualTo("King Roy"))).MustHaveHappened ();
		}

	}
}