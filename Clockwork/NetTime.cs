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
				Console.WriteLine(exp);
			}
			finally
			{
				myHttpWebRequest.Abort();
			}
			dt = DateTime.MinValue;
			return false;
		}

		public DateTime SyncSystemTimeToWeb()
		{
			GetWebTime(out DateTime datetime);
			SystemTime _time;
			_time = SystemTime.FromUniversalTime(datetime);
			NativeMethods.Win32SetSystemTime(ref _time);
			return datetime;
		}

		public DateTime SetSystemTime(DateTime time)
		{
			SystemTime _time;
			if (time.Kind == DateTimeKind.Local)
			{
				_time = SystemTime.FromUniversalTime(time.ToUniversalTime());
			}
			else
			{
				_time = SystemTime.FromUniversalTime(time);
			}
			NativeMethods.Win32SetSystemTime(ref _time);
			return SystemTime.ToUniversalDateTime(_time);
		}

		public DateTime GetSystemTime(DateTimeKind kind = DateTimeKind.Utc)
		{
			SystemTime _time = new SystemTime();
			NativeMethods.Win32GetSystemTime(ref _time);
			DateTime time;

			switch (kind)
			{
				case DateTimeKind.Unspecified:
				case DateTimeKind.Utc:
					time = SystemTime.ToUniversalDateTime(_time);
					break;
				case DateTimeKind.Local:
					time = SystemTime.ToLocalDateTime(_time);
					break;
				default:
					time = SystemTime.ToUniversalDateTime(_time);
					break;
			}
			return time;
		}
	}
}
