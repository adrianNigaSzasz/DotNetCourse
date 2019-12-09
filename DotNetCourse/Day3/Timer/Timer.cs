using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;


namespace DotNetCourse.Day3.Timer
{
	public delegate void CallBacks(Timer timer);


	public class Timer
	{

		private uint callCount;
		protected uint tickSeconds;
		public CallBacks callbacks;


		public uint TickSeconds
		{
			set { this.tickSeconds = value; } get { return this.tickSeconds; }
		}

		public Timer(uint TickSeconds)
		{
			this.TickSeconds = TickSeconds;

			while (true)
			{
				this.Tick();
			}
		}

		public Timer(string DurationInStringFormat)
		{
			Regex r = new Regex("([0-9]+)h([0-9]+)m([0-9]+)s");
			if (!r.IsMatch(DurationInStringFormat))
			{
				throw new ArgumentException("Invalid Argument. Must be in 0h0m0s format");
			}
			Match matches = r.Match(DurationInStringFormat);

			this.TickSeconds = uint.Parse(matches.Groups[1].Value) * 60 * 60 + uint.Parse(matches.Groups[2].Value) * 60 + uint.Parse(matches.Groups[3].Value);


		}

		public uint CallCount
		{
			get { return this.callCount; }
		}

		public void Start()
		{
			while (true)
			{
				this.Tick();
			}
		}

		protected void Tick()
		{
			Thread.Sleep((int)this.TickSeconds * 1000);
			if (this.callbacks != null)
			{
				this.callCount++;
				callbacks(this);
			}
		}
	}
}
