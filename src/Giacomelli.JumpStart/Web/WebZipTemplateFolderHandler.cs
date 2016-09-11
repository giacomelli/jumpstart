using System;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace Giacomelli.JumpStart
{
	/// <summary>
	/// Web zip template folder handler that download web zip files like https://github.com/giacomelli/jumpstart/archive/master.zip,
	/// unzip it to a local folder called jumpstart-template.
	/// </summary>
	public class WebZipTemplateFolderHandler : ITemplateFolderHandler
	{
		#region Fields
		private ILog m_log;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Giacomelli.JumpStart.WebZipTemplateFolderHandler"/> class.
		/// </summary>
		/// <param name="log">Log.</param>
		public WebZipTemplateFolderHandler(ILog log)
		{
			m_log = log;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Process the specified template folder path.
		/// </summary>
		/// <param name="templateFolderPath">Template folder path.</param>
		public string Process(string templateFolderPath)
		{
			if (IsUrl(templateFolderPath) 
			    && Path.GetExtension(templateFolderPath).Equals(".zip", StringComparison.OrdinalIgnoreCase))
			{
				var sourceZipFile = "jumpstart-template.zip";
				var destinationTempFolder = "jumpstart-template-temp";
				var destinationFolder = "jumpstart-template";

				ClearDestinations(sourceZipFile, destinationFolder, destinationTempFolder);

				using (var client = new Downloader())
				{
					m_log.Warn("Downloading {0}...", templateFolderPath);
					client.DownloadFile(templateFolderPath, sourceZipFile);
					ZipFile.ExtractToDirectory(sourceZipFile, destinationTempFolder);

					var subfolders = Directory.GetDirectories(destinationTempFolder);

					// The entire zip content was extract to a sub-folder?
					if (subfolders.Length == 1 && Directory.GetFiles(destinationTempFolder).Length == 0)
					{
						// Move the subfolder content to root folder.
						Directory.Move(subfolders[0], destinationFolder);
					}
					else 
					{
						Directory.Move(destinationTempFolder, destinationFolder);
					}
				}

				Directory.Delete(destinationTempFolder);
				templateFolderPath = destinationFolder;
			}

			return templateFolderPath;
		}

		private static void ClearDestinations(string sourceZipFile, string destinationFolder, string destinationTempFolder)
		{
			if (File.Exists(sourceZipFile))
			{
				File.Delete(sourceZipFile);
			}

			if (File.Exists(destinationFolder))
			{
				File.Delete(destinationFolder);
			}

			if (File.Exists(destinationTempFolder))
			{
				File.Delete(destinationTempFolder);
			}
		}

		/// <summary>
		/// http://stackoverflow.com/a/7581824/956886
		/// </summary>
		private static bool IsUrl(string templateFolderPath)
		{
			Uri uriResult;

			return Uri.TryCreate(templateFolderPath, UriKind.Absolute, out uriResult)
					&& (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
		}
		#endregion
	}
}