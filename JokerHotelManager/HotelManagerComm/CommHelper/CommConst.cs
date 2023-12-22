using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerComm.CommHelper
{
    /// <summary>
    /// 抽象常量类
    /// </summary>
    public abstract class CommConst
    {

        /// <summary>
        /// 酒店欢迎字符串
        /// </summary>
        public const string WelcomsTime = "欢迎使用酒店管理系统 当前时间是:";
        /// <summary>
        /// 验证码字符串
        /// </summary>
        protected const string AllChar = "0,1,2,3,4,5,6,7,8,9,q,w,e,r,t,y,u,i,o,p,a,s,d,f,g,h,j,k,l,z,x,c,v,b,n,m";
        /// <summary>
        /// 对话框标题文字内容
        /// </summary>
        protected const string Caption = "信息提示";
        /// <summary>
        /// 输入有误
        /// </summary>
        public const string InputFalse = "输入有误";

    }
}
