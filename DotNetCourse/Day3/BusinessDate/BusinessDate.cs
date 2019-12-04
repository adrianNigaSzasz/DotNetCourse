using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DotNetCourse.Day3.BusinessDate
{




	public struct BusinessDate : IFormattable, IEquatable<BusinessDate>, IComparable<BusinessDate>, IXmlSerializable
	{

		public int timeStamp;


		public BusinessDate(DateTime dateTime)
		{
			this.timeStamp = (Int32)(dateTime.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
		}

		public BusinessDate(int timeStamp)
		{
			this.timeStamp = timeStamp;
		}

		public int CompareTo([AllowNull] BusinessDate other)
		{
			if (this.timeStamp < other.timeStamp) return -1;
			else if (this.timeStamp > other.timeStamp) return 1;
			else return 0;
			
		}

		public bool Equals([AllowNull] BusinessDate other)
		{
			return this.timeStamp == other.timeStamp;
		}

		public XmlSchema GetSchema()
		{
			return (null);
		}


		public string ToString(string format, IFormatProvider formatProvider)
		{
			return this.timeStamp.ToString();
		}

		public new string ToString()
		{
			return this.timeStamp.ToString();
		}


		public void WriteXml(XmlWriter writer)
		{


			writer.WriteStartDocument();
			writer.WriteStartElement("businessDate");
			writer.WriteString(this.ToString());
			writer.WriteEndElement();
		}

		public void ReadXml(XmlReader reader)
		{
			timeStamp = int.Parse(reader.ReadInnerXml());
		}

	}
}
