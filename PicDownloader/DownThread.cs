using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Security.Authentication;

namespace PicDownloader
{
    public delegate void ShowMsgHanlder(string msg);
    public delegate void StopHandler();

    /// <summary>
    /// 获取服务器时间的线程类。
    /// </summary>
    public class DownThread : BaseThread
    {
        public event ShowMsgHanlder OnMsg;
        public event StopHandler OnStop;
        private string _url, _referer, _savePath, _suffix;
        private int _from, _to, _curDownIdx, _len;
        private bool _isHttps;

        public DownThread(string url, string referer, string from, string to, string savePath, string suffix, bool isHttps)
        {
            this._url = url;//下载的URI		 
            this._referer = referer;
            this._from = Convert.ToInt32(from);
            this._to = Convert.ToInt32(to);
            this._len = to.Length;
            this._savePath = savePath;//本地保存的路径
            this._suffix = suffix;
            this._isHttps = isHttps;
        }

        protected override void DoPost()
        {
            try
            {
                if (this._isHttps)
                {
                    //for 2.0 在2.0下ServicePointManager.CertificatePolicy已经过时
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                this.Download();
            }
            catch (Exception e)
            {
                this.OnMsg(e.Message);
            }
        }

        private void Download()
        {
            WebClient wc = new WebClient();
            string fn = this._savePath + "\\" + this._from.ToString().PadLeft(this._len, '0') + this._suffix;

            wc.DownloadFile(this._url, fn);
            if (this._referer != null && this._referer != "")
            {
                wc.Headers.Add("Referer", this._referer);
            }
            this.OnMsg("已下载　" + this._from + "/" + this._to);

            if (++this._from > this._to)
            {
                this.OnStop();
                this.LetGo();
            }
        }

        //for 2.0
        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            //Always accept   
            return true;
        }
    }
}
