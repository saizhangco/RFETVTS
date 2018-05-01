using Microsoft.Win32;
using RFTagSystemApp.Communication;
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
using RFTagSystemApp.model;

namespace RFTagSystemApp.Test
{
    public partial class UartProtocolTest : Form
    {
        public SerialOperUnit Serial = null;
        //private SerialDataReceivedEventHandler handler = null;
        private delegate void UpdateRXDelegate(string rx_data);

        //常量
        private const char MT_UART_SOF = (char)254; //0xFE

        public UartProtocolTest()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗口初始化函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UartProtocolTest_Load(object sender, EventArgs e)
        {
            //刷新串口列表
            refreshSerialList();
            CheckForIllegalCrossThreadCalls = false;
        }

        public void refreshSerialList() 
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

        private void ll_refreshPortName_Click(object sender, EventArgs e)
        {
            //刷新串口列表
            refreshSerialList();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (btnOpen.Text == "打开")
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
                        btnOpen.Text = "关闭";
                        //Serial.setSerialDataReceivedEventHandler(DataReceivedHandler);
                        Serial.delegateSerialRead += new SerialOperUnit.DelegateSerialRead(dataRxHandler);
                        Serial.read(true);
                        /*
                        if (handler != null)
                        {
                            Serial.setSerialDataReceivedEventHandler(handler);
                        }
                        else
                        {
                            Serial.setSerialDataReceivedEventHandler(DataReceivedHandler);
                        }*/
                    }
                }
            }
            else if (btnOpen.Text == "关闭")
            {
                if (Serial != null)
                {
                    Serial.close();
                    Serial = null;
                }
                btnOpen.Text = "打开";
            }
        }

        private void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            MessageBox.Show("Data Received:" + indata);
            //rtb_RX_Data.Text += indata;
        }

        private void UsartSendMessage(byte[] data,int offset,int count)
        {
            if( Serial != null)
            {
                Serial.write(data,offset,count);
            }
            else
            {
                MessageBox.Show("请确保串口已经成功打开，再发送数据！");
            }
        }

        private void btnTest1_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[9];
            data[0] = 254;
            data[1] = 4;  //Length
            data[2] = (byte)'1';
            data[3] = (byte)'2';
            data[4] = (byte)'3';
            data[5] = (byte)'4';
            data[6] = (byte)'+';
            data[7] = (byte)'-';
            data[8] = 254;
            Console.WriteLine("{0}", (int)data[0]);
            if (Serial != null)
            {
                Serial.write(data,0,9);
            }
            else
            {
                MessageBox.Show("Please open a SerialPort in the first!");
            }
        }

        private void dataRxHandler(byte[] data, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if( data[i] < 32 && data[i] != 10 && data[i] != 13)
                {
                    rtbRxConsole.Text += "[" + data[i] + "]";
                }
                else
                {
                    rtbRxConsole.Text += (char)data[i];
                }
            }
        }
        
        /// <summary>
        /// 取药命令功能出发函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTake_Click(object sender, EventArgs e)
        {
            /*
             * SOF
             * length
             * guid
             * shortAddress
             * command
             * value
             */
            RequestMessage requestMessage = new RequestMessage();
            requestMessage.Length = 0;
            requestMessage.Guid = getCAFromInt(2);
            requestMessage.ShortAddr = getCAFromString(tbShortAddr.Text);
            // TKME
            requestMessage.Command = getCAFromString("TKME");
            requestMessage.Length = requestMessage.setValue(123);

            rtbTxConsole.Text += "Tx:[" + requestMessage.getMessageString() + "]\n";
            UsartSendMessage(requestMessage.getMessageByte(), 0, 14 + requestMessage.Length);
            //MessageBox.Show(new string(requestMessage.Value));
        }

        private char[] getCAFromString(string cmd)
        {
            char[] ca = new char[4];
            char[] tmp = cmd.ToCharArray();
            for (int i = 0; i < 4; i++)
            {
                ca[i] = tmp[i];
            }
            return ca;
        }

        private char[] getCAFromInt(int id)
        {
            char[] ca = new char[4];
            int tmp = id;
            for (int i = 4; i > 0; i--)
            {
                ca[i - 1] = getHexFromInt(tmp % 16);
                tmp /= 16;
            }
            return ca;
        }

        private char getHexFromInt(int value)
        {
            return (char)(value > 9 ? (value - 10 + 'A') : value + '0');
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RequestMessage requestMessage = new RequestMessage();
            requestMessage.Length = 0;
            requestMessage.Guid = getCAFromInt(2);
            requestMessage.ShortAddr = getCAFromString(tbShortAddr.Text);
            // TKME
            requestMessage.Command = getCAFromString("ADME");
            requestMessage.Length = requestMessage.setValue(109);

            rtbTxConsole.Text += "Tx:[" + requestMessage.getMessageString() + "]\n";
            UsartSendMessage(requestMessage.getMessageByte(), 0, 14 + requestMessage.Length);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            RequestMessage requestMessage = new RequestMessage();
            requestMessage.Length = 0;
            requestMessage.Guid = getCAFromInt(2);
            requestMessage.ShortAddr = getCAFromString(tbShortAddr.Text);
            // TKME
            requestMessage.Command = getCAFromString("RQSA");
            requestMessage.Length = requestMessage.setValue(109);

            rtbTxConsole.Text += "Tx:[" + requestMessage.getMessageString() + "]\n";
            UsartSendMessage(requestMessage.getMessageByte(), 0, 14 + requestMessage.Length);
        }

        private void btnClearRxConsole_Click(object sender, EventArgs e)
        {
            rtbRxConsole.Text = "";
        }

        private void btnClearTxConsole_Click(object sender, EventArgs e)
        {
            rtbTxConsole.Text = "";
        }

        private void btnTestFEEI_Click(object sender, EventArgs e)
        {
            RequestMessage requestMessage = new RequestMessage();
            requestMessage.Length = 0;
            requestMessage.Guid = getCAFromInt(2);
            requestMessage.ShortAddr = getCAFromString(tbShortAddr.Text);
            requestMessage.Command = getCAFromString("TKME");
            requestMessage.Length = requestMessage.setValue(110);

            byte[] origin = requestMessage.getMessageByte();
            origin[5] = (byte)'H';
            string consoleStr = "";
            for( int i=0;i< 14 + requestMessage.Length;i++)
            {
                consoleStr += (char)origin[i];
            }
            rtbTxConsole.Text += "Tx:[" + consoleStr + "]\n";
            UsartSendMessage(origin, 0, 14 + requestMessage.Length);
        }

        private void btnTestFEEC_Click(object sender, EventArgs e)
        {
            RequestMessage requestMessage = new RequestMessage();
            requestMessage.Length = 0;
            requestMessage.Guid = getCAFromInt(2);
            requestMessage.ShortAddr = getCAFromString(tbShortAddr.Text);
            requestMessage.Command = getCAFromString("TAKE");
            requestMessage.Length = requestMessage.setValue(122);

            rtbTxConsole.Text += "Tx:[" + requestMessage.getMessageString() + "]\n";
            UsartSendMessage(requestMessage.getMessageByte(), 0, 14 + requestMessage.Length);
        }

        private void btnTestIDNM_Click(object sender, EventArgs e)
        {
            RequestMessage requestMessage = new RequestMessage();
            requestMessage.Length = 0;
            requestMessage.Guid = getCAFromInt(3);
            requestMessage.ShortAddr = getCAFromString(tbShortAddr.Text);
            requestMessage.Command = getCAFromString("TKME");
            requestMessage.Length = requestMessage.setValue(135);

            rtbTxConsole.Text += "Tx:[" + requestMessage.getMessageString() + "]\n";
            UsartSendMessage(requestMessage.getMessageByte(), 0, 14 + requestMessage.Length);
        }

    }
}
