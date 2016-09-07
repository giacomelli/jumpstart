using System;

namespace Giacomelli.JumpStart
{
	public class VerboseLog : ILog
	{
		public void Debug(string message, params object[] args)
		{
			Console.WriteLine(message, args);
		}
	}
}