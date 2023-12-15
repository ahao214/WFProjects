﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace HotelManagerUI
{
    public partial class FrmLogin : UIForm
    {
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
            Text = "欢迎使用酒店管理系统 当前时间是:" + DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
        }

        #endregion

        #region

        private void TimeStart()
        {
            // 定义一个线程
            Thread thread = new Thread (new ThreadStart(GetTimes));
            thread.Start();     // 让线程执行
        }

        private void GetTimes()
        {


        }

        #endregion
    }
}
