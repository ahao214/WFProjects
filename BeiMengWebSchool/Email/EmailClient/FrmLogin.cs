using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Configuration;

namespace EmailClient
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 完成登录
            string realAccount = ConfigurationManager.AppSettings["account"];
            string realPwd = ConfigurationManager.AppSettings["password"];

            string account = txtAccount.Text.Trim();
            string pwd = txtPwd.Text.Trim();
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("账号和密码不能为空");
                return;
            }

            if (!realAccount.Equals(account) || !realPwd.Equals(pwd))
            {
                MessageBox.Show("账号或密码不正确");
                return;
            }
            if (realAccount.Equals(account) && realPwd.Equals(pwd))
            {
                FormMain frmMain = new FormMain();
                frmMain.Show();
                this.Hide();
            }
            

        }
    }
}
