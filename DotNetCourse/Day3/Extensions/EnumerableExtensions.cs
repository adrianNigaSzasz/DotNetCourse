using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCourse.Day3.Extensions
{
	static public class EnumerableExtensions
	{
		public static T Sum<T>(this IEnumerable<T> items) 
		{
			dynamic Sum = null;
			foreach (T item in items)
			{
				if (Sum == null) Sum = item;
				else Sum += item;
			}
			return Sum;
		}
		public static T Product<T>(this IEnumerable<T> items) 
		{
			dynamic Sum = null;
			foreach (T item in items)
			{
				if (Sum == null) Sum = item;
				else Sum *= item;
			}
			return Sum;
		}
		public static T Min<T>(this IEnumerable<T> items)
		{
			dynamic Min = null;
			foreach (dynamic item in items)
			{
				if (Min == null || Min > item) Min = item;
			}
			return Min;
		}
		public static T Max<T>(this IEnumerable<T> items)
		{
			dynamic Max = null;
			foreach (T item in items)
			{
				if (Max == null || Max < item) Max = item;
			}
			return Max;
		}
		public static T Average<T>(this IEnumerable<T> items)
		{
			int count = 0;
			foreach (var item in items)
			{
				count++;
			}
			T S = items.Sum();
			return S;

		}
	}
}
