namespace QuartzExampleWin32
{
    partial class ScheduleWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleWindow));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblScheduleState = new System.Windows.Forms.Label();
            this.lblScheduleID = new System.Windows.Forms.Label();
            this.lblScheduleName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnShutDownAndStopJob = new System.Windows.Forms.Button();
            this.btnShutDown = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblScheduleState);
            this.splitContainer1.Panel1.Controls.Add(this.lblScheduleID);
            this.splitContainer1.Panel1.Controls.Add(this.lblScheduleName);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnStart);
            this.splitContainer1.Panel2.Controls.Add(this.btnShutDownAndStopJob);
            this.splitContainer1.Panel2.Controls.Add(this.btnShutDown);
            this.splitContainer1.Size = new System.Drawing.Size(298, 477);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblScheduleState
            // 
            this.lblScheduleState.AutoSize = true;
            this.lblScheduleState.Location = new System.Drawing.Point(112, 66);
            this.lblScheduleState.Name = "lblScheduleState";
            this.lblScheduleState.Size = new System.Drawing.Size(41, 12);
            this.lblScheduleState.TabIndex = 1;
            this.lblScheduleState.Text = "label2";
            // 
            // lblScheduleID
            // 
            this.lblScheduleID.AutoSize = true;
            this.lblScheduleID.Location = new System.Drawing.Point(112, 40);
            this.lblScheduleID.Name = "lblScheduleID";
            this.lblScheduleID.Size = new System.Drawing.Size(41, 12);
            this.lblScheduleID.TabIndex = 1;
            this.lblScheduleID.Text = "label2";
            // 
            // lblScheduleName
            // 
            this.lblScheduleName.AutoSize = true;
            this.lblScheduleName.Location = new System.Drawing.Point(112, 18);
            this.lblScheduleName.Name = "lblScheduleName";
            this.lblScheduleName.Size = new System.Drawing.Size(41, 12);
            this.lblScheduleName.TabIndex = 1;
            this.lblScheduleName.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "调度器状态";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "调度器ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "调度器名";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(36, 15);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "开始执行";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnShutDownAndStopJob
            // 
            this.btnShutDownAndStopJob.Location = new System.Drawing.Point(135, 63);
            this.btnShutDownAndStopJob.Name = "btnShutDownAndStopJob";
            this.btnShutDownAndStopJob.Size = new System.Drawing.Size(120, 23);
            this.btnShutDownAndStopJob.TabIndex = 0;
            this.btnShutDownAndStopJob.Text = "关闭并终止任务";
            this.btnShutDownAndStopJob.UseVisualStyleBackColor = true;
            this.btnShutDownAndStopJob.Click += new System.EventHandler(this.btnShutDownAndStopJob_Click);
            // 
            // btnShutDown
            // 
            this.btnShutDown.Location = new System.Drawing.Point(36, 63);
            this.btnShutDown.Name = "btnShutDown";
            this.btnShutDown.Size = new System.Drawing.Size(75, 23);
            this.btnShutDown.TabIndex = 0;
            this.btnShutDown.Text = "关闭";
            this.btnShutDown.UseVisualStyleBackColor = true;
            this.btnShutDown.Click += new System.EventHandler(this.btnShutDown_Click);
            // 
            // ScheduleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 477);
            this.Controls.Add(this.splitContainer1);
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScheduleWindow";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeftAutoHide;
            this.TabText = "ScheduleWindow";
            this.Text = "ScheduleWindow";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblScheduleName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScheduleState;
        private System.Windows.Forms.Label lblScheduleID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShutDown;
        private System.Windows.Forms.Button btnShutDownAndStopJob;
        private System.Windows.Forms.Button btnStart;
    }
}