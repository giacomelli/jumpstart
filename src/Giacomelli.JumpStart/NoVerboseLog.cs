using System;
namespace Giacomelli.JumpStart
{
	public class NoVerboseLog : ILog
	{
		public void Debug(string message, params object[] args)
		{
		}
	}
}

