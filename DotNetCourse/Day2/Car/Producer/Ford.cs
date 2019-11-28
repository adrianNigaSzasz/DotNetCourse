using System;
using System.Collections.Generic;
using System.Text;
using DotNetCourse.Day2.Car.Logging;
using DotNetCourse.Day2.Car.Car;

namespace DotNetCourse.Day2.Car.Producer
{
	class Ford : IProducer
	{
		public IVehicle Build()
		{
			return new FordFocus(this.Logger);
		}

		public bool FinishedBuild()
		{

			//do some logic here
			return true;
		}

		public int GetBuildTime()
		{
			return 4;
		}

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
