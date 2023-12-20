using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerComm.CommHelper
{
    /// <summary>
    /// 封装验证码
    /// </summary>
    public class VerifyCode: CommConst
    {
        #region 验证码字段长度
        /// <summary>
        /// 验证码字段长度
        /// </summary>
        private int _codeLen = 1;
        #endregion

        #region 验证码属性
        public int CodeLen
        {
            // 设置验证码的位数
            set
            {
                _codeLen = value <= 0 ? _codeLen : value;
            }
        }
        #endregion

        #region 无参数构造函数
        /// <summary>
        /// 无参数构造函数
        /// </summary>
        public VerifyCode()
        {

        } 
        #endregion

        #region 带参数的构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="codeLen"></param>
        public VerifyCode(int codeLen)
        {
            _codeLen = codeLen <= 0 ? _codeLen : codeLen;
        } 
        #endregion


    }
}
