using System;
using System.Collections.Generic;
using System.Text;
using DotNetCourse.Day2.Car.Logging;
using DotNetCourse.Day2.Car.Car;

namespace DotNetCourse.Day2.Car.Producer
{
	class Skoda : IProducer
	{
		protected ILogging Logger;

		public IVehicle Build()
		{
			return new SkodaSuperb();
		}

		public void SetLogger(ILogging logging)
		{
			this.Logger = logging;
		}

		public void Log(string message)
		{
			this.Logger.Log(message);
		}

		public bool FinishedBuild()
		{
			for (var i = 0; i < 100000; i++)
			{

			}
				
			return true;
		}

		public int GetBuildTime()
		{
			return 3;
		}



	}
}
