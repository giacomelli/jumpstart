using NUnit.Framework;
using System;
namespace Giacomelli.JumpStart.UnitTests
{
	[TestFixture]
	public class JumpStartOptionsTest
	{
		[Test]
		public void Create_NoArgs_Default()
		{
			var target = JumpStartOptions.Create(new string[0]);
			Assert.IsNotNull(target);
			Assert.AreEqual(null, target.Namespace);
			Assert.AreEqual("JumpStartTemplate", target.TemplateNamespace);
			Assert.AreEqual("jumpstart-template", target.TemplateFolder);
			Assert.IsNull(target.Folder);
			Assert.IsFalse(String.IsNullOrEmpty(target.HelpText));
			Assert.IsTrue(target.ShowHelp);
		}

		[Test]
		public void Create_InvalidArgs_ShowHelp()
		{
			var target = JumpStartOptions.Create(new string[] { "-test", "invalid" });
			Assert.IsNotNull(target);
			Assert.AreEqual(null, target.Namespace);
			Assert.IsFalse(String.IsNullOrEmpty(target.HelpText));
			Assert.IsTrue(target.ShowHelp);
		}

		[Test]
		public void Create_AllArgs_Properties()
		{
			var actual = JumpStartOptions.Create(
				"-n", "My.Great.Solution",
				"-f", "MyGreatFolder",
				"-tn", "My.Template.Solution",
				"-tf", "MyTemplateFolder"
			);

			Assert.IsNotNull(actual);
			Assert.AreEqual("My.Great.Solution", actual.Namespace);
			Assert.AreEqual("MyGreatFolder", actual.Folder);
			Assert.AreEqual("My.Template.Solution", actual.TemplateNamespace);
			Assert.AreEqual("MyTemplateFolder", actual.TemplateFolder);
			Assert.IsTrue(String.IsNullOrEmpty(actual.HelpText));
			Assert.IsFalse(actual.ShowHelp);
		}

		[Test]
		public void Create_OnlyNamespaceArg_Conventions()
		{
			var actual = JumpStartOptions.Create(
				"-n", "My.Great.Solution"
			);

			Assert.IsNotNull(actual);
			Assert.AreEqual("My.Great.Solution", actual.Namespace);
			Assert.AreEqual("My.Great.Solution", actual.Folder);
			Assert.AreEqual("JumpStartTemplate", actual.TemplateNamespace);
			Assert.AreEqual("jumpstart-template", actual.TemplateFolder);
			Assert.IsTrue(String.IsNullOrEmpty(actual.HelpText));
			Assert.IsFalse(actual.ShowHelp);
		}

		[Test]
		public void Create_AllNotShortcutArgs_Properties()
		{
			var actual = JumpStartOptions.Create(new string[] { 
				"-namespace", "My.Great.Solution", 
				"-folder", "MyGreatFolder",
				"-template-namespace", "My.Template.Solution" ,
				"-template-folder", "MyTemplateFolder",
			});

			Assert.IsNotNull(actual);
			Assert.AreEqual("My.Great.Solution", actual.Namespace);
			Assert.AreEqual("MyGreatFolder", actual.Folder);
			Assert.AreEqual("My.Template.Solution", actual.TemplateNamespace);
			Assert.AreEqual("MyTemplateFolder", actual.TemplateFolder);
			Assert.IsTrue(String.IsNullOrEmpty(actual.HelpText));
			Assert.IsFalse(actual.ShowHelp);
		}
	}
}