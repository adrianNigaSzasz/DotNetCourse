using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCourse.Day2.Hotel
{


	class Hotel
	{
		private uint _id;



		protected List<Room> rooms;

		public uint Id {
			get { 
				return this._id;
			}
			set {
				if (value == 0)
				{
					throw new ArgumentException("Positive int required");
				}
				this._id = value;
			}
			
		}

		public string Name
		{ get; set; }


		public string City
		{ get; set; }


		public List<Room> Rooms {
			get { return this.rooms; }
			set { if (value.Count == 0) throw new Exception(); this.rooms = value; }
		}

		public void Add(Room Room)
		{
			this.Rooms.Add(Room);
		}

		public void Remove(Room Room)
		{
			this.Rooms.Remove(Room);
		}

		public Hotel(uint Id, String Name, String City)
		{
			this._id = Id;
			this.Name = Name;
			this.City = City;
			this.rooms = new List<Room>();
		}

		public Hotel(uint Id, String Name, String City, List<Room> Rooms) : this(Id, Name, City)
		{
			this.rooms = Rooms;
		}

		public double GetPriceForNumberOfRooms(int numberOfRooms)
		{
			double price = 0.0;
			for (var i = 0; i < numberOfRooms; i++)
			{
				price += this.rooms[i].GetPriceForDays(1);
			}
			return price;
		}

		public void Print()
		{
			System.Console.WriteLine("Name : {0}, Id : {1}; City: {2};", this.Name, this.Id, this.City);
			foreach (Room room in this.Rooms)
			{
				room.Print();
			}
		}
	}
}
