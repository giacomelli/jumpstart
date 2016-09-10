using System;
using System.IO;
using System.Text.RegularExpressions;
using HelperSharp;

namespace Giacomelli.JumpStart
{
	/// <summary>
	/// Performs the jump start.
	/// Here is where the real job of jumpstart happens.
	/// </summary>
	public class Jumper
	{
		#region Fields
		private JumpStartOptions m_options;
		private IProgress m_progress;
		private ILog m_log;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Giacomelli.JumpStart.Jumper"/> class.
		/// </summary>
		/// <param name="options">Options.</param>
		/// <param name="log">Log.</param>
		public Jumper(JumpStartOptions options, ILog log)
		{
			m_options = options;
			m_progress = (log as IProgress) ?? new EmptyProgress();
			m_log = log;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Performs the jump start.
		/// </summary>
		public void Jump()
		{
			var currentPath = Environment.CurrentDirectory;
			var templateFolder = Path.Combine(currentPath, m_options.TemplateFolder);

			if (!Directory.Exists(templateFolder))
			{
				throw new InvalidOperationException(
					"The folder with the template solution does not exists: {0}".With(templateFolder));
			}

			var folder = Path.Combine(currentPath, m_options.Folder);

			CopyDir(
				templateFolder,
				folder,
				(filePath, content) =>
				{
					// TODO: Move this to a file handlers structure using a chain of responsability.
					content = content.Replace(m_options.TemplateNamespace.ToLowerInvariant(), m_options.Namespace.ToLowerInvariant());
					content = content.Replace(m_options.TemplateNamespace.ToUpperInvariant(), m_options.Namespace.ToUpperInvariant());

					return content.Replace(m_options.TemplateNamespace, m_options.Namespace);
				});
		}

		private void CopyDir(string src, string dest, Func<string, string, string> transformFileContent)
		{
			// Get source dirs and files.
			var dirs = Directory.GetDirectories(src, "*", SearchOption.AllDirectories);
			var files = Directory.GetFiles(src, "*.*", SearchOption.AllDirectories);
			m_progress.NotifyBegin(files.Length);

			// Create the destination dirs.
			Directory.CreateDirectory(dest);

			foreach (string path in dirs)
			{
				var newPath = ToNewPath(path, src, dest);
				m_log.Debug("Creating dir '{0}'", newPath);
				Directory.CreateDirectory(ToNewPath(path, src, dest));
			}

			// Only files that respect this regex will be content transformed.
			var filePatternRegex = new Regex("({0})".With(m_options.FilesRegex), RegexOptions.Compiled | RegexOptions.IgnoreCase);

			// Copy each source file to destination.
			for (int i = 0; i < files.Length; i++)
			{
				var file = files[i];
				var newPath = ToNewPath(file, src, dest);
				m_log.Debug("Copying file '{0}'", newPath);
				File.Copy(file, newPath, true);

				// If file matchs the regex, read its content and replace the template
				// namespace to new namespace.
				if (filePatternRegex.IsMatch(newPath))
				{
					var content = File.ReadAllText(newPath);
					var newContent = transformFileContent(newPath, content);

					if (!content.Equals(newContent, StringComparison.Ordinal))
					{
						m_log.Info("{0} updated.", newPath);
						File.WriteAllText(newPath, newContent);
					}
				}

				m_progress.NotifyFile(i + 1, file);
			}

			m_progress.NotifyEnd();
		}

		private string ToNewPath(string path, string src, string dest)
		{
			var newPath = path.Replace(src, dest);

			return newPath.Replace(m_options.TemplateNamespace, m_options.Namespace);
		}
		#endregion

	}
}