using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quartz;
using Doho.QuartzExampleWin32.Job;
using QuartzExampleWin32.Job;
using Doho.EntScheduler.Extendable;

namespace QuartzExampleWin32
{
    public partial class JobsPanel : UserControl
    {
        private object extendJob;

        public IJob SelectedJob
        {
            get
            {
                if (gvJobs.CurrentRow != null)
                {
                    if (extendJob == null)
                    {
                        Type t = ((JobInfoEntity)gvJobs.CurrentRow.DataBoundItem).GetJobType();
                        extendJob = Activator.CreateInstance(t);
                    }
                    return (IJob)extendJob;
                }
                else
                    return null;
            }
        }

        public UserControl SelectedJobConfigPanel
        {
            get
            {
                if (gvJobs.CurrentRow != null)
                {
                    if (extendJob == null)
                    {
                        Type t = ((JobInfoEntity)gvJobs.CurrentRow.DataBoundItem).GetJobType();
                        extendJob = Activator.CreateInstance(t);
                    }
                    return ((IExtendedJob)extendJob).GetConfigPanel();
                }
                else
                    return null;
            }
        }

        public JobsPanel()
        {
            InitializeComponent();

            gvJobs.DataSource = JobManager.Instance.GetAllJobs();
        }

        private void btnAddJob_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK || openFileDialog.ShowDialog() == DialogResult.Yes)
            {
                string file = openFileDialog.FileName;

                JobManager.Instance.AddJob(file);

                gvJobs.DataSource = JobManager.Instance.GetAllJobs();
                gvJobs.Update();

                MessageBox.Show("添加成功!");
            }
        }

        private void gvJobs_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //清空对象
            extendJob = null;
        }

        private void gvJobs_SelectionChanged(object sender, EventArgs e)
        {
            //清空对象
            extendJob = null;
        }

        private void gvJobs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                System.Diagnostics.Process.Start(this.gvJobs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }
    }
}
