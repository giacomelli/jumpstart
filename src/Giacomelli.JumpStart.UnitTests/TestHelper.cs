using System;
using System.IO;
using NUnit.Framework;

namespace Giacomelli.JumpStart.UnitTests
{
	public static class TestHelper
	{
		public static void AssertConsoleOutput(Action test, string expectedOutput)
		{
			using (var output = new StringWriter())
			{
				Console.SetOut(output);
				test();
				Assert.AreEqual(expectedOutput, output.ToString());
			}
		}
	}
}