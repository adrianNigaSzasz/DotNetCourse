using System;
using System.Collections.Generic;
using System.Text;
using DotNetCourse.Day2.Car.Logging;
using DotNetCourse.Day2.Car.Car;

namespace DotNetCourse.Day2.Car.Producer
{
	interface IProducer
	{
		IVehicle Build();

		int GetBuildTime();

		bool FinishedBuild();
		void SetLogger(ILogging logging);

		void Log(String message);

	}
}
