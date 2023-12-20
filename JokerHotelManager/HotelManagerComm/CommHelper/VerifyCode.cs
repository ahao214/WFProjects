using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

        #region 验证码字符串
        /// <summary>
        /// 验证码字符串字段
        /// </summary>
        private string _stringCode = string.Empty;
        /// <summary>
        /// 验证码字符串属性
        /// </summary>
        public string StringCode
        {
            get
            {
                _stringCode = CreateRndString();
                return _stringCode;
            }
        }
        #endregion

        #region 验证码图片宽度
        /// <summary>
        /// 验证码图片宽度
        /// </summary>
        private int _imgWidth = 80;
        /// <summary>
        /// 验证码图片宽度属性
        /// </summary>
        public int ImgWidth
        {
            get
            {
                return _imgWidth;
            }
        }
        #endregion

        #region 验证码图片高度
        /// <summary>
        /// 验证码图片高度
        /// </summary>
        private int _imgHeight = 32;
        /// <summary>
        /// 验证码图片高度属性
        /// </summary>
        public int ImgHeight
        {
            get
            {
                return _imgHeight;
            }
            set
            {
                _imgHeight = value <= 0 ? _imgHeight : value;
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
                if (idx == temp)
                {
                    CreateRndString();
                }
                temp = idx;
                sRndCode += charArr[idx];
            }
            return sRndCode;
        }

        #endregion


        #region 创建验证码图片
        /// <summary>
        /// 创建验证码图片
        /// </summary>
        /// <returns></returns>
        public Bitmap CreateImage()
        {
            // 没有生成随机字符串，直接退出，返回null值
            if (string.IsNullOrEmpty(_stringCode))
                return null;

            int width = _stringCode.Length * 16; // 位图的宽度
            int height = 32;    // 位图的高度
            // 创建位图和初始化字符的颜色和坐标
            Bitmap image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            Font font = new Font("Arial", 14, FontStyle.Bold | FontStyle.Italic);
            Brush brush = new SolidBrush(Color.Black);
            g.Clear(Color.White);   // 背景色
            g.DrawString(_stringCode, font, brush, 0, 5);
            // 随机线条
            Pen pen = new Pen(Color.Gray, 0);
            Random rand = new Random();
            for (int i = 0; i < _codeLen; i++)
            {
                int x1 = rand.Next(0, width);
                int y1 = rand.Next(0, height);
                int x2 = rand.Next(0, width);
                int y2 = rand.Next(0, height);
                g.DrawLine(pen, x1, y1, x2, y2);
            }
            // 加噪点
            for (int i = 0; i < 200; i++)
            {
                int x = rand.Next(0, width);
                int y = rand.Next(0, height);
                image.SetPixel(x, y, Color.Gray);
            }
            // 画边框
            g.DrawRectangle(pen, 0, 0, width - 1, height - 1);

            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            g.Dispose();
            return image;
        }

        #endregion
    }
}
