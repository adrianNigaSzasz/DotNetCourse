using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Threading;

namespace DotNetCourse.Day4.Tasks
{
	
	class WordProcessor
	{
		private string buffer; // internal datastructure
		private static object _lock = new object();

		public int Chars{
			get { return this.buffer.Length; }
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
			using (var reader = new StreamReader(stream ?? throw new InvalidOperationException()))
			{
				Console.WriteLine("thread {0}", Thread.CurrentThread.ManagedThreadId);
				StringBuilder strB = new StringBuilder(4388608);
				
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					strB.Append(line);
				}
				lock (_lock)
				{
					this.buffer = this.buffer + strB.ToString();
				}
			}
		}

		public int CountAllWords()
		{
			return this.Chars;
		}

		public int CountDistinctWords()
		{
			return this.Chars;
		}

		


	}
}
