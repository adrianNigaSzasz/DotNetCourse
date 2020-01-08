using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCourse.Day4.FileProcessor
{
	class Program
	{
		public void Main()
		{

			FileProcessor f = new FileProcessor(@"e:\dotnet\files");
			Console.WriteLine("ended");


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
	}
}
