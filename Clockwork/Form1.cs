using System;
using System.Windows.Forms;
using Clockwork.CWTime;
using System.Diagnostics;
using System.Net.Sockets;
using System.IO;
using System.Globalization;
using System.Net;
using System.Net.Cache;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Security.Principal;
using System.Reflection;

namespace Clockwork
{
	public partial class Form1 : Form
	{
		SystemTime modifiedTime;
		DateTime startupDateTime;
		DateTime lastAutoApplyTime;
		DateTime nextAutoApplyTime;
		bool isDirty;

		bool IsRunAsAdministrator()
		{
			return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
		}

		public Form1()
		{
#if !DEBUG
			if (!IsRunAsAdministrator())
			{
				var processInfo = new ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase)
				{

					// The following properties run the new process as administrator
					UseShellExecute = true,
					Verb = "runas"
				};

				// Start the new process
				try
				{
					Process.Start(processInfo);
				}
				catch (Exception)
				{
					// The user did not allow the application to run as administrator
					MessageBox.Show("Sorry, this application must be run as Administrator.");
				}

				// Shut down the current process
				Environment.Exit(0);
			}
#endif
			InitializeComponent();

			modifiedTime = new SystemTime();

			LoadValues();
		}

		void DisableAutomaticTimeChange()
		{
			checkBox2.Checked = false;
		}

		BackgroundWorker nistWorker;
		ProgressWindow progressWindow;

		void ApplyNistTime()
		{
			DisableAutomaticTimeChange();

			Console.WriteLine("ApplyNistTime");

			if (progressWindow != null && progressWindow.IsDisposed)
			{
				Console.WriteLine("Progress window is open.");
				return;
			}

			Console.WriteLine("Creating new ProgressWindow.");
			progressWindow = new ProgressWindow();
			progressWindow.Canceled += ProgressWindow_Canceled;
			progressWindow.Show();

			if (nistWorker == null)
			{
				Console.WriteLine("Creating new BackgroundWorker.");
				nistWorker = new BackgroundWorker();
			}

			if (nistWorker.IsBusy)
			{
				Console.WriteLine("worker is busy");
				return;
			}

			if (nistWorker.CancellationPending)
			{
				Console.WriteLine("worker is cancelling previous operation");
				return;
			}

			nistWorker.WorkerReportsProgress = true;
			nistWorker.WorkerSupportsCancellation = true;
			nistWorker.DoWork += NistWorker_DoWork;
			nistWorker.ProgressChanged += NistWorker_ProgressChanged;
			nistWorker.RunWorkerCompleted += NistWorker_RunWorkerCompleted;
			nistWorker.RunWorkerAsync();
		}

		private void NistWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			Console.WriteLine("worker status changed to " + e.ProgressPercentage.ToString());
			switch (e.ProgressPercentage)
			{
				case 1:
					progressWindow.ProgressText = "Connecting to time server...";
					break;
				case 9:
					progressWindow.ProgressText = "Applying data...";
					break;
				case 10:
					progressWindow.ProgressText = "Finished.";
					break;
			}
			progressWindow.ProgressValue = e.ProgressPercentage * 10;
		}

		void CloseProgressWindow()
		{
			Console.WriteLine(">>>> Closing Progress Window...");
			Console.WriteLine(">> Removing events...");
			progressWindow.Canceled -= ProgressWindow_Canceled;
			Console.WriteLine(">> Closing window...");
			progressWindow.Close();
			Console.WriteLine(">> Removing references");
			progressWindow.Dispose();
			progressWindow = null;
			Console.WriteLine(">>>> Progress Window Closed.");
		}

		private void NistWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Console.WriteLine("NistWorker_RunWorkerCompleted");
			CloseProgressWindow();
			nistWorker.Dispose();
			nistWorker = null;
		}

		private void ProgressWindow_Canceled(object sender, EventArgs e)
		{
			Console.WriteLine("attempting cancellation...");
			if (nistWorker.WorkerSupportsCancellation)
			{
				Console.WriteLine("closing progress window...");
				CloseProgressWindow();
				Console.WriteLine("cancelling worker thread cancelled.");
				nistWorker.CancelAsync();
				nistWorker.Dispose();
				nistWorker = null;
			}
			else
			{
				Console.WriteLine("thread does not support cancellation...");
			}
		}

		private void NistWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			Console.WriteLine("Worker_DoWork");
			nistWorker.ReportProgress(1);
			SystemTime time;
			if (GetNistTime(out DateTime dt))
			{
				time = dt;
				nistWorker.ReportProgress(9);
				System.Threading.Thread.Sleep(500);
				NativeMethods.Win32SetSystemTime(ref time);
				isDirty = false;
				nistWorker.ReportProgress(10);
			}
			else
			{
				if ((sender as BackgroundWorker) == nistWorker)
				{
					nistWorker.CancelAsync();
					MessageBox.Show("Erro de conexão.");
				}
			}
		}

		public bool GetNistTime(out DateTime dt)
		{
			var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.google.com");
			try
			{
				var response = myHttpWebRequest.GetResponse();
				string todaysDates = response.Headers["date"];
				dt = DateTime.ParseExact(todaysDates,
										   "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
										   CultureInfo.InvariantCulture.DateTimeFormat,
										   DateTimeStyles.AssumeLocal);

				return true;
			}
			catch (Exception exp)
			{
				Console.WriteLine(exp);
			}
			dt = DateTime.MinValue;
			return false;
		}

		void LoadValues()
		{
			checkBox1.Checked = Properties.Settings.Default.RestoreOnClose;
			numericUpDown1.Value = Properties.Settings.Default.ManualHour;
			numericUpDown2.Value = Properties.Settings.Default.ManualMinute;
			numericUpDown3.Value = Properties.Settings.Default.ManualSecond;
			numericUpDown4.Value = Properties.Settings.Default.AutoHour;
			numericUpDown5.Value = Properties.Settings.Default.AutoMinute;
			numericUpDown6.Value = Properties.Settings.Default.AutoSecond;
		}

		void SaveValue<T>(string key, T value)
		{
			Properties.Settings.Default[key] = value;
			Properties.Settings.Default.Save();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			startupDateTime = DateTime.UtcNow;
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (isDirty && Properties.Settings.Default.RestoreOnClose)
			{
				ApplyNistTime();
				MessageBox.Show("Aguarde...");
			}
		}

		private void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			SaveValue("RestoreOnClose", (sender as CheckBox).Checked);
		}

		void PerformTimeChange(ushort hour, ushort minute, ushort second)
		{
			NativeMethods.Win32GetSystemTime(ref modifiedTime);
			modifiedTime.Add(hour, minute, second);
			NativeMethods.Win32SetSystemTime(ref modifiedTime);
			isDirty = true;
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			DisableAutomaticTimeChange();
			PerformTimeChange((ushort)numericUpDown1.Value, 0, 0);
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			DisableAutomaticTimeChange();
			PerformTimeChange(0, (ushort)numericUpDown2.Value, 0);
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			DisableAutomaticTimeChange();
			PerformTimeChange(0, 0, (ushort)numericUpDown3.Value);
		}

		private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			(sender as NumericUpDown).Value %= 24;
			SaveValue("ManualHour", (ushort)(sender as NumericUpDown).Value);
		}

		private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
		{
			(sender as NumericUpDown).Value %= 60;
			SaveValue("ManualMinute", (ushort)(sender as NumericUpDown).Value);
		}

		private void NumericUpDown3_ValueChanged(object sender, EventArgs e)
		{
			(sender as NumericUpDown).Value %= 60;
			SaveValue("ManualSecond", (ushort)(sender as NumericUpDown).Value);
		}

		private void NumericUpDown4_ValueChanged(object sender, EventArgs e)
		{
			SetAutoProps((sender as NumericUpDown), "AutoHour", 24);
		}

		private void NumericUpDown5_ValueChanged(object sender, EventArgs e)
		{
			SetAutoProps((sender as NumericUpDown), "AutoMinute", 60);
		}

		private void NumericUpDown6_ValueChanged(object sender, EventArgs e)
		{
			SetAutoProps((sender as NumericUpDown), "AutoSecond", 60);
		}

		void SetAutoProps(NumericUpDown sender, string method, decimal cap)
		{
			bool reenable = checkBox2.Checked;
			DisableAutomaticTimeChange();
			(sender as NumericUpDown).Value %= cap;
			SaveValue(method, (ushort)(sender as NumericUpDown).Value);
			if (reenable)
			{
				checkBox2.Checked = true;
			}
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			UpdateAutoTimeProgress();
		}

		void UpdateAutoTimeProgress()
		{
			if (!checkBox2.Checked)
			{
				return;
			}

			// Calculate Total Span
			var totalSpan = (lastAutoApplyTime - nextAutoApplyTime).Duration();
			var totalMS = totalSpan.TotalMilliseconds;
			if (totalMS == 0)
			{
				return;
			}

			// Calculate Current Span
			var currentSpan = (DateTime.UtcNow - lastAutoApplyTime);
			var currentMS = currentSpan.TotalMilliseconds;
			var percent = (currentMS / totalMS);

			// Evaluate Progress
			if (percent >= 1)
			{
				PerformTimeChange((ushort)numericUpDown1.Value, (ushort)numericUpDown2.Value, (ushort)numericUpDown3.Value);
				CalculateAutoApply();
				return;
			}

			// Update Progress Bar
			var pct = 100 - (int)(percent * 100);
			progressBar1.Value = pct < 0 ? 0 : pct > 100 ? 100 : pct;
		}

		private void CheckBox2_CheckedChanged(object sender, EventArgs e)
		{
			CalculateAutoApply();
			progressBar1.Value = 0;
		}

		void CalculateAutoApply()
		{
			lastAutoApplyTime = DateTime.UtcNow;

			int hour, minute, second;
			hour = Properties.Settings.Default.AutoHour;
			minute = Properties.Settings.Default.AutoMinute;
			second = Properties.Settings.Default.AutoSecond;

			nextAutoApplyTime = lastAutoApplyTime.AddHours(hour).AddMinutes(minute).AddSeconds(second);
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			ApplyNistTime();
		}
	}
}
