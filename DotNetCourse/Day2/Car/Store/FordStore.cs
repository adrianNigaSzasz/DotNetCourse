using System;
using System.Collections.Generic;
using System.Text;
using DotNetCourse.Day2.Car.Car;
using DotNetCourse.Day2.Car.Logging;
using DotNetCourse.Day2.Car.Producer;
using DotNetCourse.Day2.Car.Order;

namespace DotNetCourse.Day2.Car.Store
{
	class FordStore : AbstractStore, IStore
	{

		protected Ford producer;

		protected List<Order.IOrder> orders;

		public FordStore(String City, ILogging logging)
		{
			this.City = City;
			this.SetLogger(logging);
			this.producer = new Ford();
			this.orders = new List<Order.IOrder>();
		}

		public IVehicle Deliver()
		{
			Ford producer = new Ford();
			return producer.Build();

			
		}

		public bool Wait()
		{
			return producer.FinishedBuild();
		}

		public int Estimate()
		{
			return this.producer.GetBuildTime();

		}

		public void Order(IOrder Order)
		{
			this.orders.Add(Order);
			this.Logger.Log("Ordered Ford Store");
		}

		public void Cancel(IOrder Order)
		{
			this.orders.Remove(Order);
			this.Logger.Log("Canceled Ford Focus Order");
		}
	}
}
