using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Touha.Winform.Test
{
    public partial class Form1 : Form
    {
        private BindingManagerBase bindingManagerBase;
        private DataSet ds;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ds = SqlHelper.QueryDataSet("Data Source=HKCD-DEVSQL;Initial Catalog=HK_ERP;User ID=dev_user;Password=hkdevdb@100.9;Connection Timeout=600", "select * from sys_state");
            dataGridView1.DataSource = ds.Tables["sys_state"];
            bindingManagerBase = this.BindingContext[ds.Tables["sys_state"]];
            bindingManagerBase.PositionChanged += BindingManagerBase_PositionChanged;
        }

        private void BindingManagerBase_PositionChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)bindingManagerBase.Current;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingManagerBase.Position -= 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bindingManagerBase.Position += 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bindingManagerBase.Position = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bindingManagerBase.Position = bindingManagerBase.Count - 1;
        }
    }
}
