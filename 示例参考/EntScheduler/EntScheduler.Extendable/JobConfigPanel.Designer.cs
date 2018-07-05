namespace Doho.EntScheduler.Extendable
{
    partial class JobConfigPanel
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbRequestsRecovery = new System.Windows.Forms.CheckBox();
            this.cbDurable = new System.Windows.Forms.CheckBox();
            this.cbVolatile = new System.Windows.Forms.CheckBox();
            this.txtJobGroupName = new System.Windows.Forms.TextBox();
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(212, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(212, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "*";
            // 
            // cbRequestsRecovery
            // 
            this.cbRequestsRecovery.AutoSize = true;
            this.cbRequestsRecovery.Location = new System.Drawing.Point(173, 82);
            this.cbRequestsRecovery.Name = "cbRequestsRecovery";
            this.cbRequestsRecovery.Size = new System.Drawing.Size(120, 16);
            this.cbRequestsRecovery.TabIndex = 4;
            this.cbRequestsRecovery.Text = "RequestsRecovery";
            this.cbRequestsRecovery.UseVisualStyleBackColor = true;
            // 
            // cbDurable
            // 
            this.cbDurable.AutoSize = true;
            this.cbDurable.Location = new System.Drawing.Point(101, 82);
            this.cbDurable.Name = "cbDurable";
            this.cbDurable.Size = new System.Drawing.Size(66, 16);
            this.cbDurable.TabIndex = 3;
            this.cbDurable.Text = "Durable";
            this.cbDurable.UseVisualStyleBackColor = true;
            // 
            // cbVolatile
            // 
            this.cbVolatile.AutoSize = true;
            this.cbVolatile.Location = new System.Drawing.Point(23, 82);
            this.cbVolatile.Name = "cbVolatile";
            this.cbVolatile.Size = new System.Drawing.Size(72, 16);
            this.cbVolatile.TabIndex = 2;
            this.cbVolatile.Text = "Volatile";
            this.cbVolatile.UseVisualStyleBackColor = true;
            // 
            // txtJobGroupName
            // 
            this.txtJobGroupName.Location = new System.Drawing.Point(85, 46);
            this.txtJobGroupName.Name = "txtJobGroupName";
            this.txtJobGroupName.Size = new System.Drawing.Size(121, 21);
            this.txtJobGroupName.TabIndex = 1;
            // 
            // txtJobName
            // 
            this.txtJobName.Location = new System.Drawing.Point(85, 19);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(121, 21);
            this.txtJobName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "任务组名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "任务名称";
            // 
            // JobConfigPanel
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
            this.Controls.Add(this.label2);
            this.Name = "JobConfigPanel";
            this.Size = new System.Drawing.Size(315, 238);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox cbRequestsRecovery;
        public System.Windows.Forms.CheckBox cbDurable;
        public System.Windows.Forms.CheckBox cbVolatile;
        public System.Windows.Forms.TextBox txtJobGroupName;
        public System.Windows.Forms.TextBox txtJobName;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;

    }
}
