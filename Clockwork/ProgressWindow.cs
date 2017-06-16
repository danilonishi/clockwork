using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clockwork
{

	public partial class ProgressWindow : Form
	{

		public event EventHandler<EventArgs> Canceled;

		public int ProgressValue
		{
			set { progressBar1.Value = value; }
		}

		public string ProgressText
		{
			set { label1.Text = value; }
		}

		public ProgressWindow()
		{
			InitializeComponent();
			FormClosed += ProgressWindow_FormClosed;
			FormClosing += ProgressWindow_FormClosing;
		}

		private void ProgressWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			DispatchCancelEvent(e);
		}

		private void ProgressWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			DispatchCancelEvent(e);
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			DispatchCancelEvent(e);
		}

		void DispatchCancelEvent(EventArgs e)
		{
			Canceled?.Invoke(this, e);
		}

	}

}
