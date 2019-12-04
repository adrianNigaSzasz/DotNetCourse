using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCourse.Day3.Exceptions
{
	public interface IMinMaxException<T>
	{
		T Min { get; }
		T Max { get; }
	}
	
	[System.Serializable]
	class InvalidRangeException<T> : System.Exception
	{
		private static readonly string DefaultMessage = "Out of range";
		private T min;
		private T max;


		public InvalidRangeException() : base(DefaultMessage) {}

		public InvalidRangeException(string message) : base(message) {}

		public InvalidRangeException(string message, System.Exception innerException) : base(message, innerException) { }

		public InvalidRangeException(T min, T max) : base(DefaultMessage) {
			this.min = min;
			this.max = max;
		}

		public InvalidRangeException(IMinMaxException<T> minMax) : base(DefaultMessage)
		{
			this.min = minMax.Min;
			this.max = minMax.Max;
		}


		protected InvalidRangeException(
	   System.Runtime.Serialization.SerializationInfo info,
	   System.Runtime.Serialization.StreamingContext context) : base(info, context) { }


	}
}
