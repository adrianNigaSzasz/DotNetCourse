using System;
using System.Collections.Generic;
using System.Text;
using DotNetCourse.Day2.Hotel;
using DotNetCourse.Day2.Car.Car;
using DotNetCourse.Day2.Car.Customer;
using DotNetCourse.Day2.Car.Logging;
using DotNetCourse.Day2.Car.Order;
using DotNetCourse.Day2.Car.Producer;
using DotNetCourse.Day2.Car.Store;

namespace DotNetCourse.Day2
{

	class Program
	{

		static void Main(string[] args)
		{
			Hotel.HotelList hotelList = new Hotel.HotelList();
			Hotel.Hotel h = new Hotel.Hotel(1, "Test Hotel", "Dubai");
			Room r1 = new Room("Room name", 2, 3, new Rate(100, "EUR"));
			Room r2 = new Room("Room name", 3, 3, new Rate(200, "EUR"));
			h.Rooms.Add(r1);
			h.Rooms.Add(r2);
			hotelList.Add(h);
			hotelList.findCheapestThen(300);
			hotelList.Print();
			


			Car.Logging.Console console = new Car.Logging.Console();

			Alex Alex = new Alex(30000, console);
			FordStore Store1 = new FordStore("Bucuresti", console);
			Order FordOrder = new Order(Alex, console);
			Store1.Order(FordOrder);
			
			Store1.Estimate();

			SkodaStore Store2 = new SkodaStore("Bucuresti", console);

			Store2.Estimate();

			Store2.Order(new Order(Alex, console));

			Store1.Cancel(FordOrder);

			while (Store2.Wait())
			{
				//wait
			}
			SkodaSuperb car = (SkodaSuperb)Store2.Deliver();
					   			 		  		  		 

		}

	}
}
