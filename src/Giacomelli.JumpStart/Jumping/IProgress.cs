using System;

namespace Giacomelli.JumpStart
{
	/// <summary>
	/// Define a jumpstart progress interface.
	/// </summary>
	public interface IProgress
	{
		/// <summary>
		/// Notify the start of jumpstart process.
		/// </summary>
		/// <param name="totalFiles">Total files.</param>
		void NotifyBegin(int totalFiles);

		/// <summary>
		/// Notifiy a file jump.
		/// </summary>
		/// <param name="fileNumber">File number.</param>
		/// <param name="fileName">File name.</param>
		void NotifyFile(int fileNumber, string fileName);

		/// <summary>
		/// Notify the end of the jumpstart process.
		/// </summary>
		void NotifyEnd();
	}
}