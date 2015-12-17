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
			Console.WriteLine ("Hello World!");
		}
	}
}
