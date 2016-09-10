using System;

namespace Giacomelli.JumpStart
{
	/// <summary>
	/// A diagnostic verbosity log implementation to jumpstart.
	/// </summary>
	public class DiagnosticVerbosityLog : ILog
	{
		/// <summary>
		/// Write a debug level message to log.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public virtual void Debug(string message, params object[] args)
		{
			Console.WriteLine(message, args);
		}

		/// <summary>
		/// Write an information message to jumpstart log.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public virtual void Info(string message, params object[] args)
		{
			Console.WriteLine(message, args);
		}

		/// <summary>
		/// Write a warning message to jumpstart log.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public virtual void Warn(string message, params object[] args)
		{
			Console.WriteLine(message, args);
		}

		/// <summary>
		/// Write an error message to jumpstart log.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public virtual void Error(string message, params object[] args)
		{
			Console.WriteLine(message, args);
		}
	}
}