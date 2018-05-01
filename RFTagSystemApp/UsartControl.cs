using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using RFTagSystemApp.Communication;
using System.IO.Ports;

namespace RFTagSystemApp
{
    public partial class UsartControl : UserControl
    {
        public SerialOperUnit Serial = null;
        private SerialDataReceivedEventHandler handler = null;

        public void setSerialDataReceivedEventHandler(SerialDataReceivedEventHandler handler)
        {
            this.handler = handler;
        }

        public UsartControl()
        {
            InitializeComponent();
        }

        private void UsartControl_Load(object sender, EventArgs e)
        {
            
        }

        private void labelSerialPort_Click(object sender, EventArgs e)
        {
            string[] list = SerialPort.GetPortNames();
            cmbSerialList.Items.Clear();
            //Initial Serial List
            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\SERIALCOMM");
            if (keyCom != null)
            {
                string[] sSubKeys = keyCom.GetValueNames();
                foreach (string sName in sSubKeys)
                {
                    string sValue = (string)keyCom.GetValue(sName);
                    cmbSerialList.Items.Add(sValue);
                }
                if (cmbSerialList.Items.Count > 0)
                {
                    cmbSerialList.Text = cmbSerialList.Items[0].ToString();
                }
                else
                {
                    MessageBox.Show("Not Found any Serial Port, please check your hardware connections!");
                }
            }
            else
            {
                MessageBox.Show("Failed to access registry!");
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //Open SerialPort
            if (btnOpen.Text == "Open")
            {
                string portName = cmbSerialList.Items.Count > 0 ? cmbSerialList.SelectedItem.ToString() : "";
                //MessageBox.Show(portName);
                if (portName != null && portName != "")
                {
                    Serial = new SerialOperUnit();
                    int result = Serial.init(portName, 115200, 8, "None", "1");
                    if (result > 0)
                    {
                        MessageBox.Show("Open SerialPort(" + portName + ") Error!");
                    }
                    else
                    {
                        btnOpen.Text = "Close";
                        if( handler != null)
                        {
                            Serial.setSerialDataReceivedEventHandler(handler);
                        }
                        else
                        {
                            Serial.setSerialDataReceivedEventHandler(DataReceivedHandler);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select any portName int the first!");
                }
            }
            //Close SerialPort
            else if( btnOpen.Text == "Close" )
            {
                if (Serial != null)
                {
                    Serial.close();
                    Serial = null;
                }
                btnOpen.Text = "Open";
            }
        }

        private void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            MessageBox.Show("Data Received:" + indata);
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            if( Serial != null)
            {
                Serial.write("23456789");
            }
            else
            {
                MessageBox.Show("Please open a SerialPort in the first!");
            }
        }
    }
}
