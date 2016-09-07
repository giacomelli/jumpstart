using System;

namespace Giacomelli.JumpStart
{
	/// <summary>
	/// Defines the interface to a jumpstart log.
	/// </summary>
	public interface ILog
	{
		/// <summary>
		/// Write a debug message to jumpstart log.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		void Debug(string message, params object[] args);
	}
}