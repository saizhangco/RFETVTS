using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFTagSystemApp
{
    public partial class TransmitControl : UserControl
    {
        private MainCtrlForm parent = null;
        private int TagID = 1;

        public TransmitControl(MainCtrlForm form)
        {
            InitializeComponent();
            parent = form;
        }

        private void labelTagID_Click(object sender, EventArgs e)
        {
            tbTake.Text = "";
            tbAlert.Text = "";
        }

        private void btnTake_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Take");
            if( parent != null)
            {
                int value = 0;
                try
                {
                    value = int.Parse(tbTake.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
                parent.executeTake(TagID, value);
            }
            else
            {
                MessageBox.Show("System Failure!");
            }
        }

        private void btnAlert_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Alert");
            if (parent != null)
            {
                int value = 0;
                try
                {
                    value = int.Parse(tbAlert.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
                parent.executeAlert(TagID, value);
            }
            else
            {
                MessageBox.Show("System Failure!");
            }
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("PING");
            if (parent != null)
            {
                parent.executePing(TagID);
            }
            else
            {
                MessageBox.Show("System Failure!");
            }
        }

        public void setTagID(int tagid)
        {
            if( tagid != TagID )
            {
                MessageBox.Show("The TagID changed form " + TagID + " to " + tagid + ".");
            }
            labelTagID.Text = "Tag " + tagid;
            TagID = tagid;
        }
    }
}
