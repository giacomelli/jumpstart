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
			Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

			if (Directory.Exists("TestsResults"))
			{
				Directory.Delete("TestsResults", true);
			}
		}

		[Test]
		public void Build_SimpleTemplate_Built()
		{
			var templateNamespace = "Sample.SimpleTemplate";
			Build(templateNamespace);

			AssertFile("MyClass.cs", "namespace My.Test", templateNamespace);
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
		public void Build_ClassLibraryTemplateWithPartialName_Built()
		{
			if (Directory.Exists("Sample.ClassLibraryTemplate.New"))
			{
				Directory.Delete("Sample.ClassLibraryTemplate.New", true);
			}

			var templateNamespace = "Sample.ClassLibraryTemplate";
			Build(templateNamespace, "Sample.ClassLibraryTemplate.New", "Sample.ClassLibraryTemplate.New");

			AssertFile("Sample.ClassLibraryTemplate.New.sln", "Sample.ClassLibraryTemplate.New", "N/A", "Sample.ClassLibraryTemplate.New");
			AssertFile("Sample.ClassLibraryTemplate.New/Sample.ClassLibraryTemplate.New.csproj", "Sample.ClassLibraryTemplate.New", "N/A", "Sample.ClassLibraryTemplate.New");
			AssertFile("Sample.ClassLibraryTemplate.New/MyClass.cs", "namespace Sample.ClassLibraryTemplate.New", "N/A", "Sample.ClassLibraryTemplate.New");
			AssertFile("Sample.ClassLibraryTemplate.New/Properties/AssemblyInfo.cs", "[assembly: AssemblyTitle(\"Sample.ClassLibraryTemplate.New\")]", "N/A", "Sample.ClassLibraryTemplate.New");
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

		private void Build(string templateNamespace, string n = "My.Test", string f = "TestsResults")
		{
			var resourcesFolder = VSProjectHelper.GetProjectFolderPath("Giacomelli.JumpStart.FunctionalTests");
			resourcesFolder = Path.Combine(resourcesFolder, "Resources");


			var options = JumpStartOptions.Create(
				"-n", n,
				"-f", f,
				"-tf", Path.Combine(resourcesFolder, templateNamespace),
				"-tn", templateNamespace);

			var log = new DiagnosticVerbosityLog();
			var target = new Jumper(options, log);
			target.Jump();
		}

		private static void AssertFile(string filePath, string expectedFileContent, string notExpectedFileContent, string rootFolder = "TestsResults")
		{
			var fileName = Path.Combine(rootFolder, filePath);
			TestSharp.FileAssert.ContainsContent(expectedFileContent, fileName);
			Assert.IsFalse(TestSharp.FileHelper.ContainsContent(fileName, notExpectedFileContent));
		}
	}
}

