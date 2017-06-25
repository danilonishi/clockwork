﻿using System;
using System.Windows.Forms;
using Clockwork.CWTime;
using System.Diagnostics;
using System.Security.Principal;
using System.Reflection;
using System.Deployment.Application;

namespace Clockwork
{
	public partial class Form1 : Form
	{
		AutoTimeUpdater updater;
		CustomTime customTime;

		Stopwatch watch;
		DateTime startupDateTime;
		DateTime adjustedDateTime;
		DateTime freezeTime;
		bool isDirty;
		bool isTimeFrozen;

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

			if (ApplicationDeployment.IsNetworkDeployed)
			{
				Text = string.Format("Clockwork - v{0}", ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4));
			}
			else
			{
				string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
				Text = string.Format("Clockwork - v{0}", version);
			}

			LoadProperties();
			InitializeValues();
		}

		void LoadProperties()
		{
			if (Properties.Settings.Default.FirstRun)
			{
				if (ApplicationDataPersistence.HasAppDataConfig())
				{
					ApplicationDataPersistence.ReadFromAppData();
				}
				Properties.Settings.Default.FirstRun = false;
				Properties.Settings.Default.Save();
			}

			manualHourIncrement.Value = Properties.Settings.Default.ManualHour;
			manualMinuteIncrement.Value = Properties.Settings.Default.ManualMinute;
			manualSecondIncrement.Value = Properties.Settings.Default.ManualSecond;
			automaticHourIncrement.Value = Properties.Settings.Default.AutoHour;
			automaticMinuteIncrement.Value = Properties.Settings.Default.AutoMinute;
			automaticSecondIncrement.Value = Properties.Settings.Default.AutoSecond;
			fetchDatetimeCheckbox.Checked = Properties.Settings.Default.RestoreOnClose;
		}

		private void InitializeValues()
		{
			updater = new AutoTimeUpdater();
			customTime = new CustomTime();
			watch = new Stopwatch();

			RefreshWebTime();
		}

		private void RefreshWebTime()
		{
			if (customTime.GetWebTime(out DateTime time))
			{
				startupDateTime = adjustedDateTime = realDatePicker.Value = adjustedDatePicker.Value = time;
			}
			else
			{
				adjustedDateTime = realDatePicker.Value = adjustedDatePicker.Value = DateTime.UtcNow;
				startupDateTime = DateTime.UtcNow.ToLocalTime();
			}
			watch.Restart();
			customTime.SetSystemTime(time);
		}

		private void UpdateTimers()
		{
			string dateString = "HH:mm:ss";
			double ms = watch.Elapsed.TotalMilliseconds;

			adjustedDateTime = customTime.GetSystemTime();

			if (isTimeFrozen)
			{
				adjustedDateTime = freezeTime;
				customTime.SetSystemTime(adjustedDateTime);
			}

			adjustedTimeLabel.Text = adjustedDateTime.ToLocalTime().ToString(dateString);
			adjustedDatePicker.Value = adjustedDateTime.ToLocalTime();
			adjustedTimePicker.Value = adjustedDateTime.ToLocalTime();

			var expectedRealTime = startupDateTime.AddMilliseconds(ms);
			realTimePicker.Value = expectedRealTime;
			realDatePicker.Value = expectedRealTime;
		}

		void DisableAutomaticTimeChange()
		{
			SetAutoIncrementState(false);
		}

		void SaveValue<T>(string key, T value)
		{
			if (!Properties.Settings.Default[key].Equals(value))
			{
				Properties.Settings.Default[key] = value;
				Properties.Settings.Default.Save();

				ApplicationDataPersistence.SaveToAppData();
			}
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (isDirty && Properties.Settings.Default.RestoreOnClose)
			{
				DisableAutomaticTimeChange();
				customTime.SyncSystemTimeToWeb();
			}
		}

		void PerformTimeChange(ushort hour, ushort minute, ushort second)
		{
			adjustedDateTime = customTime.GetSystemTime();
			adjustedDateTime = adjustedDateTime.AddHours(hour).AddMinutes(minute).AddSeconds(second);
			customTime.SetSystemTime(adjustedDateTime);
			isDirty = true;
		}

		#region Time UI Controls

		private void FetchDatetimeCheckChanged(object sender, EventArgs e)
		{
			if ((sender as CheckBox).Checked != Properties.Settings.Default.RestoreOnClose)
			{
				SaveValue("RestoreOnClose", (sender as CheckBox).Checked);
			}
		}

		private void ManualHourClick(object sender, EventArgs e)
		{
			DisableAutomaticTimeChange();
			PerformTimeChange((ushort)manualHourIncrement.Value, 0, 0);
		}

		private void ManualMinuteClick(object sender, EventArgs e)
		{
			DisableAutomaticTimeChange();
			PerformTimeChange(0, (ushort)manualMinuteIncrement.Value, 0);
		}

		private void ManualSecondClick(object sender, EventArgs e)
		{
			DisableAutomaticTimeChange();
			PerformTimeChange(0, 0, (ushort)manualSecondIncrement.Value);
		}

		private void ManualHourChanged(object sender, EventArgs e)
		{
			(sender as NumericUpDown).Value %= 24;
			ushort hour1 = (ushort)Properties.Settings.Default["ManualHour"];
			ushort hour2 = (ushort)(sender as NumericUpDown).Value;
			if (hour1 != hour2)
			{
				SaveValue("ManualHour", (ushort)(sender as NumericUpDown).Value);
			}
		}

		private void ManualMinuteChanged(object sender, EventArgs e)
		{
			(sender as NumericUpDown).Value %= 60;
			SaveValue("ManualMinute", (ushort)(sender as NumericUpDown).Value);
		}

		private void ManualSecondchanged(object sender, EventArgs e)
		{
			(sender as NumericUpDown).Value %= 60;
			SaveValue("ManualSecond", (ushort)(sender as NumericUpDown).Value);
		}

		private void AutoHourChanged(object sender, EventArgs e)
		{
			SetAutoProps((sender as NumericUpDown), "AutoHour", 24);
		}

		private void AutoMinuteChanged(object sender, EventArgs e)
		{
			SetAutoProps((sender as NumericUpDown), "AutoMinute", 60);
		}

		private void AutoSecondChanged(object sender, EventArgs e)
		{
			SetAutoProps((sender as NumericUpDown), "AutoSecond", 60);
		}

		#endregion TimeUI

		void SetAutoProps(NumericUpDown sender, string method, decimal cap)
		{
			bool reenable = autoIncrementCheckbox.Checked;
			DisableAutomaticTimeChange();
			(sender as NumericUpDown).Value %= cap;
			ushort value1 = (ushort)(sender as NumericUpDown).Value;
			ushort value2 = (ushort)Properties.Settings.Default[method];
			if (value1 != value2)
			{
				SaveValue(method, (ushort)(sender as NumericUpDown).Value);
			}
			if (reenable)
			{
				SetAutoIncrementState(true);
			}
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			updater.Update();
			UpdateTimers();
		}

		private void CheckBox2_CheckedChanged(object sender, EventArgs e)
		{
			if ((sender as CheckBox).Checked)
			{
				int hour, minute, second;
				hour = Properties.Settings.Default.AutoHour;
				minute = Properties.Settings.Default.AutoMinute;
				second = Properties.Settings.Default.AutoSecond;

				updater.EventMilliseconds = second * 1000 + minute * 60000 + hour * 3600000;
				updater.OnTimer += HandleUpdaterTimer;
				updater.OnUpdate += HandleUpdaterUpdate;
				updater.Restart();
			}
			else
			{
				updater.OnTimer -= HandleUpdaterTimer;
				updater.OnUpdate -= HandleUpdaterUpdate;
				updater.Stop();
			}
			automaticProgressbar.Value = 0;
		}

		private void HandleUpdaterUpdate()
		{
			this.automaticProgressbar.Value = 100 - updater.Percent;
		}

		private void HandleUpdaterTimer()
		{
			PerformTimeChange((ushort)manualHourIncrement.Value, (ushort)manualMinuteIncrement.Value, (ushort)manualSecondIncrement.Value);
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			DisableAutomaticTimeChange();
			RefreshWebTime();
		}

		private void AdjustedDatePicker_CloseUp(object sender, EventArgs e)
		{
			var targetDate = (sender as DateTimePicker).Value;
			var currentTime = adjustedDateTime;

			var combinedDate = new DateTime(targetDate.Year, targetDate.Month, targetDate.Day, currentTime.Hour, currentTime.Minute, currentTime.Second, currentTime.Millisecond, DateTimeKind.Utc);
			adjustedDateTime = combinedDate;
			SystemTime time = SystemTime.FromUniversalTime(combinedDate);
			customTime.SetSystemTime(adjustedDateTime);
		}

		private void AutoIncrementButtonClick(object sender, EventArgs e)
		{
			SetAutoIncrementState(!autoIncrementCheckbox.Checked);
		}

		void SetAutoIncrementState(bool enabled)
		{
			autoIncrementCheckbox.Checked = enabled;
			UpdateIncrementButtonText();
		}

		void UpdateIncrementButtonText()
		{
			autoIncrementButton.Text = autoIncrementCheckbox.Checked ? "Desativar autoincrementação" : "Autoincrementar";
		}

		private void adjustedTimePicker_ValueChanged(object sender, EventArgs e)
		{
			if ((adjustedDateTime.ToLocalTime() - (sender as DateTimePicker).Value).TotalSeconds != 0)
			{
				adjustedDateTime = (sender as DateTimePicker).Value;
				customTime.SetSystemTime(adjustedDateTime);
			}
		}

		private void adjustedDatePicker_ValueChanged(object sender, EventArgs e)
		{
			if ((adjustedDateTime.ToLocalTime() - (sender as DateTimePicker).Value).TotalSeconds != 0)
			{
				adjustedDateTime = (sender as DateTimePicker).Value;
				customTime.SetSystemTime(adjustedDateTime);
			}
		}

		private void FreezeClockButton_Click(object sender, EventArgs e)
		{
			isTimeFrozen = !isTimeFrozen;
			(sender as Button).Text = isTimeFrozen ? "Descongelar relógio" : "Congelar relógio";
			if (isTimeFrozen)
			{
				freezeTime = adjustedDateTime;
			}

			bool controlsEnabled = !isTimeFrozen;

			adjustedDatePicker.Enabled = adjustedTimePicker.Enabled = controlsEnabled;
			manualHourIncrement.Enabled = manualMinuteIncrement.Enabled = manualSecondIncrement.Enabled = controlsEnabled;
			automaticHourIncrement.Enabled = automaticMinuteIncrement.Enabled = automaticSecondIncrement.Enabled = controlsEnabled;
			manualHourButton.Enabled = manualMinuteButton.Enabled = manualSecondButton.Enabled = controlsEnabled;
			autoIncrementButton.Enabled = controlsEnabled;
			automaticProgressbar.Enabled = controlsEnabled;

			if (controlsEnabled)
			{
				updater.Start();
			}
			else
			{
				updater.Stop();
			}
		}
	}
}