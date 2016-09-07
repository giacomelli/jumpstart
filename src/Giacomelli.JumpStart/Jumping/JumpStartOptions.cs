using System;
using System.Globalization;
using System.IO;
using HelperSharp;
using Mono.Options;

namespace Giacomelli.JumpStart
{
	/// <summary>
	/// JumpStart options.
	/// </summary>
	public class JumpStartOptions
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Giacomelli.JumpStart.JumpStartOptions"/> class.
		/// </summary>
		private JumpStartOptions()
		{
			TemplateFolder = "jumpstart-template";
			TemplateNamespace = "JumpStartTemplate";
			Folder = null;
			FilesRegex = @"(\.cs|\.cshtml|\.csproj|\.sln|\.meta|\.asax|\.userprefs|\.config|\.sh|\.cmd)";
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:Giacomelli.JumpStart.JumpStartOptions"/> show help.
		/// </summary>
		/// <value><c>true</c> if show help; otherwise, <c>false</c>.</value>
		public bool ShowHelp { get; private set; }

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:Giacomelli.JumpStart.JumpStartOptions"/> is verbose.
		/// </summary>
		/// <value><c>true</c> if verbose; otherwise, <c>false</c>.</value>
		public bool Verbose { get; private set; }

		/// <summary>
		/// Gets the help text.
		/// </summary>
		/// <value>The help text.</value>
		public string HelpText { get; private set; }

		/// <summary>
		/// Gets the template namespace.
		/// </summary>
		/// <value>The template namespace.</value>
		public string TemplateNamespace { get; private set; }

		/// <summary>
		/// Gets the namespace.
		/// </summary>
		/// <value>The namespace.</value>
		public string Namespace { get; private set; }

		/// <summary>
		/// Gets the template folder.
		/// </summary>
		/// <value>The template folder.</value>
		public string TemplateFolder { get; private set; }

		/// <summary>
		/// Gets the folder.
		/// </summary>
		/// <value>The folder.</value>
		public string Folder { get; private set; }

		/// <summary>
		/// Gets the files regex.
		/// </summary>
		/// <value>The files regex.</value>
		public string FilesRegex { get; private set; }

		/// <summary>
		/// Create a TaskManageOptions from arguments.
		/// </summary>
		/// <param name="args">The arguments.</param>
		public static JumpStartOptions Create(params string[] args)
		{
			var options = new JumpStartOptions();
			var optionsSet = BuildOptions(options);
			options.ParseArguments(optionsSet, args);

			if (String.IsNullOrEmpty(options.Folder))
			{
				options.Folder = options.Namespace;
			}

			return options;
		}

		private static OptionSet BuildOptions(JumpStartOptions options)
		{
			return new OptionSet()
			{
				"Usage: ",
				" jumpstart -n <namespace>",
				string.Empty,
				"Options:",
				{
					"tf|template-folder=",
					"The relative path folder where your template solution is located. Optional. Default: {0}"
					.With(options.TemplateFolder),
					tf => options.TemplateFolder = tf
				},
				{
					"tn|template-namespace=",
					"The template root namespace in all projects. Optional. Default: {0}"
					.With(options.TemplateNamespace),
					tn => options.TemplateNamespace = tn
				},
				{
					"f|folder=",
					"The relative path to folder where the jumpstart will write the resulted project. Optional.",
					f => options.Folder = f
				},
				{
					"n|namespace=",
					"The new root namespace to all projects. Required.",
					n => options.Namespace = n
				},
				{
					"fr|files-regex=",
					"The files regex. Optional. Default: {0}"
					.With(options.FilesRegex),
					fp => options.FilesRegex = fp
				},
				{
					"v|verbose", "verbose log. Default: false", v => options.Verbose = v != null
				},
				{
					"h|help", "show this message and exit", h => options.ShowHelp = h != null
				},

				string.Empty,
				      string.Empty,
				"Samples:",
				"jumpstart -n My.Great.Solution",
				string.Empty
			};
		}

		private void ParseArguments(OptionSet optionsSet, string[] args)
		{
			optionsSet.Parse(args);

			if (String.IsNullOrEmpty(Namespace))
			{
				ShowHelp = true;
			}

			if (ShowHelp)
			{
				using (var writer = new StringWriter(CultureInfo.InvariantCulture))
				{
					optionsSet.WriteOptionDescriptions(writer);
					HelpText = writer.ToString();
				}
			}
		}
	}
}
