using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("shipping.tests.unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace helloeventsourcingshipping
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Event sourcing demo. See http://martinfowler.com/eaaDev/EventSourcing.html");
			Console.WriteLine ("Usage: Set breakpoints, run the tests, step through the code.");
		}
	}
}
