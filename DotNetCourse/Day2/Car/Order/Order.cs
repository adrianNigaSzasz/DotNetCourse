using System;
using System.Collections.Generic;
using System.Text;
using DotNetCourse.Day2.Car.Logging;
using DotNetCourse.Day2.Car.Customer;

namespace DotNetCourse.Day2.Car.Order
{
	class Order : IOrder
	{


		protected ILogging Logger;

		protected IPerson Customer;
		public void SetLogger(ILogging logging)
		{
			this.Logger = logging;
		}


		public Order(IPerson Customer, ILogging Logger)
		{
			this.Customer = Customer;
			this.SetLogger(Logger);

		}

		public void Log(string message)
		{
			this.Logger.Log(message);
		}

		public void Cancel()
		{
			throw new NotImplementedException();
		}

		public void Deliver()
		{
			throw new NotImplementedException();
		}

		public void Process()
		{
			throw new NotImplementedException();
		}

	}
}
