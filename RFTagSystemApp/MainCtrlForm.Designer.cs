namespace RFTagSystemApp
{
    partial class MainCtrlForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transmittSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbTransmitControl = new System.Windows.Forms.GroupBox();
            this.rtbTxConsole = new System.Windows.Forms.RichTextBox();
            this.rtbRxConsole = new System.Windows.Forms.RichTextBox();
            this.rtbStatusConsole = new System.Windows.Forms.RichTextBox();
            this.btnClearTx = new System.Windows.Forms.Button();
            this.btnClearRx = new System.Windows.Forms.Button();
            this.btnClearStatus = new System.Windows.Forms.Button();
            this.usartControl = new RFTagSystemApp.UsartControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 64);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 222F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1080, 443);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1498, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolTToolStripMenuItem
            // 
            this.toolTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transmittSToolStripMenuItem});
            this.toolTToolStripMenuItem.Name = "toolTToolStripMenuItem";
            this.toolTToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.toolTToolStripMenuItem.Text = "Tool(T)";
            // 
            // transmittSToolStripMenuItem
            // 
            this.transmittSToolStripMenuItem.Name = "transmittSToolStripMenuItem";
            this.transmittSToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.transmittSToolStripMenuItem.Text = "Transmitt(S)";
            this.transmittSToolStripMenuItem.Click += new System.EventHandler(this.transmittSToolStripMenuItem_Click);
            // 
            // gbTransmitControl
            // 
            this.gbTransmitControl.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gbTransmitControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTransmitControl.Location = new System.Drawing.Point(12, 525);
            this.gbTransmitControl.Name = "gbTransmitControl";
            this.gbTransmitControl.Size = new System.Drawing.Size(1080, 92);
            this.gbTransmitControl.TabIndex = 3;
            this.gbTransmitControl.TabStop = false;
            this.gbTransmitControl.Text = "TransmitBlock";
            // 
            // rtbTxConsole
            // 
            this.rtbTxConsole.Location = new System.Drawing.Point(1098, 64);
            this.rtbTxConsole.Name = "rtbTxConsole";
            this.rtbTxConsole.Size = new System.Drawing.Size(388, 179);
            this.rtbTxConsole.TabIndex = 4;
            this.rtbTxConsole.Text = "";
            // 
            // rtbRxConsole
            // 
            this.rtbRxConsole.Location = new System.Drawing.Point(1098, 249);
            this.rtbRxConsole.Name = "rtbRxConsole";
            this.rtbRxConsole.Size = new System.Drawing.Size(388, 176);
            this.rtbRxConsole.TabIndex = 5;
            this.rtbRxConsole.Text = "";
            // 
            // rtbStatusConsole
            // 
            this.rtbStatusConsole.Location = new System.Drawing.Point(1098, 431);
            this.rtbStatusConsole.Name = "rtbStatusConsole";
            this.rtbStatusConsole.Size = new System.Drawing.Size(388, 186);
            this.rtbStatusConsole.TabIndex = 6;
            this.rtbStatusConsole.Text = "";
            // 
            // btnClearTx
            // 
            this.btnClearTx.Location = new System.Drawing.Point(1112, 35);
            this.btnClearTx.Name = "btnClearTx";
            this.btnClearTx.Size = new System.Drawing.Size(75, 23);
            this.btnClearTx.TabIndex = 7;
            this.btnClearTx.Text = "ClearTx";
            this.btnClearTx.UseVisualStyleBackColor = true;
            this.btnClearTx.Click += new System.EventHandler(this.btnClearTx_Click);
            // 
            // btnClearRx
            // 
            this.btnClearRx.Location = new System.Drawing.Point(1213, 35);
            this.btnClearRx.Name = "btnClearRx";
            this.btnClearRx.Size = new System.Drawing.Size(75, 23);
            this.btnClearRx.TabIndex = 8;
            this.btnClearRx.Text = "ClearRx";
            this.btnClearRx.UseVisualStyleBackColor = true;
            this.btnClearRx.Click += new System.EventHandler(this.btnClearRx_Click);
            // 
            // btnClearStatus
            // 
            this.btnClearStatus.Location = new System.Drawing.Point(1312, 35);
            this.btnClearStatus.Name = "btnClearStatus";
            this.btnClearStatus.Size = new System.Drawing.Size(75, 23);
            this.btnClearStatus.TabIndex = 9;
            this.btnClearStatus.Text = "btnClearStatus";
            this.btnClearStatus.UseVisualStyleBackColor = true;
            this.btnClearStatus.Click += new System.EventHandler(this.btnClearStatus_Click);
            // 
            // usartControl
            // 
            this.usartControl.Location = new System.Drawing.Point(12, 26);
            this.usartControl.Name = "usartControl";
            this.usartControl.Size = new System.Drawing.Size(1080, 28);
            this.usartControl.TabIndex = 2;
            // 
            // MainCtrlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1498, 629);
            this.Controls.Add(this.btnClearStatus);
            this.Controls.Add(this.btnClearRx);
            this.Controls.Add(this.btnClearTx);
            this.Controls.Add(this.rtbStatusConsole);
            this.Controls.Add(this.rtbRxConsole);
            this.Controls.Add(this.rtbTxConsole);
            this.Controls.Add(this.gbTransmitControl);
            this.Controls.Add(this.usartControl);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainCtrlForm";
            this.Text = "MainCtrlForm";
            this.Load += new System.EventHandler(this.MainCtrlForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transmittSToolStripMenuItem;
        private UsartControl usartControl;
        private System.Windows.Forms.GroupBox gbTransmitControl;
        private System.Windows.Forms.RichTextBox rtbTxConsole;
        private System.Windows.Forms.RichTextBox rtbRxConsole;
        private System.Windows.Forms.RichTextBox rtbStatusConsole;
        private System.Windows.Forms.Button btnClearTx;
        private System.Windows.Forms.Button btnClearRx;
        private System.Windows.Forms.Button btnClearStatus;
    }
}

