using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DotNetCourse.Day4.LargestDivisor
{
	public static class ListExtension
	{
		public static string MyToString(this List<int> list)
		{
			string result = "";
			foreach (var i in list)
			{
				result = result + i.ToString() + " ";
			}
			return result;
		}
	}
		


	class LargestDivisor
	{
		private int Max = 1;
		static readonly object locker = new object();
		static readonly object locker2 = new object();

		public LargestDivisor(int Number)
		{
			this.Max = Number;
		}

		public static List<int> GetDivisorsInRange(int start, int stop, int max)
		{
			List<int> List = new List<int>();
			for (int i = start; i <= stop; i++)
			{
				if (max % i == 0) List.Add(i);
			}
			return List;
			
		}

		public async Task CalculateTask()
		{
			await Task.Run(() => {
				
			});
		}

		public Tuple<double, int, List<int>> Calculate()
		{
			DateTime start = DateTime.Now;
			List<int> ret = GetDivisorsInRange(1, this.Max, this.Max);
			DateTime end = DateTime.Now;
			TimeSpan duration = end - start;
			

			return new Tuple<double, int, List<int>>(duration.TotalMilliseconds, ret[ret.Count-1],ret);
		}

		public Tuple<double, int, List<int>> CalculateWithThreadPool(int noOfThreads)
		{

			DateTime startTime = DateTime.Now;
			var step = this.Max/noOfThreads;
			List<int> result = new List<int>();
			int remaining = noOfThreads;
			using (ManualResetEvent mre = new ManualResetEvent(false))
			{
				for (int i = 0; i < noOfThreads; i++)
				{
					int start = i * step + 1;
					int end = (i + 1) * step;
					ThreadPool.QueueUserWorkItem(delegate
					{
						var tmp = GetDivisorsInRange(start, end, this.Max);
						lock (locker2)
						{
							result.AddRange(tmp);
						}
						if (Interlocked.Decrement(ref remaining) == 0) mre.Set();


					});
				}
				mre.WaitOne();
			}
			DateTime endTime = DateTime.Now;
			TimeSpan duration = endTime - startTime;

			result.Sort();

			return new Tuple<double, int, List<int>>(duration.TotalMilliseconds, result[result.Count - 1], result);
		}


		public Tuple<double, int, List<int>> CalculateWithThreads(int cores)
		{

			List<Thread> tList = new List<Thread>();
			var step = this.Max / cores;
			List<int> result = new List<int>();

			for (int i = 0; i < cores; i++)
			{
				int start = i * step +1;
				int end = (i+1)*step;
				var thread = new Thread(() =>
				{
					var tmp = GetDivisorsInRange(start, end, this.Max);
					lock (locker)
					{
						result.AddRange(tmp);
					}

				});
				tList.Add(thread);
			}

			DateTime startTime = DateTime.Now;
			foreach (var thread in tList) thread.Start();
			foreach (var thread in tList) thread.Join();
			

			DateTime endTime = DateTime.Now;
			TimeSpan duration = endTime - startTime;

			result.Sort();

			return new Tuple<double, int, List<int>>(duration.TotalMilliseconds, result[result.Count-1], result);
		}
	}
}
