namespace PicDownloader
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.txtReferer = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.cbHttps = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(12, 160);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(41, 12);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "Ready.";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(14, 116);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(14, 78);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(337, 21);
            this.txtSavePath.TabIndex = 3;
            this.txtSavePath.Text = "E:\\Delphi\\@AdvOCR\\gx12530";
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(367, 78);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(70, 21);
            this.txtSuffix.TabIndex = 4;
            this.txtSuffix.Text = ".bmp";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(14, 11);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(337, 21);
            this.txtURL.TabIndex = 5;
            this.txtURL.Text = "http://gx.12530.com/user/ImageServlet";
            // 
            // txtReferer
            // 
            this.txtReferer.Location = new System.Drawing.Point(12, 38);
            this.txtReferer.Name = "txtReferer";
            this.txtReferer.Size = new System.Drawing.Size(337, 21);
            this.txtReferer.TabIndex = 6;
            this.txtReferer.Text = "http://gx.12530.com";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(367, 11);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(70, 21);
            this.txtFrom.TabIndex = 7;
            this.txtFrom.Text = "001";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(367, 38);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(70, 21);
            this.txtTo.TabIndex = 8;
            this.txtTo.Text = "999";
            // 
            // cbHttps
            // 
            this.cbHttps.AutoSize = true;
            this.cbHttps.Location = new System.Drawing.Point(367, 123);
            this.cbHttps.Name = "cbHttps";
            this.cbHttps.Size = new System.Drawing.Size(54, 16);
            this.cbHttps.TabIndex = 9;
            this.cbHttps.Text = "HTTPS";
            this.cbHttps.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 191);
            this.Controls.Add(this.cbHttps);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.txtReferer);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.txtSuffix);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblMsg);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "网络图片批量下载器V1.0 QQ:631753663";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.TextBox txtSuffix;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TextBox txtReferer;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.CheckBox cbHttps;
    }
}

