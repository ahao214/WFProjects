using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailClient.Model
{
    /// <summary>
    /// 信件类
    /// </summary>
    public class Letter
    {
        /// <summary>
        /// 邮件编号
        /// </summary>
        public int ID { get; set; } 
        /// <summary>
        /// 邮件标题
        /// </summary>
        public string Title { get; set; }   
        /// <summary>
        /// 邮件内容
        /// </summary>
        public string Content { get; set; } 
        /// <summary>
        /// 收件人
        /// </summary>
        public string Receiver { get; set; } 
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime AddTime { get; set; }



    }
}
