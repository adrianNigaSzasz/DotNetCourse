using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCourse.Day2.Hotel
{
	class Rate
	{

		public Rate(double Amount, string Currency)
		{
			this.Amount = Amount;
			this.Currency = Currency;
		}

		public double Amount {
			get;set;
		}

		public string Currency
		{
			get;set;
		}

		public void Print()
		{
			Console.WriteLine(this.Amount + ' ' + this.Currency);
		}

	}
}
