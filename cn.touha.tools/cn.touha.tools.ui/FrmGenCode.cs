using cn.touha.tools.lib.codedom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cn.touha.tools.ui
{
    public partial class FrmGenCode : Form
    {
        public FrmGenCode()
        {
            InitializeComponent();
        }

        private void btnGenCode_Click(object sender, EventArgs e)
        {
            if (cmbType.Text != null)
            {
                switch (cmbType.Text)
                {
                    case "":
                        MessageBox.Show("请选择带转换文本所属类型");
                        break;
                    case "Xml":
                        textBox2.Text = CodeGenHelper.GenCSharpFromXml(textBox1.Text);
                        break;
                    case "Json":
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
