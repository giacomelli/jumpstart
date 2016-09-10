using System;

namespace Giacomelli.JumpStart
{
	/// <summary>
	/// Program main class.
	/// </summary>
	public static class MainClass
	{
		private static ILog s_log;

		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main(string[] args)
		{
			try
			{
				var options = JumpStartOptions.Create(args);
				s_log = CreateLog(options);
				                  
				s_log.Warn ("jumpstart v.{0}", typeof(MainClass).Assembly.GetName().Version);
				s_log.Warn("by Diego Giacomelli (https://twitter.com/ogiacomelli)\n");

				if (options.ShowHelp)
				{
					s_log.Warn(options.HelpText);
				}
				else
				{
					s_log.Warn("Jump starting...");
					var prebuilder = new Jumper(options, s_log);
					prebuilder.Jump();
					s_log.Warn("Jump start done.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}     
		}

		private static ILog CreateLog(JumpStartOptions options)
		{
			switch (options.Verbosity)
			{
				case Verbosity.Quiet:
					return new QuietVerbosityLog();
					
				case Verbosity.Details:
					return new DetailsVerbosityLog();
					
				case Verbosity.Diagnostic:
					return new DiagnosticVerbosityLog();
					
				default:
					return new NormalVerbosityLog();
			}
		}
	}
}