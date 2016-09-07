using System;

namespace Giacomelli.JumpStart
{
	/// <summary>
	/// A verbose log implementation to jumpstart.
	/// </summary>
	public class VerboseLog : ILog
	{
		/// <summary>
		/// Write a debug level message to log.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public void Debug(string message, params object[] args)
		{
			Console.WriteLine(message, args);
		}
	}
}