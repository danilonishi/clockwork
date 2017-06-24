using System;
using System.Diagnostics;

namespace Clockwork
{
	class AutoTimeUpdater
	{
		Stopwatch watch;

		public event Action OnUpdate = delegate { };
		public event Action OnTimer = delegate { };

		public int EventMilliseconds = 0;
		public int Percent
		{
			get
			{
				if (EventMilliseconds == 0)
					return 0;

				var returnPct = (int)(((double)watch.ElapsedMilliseconds / (double)EventMilliseconds) * 100);
				returnPct = returnPct > 100 ? 100 : returnPct < 0 ? 0 : returnPct;

				return returnPct;
			}
		}

		public bool IsRunning
		{
			get
			{
				return watch.IsRunning;
			}
		}

		public AutoTimeUpdater()
		{
			watch = new Stopwatch();
		}

		public void Update()
		{
			if (IsRunning && EventMilliseconds > 0)
			{
				OnUpdate();
				if (watch.ElapsedMilliseconds >= EventMilliseconds)
				{
					OnTimer();
					long difference = watch.ElapsedMilliseconds - EventMilliseconds;
					Restart();
				}
			}
		}

		public void Start()
		{
			watch.Start();
		}

		public void Stop()
		{
			watch.Stop();
		}

		public void Restart()
		{
			watch.Restart();
		}
	}
}
