using System;
using System.Collections.Generic;
using System.Text;
using DotNetCourse.Day2.Car.Logging;

namespace DotNetCourse.Day2.Car.Car
{
	interface IVehicle
	{
		void SetLogger(ILogging logging);

		void Log(String message);

	}
}