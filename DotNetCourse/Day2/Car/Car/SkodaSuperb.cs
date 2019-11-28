using System;
using System.Collections.Generic;
using System.Text;
using DotNetCourse.Day2.Car.Logging;

namespace DotNetCourse.Day2.Car.Car
{
	class SkodaSuperb : IVehicle
	{
		protected ILogging Logger;
		public void SetLogger(ILogging logging)
		{
			this.Logger = logging;
		}

		public void Log(string message)
		{
			this.Logger.Log(message);
		}

		protected int price = 14000;

		public int Price
		{
			get { return this.price; }
			set { this.price = value; }
		}

		public int Model
		{
			get; set;
		}

	}
}
