namespace Clockwork
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.manualHourButton = new System.Windows.Forms.Button();
			this.manualHourIncrement = new System.Windows.Forms.NumericUpDown();
			this.fetchDatetimeCheckbox = new System.Windows.Forms.CheckBox();
			this.manualHourLabel = new System.Windows.Forms.Label();
			this.manualMinuteIncrement = new System.Windows.Forms.NumericUpDown();
			this.manualSecondIncrement = new System.Windows.Forms.NumericUpDown();
			this.manualMinuteLabel = new System.Windows.Forms.Label();
			this.manualSecondLabel = new System.Windows.Forms.Label();
			this.freezeClockButton = new System.Windows.Forms.Button();
			this.autoIncrementButton = new System.Windows.Forms.Button();
			this.autoHourLabel = new System.Windows.Forms.Label();
			this.autoSecondLabel = new System.Windows.Forms.Label();
			this.automaticSecondIncrement = new System.Windows.Forms.NumericUpDown();
			this.autoMinuteLabel = new System.Windows.Forms.Label();
			this.automaticMinuteIncrement = new System.Windows.Forms.NumericUpDown();
			this.automaticHourIncrement = new System.Windows.Forms.NumericUpDown();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.fetchDatetimeButton = new System.Windows.Forms.Button();
			this.realtimeBox = new System.Windows.Forms.GroupBox();
			this.realTimePicker = new System.Windows.Forms.DateTimePicker();
			this.realDatePicker = new System.Windows.Forms.DateTimePicker();
			this.adjustedTimeBox = new System.Windows.Forms.GroupBox();
			this.adjustedTimePicker = new System.Windows.Forms.DateTimePicker();
			this.adjustedDatePicker = new System.Windows.Forms.DateTimePicker();
			this.adjustedTimeLabel = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.manualHourIncrement)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.manualMinuteIncrement)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.manualSecondIncrement)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.automaticSecondIncrement)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.automaticMinuteIncrement)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.automaticHourIncrement)).BeginInit();
			this.realtimeBox.SuspendLayout();
			this.adjustedTimeBox.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// manualHourButton
			// 
			resources.ApplyResources(this.manualHourButton, "manualHourButton");
			this.manualHourButton.Name = "manualHourButton";
			this.manualHourButton.UseVisualStyleBackColor = true;
			this.manualHourButton.Click += new System.EventHandler(this.ManualHourClick);
			// 
			// manualHourIncrement
			// 
			resources.ApplyResources(this.manualHourIncrement, "manualHourIncrement");
			this.manualHourIncrement.Name = "manualHourIncrement";
			this.manualHourIncrement.ValueChanged += new System.EventHandler(this.ManualHourChanged);
			// 
			// fetchDatetimeCheckbox
			// 
			resources.ApplyResources(this.fetchDatetimeCheckbox, "fetchDatetimeCheckbox");
			this.fetchDatetimeCheckbox.Name = "fetchDatetimeCheckbox";
			this.fetchDatetimeCheckbox.UseVisualStyleBackColor = true;
			this.fetchDatetimeCheckbox.CheckedChanged += new System.EventHandler(this.FetchDatetimeCheckChanged);
			// 
			// manualHourLabel
			// 
			resources.ApplyResources(this.manualHourLabel, "manualHourLabel");
			this.manualHourLabel.Name = "manualHourLabel";
			// 
			// manualMinuteIncrement
			// 
			resources.ApplyResources(this.manualMinuteIncrement, "manualMinuteIncrement");
			this.manualMinuteIncrement.Name = "manualMinuteIncrement";
			this.manualMinuteIncrement.ValueChanged += new System.EventHandler(this.ManualMinuteChanged);
			// 
			// manualSecondIncrement
			// 
			resources.ApplyResources(this.manualSecondIncrement, "manualSecondIncrement");
			this.manualSecondIncrement.Name = "manualSecondIncrement";
			this.manualSecondIncrement.ValueChanged += new System.EventHandler(this.ManualSecondchanged);
			// 
			// manualMinuteLabel
			// 
			resources.ApplyResources(this.manualMinuteLabel, "manualMinuteLabel");
			this.manualMinuteLabel.Name = "manualMinuteLabel";
			// 
			// manualSecondLabel
			// 
			resources.ApplyResources(this.manualSecondLabel, "manualSecondLabel");
			this.manualSecondLabel.Name = "manualSecondLabel";
			// 
			// freezeClockButton
			// 
			resources.ApplyResources(this.freezeClockButton, "freezeClockButton");
			this.freezeClockButton.Name = "freezeClockButton";
			this.freezeClockButton.UseVisualStyleBackColor = true;
			this.freezeClockButton.Click += new System.EventHandler(this.FreezeClockButton_Click);
			// 
			// autoIncrementButton
			// 
			resources.ApplyResources(this.autoIncrementButton, "autoIncrementButton");
			this.autoIncrementButton.Name = "autoIncrementButton";
			this.autoIncrementButton.UseVisualStyleBackColor = true;
			this.autoIncrementButton.Click += new System.EventHandler(this.AutoIncrementButtonClick);
			// 
			// autoHourLabel
			// 
			resources.ApplyResources(this.autoHourLabel, "autoHourLabel");
			this.autoHourLabel.Name = "autoHourLabel";
			// 
			// autoSecondLabel
			// 
			resources.ApplyResources(this.autoSecondLabel, "autoSecondLabel");
			this.autoSecondLabel.Name = "autoSecondLabel";
			// 
			// automaticSecondIncrement
			// 
			resources.ApplyResources(this.automaticSecondIncrement, "automaticSecondIncrement");
			this.automaticSecondIncrement.Name = "automaticSecondIncrement";
			this.automaticSecondIncrement.ValueChanged += new System.EventHandler(this.AutoSecondChanged);
			// 
			// autoMinuteLabel
			// 
			resources.ApplyResources(this.autoMinuteLabel, "autoMinuteLabel");
			this.autoMinuteLabel.Name = "autoMinuteLabel";
			// 
			// automaticMinuteIncrement
			// 
			resources.ApplyResources(this.automaticMinuteIncrement, "automaticMinuteIncrement");
			this.automaticMinuteIncrement.Name = "automaticMinuteIncrement";
			this.automaticMinuteIncrement.ValueChanged += new System.EventHandler(this.AutoMinuteChanged);
			// 
			// automaticHourIncrement
			// 
			resources.ApplyResources(this.automaticHourIncrement, "automaticHourIncrement");
			this.automaticHourIncrement.Name = "automaticHourIncrement";
			this.automaticHourIncrement.ValueChanged += new System.EventHandler(this.AutoHourChanged);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 10;
			this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			// 
			// fetchDatetimeButton
			// 
			resources.ApplyResources(this.fetchDatetimeButton, "fetchDatetimeButton");
			this.fetchDatetimeButton.Name = "fetchDatetimeButton";
			this.fetchDatetimeButton.UseVisualStyleBackColor = true;
			this.fetchDatetimeButton.Click += new System.EventHandler(this.Button4_Click);
			// 
			// realtimeBox
			// 
			this.realtimeBox.Controls.Add(this.realTimePicker);
			this.realtimeBox.Controls.Add(this.realDatePicker);
			resources.ApplyResources(this.realtimeBox, "realtimeBox");
			this.realtimeBox.Name = "realtimeBox";
			this.realtimeBox.TabStop = false;
			// 
			// realTimePicker
			// 
			this.realTimePicker.CalendarMonthBackground = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.realTimePicker, "realTimePicker");
			this.realTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.realTimePicker.Name = "realTimePicker";
			this.realTimePicker.ShowUpDown = true;
			// 
			// realDatePicker
			// 
			resources.ApplyResources(this.realDatePicker, "realDatePicker");
			this.realDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.realDatePicker.Name = "realDatePicker";
			// 
			// adjustedTimeBox
			// 
			this.adjustedTimeBox.Controls.Add(this.adjustedTimePicker);
			this.adjustedTimeBox.Controls.Add(this.adjustedDatePicker);
			this.adjustedTimeBox.Controls.Add(this.adjustedTimeLabel);
			resources.ApplyResources(this.adjustedTimeBox, "adjustedTimeBox");
			this.adjustedTimeBox.Name = "adjustedTimeBox";
			this.adjustedTimeBox.TabStop = false;
			// 
			// adjustedTimePicker
			// 
			this.adjustedTimePicker.CalendarMonthBackground = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.adjustedTimePicker, "adjustedTimePicker");
			this.adjustedTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.adjustedTimePicker.Name = "adjustedTimePicker";
			this.adjustedTimePicker.ShowUpDown = true;
			this.adjustedTimePicker.ValueChanged += new System.EventHandler(this.AdjustedTimePicker_ValueChanged);
			// 
			// adjustedDatePicker
			// 
			this.adjustedDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			resources.ApplyResources(this.adjustedDatePicker, "adjustedDatePicker");
			this.adjustedDatePicker.Name = "adjustedDatePicker";
			this.adjustedDatePicker.CloseUp += new System.EventHandler(this.AdjustedDatePicker_CloseUp);
			this.adjustedDatePicker.ValueChanged += new System.EventHandler(this.AdjustedDatePicker_ValueChanged);
			// 
			// adjustedTimeLabel
			// 
			resources.ApplyResources(this.adjustedTimeLabel, "adjustedTimeLabel");
			this.adjustedTimeLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.adjustedTimeLabel.Name = "adjustedTimeLabel";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
			resources.ApplyResources(this.menuStrip1, "menuStrip1");
			this.menuStrip1.Name = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
			// 
			// profileToolStripMenuItem
			// 
			this.profileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
			this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
			resources.ApplyResources(this.profileToolStripMenuItem, "profileToolStripMenuItem");
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			resources.ApplyResources(this.loadToolStripMenuItem, "loadToolStripMenuItem");
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
			resources.ApplyResources(this.statusStrip1, "statusStrip1");
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.SizingGrip = false;
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "json";
			this.openFileDialog1.FileName = "clockwork_config";
			resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.CreatePrompt = true;
			this.saveFileDialog1.DefaultExt = "json";
			this.saveFileDialog1.FileName = "clockwork_config";
			resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
			this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.manualHourButton);
			this.groupBox1.Controls.Add(this.manualHourLabel);
			this.groupBox1.Controls.Add(this.manualSecondLabel);
			this.groupBox1.Controls.Add(this.manualSecondIncrement);
			this.groupBox1.Controls.Add(this.manualHourIncrement);
			this.groupBox1.Controls.Add(this.manualMinuteLabel);
			this.groupBox1.Controls.Add(this.manualMinuteIncrement);
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.autoIncrementButton);
			this.groupBox2.Controls.Add(this.autoHourLabel);
			this.groupBox2.Controls.Add(this.automaticSecondIncrement);
			this.groupBox2.Controls.Add(this.automaticHourIncrement);
			this.groupBox2.Controls.Add(this.autoSecondLabel);
			this.groupBox2.Controls.Add(this.automaticMinuteIncrement);
			this.groupBox2.Controls.Add(this.autoMinuteLabel);
			resources.ApplyResources(this.groupBox2, "groupBox2");
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.TabStop = false;
			// 
			// Form1
			// 
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.freezeClockButton);
			this.Controls.Add(this.adjustedTimeBox);
			this.Controls.Add(this.realtimeBox);
			this.Controls.Add(this.fetchDatetimeButton);
			this.Controls.Add(this.fetchDatetimeCheckbox);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.TransparencyKey = System.Drawing.Color.DimGray;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.manualHourIncrement)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.manualMinuteIncrement)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.manualSecondIncrement)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.automaticSecondIncrement)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.automaticMinuteIncrement)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.automaticHourIncrement)).EndInit();
			this.realtimeBox.ResumeLayout(false);
			this.adjustedTimeBox.ResumeLayout(false);
			this.adjustedTimeBox.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button manualHourButton;
		private System.Windows.Forms.CheckBox fetchDatetimeCheckbox;
		private System.Windows.Forms.Label manualHourLabel;
		private System.Windows.Forms.NumericUpDown manualMinuteIncrement;
		private System.Windows.Forms.NumericUpDown manualSecondIncrement;
		private System.Windows.Forms.Label manualMinuteLabel;
		private System.Windows.Forms.Label manualSecondLabel;
		private System.Windows.Forms.Label autoHourLabel;
		private System.Windows.Forms.Label autoSecondLabel;
		private System.Windows.Forms.NumericUpDown automaticSecondIncrement;
		private System.Windows.Forms.Label autoMinuteLabel;
		private System.Windows.Forms.NumericUpDown automaticMinuteIncrement;
		private System.Windows.Forms.NumericUpDown automaticHourIncrement;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.NumericUpDown manualHourIncrement;
		private System.Windows.Forms.Button fetchDatetimeButton;
		private System.Windows.Forms.GroupBox realtimeBox;
		private System.Windows.Forms.GroupBox adjustedTimeBox;
		private System.Windows.Forms.Label adjustedTimeLabel;
		private System.Windows.Forms.DateTimePicker realDatePicker;
		private System.Windows.Forms.DateTimePicker adjustedDatePicker;
		private System.Windows.Forms.Button autoIncrementButton;
		private System.Windows.Forms.DateTimePicker realTimePicker;
		private System.Windows.Forms.DateTimePicker adjustedTimePicker;
		private System.Windows.Forms.Button freezeClockButton;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
	}
}

