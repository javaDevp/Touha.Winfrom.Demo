using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Touha.Tool.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tabControl1.Dock = DockStyle.Fill;
        }

        private void 菜单管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string assemblyName = "Touha.Tool.UI";
            string typeName = "Touha.Tool.UI.FrmMenu";
            //Assembly ass = Assembly.LoadFrom(assemblyName); //带后缀名
            Form frm = Activator.CreateInstance(assemblyName, typeName).Unwrap() as Form;
            frm.TopLevel = false;
            TabPage page = new TabPage("菜单管理");
            frm.Show();
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            page.Controls.Add(frm);
            tabControl1.TabPages.Add(page);
        }
    }
}
