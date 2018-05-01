using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace RFTagSystemApp
{
    public partial class RFTagControl : UserControl
    {

        private int TagID = -1;
        private MainCtrlForm parent = null;

        public RFTagControl(int tagid, MainCtrlForm form)
        {
            InitializeComponent();
            TagID = tagid;
            parent = form;
            labelTagID.Text = "Tag " + tagid;
        }

        delegate void SetControlTxt(string txt);
        public void SetLabelTagID(string shortAddr)
        {
            if( labelTagID.InvokeRequired)
            {
                SetControlTxt sct = new SetControlTxt(SetLabelTagID);
                Invoke(sct, new object[] { shortAddr });
            }
            else
            {
                labelTagID.Text = "Tag " + TagID + "\n[" + shortAddr + "]";
            }
        }

        private void RFTagControl_MouseDoubleClick(object sender, System.EventArgs e)
        {
            //New TransmitForm
            //TransmitForm transmitForm = new TransmitForm(TagID , null);
            //transmitForm.Show();
            parent.setTagID(TagID);
        }

        private void RFTagControl_Load(object sender, EventArgs e)
        {
            //Disable Button
            this.btn_key1.Enabled = false;
            this.btn_key2.Enabled = false;
            this.btn_ack.Enabled = false;

            //Initial LEDs
            this.redLED.Enabled = false;
            this.yellowLED.Enabled = false;
            this.greenLED.Enabled = false;
            this.heartbeatLED.Enabled = false;

            //LEDs Test
            //this.lightLEDTest();
        }

        private void noLightLEDs()
        {
            this.redLED.BackColor = SystemColors.ControlDark;
            this.yellowLED.BackColor = SystemColors.ControlDark;
            this.greenLED.BackColor = SystemColors.ControlDark;
        }

        delegate void ControlLED(int id);
        public void lightLED(int id)
        {
            if( redLED.InvokeRequired )
            {
                ControlLED liled = new ControlLED(lightLED);
                Invoke(liled, new object[] { id });
            }
            else
            {
                if (id == 1)
                {
                    //this.noLightLEDs();
                    redLED.BackColor = Color.Red;
                    redLED.Enabled = true;
                }
                else if (id == 2)
                {
                    noLightLEDs();
                    yellowLED.BackColor = Color.Yellow;
                }
                else if (id == 3)
                {
                    noLightLEDs();
                    greenLED.BackColor = Color.Green;
                }
            }
        }

        public void darkenLED( int id )
        {
            if (redLED.InvokeRequired)
            {
                ControlLED liled = new ControlLED(darkenLED);
                Invoke(liled, new object[] { id });
            }
            else
            {
                if (id == 1)
                {
                    this.redLED.BackColor = SystemColors.ControlDark;
                }
                else if (id == 2)
                {
                    this.yellowLED.BackColor = SystemColors.ControlDark;
                }
                else if (id == 3)
                {
                    this.greenLED.BackColor = SystemColors.ControlDark;
                }
            }
        }

        public void heartBeat(int delay)
        {
            this.heartbeatLED.BackColor = Color.Red;
            Thread thread = new Thread(delegate() 
            {
                Thread.Sleep(1000 * delay);
                this.heartbeatLED.BackColor = SystemColors.ControlDark;
            });
            thread.Start();
        }

        private void lightLEDTest()
        {
            this.redLED.BackColor = Color.Red;
            this.yellowLED.BackColor = Color.Yellow;
            this.greenLED.BackColor = Color.Green;
        }

        private void redLED_Click(object sender, EventArgs e)
        {
            if( redLED.BackColor == Color.Red )
            {
                redLED.BackColor = SystemColors.ControlDark;
            }
            redLED.Enabled = false;
        }
    }
}
