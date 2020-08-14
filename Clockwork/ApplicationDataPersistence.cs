using System;
using System.IO;
using System.Xml.Serialization;

namespace Clockwork
{
	[Serializable]
	public struct AppData
	{
		public int mhour, mmin, msec, ahour, amin, asec;
		public bool restore;
		public DateTime lastDate;
	}

	public interface IPersistable
	{
		void Save();
		bool HasConfig();
		bool Load();
	}

	public class DataPersistencePath
	{
		public readonly string rootFolder;
		public readonly string filename;

		public string FilePath
		{
			get
			{
				return Path.Combine(rootFolder, filename);
			}
		}

		public DataPersistencePath(string rootFolder, string filename)
		{
			this.rootFolder = rootFolder;
			this.filename = filename;
		}
	}

	public class AppDataPersistence : IPersistable
	{
		protected readonly DataPersistencePath currentPersistencePath;

		public AppDataPersistence(string folderPath, string filename)
		{
			Logger.Append("Creating Persistence object: " + Path.Combine(folderPath, filename));
			currentPersistencePath = new DataPersistencePath(folderPath, filename);
		}

		public virtual void Save()
		{
			if (!Directory.Exists(currentPersistencePath.rootFolder))
				Directory.CreateDirectory(currentPersistencePath.rootFolder);

			if (File.Exists(currentPersistencePath.FilePath))
				File.Delete(currentPersistencePath.FilePath);
			
			AppData data = new AppData()
			{
				mhour = Properties.Settings.Default.ManualHour,
				mmin = Properties.Settings.Default.ManualMinute,
				msec = Properties.Settings.Default.ManualSecond,
				ahour = Properties.Settings.Default.AutoHour,
				amin = Properties.Settings.Default.AutoMinute,
				asec = Properties.Settings.Default.AutoSecond,
				restore = Properties.Settings.Default.RestoreOnClose,
				lastDate = Properties.Settings.Default.LastDate
			};

			Logger.Append("Writing contents to " + currentPersistencePath.FilePath);

			using (StreamWriter file = new StreamWriter(currentPersistencePath.FilePath))
			{
				XmlSerializer writer = new XmlSerializer(typeof(AppData));
				writer.Serialize(file, data);
			}
		}

		public virtual bool HasConfig()
		{
			return File.Exists(currentPersistencePath.FilePath);
		}

		public virtual bool Load()
		{
			Logger.Append("Loading config...");
			if (HasConfig())
			{
				Logger.Append("... config file found");
				using (StreamReader file = new StreamReader(currentPersistencePath.FilePath))
				{
					Logger.Append("... reading file...");
					AppData data;
					try // XML File may be corrupt or badly formatted.
					{
						XmlSerializer reader = new XmlSerializer(typeof(AppData));
						data = (AppData)reader.Deserialize(file);

						Properties.Settings.Default.ManualHour = (ushort)data.mhour;
						Properties.Settings.Default.ManualMinute = (ushort)data.mmin;
						Properties.Settings.Default.ManualSecond = (ushort)data.msec;
						Properties.Settings.Default.AutoHour = (ushort)data.ahour;
						Properties.Settings.Default.AutoMinute = (ushort)data.amin;
						Properties.Settings.Default.AutoSecond = (ushort)data.asec;
						Properties.Settings.Default.RestoreOnClose = data.restore;
						Properties.Settings.Default.LastDate = data.lastDate;
					}
					catch {
						Logger.Append("File corrupt or badly formatted.");
					};

				}
				Logger.Append("... done");
				return true;
			}
			Logger.Append("... config file not found");
			return false;
		}
	}

	public class StandardApplicationPersistence : IPersistable
	{
		const string companyName = "DaniloNishimura";
		const string configFileName = "clockwork_config";
		readonly string localAppDataPath;
		readonly string companyFolderPath;
		AppDataPersistence persistence;

		public StandardApplicationPersistence()
		{
			Logger.Append("Creating Standard Application Persistence object");
			localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			companyFolderPath = Path.Combine(localAppDataPath, companyName);

			persistence = new AppDataPersistence(companyFolderPath, string.Concat(configFileName, ".xml"));
		}

		public void Save()
		{
			persistence.Save();
		}

		public bool HasConfig()
		{ return persistence.HasConfig(); }

		public bool Load()
		{
			return persistence.Load();
		}
	}

}