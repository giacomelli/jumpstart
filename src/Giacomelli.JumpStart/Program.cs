using System;

namespace Giacomelli.JumpStart
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Show("jumpstart v.{0}", typeof(MainClass).Assembly.GetName().Version);
			Show("by Diego Giacomelli (https://twitter.com/ogiacomelli)\n");

			try
			{
				var options = JumpStartOptions.Create(args);

				if (options.ShowHelp)
				{
					Show(options.HelpText);
				}
				else
				{
					Show("Jump starting...");
					var prebuilder = new Jumper(options, CreateLog(options));
					prebuilder.Jump();
					Show("Jump start done.");
				}
			}
			catch (Exception ex)
			{
				Show(ex.Message);
			}     
		}

		private static ILog CreateLog(JumpStartOptions options)
		{
			if (options.Verbose)
			{
				return new VerboseLog();
			}

			return new NoVerboseLog();
		}

		private static void Show(string message, params object[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine(message);
			}
			else
			{
				Console.WriteLine(message, args);
			}
		}
	}
}