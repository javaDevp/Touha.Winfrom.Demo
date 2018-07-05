using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Touha.Libs.Tools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(string name in Enum.GetNames(typeof(Win32Enum)))
            {
                treeView1.Nodes.Add(name);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node.Level == 0)
            {
                ThreadPool.QueueUserWorkItem(LoadSysInfo, node);
            }else if(node.Level == 2)
            {
                richTextBox1.Text = SystemInfo.GetString(node.Parent.Parent.Text, node.Parent.Text, node.Text);
            }
        }

        private void LoadSysInfo(object state)
        {
            var node = state as TreeNode;
            try
            {
                using (ManagementClass mc = new ManagementClass(node.Text))
                {
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                        {
                            //TreeNode childNode = new TreeNode();
                            //if (treeView1.InvokeRequired)
                            //{
                            //    Action<ManagementObject> actionDelegate = (x) => { childNode = node.Nodes.Add(mo.GetHashCode().ToString()); };
                            //}
                            //else
                            //{
                            //    childNode = node.Nodes.Add(mo.GetHashCode().ToString());
                            //}
                            
                            treeView1.BeginInvoke(new Action(() => {
                                var childNode = node.Nodes.Add(mo.GetHashCode().ToString());
                                foreach (PropertyData pd in mo.Properties)
                                {
                                    childNode.Nodes.Add(pd.Name);
                                }
                            }));
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
