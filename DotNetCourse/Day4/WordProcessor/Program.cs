using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace DotNetCourse.Day4.WordProcessor
{
	class Program
	{
		public void Main()
		{
			Stopwatch stopWatch = new Stopwatch();
			var assembly = Assembly.GetExecutingAssembly();




			
			WordProcessor wordP = new WordProcessor();



			Task[] tasks = new Task[10];

			stopWatch.Start();
			for (int i = 0; i < 10; i++)
			{
				tasks[i] = wordP.ReadAsync(assembly.GetManifestResourceStream($"DotNetCourse.Day4.WordProcessor.Files.file.{i}.dat"));
			}


			Task.WaitAll(tasks);
			stopWatch.Stop();
			TimeSpan ts1 = stopWatch.Elapsed;
			Console.WriteLine("task {0}", ts1);

			Console.WriteLine("number of words " + wordP.CountAllWords());
			Console.WriteLine("distinct words " + wordP.CountDistinctWords());

			Console.WriteLine("found 'alabalaportocala' {0} ", wordP.Contains("alabalaportocala") ? "true" : "false"); 

			var groups = wordP.GroupWordsPerCategories();
			Console.WriteLine("under 5 : {0}\nbetween 5-10 : {1} \nbetween 10-15 : {2} \ngreather than 15 : {3}", groups[0], groups[1], groups[2], groups[3]);


			/*
			syncron version, just for benchmark and debugging
			
			WordProcessor wordP2 = new WordProcessor();
			stopWatch.Start();
			for (int i = 0; i < 10; i++)
			{
				wordP2.Read(assembly.GetManifestResourceStream($"DotNetCourse.Day4.WordProcessor.Files.file.{i}.dat"));
			}

			stopWatch.Stop();
			TimeSpan ts2 = stopWatch.Elapsed;

			Console.WriteLine("chars read sync:" + wordP2.Chars);
			Console.WriteLine("syncron {0}", ts2);
			*/

		}
	}
}
