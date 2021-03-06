using System;

namespace Giacomelli.JumpStart
{
	/// <summary>
	/// A normal verbosity log implementation to jumpstart.
	/// </summary>
	public sealed class NormalVerbosityLog : ILog, IProgress
	{
		private float m_totalFiles;


		/// <summary>
		/// Write a debug level message to log.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public void Debug(string message, params object[] args)
		{
		}

		/// <summary>
		/// Write an information message to jumpstart log.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public void Info(string message, params object[] args)
		{
		}

		/// <summary>
		/// Write a warning message to jumpstart log.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public void Warn(string message, params object[] args)
		{
			Console.WriteLine(message, args);
		}

		void IProgress.NotifyBegin(int totalFiles)
		{
			m_totalFiles = totalFiles; 
		}

		void IProgress.NotifyFile(int fileNumber, string fileName)
		{
			Console.Write("\rProgress: {0:p0}", fileNumber / m_totalFiles);
		}

		void IProgress.NotifyEnd()
		{
			Console.WriteLine(String.Empty);
		}
	}
}