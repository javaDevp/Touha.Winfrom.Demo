using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cn.touha.tools.ui
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void tsmiQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiGenCode_Click(object sender, EventArgs e)
        {
            Form frm = new FrmGenCode();
            frm.TopLevel = false;
            TabPage page = new TabPage("代码生成工具");
            page.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tabControl1.TabPages.Add(page);
        }
    }
}
