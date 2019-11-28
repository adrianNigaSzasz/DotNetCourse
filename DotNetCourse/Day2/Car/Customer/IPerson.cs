using System;
using System.Collections.Generic;
using System.Text;

using DotNetCourse.Day2.Car.Store;
using DotNetCourse.Day2.Car.Car;
using DotNetCourse.Day2.Car.Order;
using DotNetCourse.Day2.Car.Logging;

namespace DotNetCourse.Day2.Car.Customer
{
	interface IPerson
	{
		public void WalkInto(IStore Store);
		public void Buy(IVehicle Car);

		public void Cancel(IOrder Order);

		void SetLogger(ILogging logging);

		void Log(String message);
	}
}
