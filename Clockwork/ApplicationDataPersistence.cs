using System;
using System.IO;
using System.Xml.Serialization;

namespace Clockwork
{
	public static class ApplicationDataPersistence
	{
		[Serializable]
		public struct AppData
		{
			public int mhour, mmin, msec, ahour, amin, asec;
			public bool restore;
		}

		const string companyName = "DaniloNishimura";
		const string configFileName = "clockwork_config";
		static readonly string localAppDataPath;
		static readonly string companyFolderPath;
		static readonly string configFilePath;
		static readonly string oldConfigFilePath;

		static ApplicationDataPersistence()
		{
			localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			companyFolderPath = Path.Combine(localAppDataPath, companyName);
			configFilePath = Path.Combine(companyFolderPath, string.Concat(configFileName, ".xml"));
			oldConfigFilePath = Path.Combine(companyFolderPath, string.Concat(configFileName, ".old"));
		}

		static public void SaveToAppData()
		{
			Console.WriteLine("SaveToAppData...");
			if (!Directory.Exists(companyFolderPath))
			{
				Console.WriteLine("... Creating Directory: " + companyFolderPath);
				Directory.CreateDirectory(companyFolderPath);
			}

			Console.WriteLine("... creating persistance data");
			AppData data = new AppData()
			{
				mhour = Properties.Settings.Default.ManualHour,
				mmin = Properties.Settings.Default.ManualMinute,
				msec = Properties.Settings.Default.ManualSecond,
				ahour = Properties.Settings.Default.AutoHour,
				amin = Properties.Settings.Default.AutoMinute,
				asec = Properties.Settings.Default.AutoSecond,
				restore = Properties.Settings.Default.RestoreOnClose
			};

			if (File.Exists(configFilePath))
			{
				Console.WriteLine("... backing up previous config file");
				File.Move(configFilePath, oldConfigFilePath);
			}

			try
			{
				Console.WriteLine("... starting file write");
				// Try writing new config file
				using (StreamWriter file = new StreamWriter(configFilePath))
				{
					XmlSerializer writer = new XmlSerializer(typeof(AppData));
					Console.WriteLine("... serializing data");
					writer.Serialize(file, data);
					file.Close();
					Console.WriteLine("... successfully saved");
				}
				if (File.Exists(oldConfigFilePath))
				{
					Console.WriteLine("... removing backup");
					File.Delete(oldConfigFilePath);
				}
			}
			catch (System.Exception exp)
			{
				Console.WriteLine("... [ERROR]: " + exp.ToString());
				// If error, restore old if existent
				if (File.Exists(oldConfigFilePath))
				{
					if (File.Exists(configFilePath))
					{
						Console.WriteLine("... removing config file");
						File.Delete(configFilePath);
					}
					Console.WriteLine("... restoring backup");
					File.Move(oldConfigFilePath, configFilePath);
				}
			}
			finally
			{
				Console.WriteLine("... finished.");
			}
		}

		static public bool HasAppDataConfig()
		{
			return File.Exists(configFilePath);
		}

		static public bool ReadFromAppData()
		{
			Console.WriteLine("ReadFromAppData...");
			if (HasAppDataConfig())
			{
				Console.WriteLine("... config file found");
				using (StreamReader file = new StreamReader(configFilePath))
				{
					Console.WriteLine("... reading file...");
					AppData data;
					XmlSerializer reader = new XmlSerializer(typeof(AppData));
					data = (AppData)reader.Deserialize(file);
					Properties.Settings.Default.ManualHour = (ushort)data.mhour;
					Properties.Settings.Default.ManualMinute = (ushort)data.mmin;
					Properties.Settings.Default.ManualSecond = (ushort)data.msec;
					Properties.Settings.Default.AutoHour = (ushort)data.ahour;
					Properties.Settings.Default.AutoMinute = (ushort)data.amin;
					Properties.Settings.Default.AutoSecond = (ushort)data.asec;
					Properties.Settings.Default.RestoreOnClose = data.restore;
				}
				Console.WriteLine("... done");
				return true;
			}
			Console.WriteLine("... config file not found");
			return false;
		}
	}
}