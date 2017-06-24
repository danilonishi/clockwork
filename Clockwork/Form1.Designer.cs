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
			this.label1 = new System.Windows.Forms.Label();
			this.manualMinuteIncrement = new System.Windows.Forms.NumericUpDown();
			this.manualSecondIncrement = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.manualMinuteButton = new System.Windows.Forms.Button();
			this.manualSecondButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.autoIncrementCheckbox = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.automaticSecondIncrement = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.automaticMinuteIncrement = new System.Windows.Forms.NumericUpDown();
			this.automaticHourIncrement = new System.Windows.Forms.NumericUpDown();
			this.automaticProgressbar = new System.Windows.Forms.ProgressBar();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.fetchDatetimeButton = new System.Windows.Forms.Button();
			this.realTimeLabel = new System.Windows.Forms.Label();
			this.realtimeBox = new System.Windows.Forms.GroupBox();
			this.adjustedTimeBox = new System.Windows.Forms.GroupBox();
			this.adjustedTimeLabel = new System.Windows.Forms.Label();
			this.realDatePicker = new System.Windows.Forms.DateTimePicker();
			this.adjustedDatePicker = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.manualHourIncrement)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.manualMinuteIncrement)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.manualSecondIncrement)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
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
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
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
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.manualSecondButton);
			this.groupBox1.Controls.Add(this.manualHourButton);
			this.groupBox1.Controls.Add(this.manualMinuteButton);
			this.groupBox1.Controls.Add(this.manualHourIncrement);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.manualMinuteIncrement);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.manualSecondIncrement);
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.autoIncrementCheckbox);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.automaticSecondIncrement);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.automaticMinuteIncrement);
			this.groupBox2.Controls.Add(this.automaticHourIncrement);
			this.groupBox2.Controls.Add(this.automaticProgressbar);
			resources.ApplyResources(this.groupBox2, "groupBox2");
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.TabStop = false;
			// 
			// autoIncrementCheckbox
			// 
			resources.ApplyResources(this.autoIncrementCheckbox, "autoIncrementCheckbox");
			this.autoIncrementCheckbox.Name = "autoIncrementCheckbox";
			this.autoIncrementCheckbox.UseVisualStyleBackColor = true;
			this.autoIncrementCheckbox.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// label6
			// 
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			// 
			// automaticSecondIncrement
			// 
			resources.ApplyResources(this.automaticSecondIncrement, "automaticSecondIncrement");
			this.automaticSecondIncrement.Name = "automaticSecondIncrement";
			this.automaticSecondIncrement.ValueChanged += new System.EventHandler(this.AutoSecondChanged);
			// 
			// label7
			// 
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
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
			// realTimeLabel
			// 
			resources.ApplyResources(this.realTimeLabel, "realTimeLabel");
			this.realTimeLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.realTimeLabel.Name = "realTimeLabel";
			// 
			// realtimeBox
			// 
			this.realtimeBox.Controls.Add(this.realTimeLabel);
			resources.ApplyResources(this.realtimeBox, "realtimeBox");
			this.realtimeBox.Name = "realtimeBox";
			this.realtimeBox.TabStop = false;
			// 
			// adjustedTimeBox
			// 
			this.adjustedTimeBox.Controls.Add(this.adjustedTimeLabel);
			resources.ApplyResources(this.adjustedTimeBox, "adjustedTimeBox");
			this.adjustedTimeBox.Name = "adjustedTimeBox";
			this.adjustedTimeBox.TabStop = false;
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
			this.adjustedDatePicker.ValueChanged += new System.EventHandler(this.DatetimeAdjustmentChanged);
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
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.fetchDatetimeCheckbox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.TransparencyKey = System.Drawing.Color.DimGray;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.manualHourIncrement)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.manualMinuteIncrement)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.manualSecondIncrement)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.automaticSecondIncrement)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.automaticMinuteIncrement)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.automaticHourIncrement)).EndInit();
			this.realtimeBox.ResumeLayout(false);
			this.realtimeBox.PerformLayout();
			this.adjustedTimeBox.ResumeLayout(false);
			this.adjustedTimeBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button manualHourButton;
		private System.Windows.Forms.CheckBox fetchDatetimeCheckbox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown manualMinuteIncrement;
		private System.Windows.Forms.NumericUpDown manualSecondIncrement;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button manualMinuteButton;
		private System.Windows.Forms.Button manualSecondButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown automaticSecondIncrement;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown automaticMinuteIncrement;
		private System.Windows.Forms.NumericUpDown automaticHourIncrement;
		private System.Windows.Forms.ProgressBar automaticProgressbar;
		private System.Windows.Forms.CheckBox autoIncrementCheckbox;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.NumericUpDown manualHourIncrement;
		private System.Windows.Forms.Button fetchDatetimeButton;
		private System.Windows.Forms.Label realTimeLabel;
		private System.Windows.Forms.GroupBox realtimeBox;
		private System.Windows.Forms.GroupBox adjustedTimeBox;
		private System.Windows.Forms.Label adjustedTimeLabel;
		private System.Windows.Forms.DateTimePicker realDatePicker;
		private System.Windows.Forms.DateTimePicker adjustedDatePicker;
	}
}

