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

		/// <summary>
		/// Write an information message to jumpstart log.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		void Info(string message, params object[] args);

		/// <summary>
		/// Write a warning message to jumpstart log.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		void Warn(string message, params object[] args);

		/// <summary>
		/// Write an error message to jumpstart log.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		void Error(string message, params object[] args);
	}
}