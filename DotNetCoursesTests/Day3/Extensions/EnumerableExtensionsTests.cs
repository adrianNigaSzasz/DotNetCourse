using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetCourse.Day3.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCourse.Day3.Tests
{
	[TestClass()]
	public class EnumerableExtensionsTests
	{
		[TestMethod()]
		public void SumTest()
		{
			List<int> l = new List<int>();
			l.Add(1);
			l.Add(2);
			l.Add(3);
			Assert.AreEqual(l.Sum(), 6);
		}

		[TestMethod()]
		public void ProductTest()
		{
			List<int> l = new List<int>();
			l.Add(1);
			l.Add(2);
			l.Add(3);
			Assert.AreEqual(l.Product(), 6);
		}

		[TestMethod()]
		public void MinTest()
		{
			List<int> l = new List<int>();
			l.Add(1);
			l.Add(2);
			l.Add(3);
			Assert.AreEqual(l.Min(), 1);
		}

		[TestMethod()]
		public void MaxTest()
		{
			List<int> l = new List<int>();
			l.Add(1);
			l.Add(2);
			l.Add(3);
			Assert.AreEqual(l.Max(), 3);
		}

		[TestMethod()]
		public void AverageTest()
		{
			List<int> l = new List<int>();
			l.Add(1);
			l.Add(2);
			l.Add(3);
			Assert.AreEqual(l.Average(), 3);
		}
	}
}