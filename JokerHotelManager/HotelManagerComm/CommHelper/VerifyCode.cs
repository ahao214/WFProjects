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
    public class VerifyCode : CommConst
    {
        #region 验证码字段长度
        /// <summary>
        /// 验证码字段长度
        /// </summary>
        private int _codeLen = 1;
        #endregion

        #region 验证码长度属性
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

        #region 创建随机字符串
        /// <summary>
        /// 创建随机字符串
        /// </summary>
        /// <returns>返回一个字符串</returns>
        private string CreateRndString()
        {
            // 将已有的字符串以逗号进行分割
            string[] charArr = AllChar.Split(',');
            Random rand = new Random();
            int idx = 0;
            int temp = -1;
            string sRndCode = string.Empty;
            for (int i = 0; i < _codeLen; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)(DateTime.Now.Ticks)));
                }
                // 拿到下标
                idx = rand.Next(0, charArr.Length);
                if(idx== temp)
                {
                    CreateRndString();
                }
                temp = idx;
                sRndCode += charArr[idx];
            }
            return sRndCode;
        }

        #endregion
    }
}
