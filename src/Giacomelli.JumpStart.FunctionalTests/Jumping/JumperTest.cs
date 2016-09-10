using NUnit.Framework;
using System;
using System.IO;
using TestSharp;

namespace Giacomelli.JumpStart.FunctionalTests
{
	[TestFixture]
	public class JumperTest
	{
		[SetUp]
		public void InitializeTest()
		{
			if (Directory.Exists("TestsResults"))
			{
				Directory.Delete("TestsResults", true);
			}
		}

		[Test]
		public void Build_ClassLibraryTemplate_Built()
		{
			var templateNamespace = "Sample.ClassLibraryTemplate";
			Build(templateNamespace);

			AssertFile("My.Test.sln", "My.Test", templateNamespace);
			AssertFile("My.Test/My.Test.csproj", "My.Test", templateNamespace);
			AssertFile("My.Test/MyClass.cs", "namespace My.Test", templateNamespace);
			AssertFile("My.Test/Properties/AssemblyInfo.cs", "[assembly: AssemblyTitle(\"My.Test\")]", templateNamespace);
		}

		[Test]
		public void Build_ComplexTemplate_Built()
		{
			var templateNamespace = "Sample.ComplexTemplate";
			Build(templateNamespace);

			AssertFile("My.Test.sln", "My.Test", templateNamespace);

			// Framework.
			AssertFile("My.Test.Infrastructure.Framework/My.Test.Infrastructure.Framework.csproj", "My.Test", templateNamespace);
			AssertFile("My.Test.Infrastructure.Framework/MyFrameworkClass.cs", "namespace My.Test", templateNamespace);
			AssertFile("My.Test.Infrastructure.Framework/Properties/AssemblyInfo.cs", "[assembly: AssemblyTitle(\"My.Test.Infrastructure.Framework\")]", templateNamespace);

			// Domain.
			AssertFile("My.Test.Domain/My.Test.Domain.csproj", "My.Test", templateNamespace);
			AssertFile("My.Test.Domain/MyDomainClass.cs", "namespace My.Test", templateNamespace);
			AssertFile("My.Test.Domain/Properties/AssemblyInfo.cs", "[assembly: AssemblyTitle(\"My.Test.Domain\")]", templateNamespace);

			// ConsoleApp.
			AssertFile("My.Test.ConsoleApp/My.Test.ConsoleApp.csproj", "My.Test", templateNamespace);
			AssertFile("My.Test.ConsoleApp/Program.cs", "namespace My.Test", templateNamespace);
			AssertFile("My.Test.ConsoleApp/Properties/AssemblyInfo.cs", "[assembly: AssemblyTitle(\"My.Test.ConsoleApp\")]", templateNamespace);
			AssertFile("My.Test.ConsoleApp/Program.cs", "\"my.test\"", templateNamespace);
		}

		[Test]
		public void Build_Unity3dTemplate_Built()
		{
			var templateNamespace = "Sample.Unity3dTemplate";
			Build(templateNamespace);

			AssertFile("Unity/Assets/Prefabs/SamplePrefab.prefab.meta", "my.test", templateNamespace);
		}

		[Test]
		public void Build_WebAppTemplate_Built()
		{
			var templateNamespace = "Sample.WebAppTemplate";
			Build(templateNamespace);

			AssertFile("My.Test.sln", "My.Test", templateNamespace);
			AssertFile("My.Test/My.Test.csproj", "My.Test", templateNamespace);
			AssertFile("My.Test/Global.asax", "My.Test", templateNamespace);
			AssertFile("My.Test/Global.asax.cs", "My.Test", templateNamespace);
			AssertFile("My.Test/web.config", "My.Test", templateNamespace);
			AssertFile("My.Test.userprefs", "My.Test", templateNamespace);
		}

		private void Build(string templateNamespace)
		{
			var resourcesFolder = VSProjectHelper.GetProjectFolderPath("Giacomelli.JumpStart.FunctionalTests");
			resourcesFolder = Path.Combine(resourcesFolder, "Resources");


			var options = JumpStartOptions.Create(
				"-n", "My.Test",
				"-f", "TestsResults",
				"-tf", Path.Combine(resourcesFolder, templateNamespace),
				"-tn", templateNamespace);

			var target = new Jumper(options, new QuietVerbosityLog());
			target.Jump();
		}

		private static void AssertFile(string filePath, string expectedFileContent, string notExpectedFileContent)
		{
			var fileName = Path.Combine("TestsResults", filePath);
			TestSharp.FileAssert.ContainsContent(expectedFileContent, fileName);
			Assert.IsFalse(TestSharp.FileHelper.ContainsContent(fileName, notExpectedFileContent));
		}
	}
}

