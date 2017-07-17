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

	public class DataPersistancePath
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

		public DataPersistancePath(string rootFolder, string filename)
		{
			this.rootFolder = rootFolder;
			this.filename = filename;
		}
	}

	public class AppDataPersistence : IPersistable
	{
		protected readonly DataPersistancePath currentPersistancePath;

		public AppDataPersistence(string folderPath, string filename)
		{
			Console.WriteLine("Creating Persistance object: " + Path.Combine(folderPath, filename));
			currentPersistancePath = new DataPersistancePath(folderPath, filename);
		}

		public virtual void Save()
		{
			if (!Directory.Exists(currentPersistancePath.rootFolder))
				Directory.CreateDirectory(currentPersistancePath.rootFolder);

			if (File.Exists(currentPersistancePath.FilePath))
				File.Delete(currentPersistancePath.FilePath);
			
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

			Console.WriteLine("Writing contents to " + currentPersistancePath.FilePath);

			using (StreamWriter file = new StreamWriter(currentPersistancePath.FilePath))
			{
				XmlSerializer writer = new XmlSerializer(typeof(AppData));
				writer.Serialize(file, data);
			}
		}

		public virtual bool HasConfig()
		{
			return File.Exists(currentPersistancePath.FilePath);
		}

		public virtual bool Load()
		{
			Console.WriteLine("Loading config...");
			if (HasConfig())
			{
				Console.WriteLine("... config file found");
				using (StreamReader file = new StreamReader(currentPersistancePath.FilePath))
				{
					Console.WriteLine("... reading file...");
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
						Console.WriteLine("File corrupt or badly formatted.");
					};

				}
				Console.WriteLine("... done");
				return true;
			}
			Console.WriteLine("... config file not found");
			return false;
		}
	}

	public class StandardApplicationPersistence : IPersistable
	{
		const string companyName = "DaniloNishimura";
		const string configFileName = "clockwork_config";
		readonly string localAppDataPath;
		readonly string companyFolderPath;
		AppDataPersistence persistance;

		public StandardApplicationPersistence()
		{
			Console.WriteLine("Creating Standard Application Persistance object");
			localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			companyFolderPath = Path.Combine(localAppDataPath, companyName);

			persistance = new AppDataPersistence(companyFolderPath, string.Concat(configFileName, ".xml"));
		}

		public void Save()
		{
			persistance.Save();
		}

		public bool HasConfig()
		{ return persistance.HasConfig(); }

		public bool Load()
		{
			return persistance.Load();
		}
	}

}