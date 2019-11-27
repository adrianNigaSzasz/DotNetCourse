using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCourse.Day1
{
	public static class DictionaryExtension {
		public static void Print(this Dictionary<char, int> dict)
		{
			foreach (KeyValuePair<char, int> entry in dict)
			{
				System.Console.WriteLine("Char {0}, count {1}", entry.Key, entry.Value);
			}

		}
	}
	public static class StringExtension {
		public static string RemoveDuplicates(this string input)
		{
			if (input.Length == 0) return "";

			string newString = "";
			foreach (char Character in input)
			{
				if (!newString.Contains(Character))
				{
					newString += Character;
				}
			}

			return newString;


		}

		public static Dictionary<char, int> GetFrequency(this string input)
		{
			Dictionary<char, int> frequency = new Dictionary<char, int>();

			if (input.Length == 0)
			{
				return frequency;
			}

			foreach (char character in input)
			{
				if (!frequency.ContainsKey(character)) frequency.Add(character, 1);
				else frequency[character]++;

			}

			return frequency;
		}

		public static int GetLengthOfLastWord(this string input)
		{
			return input.LastWord().Length;
		}

		public static string LastWord(this string input)
		{


			string[] tokens = input.Split(" ");

			if (tokens.Length == 0) return "";

			return tokens[^1];

		}
	}
	class HomeWork
	{


		public static int countOccuranceIn(int[] array)
		{
			if (array.Length == 0) return 0;
			float Percentage = array.Length / 2;

			Array.Sort(array);



			int count = 0;

			for (int i = 0; i < array.Length-1;i++)
			{
				if (array[i] != array[i + 1])
				{
					if (++count > Percentage) return array[i];
					count = 0;
				}
				else
				{
					count++;
				}
				
			}

			return 0;
			
		}


		

		public static void RemoveDuplicates(LinkedList<String> linked)
		{
			List<String> seen = new List<String>();

			LinkedListNode<String> node = linked.First;
			
			while (node != null)
			{
				var next = node.Next;
				if (seen.Contains(node.Value))
				{
					linked.Remove(node);
				}
				else
				{
					seen.Add(node.Value);
				}
				node = next;
			}		 

		}

		public static void Reverse(LinkedListNode<String> node)
		{

			LinkedList<String> list = node.List;

			if (node.Next != null)
			{
				Reverse(node.Next);
				list.Remove(node);
				list.AddLast(node);

			}


					   			 		  		  		 	   		
		}

		public static void PrintList(LinkedList<String> linked)
		{
			LinkedListNode<String> node = linked.First;

			while (node != null)
			{
				System.Console.WriteLine(node.Value);
				node = node.Next;
			}
			
		}
	}

}
