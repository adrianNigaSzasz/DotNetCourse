using System;
using System.Collections.Generic;
using System.Text;
using DotNetCourse.Day3.Extensions;
using DotNetCourse.Day3.Exceptions;
using DotNetCourse.Day3.Timer;
using DotNetCourse.Day3.BusinessDate;
using System.Xml;

namespace DotNetCourse.Day3
{
	public class SomeClass
	{

		public void CallThisMethod(Timer.Timer t)
		{
			Console.WriteLine("Called instance method at {0}, this is {1} time", DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString(), t.CallCount);
		}

		public static void CallThisStaticMethod(Timer.Timer t)
		{
			Console.WriteLine("Called staticmethod at {0}, this is {1} time", DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString(), t.CallCount);
		}
	}


	class Program
	{



		static void Main(string[] args)
		{
			/*
			// 1 ==============================================================
			
			Timer.Timer timer = new Timer.Timer("0h1m30s");
			SomeClass test = new SomeClass();


			timer.callbacks += test.CallThisMethod;
			timer.callbacks += SomeClass.CallThisStaticMethod;

			timer.Start();

			// 3 ==============================================================

			
			List<string> l = new List<string>();
			l.Add("a");
			l.Add("b");
			l.Add("c");

			Console.WriteLine(l.Min());
			Console.WriteLine(l.Max());
			Console.WriteLine(l.Sum());
			Console.WriteLine(l.Average());

			// 1 ==============================================================
	
			MyIntList l = new MyIntList(0, 100);
			l.Add(1);
			try
			{
				l.Add(200);
			}
			catch (InvalidRangeException<int> e)
			{
				Console.WriteLine(e.Message);

			}

	

			MyDateList d = new MyDateList(DateTime.Parse("1980-1-1"), DateTime.Parse("2013-12-31"));
			d.Add(DateTime.Parse("2000-1-1"));
			try
			{
				d.Add(DateTime.Now);
			}
			catch (InvalidRangeException<DateTime> e)
			{
				Console.WriteLine(e.Message);

			}
			

			// 5 ==============================================================
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

			Console.WriteLine("XML = {0}",strB);
			


			Clock c = new Clock(DateTime.Parse("2019-12-04T19:00:00"));
			StringBuilder strB = new StringBuilder(100);

			XmlReaderSettings settings = new XmlReaderSettings();
			

			settings.ConformanceLevel = ConformanceLevel.Document;

			using (XmlReader reader = XmlReader.Create(new System.IO.StringReader("<businessDate>1575486000</businessDate>"), settings))
			{
				reader.Read();
				c.Today.ReadXml(reader);
			}
			*/

			LinqAndLamdaExpressions.Program.Main();

		}

	}
}
