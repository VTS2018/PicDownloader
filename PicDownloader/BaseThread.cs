using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Web;
using System.Drawing;
using System.Diagnostics;

namespace PicDownloader
{
    public struct Proxy
    {
        public string host;
        public int port;
    }

    /// <summary>
    /// ��������ҳ�������̻߳��ࡣ
    /// </summary>
    public abstract class BaseThread
    {
        private Thread _thread;
        private volatile bool _shouldStop;
        private volatile bool _shouldSleep;

        private double _sleepTime;
        private string _name;

        //ָ�� System.Threading.Thread �ĵ������ȼ�
        private ThreadPriority _priority;

        public string cookies;

        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ��ǰ�̵߳�ִ��״̬
        /// </summary>
        public bool IsAlive
        {
            get
            {
                return this._thread.IsAlive;
            }
        }
        /// <summary>
        /// �߳�����
        /// </summary>
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        /// <summary>
        /// �̵߳ĵ������ȼ�
        /// </summary>
        public ThreadPriority Priority
        {
            set
            {
                this._priority = value;
            }
        }
        /// <summary>
        /// ��ʼ��
        /// </summary>
        public BaseThread()
        {
            this._shouldStop = this._shouldSleep = false;
        }
        /// <summary>
        /// ����һ���߳�
        /// </summary>
        public void Start()
        {
            this._thread = new Thread(new ThreadStart(this.DoWork));
            this._thread.Name = this._name;
            this._thread.IsBackground = true;
            this._thread.Start();
            Debug.WriteLine(this._name + " started...");
        }
        /// <summary>
        /// �̹߳���
        /// </summary>
        /// <param name="sec"></param>
        public void Sleep(double sec)
        {
            this._sleepTime = sec;
            this._shouldSleep = this._shouldStop = true;
        }

        /// <summary>
        /// ���߳���Ȼ��ֹ��
        /// </summary>
        public void LetGo()
        {
            this._shouldStop = true;
            this._shouldSleep = false;
        }
        /// <summary>
        /// ��ֹһ���߳�
        /// </summary>
        public void Stop()
        {
            this._shouldStop = true;
            try
            {
                this._thread.Abort();
            }
            catch 
            { 

            }
        }

        public void Suspend()
        {
            this._thread.Suspend();
        }

        public void Resume()
        {
            this._thread.Resume();
        }

        private void DoWork()
        {
            while (!this._shouldStop)
            {
                this.DoPost();
            }
            if (this._shouldSleep)
            {
                Debug.WriteLine("....................." + DateTime.Now.ToString("HH:mm:ss"));
                Thread.Sleep((int)Math.Round(this._sleepTime * 1000));
                this._shouldSleep = this._shouldStop = false;
                this.DoWork();
            }
        }

        protected abstract void DoPost();
    }
}