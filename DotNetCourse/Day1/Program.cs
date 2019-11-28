using System;
using DotNetCourse.Day1;
using System.Collections.Generic;

namespace DotNetCourse
{
	class Program
	{
		static void MainOld(string[] args)
		{
			/*
			Console.WriteLine("Remove duplicates");
			string input = Console.ReadLine();
			Console.WriteLine(input.RemoveDuplicates());

			Console.WriteLine("Get frequency");
			input = Console.ReadLine();
			input.GetFrequency().Print();

			Console.WriteLine("Length of last word");
			input = Console.ReadLine();
			Console.WriteLine("Length of last word ({0}): {1}", input.LastWord(), input.GetLengthOfLastWord());
			
			string input = Console.ReadLine();
			int[] myInts = Array.ConvertAll(input.Split(","), int.Parse);
			Console.WriteLine("First occurence above 50% is {0}",Day1.HomeWork.countOccuranceIn(myInts));
			*/

			LinkedList < String > list = new LinkedList<String>();
			list.AddFirst("first 3");
			list.AddFirst("first 2");
			list.AddFirst("first 1"); 
			list.AddFirst("first 1");
			list.AddFirst("first 3");

			Day1.HomeWork.RemoveDuplicates(list);
			Day1.HomeWork.PrintList(list);

			Day1.HomeWork.Reverse(list.First);
			Day1.HomeWork.PrintList(list);


		}
	}
}
