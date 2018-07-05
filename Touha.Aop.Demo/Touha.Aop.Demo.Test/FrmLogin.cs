using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Touha.Aop.Demo.Test
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SysParam.UserName = txtUserName.Text;
            Form frm = new Form1();
            frm.ShowDialog();
            frm.Dispose();
        }
    }
}
