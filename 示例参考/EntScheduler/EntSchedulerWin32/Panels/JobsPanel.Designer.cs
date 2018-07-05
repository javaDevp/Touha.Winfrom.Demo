namespace QuartzExampleWin32
{
    partial class JobsPanel
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gvJobs = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddJob = new System.Windows.Forms.Button();
            this.clmJobName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmJobDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAuthorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAuthorEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAuthorUrl = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clmVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvJobs)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "dll 文件 (*.dll)|*.dll";
            this.openFileDialog.Title = "添加任务扩展";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gvJobs, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddJob, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.06167F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.93832F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(793, 227);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gvJobs
            // 
            this.gvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvJobs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmJobName,
            this.clmJobDescription,
            this.clmAuthorName,
            this.clmAuthorEmail,
            this.clmAuthorUrl,
            this.clmVersion});
            this.tableLayoutPanel1.SetColumnSpan(this.gvJobs, 2);
            this.gvJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvJobs.Location = new System.Drawing.Point(3, 43);
            this.gvJobs.MultiSelect = false;
            this.gvJobs.Name = "gvJobs";
            this.gvJobs.ReadOnly = true;
            this.gvJobs.RowTemplate.Height = 23;
            this.gvJobs.Size = new System.Drawing.Size(787, 181);
            this.gvJobs.TabIndex = 13;
            this.gvJobs.SelectionChanged += new System.EventHandler(this.gvJobs_SelectionChanged);
            this.gvJobs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvJobs_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(15, 15, 0, 0);
            this.label1.Size = new System.Drawing.Size(104, 27);
            this.label1.TabIndex = 14;
            this.label1.Text = "请选择任务类型";
            // 
            // btnAddJob
            // 
            this.btnAddJob.Location = new System.Drawing.Point(157, 10);
            this.btnAddJob.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnAddJob.Name = "btnAddJob";
            this.btnAddJob.Size = new System.Drawing.Size(102, 26);
            this.btnAddJob.TabIndex = 15;
            this.btnAddJob.Text = "添加任务(&A)";
            this.btnAddJob.UseVisualStyleBackColor = true;
            this.btnAddJob.Click += new System.EventHandler(this.btnAddJob_Click);
            // 
            // clmJobName
            // 
            this.clmJobName.DataPropertyName = "JobName";
            this.clmJobName.HeaderText = "任务名";
            this.clmJobName.Name = "clmJobName";
            this.clmJobName.ReadOnly = true;
            // 
            // clmJobDescription
            // 
            this.clmJobDescription.DataPropertyName = "JobDescription";
            this.clmJobDescription.HeaderText = "任务描述";
            this.clmJobDescription.Name = "clmJobDescription";
            this.clmJobDescription.ReadOnly = true;
            this.clmJobDescription.Width = 150;
            // 
            // clmAuthorName
            // 
            this.clmAuthorName.DataPropertyName = "AuthorName";
            this.clmAuthorName.HeaderText = "作者";
            this.clmAuthorName.Name = "clmAuthorName";
            this.clmAuthorName.ReadOnly = true;
            // 
            // clmAuthorEmail
            // 
            this.clmAuthorEmail.DataPropertyName = "AuthorEmail";
            this.clmAuthorEmail.HeaderText = "作者 Email";
            this.clmAuthorEmail.Name = "clmAuthorEmail";
            this.clmAuthorEmail.ReadOnly = true;
            // 
            // clmAuthorUrl
            // 
            this.clmAuthorUrl.DataPropertyName = "AuthorUrl";
            this.clmAuthorUrl.HeaderText = "作者主页";
            this.clmAuthorUrl.Name = "clmAuthorUrl";
            this.clmAuthorUrl.ReadOnly = true;
            this.clmAuthorUrl.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmAuthorUrl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmAuthorUrl.ToolTipText = "点击访问作者主页";
            this.clmAuthorUrl.Width = 200;
            // 
            // clmVersion
            // 
            this.clmVersion.DataPropertyName = "Version";
            this.clmVersion.HeaderText = "版本";
            this.clmVersion.Name = "clmVersion";
            this.clmVersion.ReadOnly = true;
            // 
            // JobsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "JobsPanel";
            this.Size = new System.Drawing.Size(793, 227);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvJobs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView gvJobs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddJob;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmJobName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmJobDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAuthorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAuthorEmail;
        private System.Windows.Forms.DataGridViewLinkColumn clmAuthorUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmVersion;
    }
}
