using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetCourse.Day3.BusinessDate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DotNetCourse.Day3.Tests
{
	[TestClass()]
	public class ClockTests
	{
		[TestMethod()]
		public void ClockTest()
		{
			Clock clock = new Clock(DateTime.Parse("2019-12-04T19:00:00"));

			Assert.AreEqual(clock.Today.ToString(), "1575486000");

		}

		[TestMethod()]
		public void ClockTestWriteXML()
		{
			Clock c = new Clock(DateTime.Parse("2019-12-04T19:00:00"));
			StringBuilder strB = new StringBuilder(100);

			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			settings.OmitXmlDeclaration = true;
			settings.NewLineOnAttributes = false;
			settings.ConformanceLevel = ConformanceLevel.Document;

			using (XmlWriter writer = XmlWriter.Create(strB, settings))
			{
				c.Today.WriteXml(writer);
			}
			Assert.AreEqual(strB.ToString(), "<businessDate>1575486000</businessDate>");
		}
		[TestMethod()]
		public void ClockTestReadXML()
		{
			Clock c = new Clock(DateTime.Parse("2019-12-04T19:00:00"));
			
			XmlReaderSettings settings = new XmlReaderSettings();
			
			settings.ConformanceLevel = ConformanceLevel.Document;

			using (XmlReader reader = XmlReader.Create(new System.IO.StringReader("<businessDate>1575486000</businessDate>"), settings))
			{
				reader.Read();
				c.Today.ReadXml(reader);
			}
			Assert.AreEqual(c.Today.ToString(), "1575486000");
		}

		[TestMethod()]
		public void BusinessDateEquals()
		{
			Clock c1 = new Clock(DateTime.Parse("2019-12-04T19:00:00"));
			Clock c2 = new Clock(DateTime.Parse("2019-12-04T19:00:00"));
			Clock c3 = new Clock(DateTime.Parse("2019-12-04T19:00:01"));


			Assert.AreEqual(c1.Today, c2.Today);

			Assert.IsTrue(c1.Today.Equals(c2.Today));

			Assert.AreNotEqual(c1.Today, c3.Today);

			Assert.IsFalse(c1.Today.Equals(c3.Today));
		}

		[TestMethod()]
		public void BusinessDateCompare()
		{
			Clock c1 = new Clock(DateTime.Parse("2019-12-04T19:00:01"));
			Clock c2 = new Clock(DateTime.Parse("2019-12-04T19:00:02"));
			Clock c3 = new Clock(DateTime.Parse("2019-12-04T19:00:01"));


			Assert.AreEqual(c1.Today.CompareTo(c2.Today), -1);
			Assert.AreEqual(c2.Today.CompareTo(c1.Today), 1);
			Assert.AreEqual(c1.Today.CompareTo(c3.Today), 0);

			Assert.AreNotEqual(c2.Today.CompareTo(c3.Today), 0);


		}

		[TestMethod()]
		public void BusinessDateToString()
		{
			Clock c1 = new Clock(DateTime.Parse("2019-12-04T19:00:00"));
		

			Assert.AreEqual(c1.Today.ToString(), "1575486000");
			Assert.AreNotEqual(c1.Today.ToString(), "1575486001");



		}

	}
}