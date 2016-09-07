using System;

namespace Giacomelli.JumpStart
{
	public interface ILog
	{
		void Debug(string message, params object[] args);
	}
}