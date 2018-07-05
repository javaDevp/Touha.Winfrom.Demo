namespace QuartzExampleWin32.Job
{
    partial class ShutdownJobConfigPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbShutdown = new System.Windows.Forms.ComboBox();
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJobGroupName = new System.Windows.Forms.TextBox();
            this.cbVolatile = new System.Windows.Forms.CheckBox();
            this.cbDurable = new System.Windows.Forms.CheckBox();
            this.cbRequestsRecovery = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "关机类型";
            // 
            // cbShutdown
            // 
            this.cbShutdown.AllowDrop = true;
            this.cbShutdown.FormattingEnabled = true;
            this.cbShutdown.Items.AddRange(new object[] {
            "关机",
            "休眠",
            "待机",
            "注销"});
            this.cbShutdown.Location = new System.Drawing.Point(95, 122);
            this.cbShutdown.Name = "cbShutdown";
            this.cbShutdown.Size = new System.Drawing.Size(121, 20);
            this.cbShutdown.TabIndex = 1;
            // 
            // txtJobName
            // 
            this.txtJobName.Location = new System.Drawing.Point(95, 27);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(121, 21);
            this.txtJobName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "任务名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "任务组名";
            // 
            // txtJobGroupName
            // 
            this.txtJobGroupName.Location = new System.Drawing.Point(95, 54);
            this.txtJobGroupName.Name = "txtJobGroupName";
            this.txtJobGroupName.Size = new System.Drawing.Size(121, 21);
            this.txtJobGroupName.TabIndex = 2;
            // 
            // cbVolatile
            // 
            this.cbVolatile.AutoSize = true;
            this.cbVolatile.Location = new System.Drawing.Point(33, 90);
            this.cbVolatile.Name = "cbVolatile";
            this.cbVolatile.Size = new System.Drawing.Size(72, 16);
            this.cbVolatile.TabIndex = 3;
            this.cbVolatile.Text = "Volatile";
            this.cbVolatile.UseVisualStyleBackColor = true;
            // 
            // cbDurable
            // 
            this.cbDurable.AutoSize = true;
            this.cbDurable.Location = new System.Drawing.Point(111, 90);
            this.cbDurable.Name = "cbDurable";
            this.cbDurable.Size = new System.Drawing.Size(66, 16);
            this.cbDurable.TabIndex = 3;
            this.cbDurable.Text = "Durable";
            this.cbDurable.UseVisualStyleBackColor = true;
            // 
            // cbRequestsRecovery
            // 
            this.cbRequestsRecovery.AutoSize = true;
            this.cbRequestsRecovery.Location = new System.Drawing.Point(183, 90);
            this.cbRequestsRecovery.Name = "cbRequestsRecovery";
            this.cbRequestsRecovery.Size = new System.Drawing.Size(120, 16);
            this.cbRequestsRecovery.TabIndex = 3;
            this.cbRequestsRecovery.Text = "RequestsRecovery";
            this.cbRequestsRecovery.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(222, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(222, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "*";
            // 
            // ShutdownJobConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbRequestsRecovery);
            this.Controls.Add(this.cbDurable);
            this.Controls.Add(this.cbVolatile);
            this.Controls.Add(this.txtJobGroupName);
            this.Controls.Add(this.txtJobName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbShutdown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ShutdownJobConfigPanel";
            this.Size = new System.Drawing.Size(308, 231);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbShutdown;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtJobGroupName;
        private System.Windows.Forms.CheckBox cbVolatile;
        private System.Windows.Forms.CheckBox cbDurable;
        private System.Windows.Forms.CheckBox cbRequestsRecovery;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
