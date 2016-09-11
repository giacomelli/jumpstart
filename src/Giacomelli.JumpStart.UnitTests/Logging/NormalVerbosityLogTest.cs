using System;
using System.IO;
using NUnit.Framework;

namespace Giacomelli.JumpStart.UnitTests
{
	[TestFixture]
	public class NormalVerbosityLogTest
	{
		[Test]
		public void Debug_Args_Nothing()
		{
			TestHelper.AssertConsoleOutput(() =>
			{
				var target = new NormalVerbosityLog();
				target.Debug("Test {0}", 1);
			},
			String.Empty);
		}

		[Test]
		public void Info_Args_Nothing()
		{
			TestHelper.AssertConsoleOutput(() =>
			{
				var target = new NormalVerbosityLog();
				target.Info("Test {0}", 1);
			},
			String.Empty);
		}

		[Test]
		public void Warn_Args_Nothing()
		{
			TestHelper.AssertConsoleOutput(() =>
			{
				var target = new NormalVerbosityLog();
				target.Warn("Test {0}", 1);
			},
			"Test 1\n");
		}
	}
}