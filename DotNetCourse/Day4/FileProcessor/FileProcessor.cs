using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace DotNetCourse.Day4.FileProcessor
{
	class FileProcessor
	{
		private Task producer;
		private Task[] consumers;

		private BlockingCollection<string> filePipe ;

		private ConcurrentDictionary<string, string> sharedData;

		private CancellationTokenSource tokenSource = new CancellationTokenSource();

		private int filesProcessed = 0;

		public FileProcessor(string directoryPath)
		{
			this.filePipe = new BlockingCollection<string>(4);
			this.sharedData = new ConcurrentDictionary<string, string>();

			this.consumers = new Task[2]; // 2?

			var token = this.tokenSource.Token;

			//start the producer
			
			this.producer = Task.Factory.StartNew((object c) =>
			{
				
				List<string> loadedFiles = new List<string>();
				//enter the loop
				while(true)
				{
					//if cancelation requested then "close the pipe" to unblock the consumer and stop this task
					if (((CancellationToken)c).IsCancellationRequested)
					{
						filePipe.CompleteAdding();
						break;
					}

					//directory stuff
					string[] filePaths = Directory.GetFiles(directoryPath);
					foreach (var file in filePaths)
					{
						if (!loadedFiles.Contains(file))
						{
							try
							{
								filePipe.Add(file);
								loadedFiles.Add(file);
							}
							catch (Exception e)
							{
								throw e;
							}
						}
					}
					Thread.Sleep(1000);
					Console.WriteLine("waiting for files...");
				}
				
			}, token, TaskCreationOptions.LongRunning).ContinueWith((t)=> {
				//when the producer thread ends, it means it was halted by consumer and we print
				foreach ((string file, string fileContent) in this.sharedData)
				{
					Console.WriteLine("file {0}, content:{1}", file, fileContent);
					
				}
				
				//bye bye
			});


			//start one or more consumers?
			for (int i = 0; i < 2; i++)
			{
				this.consumers[i] = Task.Factory.StartNew(()=> {
					Console.WriteLine("Started consumer {0}", Thread.CurrentThread.ManagedThreadId);
					try
					{
						foreach (var file in this.filePipe.GetConsumingEnumerable())
						{
							Console.WriteLine("received file {0}", file);
							//read content and add to shared
							using (StreamReader sr = new StreamReader(file))
							{
								// Read the stream to a string, and write the string to the console.
								String fileContent = sr.ReadToEnd();
								this.sharedData.TryAdd(file, fileContent);

							}
							if (Interlocked.Increment(ref filesProcessed) >= 10)
							{
								//halt this thread
								tokenSource.Cancel();
								break;
							}
						}
					}
					finally
					{
						//
					}
				}).ContinueWith((t)=> { Console.WriteLine("halted producer"); });
			}

			
			

			Task.WaitAll(this.producer, this.consumers[0], this.consumers[1]); //not sure if it should be dynamic?


			
		}



	}
}
