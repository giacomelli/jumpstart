using System;

namespace Giacomelli.JumpStart
{
	/// <summary>
	/// A quiet verbosity log implementation to jumpstart.
	/// </summary>
	public class QuietVerbosityLog : ILog
	{
		/// <summary>
		/// Write a debug level message to log.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public virtual void Debug(string message, params object[] args)
		{
		}

		/// <summary>
		/// Write an information message to jumpstart log.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public virtual void Info(string message, params object[] args)
		{
		}

		/// <summary>
		/// Write a warning message to jumpstart log.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public virtual void Warn(string message, params object[] args)
		{
		}
	}
}