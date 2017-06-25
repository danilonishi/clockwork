using Clockwork.CWTime;
using System;
using System.Globalization;
using System.Net;

namespace Clockwork
{

	class CustomTime
	{
		public bool GetWebTime(out DateTime dt)
		{
			var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.google.com.br");
			myHttpWebRequest.Timeout = 1000;
			try
			{
				var response = myHttpWebRequest.GetResponse();
				string todaysDates = response.Headers["date"];
				dt = DateTime.ParseExact(
					todaysDates,
					"ddd, dd MMM yyyy HH:mm:ss 'GMT'",
					CultureInfo.InvariantCulture.DateTimeFormat,
					DateTimeStyles.AssumeUniversal);

				return true;
			}
			catch (Exception exp)
			{
				dt = DateTime.UtcNow;
				Console.WriteLine(exp);
			}
			finally
			{
				myHttpWebRequest.Abort();
			}
			return false;
		}

		public DateTime SyncSystemTimeToWeb()
		{
			if(GetWebTime(out DateTime datetime))
			{
				SystemTime _time = SystemTime.FromUniversalTime(datetime);
				NativeMethods.Win32SetSystemTime(ref _time);
			}
			return datetime;
		}

		public DateTime SetSystemTime(DateTime time)
		{
			SystemTime _time;
			switch (time.Kind)
			{
				case DateTimeKind.Unspecified:
				case DateTimeKind.Utc:
				default:
					_time = SystemTime.FromUniversalTime(time);
					break;
				case DateTimeKind.Local:
					_time = SystemTime.FromUniversalTime(time.ToUniversalTime());
					break;
			}
			NativeMethods.Win32SetSystemTime(ref _time);
			return SystemTime.ToUniversalDateTime(_time);
		}

		public DateTime GetSystemTime(DateTimeKind kind = DateTimeKind.Utc)
		{
			SystemTime _time = new SystemTime();
			DateTime time;
			NativeMethods.Win32GetSystemTime(ref _time);
			switch (kind)
			{
				case DateTimeKind.Unspecified:
				case DateTimeKind.Utc:
				default:
					time = SystemTime.ToUniversalDateTime(_time);
					break;
				case DateTimeKind.Local:
					time = SystemTime.ToLocalDateTime(_time);
					break;
			}
			return time;
		}
	}
}
