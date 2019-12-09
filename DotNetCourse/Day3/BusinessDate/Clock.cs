using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCourse.Day3.BusinessDate
{
	public interface IClock
	{
		DateTime Now { get; }

		DateTime UtcNow { get; }

		BusinessDate Today { get; }
	}


	public class Clock : IClock
	{
		protected DateTime now;

		public DateTime Now
		{
			get
			{
				return this.now;
			}
		}
		public DateTime UtcNow
		{
			get
			{
				return this.now.ToUniversalTime();
			}
		}
		public BusinessDate Today {
			get {
				return new BusinessDate(this.now);
			}
		}

		public Clock()
		{
			this.now = DateTime.Now;
		}

		public Clock(DateTime datetime)
		{
			this.now = datetime;
		}


	}
}
