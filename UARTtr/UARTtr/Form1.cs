using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace UARTtr
{
    public partial class Form1 : Form
    {
        string[] ports;
        string portname = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SerialPort sp = new SerialPort(portname, 115200, Parity.None, 8, StopBits.One);
            if (sp.IsOpen)
            { sp.Close(); }
            sp.Open();
            byte[] toBytes = Encoding.ASCII.GetBytes("ON");
            sp.Write(toBytes, 0, 3);
            sp.Close();
            sp.Dispose();
            textBox1.Text += sp.ReadExisting();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SerialPort sp = new SerialPort(portname, 115200, Parity.None, 8, StopBits.One);
            if (sp.IsOpen)
            { sp.Close(); }
            sp.Open();
            byte[] toBytes = Encoding.ASCII.GetBytes("OFF");
            sp.Write(toBytes, 0, 4);
            sp.Close();
            sp.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            portname = comboBox1.SelectedItem.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox1.Text = "UART Buffer: \n\n";
            ports = SerialPort.GetPortNames();
            if (ports.Length != 0)
            {
                comboBox1.DataSource = ports;
                comboBox1.SelectedItem = ports[0];
            }
            else
            {
                comboBox1.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }
    }
}
