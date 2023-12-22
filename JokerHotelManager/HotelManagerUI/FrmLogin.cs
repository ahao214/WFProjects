using System;
using System.Threading;
using HotelManagerComm.CommHelper;
using Sunny.UI;
using System.Timers;

namespace HotelManagerUI
{
    public partial class FrmLogin : UIForm
    {
        #region 获取图片验证码的变量

        private string imgCode = string.Empty;

        #endregion


        #region 时间字符串
        private string _TimesString = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
        }
        #endregion

        #region 窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            TimeStart();
            //StartTimer();
        }

        #endregion

        #region 时间的显示
        /// <summary>
        /// 开始时间
        /// </summary>
        private void TimeStart()
        {
            Text = CommConst.WelcomsTime + _TimesString;
            // 定义一个线程
            Thread thread = new Thread(new ThreadStart(GetTimes));
            thread.IsBackground = true;
            thread.Start();     // 让线程执行
        }
        /// <summary>
        /// 获取时间
        /// </summary>
        private void GetTimes()
        {
            while (true)
            {
                ShowTimes();
                Thread.Sleep(1000);
            }

        }
        /// <summary>
        /// 显示时间
        /// </summary>
        private void ShowTimes()
        {
            if (this.InvokeRequired)
            {
                Action action = new Action(ShowTimes);
                Invoke(action);
            }
            else
            {
                if (IsHandleCreated)
                {
                    Text = CommConst.WelcomsTime + DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
                }
            }
        }

        #endregion

        #region 开始计时器

        private void StartTimer()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;   // 激活后就可以触发一个事件
            timer.Interval = 1000;  // 一秒
            timer.AutoReset = true; // 让一个事件引发多次
            timer.Elapsed += new ElapsedEventHandler(ChangedFrmText);
        }

        /// <summary>
        /// 改变窗体的Text值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangedFrmText(object sender, ElapsedEventArgs e)
        {
            if (IsHandleCreated)
            {
                this.BeginInvoke(new Action(() =>
                {
                    Text = CommConst.WelcomsTime + DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
                }));
            }
        }

        #endregion

        #region 验证码
        /// <summary>
        /// 验证码
        /// </summary>
        private void InitVerityCode()
        {
            VerifyCode code = new VerifyCode(1);
            string strCode = code.StringCode;
            PbVerifyCode.Image = code.CreateImage();
        }

        #endregion

        #region 验证码点击事件
        private void PbVerifyCode_Click(object sender, EventArgs e)
        {
            InitVerityCode();
        }
        #endregion

        #region 登录按钮事件
        /// <summary>
        /// 登录按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
