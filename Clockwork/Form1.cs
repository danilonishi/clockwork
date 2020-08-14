using System;
using System.Windows.Forms;
using Clockwork.CWTime;
using System.Diagnostics;
using System.Security.Principal;
using System.Reflection;
using System.Deployment.Application;
using System.Collections.Generic;
using System.Threading;

namespace Clockwork
{
	public partial class Form1 : Form
	{
		static Mutex _mutex;

		AutoTimeUpdater updater;
		CustomTime customTime;

		Stopwatch watch;
		DateTime startupDateTime;
		DateTime adjustedDateTime;
		DateTime freezeTime;
		bool isTimeFrozen;

		bool IsRunAsAdministrator()
		{
			return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
		}

		bool containsUnsavedChanges;
		bool ContainsUnsavedChanges
		{
			get
			{
				return containsUnsavedChanges;
			}
			set
			{
				containsUnsavedChanges = value;
				UpdateWindowTitle();
			}
		}

		string profileName = string.Empty;

		public void UpdateWindowTitle()
		{
			if (!string.IsNullOrWhiteSpace(profileName))
			{
				var text = string.Format("Clockwork 1.0 | Profile:{0}{1}", profileName, ContainsUnsavedChanges ? " (Not Saved)" : "");
				if (Text != text)
				{
					Text = text;
					Logger.Append("Title updated to " + Text);
				}
			}
			else
			{
				if (Text != "Clockwork 1.0")
				{
					Text = "Clockwork 1.0";
					Logger.Append("Title updated to " + Text);
				}
			}
		}

		public void SetProfileTitleText(string profileName)
		{
			this.profileName = profileName;
			UpdateWindowTitle();
		}

		public List<string> GetApplicationArguments()
		{
			List<string> arguments = new List<string>();
			arguments.AddRange(Environment.GetCommandLineArgs());
			Logger.Append("Added Environment command line arguments. ArgCount:" + arguments.Count);

			try
			{
				if (AppDomain.CurrentDomain.SetupInformation.ActivationArguments != null && AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData.Length > 0)
				{
					arguments.AddRange(AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData);
					Logger.Append("Added AppDomain arguments. ArgCount:" + arguments.Count);
				}
				else
				{
					Logger.Append("No AppDomain arguments. Skipping.");
				}
			}
			catch (Exception e)
			{
				Logger.Append("Could not read AppDomain arguments. Reason:" + e.ToString());
			}

			return arguments;
		}

		public delegate void ProcessArgumentsDelegate(string[] arguments);

		public string[] Args;
		
		public void ProcessArguments(string[] arguments)
		{
			Logger.Append("Processing arguments");
			string profilePath = string.Empty;
			int idx = 0;
			Uri uri;
			foreach (var arg in arguments)
			{
				var filepath = arg;
				uri = new Uri(arg);
				if (uri.IsFile)
				{
					filepath = uri.LocalPath;
				}
				Logger.Append(string.Format("Argument {0}: {1}", idx++, arg));
				var path = System.IO.Path.GetFullPath(filepath);
				if (System.IO.File.Exists(filepath))
				{
					if (filepath.EndsWith(".cwc"))
					{
						Logger.Append("CWC File found in environment arguments.");
						profilePath = filepath;
					}
				}
			}

			// If found, load its data
			if (!string.IsNullOrWhiteSpace(profilePath))
			{
				LoadDataFromPath(profilePath);
			}

		}

		void StartNewProcess()
		{
			var processInfo = new ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase)
			{
				// The following properties run the new process as administrator
				UseShellExecute = true,
				Verb = "runas"
			};

			var arguments = GetApplicationArguments();
			if (arguments.Count > 0)
			{
				int idx = 0;
				string fullarg = string.Empty;
				foreach (var arg in arguments)
				{
					Logger.Append(string.Format("Argument {0}: {1}", idx, arg));
					if (idx > 0)
					{
						fullarg += string.Format("\"{0}\"", arg);
					}
					idx++;
				}

				Logger.Append("Starting new process with arguments:" + fullarg);
				processInfo.Arguments = fullarg;
			}

			// Start the new process
			try
			{
				Process.Start(processInfo);
			}
			catch (Exception)
			{
				// The user did not allow the application to run as administrator
				string windowMessage = "This application works by modifying your system time.\nUnfortunately, Windows *requires* administrator previlegies to modify system clock. The app can not work without it.";
				string windowTitle = "Administrator previlegies required";
				DialogResult result = MessageBox.Show(windowMessage, windowTitle, MessageBoxButtons.RetryCancel);
				switch (result)
				{
					case DialogResult.None:
					case DialogResult.OK:
					case DialogResult.Retry:
					case DialogResult.Yes:
						StartNewProcess();
						break;
					case DialogResult.Abort:
					case DialogResult.Cancel:
					case DialogResult.Ignore:
					case DialogResult.No:
					default:
						break;
				}

				// Shut down the current process
				Environment.Exit(0);
			}
		}

		void ReadCWCFile()
		{
			Logger.Append("Checking CWC file...");
			//Check if a CWC file is provided by the environment
			ProcessArguments(GetApplicationArguments().ToArray());
		}

		bool IsMainInstance()
		{
			try
			{
				// Try to open existing mutex.
				Mutex.OpenExisting("Clockwork");
			}
			catch
			{
				// If exception occurred, there is no such mutex.
				_mutex = new Mutex(true, "Clockwork");

				// Only one instance.
				return true;
			}
			// More than one instance.
			return false;
		}

		void StartupLogic()
		{
			if (!IsMainInstance())
			{

			}

			Logger.Append("Cheking for other instances");
			var exists = Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)).Length > 1;
			if (exists)
			{
				Logger.Append("Other instance is open.");
				//MessageBox.Show("Clockwork is already running.");
				//Environment.Exit(0);
			}

			var runningAsAdministrator = IsRunAsAdministrator();

#if !DEBUG
			if (!runningAsAdministrator)
			{
				Logger.Append("Not running as administrator");
				StartNewProcess();
				// Shut down the current process
				Environment.Exit(0);
			}
#endif
		}


		public Form1()
		{
			Logger.Append("Application Startup");

			StartupLogic();

			Logger.Append("Initializing Clockwork window");
			InitializeComponent();

			Logger.Append("Initializing Persistence");
			//Default (safe) Persistence Data
			standardPersistence = new StandardApplicationPersistence();
			if (Properties.Settings.Default.FirstRun)
			{
				if (standardPersistence.HasConfig())
				{
					standardPersistence.Load();
					Properties.Settings.Default.FirstRun = false;
				}
				else
				{
					standardPersistence.Save();
				}
			}
			SetProfileTitleText("Default");

			ReadCWCFile();

			ReadProperties();

			toolStripStatusLabel1.Text = "Timer not running";
			toolStripProgressBar1.Visible = false;
		}

		IPersistable standardPersistence;
		IPersistable customPersistenceData;

		void ReadProperties()
		{
			manualHourIncrement.Value = Properties.Settings.Default.ManualHour;
			manualMinuteIncrement.Value = Properties.Settings.Default.ManualMinute;
			manualSecondIncrement.Value = Properties.Settings.Default.ManualSecond;
			automaticHourIncrement.Value = Properties.Settings.Default.AutoHour;
			automaticMinuteIncrement.Value = Properties.Settings.Default.AutoMinute;
			automaticSecondIncrement.Value = Properties.Settings.Default.AutoSecond;
			fetchDatetimeCheckbox.Checked = Properties.Settings.Default.RestoreOnClose;
			// last date needs to be restored after web time refresh;
			InitializeTimeValue();
		}

		private void InitializeTimeValue()
		{
			updater = new AutoTimeUpdater();
			customTime = new CustomTime();
			watch = new Stopwatch();

			RefreshWebTime();

			if (!Properties.Settings.Default.FirstRun)
			{
				DateTime _lastDate = Properties.Settings.Default.LastDate;
				if (_lastDate.Year > 1000)
				{
					/*
					var msg = string.Format("Restaurar data da última execução?\n{0}", _lastDate.ToString());
					var result = MessageBox.Show(msg, "Recuperar valor salvo", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						adjustedDateTime = Properties.Settings.Default.LastDate;
						customTime.SetSystemTime(adjustedDateTime);
					}
					//*/
					adjustedDateTime = Properties.Settings.Default.LastDate;
					customTime.SetSystemTime(adjustedDateTime);
				}
			}
			else
			{
				Logger.Append("First run");
			}
		}

		private void RefreshWebTime()
		{
			if (customTime.GetWebTime(out DateTime time))
			{
				adjustedDateTime = startupDateTime = realDatePicker.Value = adjustedDatePicker.Value = time;
			}
			else
			{
				adjustedDateTime = realDatePicker.Value = adjustedDatePicker.Value = DateTime.UtcNow;
				startupDateTime = DateTime.UtcNow.ToLocalTime();
			}
			watch.Restart();
			customTime.SetSystemTime(adjustedDateTime);
		}

		string dateString = "HH:mm:ss";

		DateTime localDisplayTime;

		private void UpdateTimers()
		{
			adjustedDateTime = customTime.GetSystemTime();

			if (isTimeFrozen)
			{
				adjustedDateTime = freezeTime;
				customTime.SetSystemTime(adjustedDateTime);
			}
			localDisplayTime = adjustedDateTime.ToLocalTime();
			adjustedDatePicker.Value = adjustedTimePicker.Value = localDisplayTime;
			adjustedTimeLabel.Text = localDisplayTime.ToString(dateString);

			realTimePicker.Value = realDatePicker.Value = startupDateTime.AddMilliseconds(watch.Elapsed.TotalMilliseconds);
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

				ContainsUnsavedChanges = true;
			}
		}

		public void FullSave()
		{
			Properties.Settings.Default.LastDate = adjustedDateTime.ToLocalTime();
			Properties.Settings.Default.FirstRun = false;
			Properties.Settings.Default.Save();

			standardPersistence.Save();

			if (customPersistenceData != null)
			{
				customPersistenceData.Save();
			}

			ContainsUnsavedChanges = false;
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			FullSave();
			if (Properties.Settings.Default.RestoreOnClose)
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
			PerformTimeChange((ushort)manualHourIncrement.Value, (ushort)manualMinuteIncrement.Value, (ushort)manualSecondIncrement.Value);
		}

		private void ManualHourChanged(object sender, EventArgs e)
		{
			(sender as NumericUpDown).Value %= 24;
			SaveValue("ManualHour", (ushort)(sender as NumericUpDown).Value);
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
			bool reenable = EnableAutoUpdate;
			DisableAutomaticTimeChange();
			(sender as NumericUpDown).Value %= cap;
			if ((ushort)(sender as NumericUpDown).Value != (ushort)Properties.Settings.Default[method])
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

		bool enableAutoUpdate;
		public bool EnableAutoUpdate
		{
			set
			{
				enableAutoUpdate = value;
				SetAutoBehaviour();
			}
			get
			{
				return enableAutoUpdate;
			}
		}

		void SetAutoBehaviour()
		{
			if (updater != null)
			{
				if (enableAutoUpdate)
				{
					updater.EventMilliseconds =
						Properties.Settings.Default.AutoSecond * 1000 +
						Properties.Settings.Default.AutoMinute * 60000 +
						Properties.Settings.Default.AutoHour * 3600000;

					updater.OnTimer += HandleUpdaterTimer;
					updater.OnUpdate += HandleUpdaterUpdate;
					toolStripProgressBar1.Visible = true;
					updater.Restart();
				}
				else
				{
					updater.OnTimer -= HandleUpdaterTimer;
					updater.OnUpdate -= HandleUpdaterUpdate;
					updater.Stop();
					toolStripStatusLabel1.Text = "Timer not running";
					toolStripProgressBar1.Visible = false;
				}
			}
			toolStripProgressBar1.Value = 0;
		}

		private void HandleUpdaterUpdate()
		{
			string manualTime = string.Format("{0}:{1}:{2}", manualHourIncrement.Value.ToString("00"), manualMinuteIncrement.Value.ToString("00"), manualSecondIncrement.Value.ToString("00"));
			string automaticTime = string.Format("{0}:{1}:{2}", automaticHourIncrement.Value.ToString("00"), automaticMinuteIncrement.Value.ToString("00"), automaticSecondIncrement.Value.ToString("00"));
			toolStripStatusLabel1.Text = string.Format("Incrementing {0} every {1}", manualTime, automaticTime);
			toolStripProgressBar1.Value = 100 - updater.Percent;
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
			SetAutoIncrementState(!EnableAutoUpdate);
		}

		void SetAutoIncrementState(bool enabled)
		{
			EnableAutoUpdate = enabled;
			//autoIncrementCheckbox.Checked = enabled;
			UpdateIncrementButtonText();
		}

		void UpdateIncrementButtonText()
		{
			autoIncrementButton.Text = EnableAutoUpdate ? "Disable autoincrementation" : "Enable autoincrementation";
		}

		private void AdjustedTimePicker_ValueChanged(object sender, EventArgs e)
		{
			if ((adjustedDateTime.ToLocalTime() - (sender as DateTimePicker).Value).TotalSeconds != 0)
			{
				adjustedDateTime = (sender as DateTimePicker).Value;
				customTime.SetSystemTime(adjustedDateTime);
				ContainsUnsavedChanges = true;
			}
		}

		private void AdjustedDatePicker_ValueChanged(object sender, EventArgs e)
		{
			if ((adjustedDateTime.ToLocalTime() - (sender as DateTimePicker).Value).TotalSeconds != 0)
			{
				adjustedDateTime = (sender as DateTimePicker).Value;
				customTime.SetSystemTime(adjustedDateTime);
				ContainsUnsavedChanges = true;
			}
		}

		private void FreezeClockButton_Click(object sender, EventArgs e)
		{
			isTimeFrozen = !isTimeFrozen;
			(sender as Button).Text = isTimeFrozen ? "Unfreeze system clock" : "Freeze system clock";
			if (isTimeFrozen)
			{
				freezeTime = adjustedDateTime;
			}

			bool controlsEnabled = !isTimeFrozen;

			adjustedDatePicker.Enabled = adjustedTimePicker.Enabled = controlsEnabled;
			manualHourIncrement.Enabled = manualMinuteIncrement.Enabled = manualSecondIncrement.Enabled = controlsEnabled;
			automaticHourIncrement.Enabled = automaticMinuteIncrement.Enabled = automaticSecondIncrement.Enabled = controlsEnabled;
			manualHourButton.Enabled = controlsEnabled;
			autoIncrementButton.Enabled = controlsEnabled;
			fetchDatetimeButton.Enabled = controlsEnabled;

			if (controlsEnabled)
			{
				updater.Start();
			}
			else
			{
				updater.Stop();
			}
			ContainsUnsavedChanges = true;
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FullSave();
			ContainsUnsavedChanges = false;
		}

		private void loadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			saveFileDialog1.ShowDialog();
		}

		private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			var fullPath = (sender as OpenFileDialog).FileName;
			LoadDataFromPath(fullPath);
		}

		void LoadDataFromPath(string path)
		{
			SetupPersistenceForPath(path);
			customPersistenceData.Load();
			ReadProperties();
			ContainsUnsavedChanges = false;
		}

		private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			var fullPath = (sender as SaveFileDialog).FileName;
			SetupPersistenceForPath(fullPath);
			FullSave();
		}

		void SetupPersistenceForPath(string filepath)
		{
			var index = filepath.LastIndexOf('\\');
			var filename = filepath.Substring(index + 1);
			var folder = filepath.Substring(0, index);

			var fileNoExt = filename.Substring(0, filename.IndexOf('.'));

			SetProfileTitleText(fileNoExt);

			customPersistenceData = new AppDataPersistence(folder, filename);
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FullSave();

			if (Properties.Settings.Default.RestoreOnClose)
			{
				DisableAutomaticTimeChange();
				customTime.SyncSystemTimeToWeb();
			}

			// Shut down the current process
			Environment.Exit(0);
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutBox1 box = new AboutBox1();
			box.Show();
		}
	}
}