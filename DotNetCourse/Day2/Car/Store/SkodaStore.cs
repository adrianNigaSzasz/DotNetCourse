using System;
using System.Collections.Generic;
using System.Text;
using DotNetCourse.Day2.Car.Car;
using DotNetCourse.Day2.Car.Producer;
using DotNetCourse.Day2.Car.Logging;

namespace DotNetCourse.Day2.Car.Store
{
	class SkodaStore : AbstractStore, IStore
	{

		protected Skoda producer;
		protected List<Order.IOrder> orders;

		public SkodaStore(String City, ILogging Logger)
		{
			this.City = City;
			this.SetLogger(Logger);
			this.producer = new Skoda();
			this.orders = new List<Order.IOrder>();
		}

		public IVehicle Deliver()
		{
			return this.producer.Build();
		}

		public int Estimate()
		{
			return this.producer.GetBuildTime();
		}

		public bool Wait()
		{
			return !producer.FinishedBuild();
		}


		public void Order(Order.IOrder Order)
		{
			this.orders.Add(Order);
			this.Logger.Log("Skoda Store Order");
		}

		public void Cancel(Order.IOrder Order)
		{
			this.orders.Remove(Order);
			this.Logger.Log("Canceled Skoda Order");
		}


	}
}
