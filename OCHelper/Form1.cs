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
    public partial class Form1 : Form
    {
        private string oldServer = string.Empty;
        private string oldUserName = string.Empty;
        private string oldPassword = string.Empty;
        private const string connectStringPattern = "Data Source={0};Initial Catalog={1};User ID={2};Password={3};Connection Timeout=600";
        private const string loadDatabaseSql = "Select Name FROM Master..SysDatabases";

        public Form1()
        {
            InitializeComponent();
           

            cmbCompany.ValueMember = "Value";
            cmbCompany.DisplayMember = "Text";
        }

        private void txtServer_Leave(object sender, EventArgs e)
        {
            if(txtServer.Text != oldServer)
            {
                oldServer = txtServer.Text;
                if(!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    LoadDatabases();
                }
            }
        }

        private void LoadDatabases()
        {
            string connectString = string.Format(connectStringPattern, oldServer, "master", oldUserName, oldPassword);
            DataTable dtDatabases = DbHelper.QueryTable(loadDatabaseSql, connectString);
            cmbDatabase.Items.Clear();
            cmbCompany.Items.Clear();
            List<ComboBoxItem> lst = new List<ComboBoxItem>();
            foreach (DataRow dr in dtDatabases.Rows)
            {
                lst.Add(new ComboBoxItem { Value = dr["Name"].ToString(), Text = dr["Name"].ToString() });
            }
            cmbDatabase.DataSource = lst;
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if(txtUserName.Text != oldUserName)
            {
                oldUserName = txtUserName.Text;
                if(!string.IsNullOrEmpty(txtServer.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    LoadDatabases();
                }
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text != oldPassword)
            {
                oldPassword = txtPassword.Text;
                if (!string.IsNullOrEmpty(txtServer.Text) && !string.IsNullOrEmpty(txtUserName.Text))
                {
                    LoadDatabases();
                }
            }
        }

        private void cmbDatabase_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadCompanys();
        }

        private void LoadCompanys()
        {
            if (!string.IsNullOrEmpty(cmbDatabase.Text))
            {
                string connectString = string.Format(connectStringPattern, oldServer, cmbDatabase.SelectedValue, oldUserName, oldPassword);
                var sql = "SELECT CompanyID, CompanyName FROM dbo.Bas_Company WHERE AllowUsed = 1";
                DataTable dtCompanys = DbHelper.QueryTable(sql, connectString);
                List<ComboBoxItem> lst = new List<ComboBoxItem>();
                foreach (DataRow dr in dtCompanys.Rows)
                {
                    lst.Add(new ComboBoxItem { Value = dr["CompanyID"].ToString(), Text = dr["CompanyName"].ToString() });
                }
                cmbCompany.DataSource = lst;

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                SysParam.ConnectionString = string.Format(connectStringPattern, oldServer, cmbDatabase.SelectedValue, oldUserName, oldPassword);
                SysParam.CompanyID = cmbCompany.SelectedValue.ToString();
                Form2 frm = new Form2();
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        private bool CheckData()
        {
            if (string.IsNullOrEmpty(txtServer.Text))
            {
                MessageBox.Show("服务器不能为空");
                txtServer.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("用户名不能为空");
                txtUserName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("密码不能为空");
                txtPassword.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cmbDatabase.Text))
            {
                MessageBox.Show("数据库不能为空");
                cmbDatabase.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cmbCompany.Text))
            {
                MessageBox.Show("公司不能为空");
                cmbCompany.Focus();
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
