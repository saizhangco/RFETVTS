namespace RFTagSystemApp
{
    partial class RFTagControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RFTagControl));
            this.pb_oled = new System.Windows.Forms.PictureBox();
            this.btn_key1 = new System.Windows.Forms.Button();
            this.btn_key2 = new System.Windows.Forms.Button();
            this.btn_ack = new System.Windows.Forms.Button();
            this.labelTagID = new System.Windows.Forms.Label();
            this.redLED = new System.Windows.Forms.Button();
            this.yellowLED = new System.Windows.Forms.Button();
            this.greenLED = new System.Windows.Forms.Button();
            this.heartbeatLED = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_oled)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_oled
            // 
            this.pb_oled.Image = ((System.Drawing.Image)(resources.GetObject("pb_oled.Image")));
            this.pb_oled.Location = new System.Drawing.Point(0, 44);
            this.pb_oled.Name = "pb_oled";
            this.pb_oled.Size = new System.Drawing.Size(256, 177);
            this.pb_oled.TabIndex = 0;
            this.pb_oled.TabStop = false;
            // 
            // btn_key1
            // 
            this.btn_key1.Location = new System.Drawing.Point(29, 3);
            this.btn_key1.Name = "btn_key1";
            this.btn_key1.Size = new System.Drawing.Size(75, 28);
            this.btn_key1.TabIndex = 1;
            this.btn_key1.Text = "KEY1";
            this.btn_key1.UseVisualStyleBackColor = true;
            // 
            // btn_key2
            // 
            this.btn_key2.Location = new System.Drawing.Point(144, 3);
            this.btn_key2.Name = "btn_key2";
            this.btn_key2.Size = new System.Drawing.Size(75, 28);
            this.btn_key2.TabIndex = 2;
            this.btn_key2.Text = "KEY2";
            this.btn_key2.UseVisualStyleBackColor = true;
            // 
            // btn_ack
            // 
            this.btn_ack.Location = new System.Drawing.Point(278, 150);
            this.btn_ack.Name = "btn_ack";
            this.btn_ack.Size = new System.Drawing.Size(60, 55);
            this.btn_ack.TabIndex = 3;
            this.btn_ack.Text = "ACK";
            this.btn_ack.UseVisualStyleBackColor = true;
            // 
            // labelTagID
            // 
            this.labelTagID.AutoSize = true;
            this.labelTagID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTagID.Location = new System.Drawing.Point(275, 9);
            this.labelTagID.Name = "labelTagID";
            this.labelTagID.Size = new System.Drawing.Size(56, 16);
            this.labelTagID.TabIndex = 7;
            this.labelTagID.Text = "Tag   1";
            this.labelTagID.Click += new System.EventHandler(this.RFTagControl_MouseDoubleClick);
            // 
            // redLED
            // 
            this.redLED.BackColor = System.Drawing.SystemColors.ControlDark;
            this.redLED.Location = new System.Drawing.Point(278, 44);
            this.redLED.Name = "redLED";
            this.redLED.Size = new System.Drawing.Size(57, 28);
            this.redLED.TabIndex = 8;
            this.redLED.UseVisualStyleBackColor = false;
            this.redLED.Click += new System.EventHandler(this.redLED_Click);
            // 
            // yellowLED
            // 
            this.yellowLED.BackColor = System.Drawing.SystemColors.ControlDark;
            this.yellowLED.Location = new System.Drawing.Point(278, 77);
            this.yellowLED.Name = "yellowLED";
            this.yellowLED.Size = new System.Drawing.Size(57, 28);
            this.yellowLED.TabIndex = 9;
            this.yellowLED.UseVisualStyleBackColor = false;
            // 
            // greenLED
            // 
            this.greenLED.BackColor = System.Drawing.SystemColors.ControlDark;
            this.greenLED.Location = new System.Drawing.Point(278, 110);
            this.greenLED.Name = "greenLED";
            this.greenLED.Size = new System.Drawing.Size(57, 28);
            this.greenLED.TabIndex = 10;
            this.greenLED.UseVisualStyleBackColor = false;
            // 
            // heartbeatLED
            // 
            this.heartbeatLED.BackColor = System.Drawing.SystemColors.ControlDark;
            this.heartbeatLED.Location = new System.Drawing.Point(231, 44);
            this.heartbeatLED.Name = "heartbeatLED";
            this.heartbeatLED.Size = new System.Drawing.Size(25, 23);
            this.heartbeatLED.TabIndex = 11;
            this.heartbeatLED.UseVisualStyleBackColor = false;
            // 
            // RFTagControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.heartbeatLED);
            this.Controls.Add(this.greenLED);
            this.Controls.Add(this.yellowLED);
            this.Controls.Add(this.redLED);
            this.Controls.Add(this.labelTagID);
            this.Controls.Add(this.btn_ack);
            this.Controls.Add(this.btn_key2);
            this.Controls.Add(this.btn_key1);
            this.Controls.Add(this.pb_oled);
            this.Name = "RFTagControl";
            this.Size = new System.Drawing.Size(358, 220);
            this.Load += new System.EventHandler(this.RFTagControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_oled)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_oled;
        private System.Windows.Forms.Button btn_key1;
        private System.Windows.Forms.Button btn_key2;
        private System.Windows.Forms.Button btn_ack;
        private System.Windows.Forms.Label labelTagID;
        private System.Windows.Forms.Button redLED;
        private System.Windows.Forms.Button yellowLED;
        private System.Windows.Forms.Button greenLED;
        private System.Windows.Forms.Button heartbeatLED;
    }
}
