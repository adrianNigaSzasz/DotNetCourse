using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCourse.Day2.Hotel
{
	class Room
	{
		protected Rate rate;
		public string Name { get; set; }
		public int Adults { get; set; }
		public int Children { get; set; }

		public double GetPriceForDays(int numberOfDays)
		{
			return this.rate.Amount * numberOfDays;
		}

		public Room(string Name, int Adults, int Children, Rate rate) 
		{
			this.Name = Name;
			this.Adults = Adults;
			this.rate = rate;
		}

		public void Print()
		{
			System.Console.WriteLine("Name : {0}, Adults : {1}; Children: {2}", this.Name, this.Adults, this.Children);
			this.rate.Print();
		}


	}
}
