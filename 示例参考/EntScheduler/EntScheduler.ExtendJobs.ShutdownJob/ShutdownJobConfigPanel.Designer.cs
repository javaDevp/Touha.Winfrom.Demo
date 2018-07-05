namespace Doho.EntScheduler.ExtendJobs
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 120);
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
            this.cbShutdown.Location = new System.Drawing.Point(85, 117);
            this.cbShutdown.Name = "cbShutdown";
            this.cbShutdown.Size = new System.Drawing.Size(121, 20);
            this.cbShutdown.TabIndex = 5;
            // 
            // ShutdownJobConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbShutdown);
            this.Name = "ShutdownJobConfigPanel";
            this.Size = new System.Drawing.Size(308, 231);
            this.Controls.SetChildIndex(this.cbShutdown, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtJobName, 0);
            this.Controls.SetChildIndex(this.txtJobGroupName, 0);
            this.Controls.SetChildIndex(this.cbVolatile, 0);
            this.Controls.SetChildIndex(this.cbDurable, 0);
            this.Controls.SetChildIndex(this.cbRequestsRecovery, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbShutdown;
    }
}
