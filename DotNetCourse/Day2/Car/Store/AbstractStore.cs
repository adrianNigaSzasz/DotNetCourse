using System;
using System.Collections.Generic;
using System.Text;
using DotNetCourse.Day2.Car.Logging;

namespace DotNetCourse.Day2.Car.Store
{
	abstract class AbstractStore
	{

		public String City { get; set; }




		protected ILogging Logger;
		public void SetLogger(ILogging logging)
		{
			this.Logger = logging;
		}

		public void Log(string message)
		{
			this.Logger.Log(message);
		}
	}
}
