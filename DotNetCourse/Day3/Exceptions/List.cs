using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCourse.Day3.Exceptions
{
	class MyIntList : List<int> , IMinMaxException<int>
	{

		public int Min
		{
			get;set;
		}

		public int Max
		{
			get;set;
		}

		public MyIntList(int min, int max) : base()
		{
			this.Min = min;
			this.Max = max;

		}

		public new void Add(int item)
		{
			if (item < this.Min || item > this.Max)
			{
				throw new InvalidRangeException<int>(this);
			}
			base.Add(item);
		}



	}

	class MyDateList : List<DateTime>, IMinMaxException<DateTime>
	{
		public DateTime Min
		{
			get; set;
		}

		public DateTime Max
		{
			get; set;
		}

		public MyDateList(DateTime min, DateTime max) : base()
		{
			this.Min = min;
			this.Max = max;

		}

		public new void Add(DateTime item)
		{
			if (item < this.Min || item > this.Max)
			{
				throw new InvalidRangeException<DateTime>(this);
			}
			base.Add(item);
		}

	}



}
