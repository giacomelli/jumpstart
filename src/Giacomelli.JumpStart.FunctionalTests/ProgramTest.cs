using System;
using System.IO;
using NUnit.Framework;
using TestSharp;

namespace Giacomelli.JumpStart.FunctionalTests
{
	[TestFixture]
	public class ProgramTest
	{
		private string exePath;

		[SetUp]
		public void InitializeTest()
		{
#if DEBUG
			exePath = Path.Combine(VSProjectHelper.GetProjectFolderPath("Giacomelli.JumpStart"), "bin/Debug/jumpstart.exe");
#else
			exePath = Path.Combine(VSProjectHelper.GetProjectFolderPath("Giacomelli.JumpStart"), "bin/Release/jumpstart.exe");
#endif
		}

		[Test]
		public void Run_NoArgs_Help()
		{
			var output = ProcessHelper.Run(exePath);

			Assert.IsNotNull(output);
			StringAssert.Contains("help", output);
		}

		[Test]
		public void Run_Args_Done()
		{
			var output = ProcessHelper.Run(exePath, "-n Test1 -tf ..");

			Assert.IsNotNull(output);
			StringAssert.Contains("done.", output);
		}
	}
}

