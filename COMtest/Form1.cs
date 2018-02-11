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
            ports = SerialPort.GetPortNames();
            if (ports.Length != 0)
            {
                comboBox1.DataSource = ports;
                comboBox1.SelectedItem = ports[0];
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (portname != "")
            {
                int b;
                SerialPort sp = new SerialPort(portname, 115200, Parity.None, 8, StopBits.One);
                if (sp.IsOpen)
                { sp.Close(); }
                sp.Open();
                byte[] toBytes = Encoding.ASCII.GetBytes("ON\r");
                sp.Write(toBytes, 0, 3);
                string resp;
                b = sp.BytesToRead;
                byte[] respp = new byte[b];
                sp.Read(respp, 0, b);
                resp = Encoding.ASCII.GetString(respp);
                MessageBox.Show(resp);
                sp.Close();
                sp.Dispose();
            }
        }

       private void button2_Click(object sender, EventArgs e)
            {
            if (portname != "")
            {
                int b;
                SerialPort sp = new SerialPort(portname, 115200, Parity.None, 8, StopBits.One);
                if (sp.IsOpen)
                { sp.Close(); }
                sp.Open();
                byte[] toBytes = Encoding.ASCII.GetBytes("OFF\r");
                sp.Write(toBytes, 0, 4);
                string resp;

                b = sp.BytesToRead;
                byte[] respp = new byte[b];
                sp.Read(respp, 0, b);
                resp = Encoding.ASCII.GetString(respp);
                MessageBox.Show(resp);
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

        }
    }
}
