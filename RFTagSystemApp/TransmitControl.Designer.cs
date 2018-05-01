namespace RFTagSystemApp
{
    partial class TransmitControl
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
            this.labelTagID = new System.Windows.Forms.Label();
            this.tbTake = new System.Windows.Forms.TextBox();
            this.tbAlert = new System.Windows.Forms.TextBox();
            this.btnTake = new System.Windows.Forms.Button();
            this.btnAlert = new System.Windows.Forms.Button();
            this.btnPing = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTagID
            // 
            this.labelTagID.AutoSize = true;
            this.labelTagID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTagID.Location = new System.Drawing.Point(42, 36);
            this.labelTagID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTagID.Name = "labelTagID";
            this.labelTagID.Size = new System.Drawing.Size(54, 20);
            this.labelTagID.TabIndex = 0;
            this.labelTagID.Text = "Tag 1";
            this.labelTagID.Click += new System.EventHandler(this.labelTagID_Click);
            // 
            // tbTake
            // 
            this.tbTake.Location = new System.Drawing.Point(189, 16);
            this.tbTake.Name = "tbTake";
            this.tbTake.Size = new System.Drawing.Size(120, 26);
            this.tbTake.TabIndex = 2;
            // 
            // tbAlert
            // 
            this.tbAlert.Location = new System.Drawing.Point(351, 16);
            this.tbAlert.Name = "tbAlert";
            this.tbAlert.Size = new System.Drawing.Size(120, 26);
            this.tbAlert.TabIndex = 4;
            // 
            // btnTake
            // 
            this.btnTake.Location = new System.Drawing.Point(189, 48);
            this.btnTake.Name = "btnTake";
            this.btnTake.Size = new System.Drawing.Size(120, 30);
            this.btnTake.TabIndex = 5;
            this.btnTake.Text = "Take";
            this.btnTake.UseVisualStyleBackColor = true;
            this.btnTake.Click += new System.EventHandler(this.btnTake_Click);
            // 
            // btnAlert
            // 
            this.btnAlert.Location = new System.Drawing.Point(351, 48);
            this.btnAlert.Name = "btnAlert";
            this.btnAlert.Size = new System.Drawing.Size(120, 30);
            this.btnAlert.TabIndex = 6;
            this.btnAlert.Text = "Alert";
            this.btnAlert.UseVisualStyleBackColor = true;
            this.btnAlert.Click += new System.EventHandler(this.btnAlert_Click);
            // 
            // btnPing
            // 
            this.btnPing.Location = new System.Drawing.Point(497, 16);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(60, 60);
            this.btnPing.TabIndex = 7;
            this.btnPing.Text = "PING";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // TransmitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPing);
            this.Controls.Add(this.btnAlert);
            this.Controls.Add(this.btnTake);
            this.Controls.Add(this.tbAlert);
            this.Controls.Add(this.tbTake);
            this.Controls.Add(this.labelTagID);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TransmitControl";
            this.Size = new System.Drawing.Size(1080, 90);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTagID;
        private System.Windows.Forms.TextBox tbTake;
        private System.Windows.Forms.TextBox tbAlert;
        private System.Windows.Forms.Button btnTake;
        private System.Windows.Forms.Button btnAlert;
        private System.Windows.Forms.Button btnPing;
    }
}
