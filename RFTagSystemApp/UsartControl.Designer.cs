namespace RFTagSystemApp
{
    partial class UsartControl
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.labelSerialPort = new System.Windows.Forms.Label();
            this.cmbSerialList = new System.Windows.Forms.ComboBox();
            this.btn_test = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(213, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // labelSerialPort
            // 
            this.labelSerialPort.AutoSize = true;
            this.labelSerialPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSerialPort.Location = new System.Drawing.Point(3, 7);
            this.labelSerialPort.Name = "labelSerialPort";
            this.labelSerialPort.Size = new System.Drawing.Size(77, 16);
            this.labelSerialPort.TabIndex = 1;
            this.labelSerialPort.Text = "SerialPort";
            this.labelSerialPort.Click += new System.EventHandler(this.labelSerialPort_Click);
            // 
            // cmbSerialList
            // 
            this.cmbSerialList.FormattingEnabled = true;
            this.cmbSerialList.Location = new System.Drawing.Point(86, 6);
            this.cmbSerialList.Name = "cmbSerialList";
            this.cmbSerialList.Size = new System.Drawing.Size(121, 21);
            this.cmbSerialList.TabIndex = 2;
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(294, 4);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(75, 23);
            this.btn_test.TabIndex = 3;
            this.btn_test.Text = "Test";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // UsartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.cmbSerialList);
            this.Controls.Add(this.labelSerialPort);
            this.Controls.Add(this.btnOpen);
            this.Name = "UsartControl";
            this.Size = new System.Drawing.Size(1080, 30);
            this.Load += new System.EventHandler(this.UsartControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label labelSerialPort;
        private System.Windows.Forms.ComboBox cmbSerialList;
        private System.Windows.Forms.Button btn_test;
    }
}
