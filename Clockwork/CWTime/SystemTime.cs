using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Clockwork.CWTime
{
	[StructLayout(LayoutKind.Sequential)]
	public struct SystemTime
	{
		public ushort Year;
		public ushort Month;
		public ushort DayOfWeek;
		public ushort Day;
		public ushort Hour;
		public ushort Minute;
		public ushort Second;
		public ushort Milliseconds;

		public string ToTimeFormat()
		{
			return string.Format("{0}:{1}:{2},{3}", Hour, Minute, Second, Milliseconds);
		}

		public string ToDateFormat()
		{
			return string.Format("{0}/{1}/{2}", Day, Month, Year);
		}

		public static implicit operator DateTime(SystemTime _time)
		{
			return new DateTime(_time.Year, _time.Month, _time.Day, _time.Hour, _time.Minute, _time.Second);
		}

		public static implicit operator SystemTime(DateTime _time)
		{
			var time = new SystemTime()
			{
				Year = (ushort)_time.Year,
				Month = (ushort)_time.Month,
				Day = (ushort)_time.Day,
				Hour = (ushort)_time.Hour,
				Minute = (ushort)_time.Minute,
				Second = (ushort)_time.Second
			};
			return time;
		}

		public void Add(ushort hour, ushort minute, ushort second)
		{
			Second += second;
			Minute += minute;
			Hour += hour;
			ValidateTimeConstraints();
		}

		public void AddSecond(ushort seconds)
		{
			Second += seconds;
			ValidateTimeConstraints();
		}

		public void AddMinute(ushort minutes)
		{
			Minute += minutes;
			ValidateTimeConstraints();
		}

		public void AddHour(ushort hours)
		{
			Hour += hours;
			ValidateTimeConstraints();
		}

		void ValidateTimeConstraints()
		{
			Minute += (ushort)Math.Floor(Second / 60m);
			Hour += (ushort)Math.Floor(Minute / 60m);
			Day += (ushort)Math.Floor(Hour / 24m);
			// Month é treta
			Second %= 60;
			Minute %= 60;
			Hour %= 24;
		}
	}
}
