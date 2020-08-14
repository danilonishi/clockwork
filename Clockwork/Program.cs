using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ServiceProcess;

namespace Clockwork
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			App myApp = new App();
			myApp.Run(GetApplicationArguments().ToArray());
		}

		static public List<string> GetApplicationArguments()
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
	}

	public class App : Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
	{
		public App()
		{
			Logger.Append("Program init.");

			this.IsSingleInstance = true;
			this.EnableVisualStyles = true;
			this.ShutdownStyle = Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses;
			this.StartupNextInstance += App_StartupNextInstance;
			try
			{
				DisableWindowsTimeService();
			}
			catch(System.Exception exp)
			{
				Console.WriteLine(exp);
			}
		}

		void DisableWindowsTimeService()
		{
			//TODO: RESTORE CLOCK STATE

			//*
			// first, stop the service if it's started.
			ServiceController controller = new ServiceController("W32Time");
			if (controller.Status == ServiceControllerStatus.Running)
			{
				controller.Stop();
			}
			//*/


			// now, set the startup type of the service.
			RegistryKey localMachine = Registry.LocalMachine;
			RegistryKey w32time = localMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\W32Time", true);
			// set value to 2 for automatic, 3 for manual, or 4 for disabled.
			w32time.SetValue("Start", 4);
		}

		protected override void OnCreateMainForm()
		{
			Logger.Append("Creating new Form.");

			this.MainForm = new Form1();
			((Form1)this.MainForm).Args = new string[this.CommandLineArgs.Count];
			this.CommandLineArgs.CopyTo(((Form1)this.MainForm).Args, 0);
		}

		private void App_StartupNextInstance(object sender, Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs e)
		{
			Logger.Append("Sending data to other instance");

			string[] args = new string[e.CommandLine.Count];
			e.CommandLine.CopyTo(args, 0);

			object[] parameters = new object[1];
			parameters[0] = args;

			this.MainForm.Invoke(
				new Form1.ProcessArgumentsDelegate(((Form1)this.MainForm).ProcessArguments)
				, parameters
				);
		}
	}
}
