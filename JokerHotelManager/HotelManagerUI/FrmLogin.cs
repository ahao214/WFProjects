using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagerComm;
using Sunny.UI;


namespace HotelManagerUI
{
    public partial class FrmLogin : UIForm
    {
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
                Text = CommConst.WelcomsTime + DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
            }
        }

        #endregion

    }
}
