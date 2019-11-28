using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCourse.Day2.Car.Logging
{
	class Console : ILogging
	{
		public void Log(String Message)
		{
			System.Console.WriteLine(Message);
		}
	}
}
