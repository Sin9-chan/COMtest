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

namespace COMtest
{
    public partial class Form1 : Form
    {   string[] ports;
        string portname = "";
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (portname != "")
            {
                SerialPort sp = new SerialPort(portname, 115200, Parity.None, 8, StopBits.One);
                if (sp.IsOpen)
                { sp.Close(); }
                sp.Open();
                byte[] toBytes = Encoding.ASCII.GetBytes("ON\r");
                sp.Write(toBytes, 0, 3);
                sp.Close();
                sp.Dispose();
            }
        }

       private void button2_Click(object sender, EventArgs e)
            {
            if (portname != "")
            {
                SerialPort sp = new SerialPort(portname, 115200, Parity.None, 8, StopBits.One);
                if (sp.IsOpen)
                { sp.Close(); }
                sp.Open();
                byte[] toBytes = Encoding.ASCII.GetBytes("OFF\r");
                sp.Write(toBytes, 0, 4);
                sp.Close();
                sp.Dispose();
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            portname = comboBox1.SelectedItem.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
                button3.Enabled = false;
                textBox1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (portname != "" && textBox1.Text != "")
            { 
            int num;
            string cmd;
            if (Int32.TryParse(textBox1.Text, out num))
            {
                SerialPort sp = new SerialPort(portname, 115200, Parity.None, 8, StopBits.One);
                if (sp.IsOpen)
                { sp.Close(); }
                sp.Open();
                cmd = "PRINT NUM " + num.ToString() + "\r";
                byte[] toBytes = Encoding.ASCII.GetBytes(cmd);
                sp.Write(toBytes, 0, cmd.Length);
                sp.Close();
                sp.Dispose();
            }
            else
            {
                SerialPort sp = new SerialPort(portname, 115200, Parity.None, 8, StopBits.One);
                if (sp.IsOpen)
                { sp.Close(); }
                sp.Open();
                cmd = "PRINT CHAR " + textBox1.Text + "\r";
                byte[] toBytes = Encoding.ASCII.GetBytes(cmd);
                sp.Write(toBytes, 0, cmd.Length);
                sp.Close();
                sp.Dispose();
            }
            }
        }
    }
}
