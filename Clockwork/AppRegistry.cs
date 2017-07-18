using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace Clockwork
{
	public class AppRegistry
	{
		const string fileExtension = ".cwc";
		const string rootKey = "Clockwork" + fileExtension;
		readonly string appPath;
		readonly string openFilePath;
		readonly string iconPath;

		public AppRegistry()
		{
			Console.WriteLine("AppRegistry instance created");
			appPath = Application.ExecutablePath.ToLower();
			openFilePath = appPath + " \"%1\"";
			iconPath = appPath + ",2";
		}

		public void Checkup()
		{
			Console.WriteLine("Checking up...");
			RegistryKey registryCheckUp;
			registryCheckUp = Registry.CurrentUser.OpenSubKey(rootKey);
			if (registryCheckUp == null)
			{
				WriteEntries();
				Console.WriteLine("Registry entries added to current user.");
			}
			else
			{
				Console.WriteLine("Entry exists.");
			}
		}

		public void WriteEntries()
		{
			// Write Entries
			RegistryKey appKey;
			appKey = Registry.CurrentUser.CreateSubKey(rootKey);
			appKey.SetValue("Default", "Clockwork config file");

			RegistryKey iconKey;
			iconKey = appKey.CreateSubKey("DefaultIcon");
			iconKey.SetValue("", iconPath);
			appKey.Close();

			RegistryKey filetypekey = Registry.CurrentUser.CreateSubKey(fileExtension);
			filetypekey.SetValue("", rootKey);
			filetypekey.Close();
		}
	}
}
