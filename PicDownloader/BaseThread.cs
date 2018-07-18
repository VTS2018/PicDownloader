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
    /// 用来与网页交互的线程基类。
    /// </summary>
    public abstract class BaseThread
    {
        private Thread _thread;
        private volatile bool _shouldStop;
        private volatile bool _shouldSleep;

        private double _sleepTime;
        private string _name;

        //指定 System.Threading.Thread 的调度优先级
        private ThreadPriority _priority;

        public string cookies;

        /// <summary>
        /// 获取一个值，该值指示当前线程的执行状态
        /// </summary>
        public bool IsAlive
        {
            get
            {
                return this._thread.IsAlive;
            }
        }
        /// <summary>
        /// 线程名字
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
        /// 线程的调度优先级
        /// </summary>
        public ThreadPriority Priority
        {
            set
            {
                this._priority = value;
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public BaseThread()
        {
            this._shouldStop = this._shouldSleep = false;
        }
        /// <summary>
        /// 开启一个线程
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
        /// 线程挂起
        /// </summary>
        /// <param name="sec"></param>
        public void Sleep(double sec)
        {
            this._sleepTime = sec;
            this._shouldSleep = this._shouldStop = true;
        }

        /// <summary>
        /// 让线程自然终止。
        /// </summary>
        public void LetGo()
        {
            this._shouldStop = true;
            this._shouldSleep = false;
        }
        /// <summary>
        /// 终止一个线程
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