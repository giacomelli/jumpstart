using System;
using System.IO;
using NUnit.Framework;

namespace Giacomelli.JumpStart.FunctionalTests
{
	[TestFixture]
	public class WebZipTemplateFolderHandlerTest
	{
		[SetUp]
		public void InitializeTest()
		{
			Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

			if (Directory.Exists("jumpstart-template"))
			{
				Directory.Delete("jumpstart-template", true);
			}
		}

		[Test]
		public void Process_NonHttpZipFile_PassBy()
		{
			var target = new WebZipTemplateFolderHandler(new NormalVerbosityLog());
			var actual = target.Process("local-template-folder");
			Assert.AreEqual("local-template-folder", actual);
		}

		[Test]
		public void Process_HttpButNotZip_PassBy()
		{
			var target = new WebZipTemplateFolderHandler(new NormalVerbosityLog());
			var actual = target.Process("http://web-template-folder.com");
			Assert.AreEqual("http://web-template-folder.com", actual);
		}

		[Test]
		public void Process_HttpZip_DownloadAndUnzip()
		{
			var target = new WebZipTemplateFolderHandler(new NormalVerbosityLog());
			var actual = target.Process("https://github.com/xamarin/sport/archive/master.zip");
			Assert.AreEqual("jumpstart-template", actual);
			FileAssert.Exists("jumpstart-template/README.md");
			FileAssert.Exists("jumpstart-template/Sport.Mobile.sln");
		}
	}
}