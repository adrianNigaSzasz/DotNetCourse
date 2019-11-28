using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace DotNetCourse.Day2.Car.Logging
{
	class File : ILogging
	{

		private System.IO.StreamWriter _file;
		private String path;

		public File(String Path)
		{
			this.path = Path;
			if (!System.IO.File.Exists(path))
			{
				throw new ArgumentException("File does not exists");
			}
		}

		public void Log(String Message)
		{
			this._file = System.IO.File.AppendText(this.path);
			this._file.WriteLine(Message);


		}
	}
}
