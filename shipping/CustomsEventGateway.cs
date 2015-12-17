using System;

namespace helloeventsourcingshipping
{
	internal class CustomsEventGateway 
	{
		public void Notify (DateTime arrivalDate, Ship ship, Port port) {
			if (_gatewayIsActive) {
				_customsApi.SendArrivalNotification (ship.Name);
			}
		}


		public CustomsEventGateway(bool isActive, ICustomsApi api) {
			_customsApi = api;
			_gatewayIsActive = isActive;
		}

		ICustomsApi _customsApi;
		bool _gatewayIsActive;
	}

	internal interface ICustomsApi
	{
		void  SendArrivalNotification(string nameOfShip);
	}
}

