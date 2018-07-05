using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 数据绑定
{
    public partial class Form1 : Form
    {
        private DataTable dt;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            dataGridView1.DataSource = dt;
            textBox1.DataBindings.Add("Text", dt, "A");
            textBox2.DataBindings.Add("Text", dt, "B");
            textBox3.DataBindings.Add("Text", dt, "C");
        }

        private void LoadData()
        {
            dt = new DataTable();
            dt.Columns.Add("A");
            dt.Columns.Add("B");
            dt.Columns.Add("C");

            for(int i = 0; i < 10; i++)
            {
                DataRow dr = dt.NewRow();
                dr["A"] = "A" + i;
                dr["B"] = "B" + i;
                dr["C"] = "C" + i;
                dt.Rows.Add(dr);
            }
        }
    }
}
