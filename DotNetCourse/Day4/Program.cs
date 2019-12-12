using System;
using System.Collections.Generic;
using System.Text;
using DotNetCourse.Day4.LargestDivisor;
using DotNetCourse.Day4.Tasks;
using System.Reflection;
using System.Threading.Tasks;
using System.Diagnostics;
using DotNetCourse.Day4.FileProcessor;

namespace DotNetCourse.Day4
{
	public static class Program
	{
		public static void Main(string[] args)
		{

			// 1 ========================================================================

			//first();

			//Largest divisor is 100000000, time spent: 845.5471, list of divisors: 1 2 4 5 8 10 16 20 25 32 40 50 64 80 100 125 128 160 200 250 256 320 400 500 625 640 800 1000 1250 1280 1600 2000 2500 3125 3200 4000 5000 6250 6400 8000 10000 12500 15625 16000 20000 25000 31250 32000 40000 50000 62500 78125 80000 100000 125000 156250 160000 200000 250000 312500 390625 400000 500000 625000 781250 800000 1000000 1250000 1562500 2000000 2500000 3125000 4000000 5000000 6250000 10000000 12500000 20000000 25000000 50000000 100000000
			//Largest divisor is 100000000, time spent with threading: 490.9883, list of divisors: 1 2 4 5 8 10 16 20 25 32 40 50 64 80 100 125 128 160 200 250 256 320 400 500 625 640 800 1000 1250 1280 1600 2000 2500 3125 3200 4000 5000 6250 6400 8000 10000 12500 15625 16000 20000 25000 31250 32000 40000 50000 62500 78125 80000 100000 125000 156250 160000 200000 250000 312500 390625 400000 500000 625000 781250 800000 1000000 1250000 1562500 2000000 2500000 3125000 4000000 5000000 6250000 10000000 12500000 20000000 25000000 50000000 100000000
			//Largest divisor is 100000000, time spent with thread pool: 320.2413, list of divisors: 1 2 4 5 8 10 16 20 25 32 40 50 64 80 100 125 128 160 200 250 256 320 400 500 625 640 800 1000 1250 1280 1600 2000 2500 3125 3200 4000 5000 6250 6400 8000 10000 12500 15625 16000 20000 25000 31250 32000 40000 50000 62500 78125 80000 100000 125000 156250 160000 200000 250000 312500 390625 400000 500000 625000 781250 800000 1000000 1250000 1562500 2000000 2500000 3125000 4000000 5000000 6250000 10000000 12500000 20000000 25000000 50000000 100000000
			// 2 ========================================================================

			//second();


			// 3 ========================================================================




			// 4 ========================================================================
			forth();

			/*
			 *	Started consumer 6
				Started consumer 4
				waiting for files...
				waiting for files...
				waiting for files...
				waiting for files...
				waiting for files...
				waiting for files...
				waiting for files...
				received file e:\dotnet\files\test1.txt
				received file e:\dotnet\files\test2 - Copy (10).txt
				received file e:\dotnet\files\test2 - Copy (2).txt
				received file e:\dotnet\files\test2 - Copy (3).txt
				received file e:\dotnet\files\test2 - Copy.txt
				received file e:\dotnet\files\test2.txt
				waiting for files...
				waiting for files...
				received file e:\dotnet\files\test2 - Copy (4).txt
				received file e:\dotnet\files\test2 - Copy (5).txt
				waiting for files...
				received file e:\dotnet\files\test2 - Copy (6).txt
				waiting for files...
				waiting for files...
				received file e:\dotnet\files\test2 - Copy (7).txt
				halted producer
				waiting for files...
				file e:\dotnet\files\test2 - Copy (2).txt, content:aaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbcccccccccccccccccccc
				file e:\dotnet\files\test1.txt, content:aaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbcccccccccccccccccccc
				file e:\dotnet\files\test2 - Copy (3).txt, content:aaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbcccccccccccccccccccc
				file e:\dotnet\files\test2 - Copy (5).txt, content:aaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbcccccccccccccccccccc
				file e:\dotnet\files\test2 - Copy (4).txt, content:aaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbcccccccccccccccccccc
				file e:\dotnet\files\test2 - Copy.txt, content:aaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbcccccccccccccccccccc
				file e:\dotnet\files\test2 - Copy (7).txt, content:aaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbcccccccccccccccccccc
				file e:\dotnet\files\test2 - Copy (6).txt, content:aaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbcccccccccccccccccccc
				file e:\dotnet\files\test2.txt, content:aaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbcccccccccccccccccccc
				file e:\dotnet\files\test2 - Copy (10).txt, content:aaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbcccccccccccccccccccc
				halted producer
				ended
			 * */

		}

		public static void first()
		{
			LargestDivisor.LargestDivisor ld = new LargestDivisor.LargestDivisor(100000000);
			var (miliseconds, largestNumber, list) = ld.Calculate();
			System.Console.WriteLine("Largest divisor is {0}, time spent: {1}, list of divisors: {2}", largestNumber, miliseconds, list.MyToString());

			(double miliseconds2, int largestNumber2, List<int> list2) = ld.CalculateWithThreads(Environment.ProcessorCount);
			System.Console.WriteLine("Largest divisor is {0}, time spent with threading: {1}, list of divisors: {2}", largestNumber2, miliseconds2, list2.MyToString());

			(double miliseconds3, int largestNumber3, List<int> list3) = ld.CalculateWithThreadPool(4);
			System.Console.WriteLine("Largest divisor is {0}, time spent with thread pool: {1}, list of divisors: {2}", largestNumber3, miliseconds3, list3.MyToString());

		}

		public static void second()
		{
			Stopwatch stopWatch = new Stopwatch();
			WordProcessor wordP = new WordProcessor();

			var assembly = Assembly.GetExecutingAssembly();
			Task[] tasks = new Task[10];

			stopWatch.Start();
			for (int i = 0; i < 10; i++)
			{
				tasks[i] = wordP.ReadAsync(assembly.GetManifestResourceStream($"DotNetCourse.Day4.Tasks.Files.file.{i}.dat"));
			}


			Task.WaitAll(tasks);
			stopWatch.Stop();
			TimeSpan ts1 = stopWatch.Elapsed;
			Console.WriteLine("chars read async:" + wordP.Chars);

			WordProcessor wordP2 = new WordProcessor();
			stopWatch.Start();
			for (int i = 0; i < 10; i++)
			{
				wordP2.Read(assembly.GetManifestResourceStream($"DotNetCourse.Day4.Tasks.Files.file.{i}.dat"));
			}

			stopWatch.Stop();
			TimeSpan ts2 = stopWatch.Elapsed;

			Console.WriteLine("chars read sync:" + wordP2.Chars);
			Console.WriteLine("task {0}, syncron {1}", ts1, ts2);


		}

		public static void forth()
		{
			FileProcessor.FileProcessor f = new FileProcessor.FileProcessor(@"e:\dotnet\files");
			Console.WriteLine("ended");

		}
	}
}
