using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCHelper
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            cmbBegCity.ValueMember = "Value";
            cmbBegCity.DisplayMember = "Text";

            cmbEndCity.ValueMember = "Value";
            cmbEndCity.DisplayMember = "Text";
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            InitControls();
        }

        private void InitControls()
        {
            LoadCitys();

            LoadData();
        }

        private void LoadData()
        {
            var sql = "SELECT * FROM dbo.BC_OC_OCBasCityTransDay";
            DataTable dt = DbHelper.QueryTable(sql, SysParam.ConnectionString);
            dataGridView1.DataSource = dt;
        }

        private void LoadCitys()
        {
            var sql = "SELECT * FROM dbo.Bas_Area WHERE Level = 2";
            DataTable dt = DbHelper.QueryTable(sql, SysParam.ConnectionString);
            cmbBegCity.Items.Clear();
            cmbEndCity.Items.Clear();
            List<ComboBoxItem> lst = new List<ComboBoxItem>();
            List<ComboBoxItem> lst2 = new List<ComboBoxItem>();
            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(new ComboBoxItem { Value = dr["AreaID"].ToString(), Text = dr["AreaName"].ToString() });
                lst2.Add(new ComboBoxItem { Value = dr["AreaID"].ToString(), Text = dr["AreaName"].ToString() });
            }

            cmbBegCity.DataSource = lst;
            cmbEndCity.DataSource = lst2;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                var sql = string.Format(@"INSERT INTO dbo.BC_OC_OCBasCityTransDay
        ( CompanyID ,
          AreaIDBg ,
          AreaIDEnd ,
          TransDays ,
          ModifyDTM
        )
VALUES  ( '{0}' , -- CompanyID - varchar(20)
          '{1}' , -- AreaIDBg - varchar(30)
          '{2}' , -- AreaIDEnd - varchar(30)
          {3} , -- TransDays - int
          GETDATE()  -- ModifyDTM - datetime
        )", SysParam.CompanyID, cmbBegCity.SelectedValue, cmbEndCity.SelectedValue, txtDistance.Text);
                DbHelper.ExecuteSql(sql, SysParam.ConnectionString);
            }
        }

        private bool CheckData()
        {
            if (string.IsNullOrEmpty(cmbBegCity.Text))
            {
                MessageBox.Show("起始地不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(cmbEndCity.Text))
            {
                MessageBox.Show("目的地不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtDistance.Text))
            {
                MessageBox.Show("运输天数不能为空");
                return false;
            }
            int i;
            if (!int.TryParse(txtDistance.Text, out i))
            {
                MessageBox.Show("运输天数格式不正确");
                return false;
            }
            return true;
        }
    }
}
