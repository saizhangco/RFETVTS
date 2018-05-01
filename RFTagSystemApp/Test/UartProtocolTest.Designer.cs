namespace RFTagSystemApp.Test
{
    partial class UartProtocolTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbRxConsole = new System.Windows.Forms.RichTextBox();
            this.cmbSerialList = new System.Windows.Forms.ComboBox();
            this.ll_refreshPortName = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnTest1 = new System.Windows.Forms.Button();
            this.btnTake = new System.Windows.Forms.Button();
            this.tbShortAddr = new System.Windows.Forms.TextBox();
            this.rtbTxConsole = new System.Windows.Forms.RichTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClearRxConsole = new System.Windows.Forms.Button();
            this.btnClearTxConsole = new System.Windows.Forms.Button();
            this.btnTestFEEI = new System.Windows.Forms.Button();
            this.btnTestFEEC = new System.Windows.Forms.Button();
            this.btnTestIDNM = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbRxConsole
            // 
            this.rtbRxConsole.Location = new System.Drawing.Point(492, 12);
            this.rtbRxConsole.Name = "rtbRxConsole";
            this.rtbRxConsole.Size = new System.Drawing.Size(509, 587);
            this.rtbRxConsole.TabIndex = 0;
            this.rtbRxConsole.Text = "";
            // 
            // cmbSerialList
            // 
            this.cmbSerialList.FormattingEnabled = true;
            this.cmbSerialList.Location = new System.Drawing.Point(79, 27);
            this.cmbSerialList.Name = "cmbSerialList";
            this.cmbSerialList.Size = new System.Drawing.Size(121, 20);
            this.cmbSerialList.TabIndex = 1;
            // 
            // ll_refreshPortName
            // 
            this.ll_refreshPortName.AutoSize = true;
            this.ll_refreshPortName.Location = new System.Drawing.Point(26, 30);
            this.ll_refreshPortName.Name = "ll_refreshPortName";
            this.ll_refreshPortName.Size = new System.Drawing.Size(29, 12);
            this.ll_refreshPortName.TabIndex = 2;
            this.ll_refreshPortName.Text = "串口";
            this.ll_refreshPortName.Click += new System.EventHandler(this.ll_refreshPortName_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(125, 71);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "打开";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(125, 119);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(75, 23);
            this.btnTest1.TabIndex = 4;
            this.btnTest1.Text = "测试1";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // btnTake
            // 
            this.btnTake.Location = new System.Drawing.Point(125, 172);
            this.btnTake.Name = "btnTake";
            this.btnTake.Size = new System.Drawing.Size(75, 23);
            this.btnTake.TabIndex = 5;
            this.btnTake.Text = "取药命令";
            this.btnTake.UseVisualStyleBackColor = true;
            this.btnTake.Click += new System.EventHandler(this.btnTake_Click);
            // 
            // tbShortAddr
            // 
            this.tbShortAddr.Location = new System.Drawing.Point(12, 172);
            this.tbShortAddr.Name = "tbShortAddr";
            this.tbShortAddr.Size = new System.Drawing.Size(100, 21);
            this.tbShortAddr.TabIndex = 6;
            // 
            // rtbTxConsole
            // 
            this.rtbTxConsole.Location = new System.Drawing.Point(12, 206);
            this.rtbTxConsole.Name = "rtbTxConsole";
            this.rtbTxConsole.Size = new System.Drawing.Size(464, 393);
            this.rtbTxConsole.TabIndex = 7;
            this.rtbTxConsole.Text = "";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(215, 172);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "补药命令";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClearRxConsole
            // 
            this.btnClearRxConsole.Location = new System.Drawing.Point(332, 25);
            this.btnClearRxConsole.Name = "btnClearRxConsole";
            this.btnClearRxConsole.Size = new System.Drawing.Size(131, 23);
            this.btnClearRxConsole.TabIndex = 10;
            this.btnClearRxConsole.Text = "清空 RX 控制台";
            this.btnClearRxConsole.UseVisualStyleBackColor = true;
            this.btnClearRxConsole.Click += new System.EventHandler(this.btnClearRxConsole_Click);
            // 
            // btnClearTxConsole
            // 
            this.btnClearTxConsole.Location = new System.Drawing.Point(332, 71);
            this.btnClearTxConsole.Name = "btnClearTxConsole";
            this.btnClearTxConsole.Size = new System.Drawing.Size(131, 23);
            this.btnClearTxConsole.TabIndex = 11;
            this.btnClearTxConsole.Text = "清空 TX 控制台";
            this.btnClearTxConsole.UseVisualStyleBackColor = true;
            this.btnClearTxConsole.Click += new System.EventHandler(this.btnClearTxConsole_Click);
            // 
            // btnTestFEEI
            // 
            this.btnTestFEEI.Location = new System.Drawing.Point(332, 119);
            this.btnTestFEEI.Name = "btnTestFEEI";
            this.btnTestFEEI.Size = new System.Drawing.Size(75, 23);
            this.btnTestFEEI.TabIndex = 12;
            this.btnTestFEEI.Text = "测试 FEEI";
            this.btnTestFEEI.UseVisualStyleBackColor = true;
            this.btnTestFEEI.Click += new System.EventHandler(this.btnTestFEEI_Click);
            // 
            // btnTestFEEC
            // 
            this.btnTestFEEC.Location = new System.Drawing.Point(332, 148);
            this.btnTestFEEC.Name = "btnTestFEEC";
            this.btnTestFEEC.Size = new System.Drawing.Size(75, 23);
            this.btnTestFEEC.TabIndex = 13;
            this.btnTestFEEC.Text = "测试 FEEC";
            this.btnTestFEEC.UseVisualStyleBackColor = true;
            this.btnTestFEEC.Click += new System.EventHandler(this.btnTestFEEC_Click);
            // 
            // btnTestIDNM
            // 
            this.btnTestIDNM.Location = new System.Drawing.Point(332, 177);
            this.btnTestIDNM.Name = "btnTestIDNM";
            this.btnTestIDNM.Size = new System.Drawing.Size(75, 23);
            this.btnTestIDNM.TabIndex = 14;
            this.btnTestIDNM.Text = "测试 IDNM";
            this.btnTestIDNM.UseVisualStyleBackColor = true;
            this.btnTestIDNM.Click += new System.EventHandler(this.btnTestIDNM_Click);
            // 
            // UartProtocolTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 611);
            this.Controls.Add(this.btnTestIDNM);
            this.Controls.Add(this.btnTestFEEC);
            this.Controls.Add(this.btnTestFEEI);
            this.Controls.Add(this.btnClearTxConsole);
            this.Controls.Add(this.btnClearRxConsole);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rtbTxConsole);
            this.Controls.Add(this.tbShortAddr);
            this.Controls.Add(this.btnTake);
            this.Controls.Add(this.btnTest1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.ll_refreshPortName);
            this.Controls.Add(this.cmbSerialList);
            this.Controls.Add(this.rtbRxConsole);
            this.Name = "UartProtocolTest";
            this.Text = "UartProtocolTest";
            this.Load += new System.EventHandler(this.UartProtocolTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbRxConsole;
        private System.Windows.Forms.ComboBox cmbSerialList;
        private System.Windows.Forms.Label ll_refreshPortName;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnTest1;
        private System.Windows.Forms.Button btnTake;
        private System.Windows.Forms.TextBox tbShortAddr;
        private System.Windows.Forms.RichTextBox rtbTxConsole;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClearRxConsole;
        private System.Windows.Forms.Button btnClearTxConsole;
        private System.Windows.Forms.Button btnTestFEEI;
        private System.Windows.Forms.Button btnTestFEEC;
        private System.Windows.Forms.Button btnTestIDNM;
    }
}