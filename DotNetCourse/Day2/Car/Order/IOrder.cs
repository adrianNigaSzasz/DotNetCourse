using System;
using System.Collections.Generic;
using System.Text;
using DotNetCourse.Day2.Car.Logging;

namespace DotNetCourse.Day2.Car.Order
{
	interface IOrder
	{

		public void Cancel();

		public void Process();

		public void Deliver();

		void SetLogger(ILogging logging);

		void Log(String message);
	}
}
