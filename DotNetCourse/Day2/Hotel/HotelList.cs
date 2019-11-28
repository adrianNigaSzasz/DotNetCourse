using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCourse.Day2.Hotel
{
	class HotelList
	{
		private Dictionary<uint, Hotel> internalStructure;

		public HotelList()
		{
			this.internalStructure = new Dictionary<uint, Hotel>();
		}
		public void Add(Hotel hotel)
		{
			this.internalStructure[hotel.Id] = hotel;
		}

		public void Remove(uint id)
		{
			this.internalStructure.Remove(id);

		}

		public bool findCheapestThen(double value)
		{
			foreach (KeyValuePair<uint, Hotel> pair in this.internalStructure)
			{
				foreach (Room room in pair.Value.Rooms)
				{
					if (room.GetPriceForDays(1) < value)
					{
						pair.Value.Print();
						return true;
					}
				}
			}
			return false;
		}

		public void Print()
		{
			foreach (KeyValuePair<uint, Hotel> pair in this.internalStructure)
			{
				pair.Value.Print();
			}
		}
	}
}
