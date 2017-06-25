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
			this.manualMinuteButton = new System.Windows.Forms.Button();
			this.manualSecondButton = new System.Windows.Forms.Button();
			this.manualIncrementBox = new System.Windows.Forms.GroupBox();
			this.autoIncrementBox = new System.Windows.Forms.GroupBox();
			this.autoIncrementButton = new System.Windows.Forms.Button();
			this.autoIncrementCheckbox = new System.Windows.Forms.CheckBox();
			this.autoHourLabel = new System.Windows.Forms.Label();
			this.autoSecondLabel = new System.Windows.Forms.Label();
			this.automaticSecondIncrement = new System.Windows.Forms.NumericUpDown();
			this.autoMinuteLabel = new System.Windows.Forms.Label();
			this.automaticMinuteIncrement = new System.Windows.Forms.NumericUpDown();
			this.automaticHourIncrement = new System.Windows.Forms.NumericUpDown();
			this.automaticProgressbar = new System.Windows.Forms.ProgressBar();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.fetchDatetimeButton = new System.Windows.Forms.Button();
			this.realtimeBox = new System.Windows.Forms.GroupBox();
			this.realTimePicker = new System.Windows.Forms.DateTimePicker();
			this.adjustedTimeBox = new System.Windows.Forms.GroupBox();
			this.adjustedTimePicker = new System.Windows.Forms.DateTimePicker();
			this.adjustedTimeLabel = new System.Windows.Forms.Label();
			this.realDatePicker = new System.Windows.Forms.DateTimePicker();
			this.adjustedDatePicker = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.manualHourIncrement)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.manualMinuteIncrement)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.manualSecondIncrement)).BeginInit();
			this.manualIncrementBox.SuspendLayout();
			this.autoIncrementBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.automaticSecondIncrement)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.automaticMinuteIncrement)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.automaticHourIncrement)).BeginInit();
			this.realtimeBox.SuspendLayout();
			this.adjustedTimeBox.SuspendLayout();
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
			// manualMinuteButton
			// 
			resources.ApplyResources(this.manualMinuteButton, "manualMinuteButton");
			this.manualMinuteButton.Name = "manualMinuteButton";
			this.manualMinuteButton.UseVisualStyleBackColor = true;
			this.manualMinuteButton.Click += new System.EventHandler(this.ManualMinuteClick);
			// 
			// manualSecondButton
			// 
			resources.ApplyResources(this.manualSecondButton, "manualSecondButton");
			this.manualSecondButton.Name = "manualSecondButton";
			this.manualSecondButton.UseVisualStyleBackColor = true;
			this.manualSecondButton.Click += new System.EventHandler(this.ManualSecondClick);
			// 
			// manualIncrementBox
			// 
			this.manualIncrementBox.Controls.Add(this.manualHourLabel);
			this.manualIncrementBox.Controls.Add(this.manualSecondButton);
			this.manualIncrementBox.Controls.Add(this.manualHourButton);
			this.manualIncrementBox.Controls.Add(this.manualMinuteButton);
			this.manualIncrementBox.Controls.Add(this.manualHourIncrement);
			this.manualIncrementBox.Controls.Add(this.manualSecondLabel);
			this.manualIncrementBox.Controls.Add(this.manualMinuteIncrement);
			this.manualIncrementBox.Controls.Add(this.manualMinuteLabel);
			this.manualIncrementBox.Controls.Add(this.manualSecondIncrement);
			resources.ApplyResources(this.manualIncrementBox, "manualIncrementBox");
			this.manualIncrementBox.Name = "manualIncrementBox";
			this.manualIncrementBox.TabStop = false;
			// 
			// autoIncrementBox
			// 
			this.autoIncrementBox.Controls.Add(this.autoIncrementButton);
			this.autoIncrementBox.Controls.Add(this.autoIncrementCheckbox);
			this.autoIncrementBox.Controls.Add(this.autoHourLabel);
			this.autoIncrementBox.Controls.Add(this.autoSecondLabel);
			this.autoIncrementBox.Controls.Add(this.automaticSecondIncrement);
			this.autoIncrementBox.Controls.Add(this.autoMinuteLabel);
			this.autoIncrementBox.Controls.Add(this.automaticMinuteIncrement);
			this.autoIncrementBox.Controls.Add(this.automaticHourIncrement);
			this.autoIncrementBox.Controls.Add(this.automaticProgressbar);
			resources.ApplyResources(this.autoIncrementBox, "autoIncrementBox");
			this.autoIncrementBox.Name = "autoIncrementBox";
			this.autoIncrementBox.TabStop = false;
			// 
			// autoIncrementButton
			// 
			resources.ApplyResources(this.autoIncrementButton, "autoIncrementButton");
			this.autoIncrementButton.Name = "autoIncrementButton";
			this.autoIncrementButton.UseVisualStyleBackColor = true;
			this.autoIncrementButton.Click += new System.EventHandler(this.AutoIncrementButtonClick);
			// 
			// autoIncrementCheckbox
			// 
			resources.ApplyResources(this.autoIncrementCheckbox, "autoIncrementCheckbox");
			this.autoIncrementCheckbox.Name = "autoIncrementCheckbox";
			this.autoIncrementCheckbox.UseVisualStyleBackColor = true;
			this.autoIncrementCheckbox.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
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
			// automaticProgressbar
			// 
			resources.ApplyResources(this.automaticProgressbar, "automaticProgressbar");
			this.automaticProgressbar.Name = "automaticProgressbar";
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
			// adjustedTimeBox
			// 
			this.adjustedTimeBox.Controls.Add(this.adjustedTimePicker);
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
			this.adjustedTimePicker.ValueChanged += new System.EventHandler(this.adjustedTimePicker_ValueChanged);
			// 
			// adjustedTimeLabel
			// 
			resources.ApplyResources(this.adjustedTimeLabel, "adjustedTimeLabel");
			this.adjustedTimeLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.adjustedTimeLabel.Name = "adjustedTimeLabel";
			// 
			// realDatePicker
			// 
			resources.ApplyResources(this.realDatePicker, "realDatePicker");
			this.realDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.realDatePicker.Name = "realDatePicker";
			// 
			// adjustedDatePicker
			// 
			this.adjustedDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			resources.ApplyResources(this.adjustedDatePicker, "adjustedDatePicker");
			this.adjustedDatePicker.Name = "adjustedDatePicker";
			this.adjustedDatePicker.CloseUp += new System.EventHandler(this.AdjustedDatePicker_CloseUp);
			this.adjustedDatePicker.ValueChanged += new System.EventHandler(this.adjustedDatePicker_ValueChanged);
			// 
			// Form1
			// 
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.adjustedDatePicker);
			this.Controls.Add(this.realDatePicker);
			this.Controls.Add(this.adjustedTimeBox);
			this.Controls.Add(this.realtimeBox);
			this.Controls.Add(this.fetchDatetimeButton);
			this.Controls.Add(this.autoIncrementBox);
			this.Controls.Add(this.manualIncrementBox);
			this.Controls.Add(this.fetchDatetimeCheckbox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.TransparencyKey = System.Drawing.Color.DimGray;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.manualHourIncrement)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.manualMinuteIncrement)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.manualSecondIncrement)).EndInit();
			this.manualIncrementBox.ResumeLayout(false);
			this.manualIncrementBox.PerformLayout();
			this.autoIncrementBox.ResumeLayout(false);
			this.autoIncrementBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.automaticSecondIncrement)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.automaticMinuteIncrement)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.automaticHourIncrement)).EndInit();
			this.realtimeBox.ResumeLayout(false);
			this.adjustedTimeBox.ResumeLayout(false);
			this.adjustedTimeBox.PerformLayout();
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
		private System.Windows.Forms.Button manualMinuteButton;
		private System.Windows.Forms.Button manualSecondButton;
		private System.Windows.Forms.GroupBox manualIncrementBox;
		private System.Windows.Forms.GroupBox autoIncrementBox;
		private System.Windows.Forms.Label autoHourLabel;
		private System.Windows.Forms.Label autoSecondLabel;
		private System.Windows.Forms.NumericUpDown automaticSecondIncrement;
		private System.Windows.Forms.Label autoMinuteLabel;
		private System.Windows.Forms.NumericUpDown automaticMinuteIncrement;
		private System.Windows.Forms.NumericUpDown automaticHourIncrement;
		private System.Windows.Forms.ProgressBar automaticProgressbar;
		private System.Windows.Forms.CheckBox autoIncrementCheckbox;
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
	}
}

