namespace Giacomelli.JumpStart
{
	/// <summary>
	/// Empty progress.
	/// </summary>
	public class EmptyProgress : IProgress
	{
		/// <summary>
		/// Do nothing.
		/// </summary>
		/// <param name="totalFiles">Total files.</param>
		public void NotifyBegin(int totalFiles)
		{
		}

		/// <summary>
		/// Do nothing.
		/// </summary>
		public void NotifyEnd()
		{
		}

		/// <summary>
		/// Do nothing.
		/// </summary>
		/// <param name="fileNumber">File number.</param>
		/// <param name="fileName">File name.</param>
		public void NotifyFile(int fileNumber, string fileName)
		{
		}
	}
}