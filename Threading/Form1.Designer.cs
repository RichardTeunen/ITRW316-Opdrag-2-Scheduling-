namespace Threading
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
            this.gbxProgressBars = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlObjects = new System.Windows.Forms.Panel();
            this.cbxAlgorithm = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.nudDuration = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NUDStarttime = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.nudPriorityLevel = new System.Windows.Forms.NumericUpDown();
            this.btnStopped = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnResetProgress = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbxProgressBars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDStarttime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriorityLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxProgressBars
            // 
            this.gbxProgressBars.Controls.Add(this.label2);
            this.gbxProgressBars.Controls.Add(this.label12);
            this.gbxProgressBars.Controls.Add(this.pnlObjects);
            this.gbxProgressBars.Location = new System.Drawing.Point(176, 36);
            this.gbxProgressBars.Name = "gbxProgressBars";
            this.gbxProgressBars.Size = new System.Drawing.Size(348, 313);
            this.gbxProgressBars.TabIndex = 4;
            this.gbxProgressBars.TabStop = false;
            this.gbxProgressBars.Text = "   Thread Completion Progress";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(205, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Priority\r\n";
            // 
            // pnlObjects
            // 
            this.pnlObjects.AutoScroll = true;
            this.pnlObjects.Location = new System.Drawing.Point(7, 16);
            this.pnlObjects.Name = "pnlObjects";
            this.pnlObjects.Size = new System.Drawing.Size(335, 291);
            this.pnlObjects.TabIndex = 9;
            // 
            // cbxAlgorithm
            // 
            this.cbxAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlgorithm.FormattingEnabled = true;
            this.cbxAlgorithm.Items.AddRange(new object[] {
            "Round Robin",
            "Priority",
            "Multiple Queues"});
            this.cbxAlgorithm.Location = new System.Drawing.Point(24, 178);
            this.cbxAlgorithm.Name = "cbxAlgorithm";
            this.cbxAlgorithm.Size = new System.Drawing.Size(107, 21);
            this.cbxAlgorithm.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 162);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Scheduling algorithm";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(24, 214);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(107, 23);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click_1);
            // 
            // nudDuration
            // 
            this.nudDuration.Location = new System.Drawing.Point(90, 24);
            this.nudDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDuration.Name = "nudDuration";
            this.nudDuration.Size = new System.Drawing.Size(49, 20);
            this.nudDuration.TabIndex = 14;
            this.nudDuration.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Duration";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NUDStarttime);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.nudPriorityLevel);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.nudDuration);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 131);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add new processes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Starting time";
            // 
            // NUDStarttime
            // 
            this.NUDStarttime.Location = new System.Drawing.Point(90, 75);
            this.NUDStarttime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.NUDStarttime.Name = "NUDStarttime";
            this.NUDStarttime.Size = new System.Drawing.Size(49, 20);
            this.NUDStarttime.TabIndex = 19;
            this.NUDStarttime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(16, 102);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(119, 23);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Add process";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Priority Level";
            // 
            // nudPriorityLevel
            // 
            this.nudPriorityLevel.Location = new System.Drawing.Point(90, 50);
            this.nudPriorityLevel.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudPriorityLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPriorityLevel.Name = "nudPriorityLevel";
            this.nudPriorityLevel.Size = new System.Drawing.Size(49, 20);
            this.nudPriorityLevel.TabIndex = 16;
            this.nudPriorityLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnStopped
            // 
            this.btnStopped.Location = new System.Drawing.Point(24, 240);
            this.btnStopped.Name = "btnStopped";
            this.btnStopped.Size = new System.Drawing.Size(107, 23);
            this.btnStopped.TabIndex = 17;
            this.btnStopped.Text = "Stop";
            this.btnStopped.UseVisualStyleBackColor = true;
            this.btnStopped.Click += new System.EventHandler(this.btnStopped_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(24, 316);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(107, 23);
            this.btnDeleteAll.TabIndex = 18;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnResetProgress
            // 
            this.btnResetProgress.Location = new System.Drawing.Point(24, 290);
            this.btnResetProgress.Name = "btnResetProgress";
            this.btnResetProgress.Size = new System.Drawing.Size(107, 23);
            this.btnResetProgress.TabIndex = 19;
            this.btnResetProgress.Text = "Reset Progress";
            this.btnResetProgress.UseVisualStyleBackColor = true;
            this.btnResetProgress.Click += new System.EventHandler(this.btnResetProgress_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(381, 12);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(100, 13);
            this.lblTimer.TabIndex = 20;
            this.lblTimer.Text = "Time running: 0 sec";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Starting Time";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(562, 361);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnResetProgress);
            this.Controls.Add(this.gbxProgressBars);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnStopped);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbxAlgorithm);
            this.Name = "Form1";
            this.Text = "Threading";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxProgressBars.ResumeLayout(false);
            this.gbxProgressBars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDStarttime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriorityLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbxProgressBars;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbxAlgorithm;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown nudDuration;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudPriorityLevel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnStopped;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Panel pnlObjects;
        private System.Windows.Forms.Button btnResetProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NUDStarttime;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label label2;
    }
}

