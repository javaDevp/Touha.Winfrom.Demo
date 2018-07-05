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
    public partial class Form2 : Form
    {
        private DataTable dtInfo = null;
        public Form2()
        {
            InitializeComponent();
            dtInfo = GetInfoTable();
            LoadColumns();
        }

        private DataTable GetInfoTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ColumnName");
            dt.Columns.Add("ColumnNameCN");
            dt.Columns.Add("Alignment");
            dt.Columns.Add("IsShow", typeof(bool));
            dt.Columns.Add("Type");
            DataRow dr = dt.NewRow();
            dr["ColumnName"] = "Name";
            dr["ColumnNameCN"] = "姓名";
            dr["Alignment"] = "MiddleLeft";
            dr["IsShow"] = true;
            dr["Type"] = "Text";
            dt.Rows.Add(dr);
            return dt;
        }

        private void LoadColumns()
        {
            foreach (DataRow dr in dtInfo.Rows)
            {
                if ((bool)dr["IsShow"])
                {
                    DataGridViewColumn dgvc = null;
                    switch (dr["Type"].ToString())
                    {
                        case "Text":
                            dgvc = new DataGridViewTextBoxColumn();
                            break;
                        case "Check":
                            dgvc = new DataGridViewCheckBoxColumn();
                            break;
                        default:
                            dgvc = new DataGridViewTextBoxColumn();
                            break;
                    }
                    if(dgvc != null)
                    {
                        dgvc.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)Enum.Parse(typeof(DataGridViewContentAlignment), dr["Alignment"].ToString());
                        dgvc.HeaderText = dr["ColumnNameCN"].ToString();
                        dgvc.Name = dr["ColumnName"].ToString();
                        dataGridView1.Columns.Add(dgvc);
                    }
                    
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
