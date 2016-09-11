namespace Giacomelli.JumpStart
{
	/// <summary>
	/// Defines an interface to a template folder handler.
	/// </summary>
	public interface ITemplateFolderHandler
	{
		/// <summary>
		/// Process the specified template folder path and change it if necessary.
		/// </summary>
		/// <param name="templateFolderPath">Template folder path.</param>
		string Process(string templateFolderPath);
	}
}