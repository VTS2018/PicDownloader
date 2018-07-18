using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PicDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.btnStart.Enabled = false;
            DownThread dt = new DownThread(this.txtURL.Text, this.txtReferer.Text, this.txtFrom.Text,this.txtTo.Text, 
                                            this.txtSavePath.Text, this.txtSuffix.Text,this.cbHttps.Checked);
            dt.OnMsg += new ShowMsgHanlder(this.ShowMsg);
            dt.OnStop += new StopHandler(this.StopThread);
            dt.Name = "Download Thread 1";
            dt.Start();
        }

        private void ShowMsg(string msg)
        {
            if (this.lblMsg.InvokeRequired)
            {
                ShowMsgHanlder smh = new ShowMsgHanlder(ShowMsg);
                this.Invoke(smh, new object[] { msg });
            }
            else
            {
                this.lblMsg.Text = msg;
            }
        }

        private void StopThread()
        {
            if (this.btnStart.InvokeRequired)
            {
                StopHandler sh = new StopHandler(StopThread);
                this.Invoke(sh, new object[] {});
            }
            else
            {
                this.btnStart.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}