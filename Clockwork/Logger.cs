using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clockwork
{
	static public class Logger
	{
		static readonly string logFolder;
		static readonly string filePath;

		static Logger()
		{
			var productName = Application.ProductName;
			logFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), productName);
			filePath = Path.Combine(logFolder, "log.txt");

			if (!Directory.Exists(logFolder))
			{
				Directory.CreateDirectory(logFolder);
			}

			Append("################ Application START ################");
		}

		static public void Append(string text)
		{
			using (StreamWriter w = File.AppendText(filePath))
			{
				Log(text, w);
				Console.WriteLine("[Logger] " + text);
			}
		}

		static void Log(string logMessage, TextWriter w)
		{
			w.Write("\r\n{1}", DateTime.Now.ToString(), logMessage);
		}
	}
}
