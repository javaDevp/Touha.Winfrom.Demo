using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 串口小程序.Common;

namespace 串口小程序
{
    public partial class Form1 : Form
    {
        SerialPort sp = new SerialPort();

        bool IsConfiged;

        public Form1()
        {
            InitializeComponent();
            InitComboboxDataSource();
        }

        private void InitComboboxDataSource()
        {
            List<ComboBoxItem> portNames = new List<ComboBoxItem>();
            for (var i = 1; i < 10; i++)
            {
                portNames.Add(new ComboBoxItem { Text = "COM" + i, Value = "COM" + i });
            }
            cmbPortName.ValueMember = "Value";
            cmbPortName.DisplayMember = "Text";
            cmbPortName.DataSource = portNames;
            List<ComboBoxItem> baudRates = new List<ComboBoxItem>();
            baudRates.Add(new ComboBoxItem { Text = "1200", Value = "1200" });
            baudRates.Add(new ComboBoxItem { Text = "1800", Value = "1800" });
            baudRates.Add(new ComboBoxItem { Text = "2400", Value = "2400" });
            baudRates.Add(new ComboBoxItem { Text = "4800", Value = "4800" });
            baudRates.Add(new ComboBoxItem { Text = "7200", Value = "7200" });
            baudRates.Add(new ComboBoxItem { Text = "9600", Value = "9600" });
            baudRates.Add(new ComboBoxItem { Text = "14400", Value = "14400" });
            baudRates.Add(new ComboBoxItem { Text = "19200", Value = "19200" });
            baudRates.Add(new ComboBoxItem { Text = "38400", Value = "38400" });
            cmbBaudRate.ValueMember = "Value";
            cmbBaudRate.DisplayMember = "Text";
            cmbBaudRate.DataSource = baudRates;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            ConfigSerialPort(cmbPortName.SelectedValue.ToString(), int.Parse(cmbBaudRate.SelectedValue.ToString()));
        }

        private void ConfigSerialPort(string portName, int raudRate)
        {
            sp.PortName = portName;
            sp.BaudRate = raudRate;
            sp.Parity = Parity.None;
            sp.DataBits = 8;
            sp.StopBits = StopBits.One;
            sp.DataReceived += Sp_DataReceived;
            IsConfiged = true;
            lblCurConfig.Text = string.Format("当前串口配置\n端口：{0}\n波特率：{1}", portName, raudRate);
        }

        private void Sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            txtReceived.Text += sp.ReadExisting() + "\n";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (IsConfiged)
            {
                if (sp.IsOpen)
                {
                    sp.Close();
                    btnOpen.Text = "打开";
                }
                else
                {
                    sp.Open();
                    btnOpen.Text = "关闭";
                }
            }
            else
            {
                MessageBox.Show("请先配置串口");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (sp.IsOpen)
            {
                sp.WriteLine(txtSend.Text);
            }
            else
            {
                MessageBox.Show("请先打开串口");
            }
        }
    }
}
