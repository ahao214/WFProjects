using EmailClient.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailClient
{
    public partial class FrmWriter : Form
    {
        public FrmWriter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 发送按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            string title = this.txtTitle.Text.Trim();
            string content = this .txtContent.Text.Trim();  
            string receiver = this .txtReceiver.Text.Trim(); 
            
        }
    }
}
