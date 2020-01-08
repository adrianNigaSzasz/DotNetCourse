using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Threading;
using System.Linq;

namespace DotNetCourse.Day4.WordProcessor
{
	
	class WordProcessor
	{
		private List<string> WordList; // internal datastructure
		private static object _lock = new object();
		private long _groupLock = 0;

		public WordProcessor()
		{
			this.WordList = new List<string>();
		}

		public int Chars{
			get { return this.CountAllWords(); }
		}
		public async Task ReadAsync(Stream stream)
		{
			await Task.Run(() =>
			{
				this.Read(stream);
			});
		}

		public void Read(Stream stream)
		{
			List<string> tmp = new List<string>();
			string line;
			using (var reader = new StreamReader(stream ?? throw new InvalidOperationException()))
			{
				Console.WriteLine("thread {0}", Thread.CurrentThread.ManagedThreadId);
				
				while ((line = reader.ReadLine()) != null)
				{
					if (tmp.Count == 1000)
					{
						lock (_lock)
						{
							this.WordList.AddRange(tmp);
						}
						tmp.Clear();
					}
					tmp.Add(line);
				}
				if (tmp.Count > 0)
				{
					lock (_lock)
					{
						this.WordList.AddRange(tmp);
					}
				}
			}
		}

		public int CountAllWords()
		{
			return this.WordList.AsParallel().Count();
		}

		public int CountDistinctWords()
		{
			return this.WordList.AsParallel().GroupBy(c => c).Count();
		}

		public bool Contains(string findMe)
		{
			var finds = this.WordList.AsParallel().Where(c => c.Contains(findMe)).ToList();
			return finds.Count > 0 ? true : false;
		}

		public int[] GroupWordsPerCategories()
		{
			var l = new int[4]{ 0,0,0,0};

			Parallel.For(0, this.WordList.Count, index => {
				if (this.WordList[index].Length < 5)
				{
					Interlocked.Add(ref l[0], 1);
				}
				if (this.WordList[index].Length > 5 && this.WordList[index].Length < 10)
				{
					Interlocked.Add(ref l[1], 1);
				}
				if (this.WordList[index].Length > 10 && this.WordList[index].Length < 15)
				{
					Interlocked.Add(ref l[2], 1);
				}
				if (this.WordList[index].Length > 15)
				{
					Interlocked.Add(ref l[3], 1);
				}
			});

			return l;
		}




	}
}
