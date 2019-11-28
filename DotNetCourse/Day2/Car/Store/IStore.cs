using System;
using System.Collections.Generic;
using System.Text;
using DotNetCourse.Day2.Car.Logging;
using DotNetCourse.Day2.Car.Car;
using DotNetCourse.Day2.Car.Order;


namespace DotNetCourse.Day2.Car.Store
{
	interface IStore
	{
		void SetLogger(ILogging logging);

		void Log(String message);

		void Order(IOrder Order);

		IVehicle Deliver();

		public int Estimate();

		bool Wait();
	}
}
