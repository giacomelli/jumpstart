using System;
using Sample.ComplexTemplate.Domain;
using Sample.ComplexTemplate.Infrastructure.Framework;

namespace Sample.ComplexTemplate.ConsoleApp
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("sample.complextemplate");
			Console.WriteLine(typeof(MyFrameworkClass).Assembly.FullName);
			Console.WriteLine(typeof(MyDomainClass).Assembly.FullName);
		}
	}
}
