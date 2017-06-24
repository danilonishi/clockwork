using System;
using System.Runtime.InteropServices;

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

		public static SystemTime FromLocalTime(DateTime _time)
		{
			return CreateTime(_time.ToLocalTime());
		}

		public static SystemTime FromUniversalTime(DateTime _time)
		{
			return CreateTime(_time.ToUniversalTime());
		}

		static SystemTime CreateTime(DateTime _time)
		{
			var time = new SystemTime()
			{
				Year = (ushort)_time.Year,
				Month = (ushort)_time.Month,
				Day = (ushort)_time.Day,
				Hour = (ushort)_time.Hour,
				Minute = (ushort)_time.Minute,
				Second = (ushort)_time.Second,
				Milliseconds = (ushort)_time.Millisecond
			};
			return time;
		}

		public static DateTime ToLocalDateTime(SystemTime _time)
		{
			return new DateTime(_time.Year, _time.Month, _time.Day, _time.Hour, _time.Minute, _time.Second, _time.Milliseconds, DateTimeKind.Local);
		}

		public static DateTime ToUniversalDateTime(SystemTime _time)
		{
			return new DateTime(_time.Year, _time.Month, _time.Day, _time.Hour, _time.Minute, _time.Second, _time.Milliseconds, DateTimeKind.Utc);
		}

		public override string ToString()
		{
			return string.Format("{0} {1}/{2}/{3} {4}:{5}:{6}::{7}", base.ToString(), Day, Month, Year, Hour, Minute, Second, Milliseconds);
		}
	}
}
