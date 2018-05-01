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
using System.Threading;
using RFTagSystemApp.model;
using RFTagSystemApp.utils;

namespace RFTagSystemApp
{
    public partial class MainCtrlForm : Form
    {
        private TransmitControl transmitControl = null;
        private const char StartReceivedChar = '#';
        private const char EndReceivedChar = ';';
        //private string ReceivedBuffer = "";
        private bool TransmitEnable = true;
        private int Offset = 0;

        private enum Status {
            SOF,LENGTH,GUID,COMMAND,VALUE
        };
        private Status status = Status.SOF;
        private ResponseMessage responseMsg = new ResponseMessage();
        private int posi = 0;


        private Session[] SessionArray = 
        {
            new Session(0),
            new Session(1),
            new Session(2),
            new Session(3),
            new Session(4),
            new Session(5),
            new Session(6),
        };

        public MainCtrlForm()
        {
            InitializeComponent();
        }

        private List<RFTagControl> rftaglist = new List<RFTagControl>();

        private void MainCtrlForm_Load(object sender, EventArgs e)
        {
            
            rftaglist.Clear();
            RFTagControl rftag1 = new RFTagControl(1, this);
            tableLayoutPanel1.Controls.Add(rftag1);
            RFTagControl rftag2 = new RFTagControl(2, this);
            tableLayoutPanel1.Controls.Add(rftag2);
            RFTagControl rftag3 = new RFTagControl(3, this);
            tableLayoutPanel1.Controls.Add(rftag3);
            RFTagControl rftag4 = new RFTagControl(4, this);
            tableLayoutPanel1.Controls.Add(rftag4);
            RFTagControl rftag5 = new RFTagControl(5, this);
            tableLayoutPanel1.Controls.Add(rftag5);
            RFTagControl rftag6 = new RFTagControl(6, this);
            tableLayoutPanel1.Controls.Add(rftag6);

            rftaglist.Add(rftag1);
            rftaglist.Add(rftag2);
            rftaglist.Add(rftag3);
            rftaglist.Add(rftag4);
            rftaglist.Add(rftag5);
            rftaglist.Add(rftag6);

            //Set UsartControl SerialDataReceivedEventHandler
            usartControl.setSerialDataReceivedEventHandler(DataReceivedHandler);
            transmitControl = new TransmitControl(this);
            gbTransmitControl.Controls.Add(transmitControl);
        }

        private void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            
            string indata = sp.ReadExisting();
            //MessageBox.Show("XXX Data Received:" + indata);
            char[] data = indata.ToCharArray();
            
            /*
            byte[] data = new byte[32];
            int len = sp.Read(data, 0, 32);
            MessageBox.Show("Len " + len);
            */
            for( int i=0;i<data.Length;i++)
            {
                if (data[i] < 32 && data[i] != 10 && data[i] != 13)
                {
                    SetRtbRxConsole("[" + (int)data[i] + "]");
                }
                else
                {
                    SetRtbRxConsole(data[i].ToString());
                }
                /*
                if (cadata[i] == StartReceivedChar)
                {
                    ReceivedBuffer = "";
                }
                else if (cadata[i] == EndReceivedChar)
                {
                    verifyReceivedData(ReceivedBuffer);
                    ReceivedBuffer = "";
                }
                else
                {
                    ReceivedBuffer += cadata[i].ToString();
                }*/
                switch ( status )
                {
                    case Status.SOF:
                        if( data[i] == '#' )
                        {
                            status = Status.LENGTH;
                        }
                        break;
                    case Status.LENGTH:
                        responseMsg.Length = (byte)data[i];
                        status = Status.GUID;
                        break;
                    case Status.GUID:
                        responseMsg.Guid[posi++] = data[i];
                        if (posi >= 4)
                        {
                            posi = 0;
                            status = Status.COMMAND;
                        }
                        break;
                    case Status.COMMAND:
                        responseMsg.Command[posi++] = data[i];
                        if( posi >= 4 )
                        {
                            posi = 0;
                            if( responseMsg.Length == 0 )
                            {
                                status = Status.SOF;
                                // 处理ResponseMsg
                                executeResponseMsg();
                            }
                            else
                            {
                                status = Status.VALUE;
                            }
                        }
                        break;
                    case Status.VALUE:
                        responseMsg.Value[posi++] = data[i];
                        if (posi >= responseMsg.Length || posi >= 33)
                        {
                            responseMsg.Value[posi] = '\0'; //字符串结束，方便后面使用
                            posi = 0;
                            status = Status.SOF;
                            // 处理ResponseMsg
                            executeResponseMsg();
                        }
                        break;
                    default:
                        status = Status.SOF;
                        break;
                }
            }
        }

        public void verifyReceivedData(string buffer)
        {
            if( buffer == null || buffer == "" || buffer.ToCharArray().Length <= 6)
            {
                return;
            }
            char high = buffer.ToCharArray()[0];
            char low = buffer.ToCharArray()[1];
            if( !((high >= '0' && high <= '9') || ( high >= 'A' && high <= 'F')))
            {
                return;
            }
            if (!((low >= '0' && low <= '9') || (low >= 'A' && low <= 'F')))
            {
                return;
            }
            int tagid = ((high >= '0' && high <= '9') ? (high - '0') : (high - 'A' + 10)) * 16 +
                ((low >= '0' && low <= '9') ? (low - '0') : (low - 'A' + 10));
            if( !(tagid >= Offset+1 && tagid <= Offset+6))
            {
                return;
            }
            string command = buffer.Substring(2, 4);
            if( command == "TAKE" )
            {
                SessionArray[tagid].TakeResult = buffer;
            }
            else if( command == "ALER" )
            {
                SessionArray[tagid].AlerResult= buffer;
            }
            else if( command == "PING" )
            {
                SessionArray[tagid].PingResult = buffer;
            }
            else
            {
                if( buffer.ToCharArray().Length >= 9)
                {
                    command = buffer.Substring(2, 7);
                    if( command == "ACTTAKE" )
                    {
                        //Take Action & Darken Green LED
                        rftaglist[tagid - Offset - 1].darkenLED(3);
                        Thread thread = new Thread(delegate() 
                        {
                            string result = transmitACK(tagid, command);
                            if ( result != "Success")
                            {
                                MessageBox.Show("Response for [" + tagid + ":" + command + "] " + result );
                            }
                        });
                        thread.Start();
                    }
                    else if( command == "ACTALER" )
                    {
                        //Alert Action & Darken Yellow LED
                        rftaglist[tagid - Offset - 1].darkenLED(2);
                        Thread thread = new Thread(delegate ()
                        {
                            string result = transmitACK(tagid, command);
                            if (result != "Success")
                            {
                                MessageBox.Show("Response for [" + tagid + ":" + command + "] " + result);
                            }
                        });
                        thread.Start();
                    }
                    else if( command == "NOTLPWR" )
                    {
                        //Notice Low Power & Light Red LED
                        rftaglist[tagid - Offset - 1].lightLED(1);
                        Thread thread = new Thread(delegate ()
                        {
                            string result = transmitACK(tagid, command);
                            if (result != "Success")
                            {
                                MessageBox.Show("Response for [" + tagid + ":" + command + "] " + result);
                            }
                        });
                        thread.Start();
                    }
                }
            }
        }

        public void setTagID(int tagid)
        {
            if(transmitControl !=null)
            {
                transmitControl.setTagID(tagid);
            }
            else
            {
                MessageBox.Show( "TransmitControl is uninitialized!" );
            }
        }

        private void UsartSendMessage(byte[] data, int offset, int count)
        {
            if (usartControl.Serial != null)
            {
                usartControl.Serial.write(data, offset, count);
            }
            else
            {
                MessageBox.Show("请确保串口已经成功打开，再发送数据！");
            }
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

        public void executeTake(int tagid, int value)
        {
            RequestMessage requestMessage = new RequestMessage();
            requestMessage.Length = 0;
            requestMessage.Guid = getCAFromInt(tagid);
            requestMessage.ShortAddr = getCAFromString(SessionArray[tagid].ShortAddr);
            // MessageBox.Show(SessionArray[tagid].ShortAddr);
            // TKME
            requestMessage.Command = getCAFromString("TKME");
            requestMessage.Length = requestMessage.setValue(value);

            SetRtbTxConsole( "Tx:[" + requestMessage.getMessageString() + "]\n");
            UsartSendMessage(requestMessage.getMessageByte(), 0, 14 + requestMessage.Length);
            /*
            string result = transmitMessage(tagid, "TAKE", value.ToString());
            if (result == "TxBusy")
            {
                MessageBox.Show("Transmitter is Busy now, please Retry!");
            }
            else if (result == "RxBusy")
            {
                MessageBox.Show("Receiver is Busy now, please Retry!");
            }
            else if (result == "Timeout")
            {
                MessageBox.Show("the Request is Timeout, please Retry!");
            }
            else
            {
                string[] _list = result.Split('-');
                string retValue = _list[_list.Length - 1];
                //IDER
                if( retValue == "IDER")
                {
                    MessageBox.Show("the TagID is Error, please Check it!");
                }
                //ACK
                else if( retValue == "ACK" )
                {
                    //Light Green LED
                    rftaglist[tagid - Offset -1].lightLED(3);
                }
            }
            */
        }

        public void executeTakeAck(int tagid)
        {
            RequestMessage requestMessage = new RequestMessage();
            requestMessage.Length = 2;
            requestMessage.Guid = getCAFromInt(tagid);
            requestMessage.ShortAddr = getCAFromString(SessionArray[tagid].ShortAddr);
            // MessageBox.Show(SessionArray[tagid].ShortAddr);
            // TKME
            requestMessage.Command = getCAFromString("AKTK");
            requestMessage.Value[0] = 'O';
            requestMessage.Value[1] = 'K';

            SetRtbTxConsole("Tx:[" + requestMessage.getMessageString() + "]\n");
            UsartSendMessage(requestMessage.getMessageByte(), 0, 14 + requestMessage.Length);
        }

        public void executeAlert(int tagid, int value)
        {
            RequestMessage requestMessage = new RequestMessage();
            // Length
            requestMessage.Length = 0;
            // Guid
            requestMessage.Guid = getCAFromInt(tagid);
            // ShortAddress
            requestMessage.ShortAddr = getCAFromString(SessionArray[tagid].ShortAddr);
            // MessageBox.Show(SessionArray[tagid].ShortAddr);
            // cmd : "ADME"
            requestMessage.Command = getCAFromString("ADME");
            // value
            requestMessage.Length = requestMessage.setValue(value);

            SetRtbTxConsole( "Tx:[" + requestMessage.getMessageString() + "]\n");
            UsartSendMessage(requestMessage.getMessageByte(), 0, 14 + requestMessage.Length);
            /*
            string result = transmitMessage(tagid, "ALER", value.ToString());
            if (result == "TxBusy")
            {
                MessageBox.Show("Transmitter is Busy now, please Retry!");
                return;
            }
            else if (result == "RxBusy")
            {
                MessageBox.Show("Receiver is Busy now, please Retry!");
                return;
            }
            else if (result == "Timeout")
            {
                MessageBox.Show("the Request is Timeout, please Retry!");
                return;
            }
            else
            {
                string[] _list = result.Split('-');
                string retValue = _list[_list.Length - 1];
                //IDER
                if (retValue == "IDER")
                {
                    MessageBox.Show("the TagID is Error, please Check it!");
                }
                //ACK
                else if (retValue == "ACK")
                {
                    //Light Yellow LED
                    rftaglist[tagid - Offset -1].lightLED(2);
                }
            }
            */
        }

        public void executeAlertAck(int tagid)
        {
            RequestMessage requestMessage = new RequestMessage();
            // Length
            requestMessage.Length = 2;
            // Guid
            requestMessage.Guid = getCAFromInt(tagid);
            // ShortAddress
            requestMessage.ShortAddr = getCAFromString(SessionArray[tagid].ShortAddr);
            // MessageBox.Show(SessionArray[tagid].ShortAddr);
            // cmd : "AKAD"
            requestMessage.Command = getCAFromString("AKAD");
            requestMessage.Value[0] = 'O';
            requestMessage.Value[1] = 'K';

            SetRtbTxConsole("Tx:[" + requestMessage.getMessageString() + "]\n");
            UsartSendMessage(requestMessage.getMessageByte(), 0, 14 + requestMessage.Length);
        }

        public void executeQueryAck(int tagid)
        {
            RequestMessage requestMessage = new RequestMessage();
            // Length
            requestMessage.Length = 0;
            // Guid
            requestMessage.Guid = getCAFromInt(tagid);
            // ShortAddress
            requestMessage.ShortAddr = getCAFromString(SessionArray[tagid].ShortAddr);
            // MessageBox.Show(SessionArray[tagid].ShortAddr);
            // cmd : "AKAD"
            requestMessage.Command = getCAFromString("LTME");
            // value
            requestMessage.Length = requestMessage.setValue(12);

            SetRtbTxConsole( "Tx:[" + requestMessage.getMessageString() + "]\n");
            UsartSendMessage(requestMessage.getMessageByte(), 0, 14 + requestMessage.Length);
        }


        public void executePing(int tagid)
        {
            string result = transmitMessage(tagid, "PING", "");
            if ( result == "TxBusy")
            {
                MessageBox.Show("Transmitter is Busy now, please Retry!");
                return;
            }
            else if( result == "RxBusy" )
            {
                MessageBox.Show("Receiver is Busy now, please Retry!");
                return;
            }
            else if( result == "Timeout" )
            {
                MessageBox.Show("the Request is Timeout, please Retry!");
                return;
            }
            else
            {
                string[] _list = result.Split('-');
                string retValue = _list[_list.Length - 1];
                //IDER
                if (retValue == "IDER")
                {
                    MessageBox.Show("the TagID is Error, please Check it!");
                }
                //ACK
                else if (retValue == "ACK")
                {
                    //Heart Beat delay 1 second
                    rftaglist[tagid - Offset - 1].heartBeat(1);
                }
            }
        }

        private string transmitMessage(int tagid, string command, string value)
        {
            if (!TransmitEnable)
            {
                return "TxBusy";
            }
            if( SessionArray[tagid].Locked )
            {
                return "RxBusy";
            }
            TransmitEnable = false;
            SessionArray[tagid].Locked = true;  //Locked
            SessionArray[tagid].Clear(command);
            usartControl.Serial.write("#" + tagIdToHex(tagid) + command + 
                                      ((command == "PING")?"":value) + ";");
            TransmitEnable = true;

            //Waiting 1 second to Receive the Message returned
            bool isReceived = false;
            string receivedMsg = "";
            int timecount = 1000 / 10;
            while( timecount-- > 0 )
            {
                if(SessionArray[tagid].GetReceivedMessage(command) != "")
                {
                    isReceived = true;
                    receivedMsg = SessionArray[tagid].GetReceivedMessage(command);
                    //MessageBox.Show(receivedMsg);
                    timecount = 0;
                }
                Thread.Sleep(10);   //Waiting 10 milliseconds
            }
            //End Waiting
            SessionArray[tagid].Locked = false; //Unlocked
            //
            if( isReceived)
            {
                return receivedMsg;
            }
            return "Timeout";
        }

        private string transmitACK(int tagid, string command)
        {
            int waitCount = 1000 / 10;
            while (!TransmitEnable)
            {
                if( waitCount-- <= 0 )
                {
                    return "WaitingTxTimeout";
                }
            }
            TransmitEnable = false;
            usartControl.Serial.write("#" + tagIdToHex(tagid) + "ACK-" + command + ";");
            TransmitEnable = true;

            return "Success";
        }

        public string tagIdToHex(int tagid)
        {
            int _tagid = tagid % 255;
            int high = _tagid / 16;
            int low = _tagid % 16;
            return (high < 10 ? ((char)('0' + high)).ToString() : ((char)('A' + high - 10)).ToString())
                + (low < 10 ? ((char)('0' + low)).ToString() : ((char)('A' + low - 10)).ToString());
        }

        private void transmittSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void executeResponseMsg()
        {
            //SetRtbRxConsole(responseMsg.getMessageByte);
            int id = getIdFromCA(responseMsg.Guid);
            string command = new string(responseMsg.Command);
            // 1层数据流
            if (command == "PING")
            {
                //在界面上显示心跳
                string _shortAddr = new string(responseMsg.Value, 0, 4);
                rftaglist[id - Offset - 1].heartBeat(8);
                SetRtbStatusConsole("" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 网络地址[" + _shortAddr + "]\n");
                SessionArray[id].ShortAddr = _shortAddr;
                rftaglist[id - Offset - 1].SetLabelTagID(_shortAddr);
            }
            // 2层数据流
            else if( command == "TKME" )
            {
                string respResult = new string(responseMsg.Value, 0, responseMsg.Length);
                if (respResult == "OK")
                {
                    rftaglist[id - Offset - 1].darkenLED(2);
                    rftaglist[id - Offset - 1].lightLED(1);
                    SetRtbStatusConsole("" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 取药命令[成功]\n");
                }
                else
                {
                    rftaglist[id - Offset - 1].darkenLED(1);
                    rftaglist[id - Offset - 1].darkenLED(2);
                    string alertValue = "" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 补药命令[错误:" + respResult + "]\n";
                    SetRtbStatusConsole(alertValue);
                    MessageBox.Show(alertValue);
                }
            }
            // 2层数据流
            else if( command == "ADME" )
            {
                string respResult = new string(responseMsg.Value, 0, responseMsg.Length);
                if (respResult == "OK")
                {
                    rftaglist[id - Offset - 1].darkenLED(1);
                    rftaglist[id - Offset - 1].lightLED(2);
                    SetRtbStatusConsole("" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 补药命令[成功]\n");
                }
                else
                {
                    rftaglist[id - Offset - 1].darkenLED(1);
                    rftaglist[id - Offset - 1].darkenLED(2);
                    string alertValue = "" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 补药命令[错误:" + respResult + "]\n";
                    SetRtbStatusConsole(alertValue);
                    MessageBox.Show(alertValue);
                }
            }
            // 3层数据流
            else if( command == "AKTK" )
            {
                //1 判断是否为Push Button首次确认
                if(  responseMsg.Length == 0 )
                {
                    executeTakeAck(id);
                }
                // 2 
                else
                {
                    string respResult = new string(responseMsg.Value, 0, responseMsg.Length);
                    if (respResult == "OK")
                    {
                        rftaglist[id - Offset - 1].darkenLED(1);
                        SetRtbStatusConsole("" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 取药确认[成功]\n");
                    }
                    else
                    {
                        rftaglist[id - Offset - 1].darkenLED(1);
                        string alertValue = "" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 取药确认[错误:" + respResult + "]\n";
                        SetRtbStatusConsole(alertValue);
                        MessageBox.Show(alertValue);
                    }
                }
            }
            // 3层数据流
            else if( command == "AKAD" )
            {
                //1 判断是否为Push Button首次确认
                if (responseMsg.Length == 0)
                {
                    executeAlertAck(id);
                }
                // 2 
                else
                {
                    string respResult = new string(responseMsg.Value, 0, responseMsg.Length);
                    if (respResult == "OK")
                    {
                        rftaglist[id - Offset - 1].darkenLED(2);
                        SetRtbStatusConsole("" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 补药确认[成功]\n");
                    }
                    else
                    {
                        rftaglist[id - Offset - 1].darkenLED(2);
                        string alertValue = "" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 补药确认[错误:" + respResult + "]\n";
                        SetRtbStatusConsole(alertValue);
                        MessageBox.Show(alertValue);
                    }
                }
            }
            // 3层数据流
            else if( command == "LTME" )
            {
                //1 判断是否为Push Button首次确认
                if (responseMsg.Length == 0)
                {
                    executeQueryAck(id);
                }
                // 2 
                else
                {
                    string respResult = new string(responseMsg.Value, 0, responseMsg.Length);
                    if (respResult == "OK")
                    {
                        SetRtbStatusConsole("" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 查询确认[成功]\n");
                    }
                    else
                    {
                        string alertValue = "" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 查询确认[错误:" + respResult + "]\n";
                        SetRtbStatusConsole(alertValue);
                        MessageBox.Show(alertValue);
                    }
                }
            }
        }

        /*
         * 通过delegate 在前端显示信息
         */
        delegate void SetRtbConsole(string txt);
        private void  SetRtbStatusConsole(string txt)
        {
            if( rtbStatusConsole.InvokeRequired)
            {
                SetRtbConsole src = new SetRtbConsole(SetRtbStatusConsole);
                Invoke(src, new object[] { txt });
            }
            else
            {
                rtbStatusConsole.Text += txt;
            }
        }
        private void  SetRtbRxConsole(string txt)
        {
            if( rtbRxConsole.InvokeRequired )
            {
                SetRtbConsole src = new SetRtbConsole(SetRtbRxConsole);
                Invoke(src, new object[] { txt });
            }
            else
            {
                rtbRxConsole.Text += txt;
            }
        }

        private void SetRtbTxConsole(string txt)
        {
            if (rtbRxConsole.InvokeRequired)
            {
                SetRtbConsole src = new SetRtbConsole(SetRtbTxConsole);
                Invoke(src, new object[] { txt });
            }
            else
            {
                rtbTxConsole.Text += txt;
            }
        }

        private int getIdFromCA(char[] ca)
        {
            int retValue = 0;
            for (int i = 0; i < 4; i++)
            {
                retValue *= 16;
                retValue += getValueFormHex(ca[i]);
            }
            return retValue;
        }

        private int getValueFormHex(char c)
        {
            return c >= 'A' ? (c - 'A' + 10) : (c - '0');
        }

        private void btnClearTx_Click(object sender, EventArgs e)
        {
            rtbTxConsole.Text = "";
        }

        private void btnClearRx_Click(object sender, EventArgs e)
        {
            rtbRxConsole.Text = "";
        }

        private void btnClearStatus_Click(object sender, EventArgs e)
        {
            rtbStatusConsole.Text = "";
        }
    }
}
