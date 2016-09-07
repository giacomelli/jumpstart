using System;
namespace Giacomelli.JumpStart
{
	/// <summary>
	/// A non-verbose log implementation to jumpstart.
	/// </summary>
	public class NoVerboseLog : ILog
	{
		/// <summary>
		/// Do not write anything to log message.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public void Debug(string message, params object[] args)
		{
		}
	}
}