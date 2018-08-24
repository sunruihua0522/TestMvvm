namespace SuperSocketTest
{
    partial class Form1
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
            this.textBox_serverRecv = new System.Windows.Forms.TextBox();
            this.textBox_serverSend = new System.Windows.Forms.TextBox();
            this.button_ServerSend = new System.Windows.Forms.Button();
            this.textBox_ClientRecv = new System.Windows.Forms.TextBox();
            this.textBox_ClientSend = new System.Windows.Forms.TextBox();
            this.button_ClientSend = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBox_serverRecv
            // 
            this.textBox_serverRecv.Location = new System.Drawing.Point(278, 12);
            this.textBox_serverRecv.Multiline = true;
            this.textBox_serverRecv.Name = "textBox_serverRecv";
            this.textBox_serverRecv.Size = new System.Drawing.Size(310, 323);
            this.textBox_serverRecv.TabIndex = 0;
            // 
            // textBox_serverSend
            // 
            this.textBox_serverSend.Location = new System.Drawing.Point(278, 357);
            this.textBox_serverSend.Multiline = true;
            this.textBox_serverSend.Name = "textBox_serverSend";
            this.textBox_serverSend.Size = new System.Drawing.Size(310, 46);
            this.textBox_serverSend.TabIndex = 0;
            // 
            // button_ServerSend
            // 
            this.button_ServerSend.Location = new System.Drawing.Point(278, 416);
            this.button_ServerSend.Name = "button_ServerSend";
            this.button_ServerSend.Size = new System.Drawing.Size(310, 48);
            this.button_ServerSend.TabIndex = 1;
            this.button_ServerSend.Text = "Send";
            this.button_ServerSend.UseVisualStyleBackColor = true;
            this.button_ServerSend.Click += new System.EventHandler(this.button_ServerSend_Click);
            // 
            // textBox_ClientRecv
            // 
            this.textBox_ClientRecv.Location = new System.Drawing.Point(646, 12);
            this.textBox_ClientRecv.Multiline = true;
            this.textBox_ClientRecv.Name = "textBox_ClientRecv";
            this.textBox_ClientRecv.Size = new System.Drawing.Size(310, 323);
            this.textBox_ClientRecv.TabIndex = 0;
            // 
            // textBox_ClientSend
            // 
            this.textBox_ClientSend.Location = new System.Drawing.Point(646, 357);
            this.textBox_ClientSend.Multiline = true;
            this.textBox_ClientSend.Name = "textBox_ClientSend";
            this.textBox_ClientSend.Size = new System.Drawing.Size(310, 46);
            this.textBox_ClientSend.TabIndex = 0;
            // 
            // button_ClientSend
            // 
            this.button_ClientSend.Location = new System.Drawing.Point(646, 416);
            this.button_ClientSend.Name = "button_ClientSend";
            this.button_ClientSend.Size = new System.Drawing.Size(310, 48);
            this.button_ClientSend.TabIndex = 1;
            this.button_ClientSend.Text = "Send";
            this.button_ClientSend.UseVisualStyleBackColor = true;
            this.button_ClientSend.Click += new System.EventHandler(this.button_ClientSend_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(251, 448);
            this.listBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 479);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button_ClientSend);
            this.Controls.Add(this.button_ServerSend);
            this.Controls.Add(this.textBox_ClientSend);
            this.Controls.Add(this.textBox_serverSend);
            this.Controls.Add(this.textBox_ClientRecv);
            this.Controls.Add(this.textBox_serverRecv);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_serverRecv;
        private System.Windows.Forms.TextBox textBox_serverSend;
        private System.Windows.Forms.Button button_ServerSend;
        private System.Windows.Forms.TextBox textBox_ClientRecv;
        private System.Windows.Forms.TextBox textBox_ClientSend;
        private System.Windows.Forms.Button button_ClientSend;
        private System.Windows.Forms.ListBox listBox1;
    }
}

