using System;
using System.IO;
using HelperSharp;
using NUnit.Framework;
using TestSharp;

namespace Giacomelli.JumpStart.FunctionalTests
{
	[TestFixture]
	public class ProgramTest
	{
		private string s_exePath;
		private string s_sampleProjectFolder;

		[SetUp]
		public void InitializeTest()
		{
			Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

			if (Directory.Exists("Test1"))
			{
				Directory.Delete("Test1", true);
			}

			s_sampleProjectFolder = VSProjectHelper.GetProjectFolderPath("Giacomelli.JumpStart.FunctionalTests");
			s_sampleProjectFolder = Path.Combine(s_sampleProjectFolder, "Resources", "Sample.ClassLibraryTemplate");

#if DEBUG
			s_exePath = Path.Combine(VSProjectHelper.GetProjectFolderPath("Giacomelli.JumpStart"), "bin/Debug/jumpstart.exe");
#else
			s_exePath = Path.Combine(VSProjectHelper.GetProjectFolderPath("Giacomelli.JumpStart"), "bin/Release/jumpstart.exe");
#endif
		}

		[Test]
		public void Run_NoArgs_Help()
		{
			var output = ProcessHelper.Run(s_exePath);

			Assert.IsNotNull(output);
			StringAssert.Contains("help", output);
		}

		[Test]
		public void Run_Args_Done()
		{
			var output = ProcessHelper.Run(s_exePath, "-n Test1 -tf ..");

			Assert.IsNotNull(output);
			StringAssert.Contains("done.", output);
		}

		[Test]
		public void Run_VerbosityQuit_Done()
		{
			var output = ProcessHelper.Run(s_exePath, "-n Test1 -tf .. -v quiet");

			Assert.IsNotNull(output);
			Assert.AreEqual(0, output.Length);
		}

		[Test]
		public void Run_VerbosityNormal_Done()
		{
			var output = ProcessHelper.Run(s_exePath, "-n Test1 -tf .. -v normal");

			Assert.IsNotNull(output);
			StringAssert.Contains("jumpstart v.", output);
			StringAssert.Contains("by Diego Giacomelli ", output);
			StringAssert.Contains("Jump starting...", output);
			StringAssert.Contains("Jump start done.", output);
			StringAssert.DoesNotContain("updated", output);
			StringAssert.DoesNotContain("Copy", output);
		}

		[Test]
		public void Run_VerbosityDetails_Done()
		{
			var output = ProcessHelper.Run(s_exePath, "-n Test1 -tf {0} -tn Sample.ClassLibraryTemplate -v details".With(s_sampleProjectFolder));

			Assert.IsNotNull(output);
			StringAssert.Contains("jumpstart v.", output);
			StringAssert.Contains("by Diego Giacomelli ", output);
			StringAssert.Contains("Jump starting...", output);
			StringAssert.Contains("Jump start done.", output);
			StringAssert.Contains("updated", output);
			StringAssert.DoesNotContain("Copy", output);
		}

		[Test]
		public void Run_VerbosityDiagnostics_Done()
		{
			var output = ProcessHelper.Run(s_exePath, "-n Test1 -tf {0} -tn Sample.ClassLibraryTemplate -v diagnostic".With(s_sampleProjectFolder));

			Assert.IsNotNull(output);
			StringAssert.Contains("jumpstart v.", output);
			StringAssert.Contains("by Diego Giacomelli ", output);
			StringAssert.Contains("Jump starting...", output);
			StringAssert.Contains("Jump start done.", output);
			StringAssert.Contains("updated", output);
			StringAssert.Contains("Copy", output);
		}
	}
}

