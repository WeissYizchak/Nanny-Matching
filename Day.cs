using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
	public class Day
	{
		TimeSpan _startTime;
		public TimeSpan StartTime
		{
			get { return _startTime; }
			set
			{

				_startTime = value;
				if (_endTime != TimeSpan.Zero && _startTime > _endTime) throw new Exception("the start time is must to be befor the end time");
			}
		}

		TimeSpan _endTime;
		public TimeSpan EndTime
		{
			get { return _endTime; }
			set
			{

				_endTime = value;
				if (_startTime != TimeSpan.Zero && _startTime > _endTime)
					throw new Exception("the end time is must to be after the start time");
			}
		}
		public bool IsWork { get; set; }

		public Day() { }

		public Day(TimeSpan startTime, TimeSpan endTime, bool isWork = true)
		{
			StartTime = startTime;
			EndTime = endTime;
			IsWork = isWork;
		}
	}
}
