using System;
using System.Collections.Generic;
using System.Text;

using DotNetCourse.Day2.Car.Car;
using DotNetCourse.Day2.Car.Logging;
using DotNetCourse.Day2.Car.Order;
using DotNetCourse.Day2.Car.Store;

namespace DotNetCourse.Day2.Car.Customer
{
	class Alex : AbstractCustomer, IPerson
	{

		protected ILogging Logger;

		public Alex(double BankAccount, ILogging Logger)
		{
			this.BankAccount = BankAccount;
			this.SetLogger(Logger);

		}

		public void WalkInto(IStore Store)
		{
			throw new NotImplementedException();
		}

		public void Buy(IVehicle Car)
		{
			throw new NotImplementedException();
		}

		public void Cancel(IOrder Order)
		{
			throw new NotImplementedException();
		}

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
