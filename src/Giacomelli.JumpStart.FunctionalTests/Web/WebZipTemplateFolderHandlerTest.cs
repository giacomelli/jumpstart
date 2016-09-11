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

		[Test]
		public void Process_HttpZipNotSubFolder_DownloadAndUnzip()
		{
			var target = new WebZipTemplateFolderHandler(new NormalVerbosityLog());
			var actual = target.Process("http://diegogiacomelli.com.br/labs/testing-js-dos/sample.zip");
			Assert.AreEqual("jumpstart-template", actual);
			FileAssert.Exists("jumpstart-template/nibble.html");
		}

		[Test]
		public void Process_DestinationFoldersAlreadExists_DeleteDestinationsAndDownloadAndUnzip()
		{
			var sourceZipFile = "jumpstart-template.zip";
			var destinationTempFolder = "jumpstart-template-temp";
			var destinationFolder = "jumpstart-template";

			File.WriteAllText(sourceZipFile, "test");
			Directory.CreateDirectory(destinationTempFolder);
			Directory.CreateDirectory(destinationFolder);
			
			var target = new WebZipTemplateFolderHandler(new NormalVerbosityLog());
			var actual = target.Process("http://diegogiacomelli.com.br/labs/testing-js-dos/sample.zip");
			Assert.AreEqual("jumpstart-template", actual);
			FileAssert.Exists("jumpstart-template/nibble.html");
		}
	}
}