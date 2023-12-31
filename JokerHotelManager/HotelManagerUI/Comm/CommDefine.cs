﻿using HotelManagerComm.CommHelper;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagerUI.Comm
{
    public class CommDefine
    {

        #region 获取MD5哈希值

        /// <summary>
        /// 获取MD5哈希值
        /// </summary>
        /// <param name="sVal">传入的字符</param>
        /// <returns>返回加密后的字符串</returns>
        public static string GetMD5Hash(string sVal)
        {
            MD5 md5 = MD5.Create();
            byte[] bs = md5.ComputeHash(Encoding.Default.GetBytes(sVal));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bs.Length; i++)
            {
                sb.Append(bs[i].ToString("x2"));
            }
            return sb.ToString();
        }

        #endregion

        #region 字符替换

        /// <summary>
        /// 字符替换
        /// </summary>
        /// <param name="val">字符串</param>
        /// <returns>返回替换后的字符</returns>
        public static string RepString(string val)
        {
            if (val.Length == 0 || string.IsNullOrEmpty(val))
            {
                return "";
            }
            val = val.Replace("/", "-");
            return val;
        }

        #endregion


        #region 编码加一 

        /// <summary>
        /// 编码加一
        /// </summary>
        /// <param name="headerCode"></param>
        /// <param name="sNumber"></param>
        /// <returns>返回加一后的读者编码</returns>
        public static string NumberPlusOne(string headerCode, string sNumber)
        {
            int len = sNumber.Length;
            int iHeadLen = headerCode.Length;
            sNumber = sNumber.Substring(iHeadLen, len - iHeadLen);
            //int iNumber = sNumber.ChangeInt() + 1;
            int iNumber = 1;
            return FillIn(headerCode, iNumber.ToString());
        }

        #endregion


        #region 构造11位编码
        /// <summary>
        /// 构造11位编码
        /// </summary>
        /// <param name="dataSource"></param>
        /// <returns></returns>
        private static string FillIn(string headerCode, string dataSource)
        {
            // 首先得到字符串长度
            int len = dataSource.Length;
            // 判断字符串是否已经是11位了
            //if (len == CommConst.ReaderNumberLen) return dataSource;
            //// 如果不是11位，进行补零操作(在左边)
            //int end = CommConst.ReaderNumberLen - len;
            //for (int i = 0; i <= end; i++)
            //{
            //    dataSource = "0" + dataSource;
            //}
            return headerCode + dataSource;
        }
        #endregion

        #region 绑定出版社


        //public static void PublishDataBind(UIComboBox cbo)
        //{
        //    try
        //    {
        //        PublishHouseBLL bll = new PublishHouseBLL();
        //        cbo.DataSource = bll.GetPublishHouses();
        //        cbo.DisplayMember = "PublishName";
        //        cbo.ValueMember = "PublishId";
        //        if (cbo.Items.Count > 0)
        //            cbo.SelectedIndex = 0;
        //    }
        //    catch (System.Exception err)
        //    {
        //        CommMsgBox.MsgBoxCaveat(err.Message);
        //    }

        //}

        #endregion


        #region 绑定图书类别

        //public static void BookTypeDataBind(UIComboBox cbo)
        //{
        //    try
        //    {
        //        BookTypeBLL bll = new BookTypeBLL();
        //        cbo.DataSource = bll.GetBookTypes();
        //        cbo.DisplayMember = "BookTypeName";
        //        cbo.ValueMember = "BookTypeId";
        //        if (cbo.Items.Count > 0)
        //            cbo.SelectedIndex = 0;
        //    }
        //    catch (System.Exception err)
        //    {
        //        CommMsgBox.MsgBoxCaveat(err.Message);
        //    }

        //}

        #endregion

        #region 绑定图书作者

        //public static void AuthorDataBind(UIComboBox cbo)
        //{
        //    try
        //    {
        //        AuthorBLL bll = new AuthorBLL();
        //        cbo.DataSource = bll.GetAuthors();
        //        cbo.DisplayMember = "AuthorName";
        //        cbo.ValueMember = "AuthorId";
        //        if (cbo.Items.Count > 0)
        //            cbo.SelectedIndex = 0;
        //    }
        //    catch (System.Exception err)
        //    {
        //        CommMsgBox.MsgBoxCaveat(err.Message);
        //    }

        //}

        #endregion

        #region 验证纯数字
        /// <summary>
        /// 验证纯数字
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsDigital(string input)
        {
            return Regex.IsMatch(input, "^[1-9]([0-9])*$");
        }

        #endregion


        #region 验证小数点后面有两位数字
        /// <summary>
        /// 验证小数点后面有两位数字
        /// </summary>
        /// <param name="input">输入的值</param>
        /// <returns>正确返回True 否则返回False</returns>
        public static bool IsDecimal(string input)
        {
            return Regex.IsMatch(input, @"^(\d+)$|^(\d+[.]\d{2})$");

        }

        #endregion

        #region  Image类型转换Byte类型

        /// <summary>
        /// Image类型转换Byte类型
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static byte[] ImageToByte(Image img)
        {
            MemoryStream stream = new MemoryStream();
            img.Save(stream, ImageFormat.Bmp);
            byte[] bytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(bytes, 0, bytes.Length);
            stream.Close();
            return bytes;

        }

        #endregion


        #region Byte类型转换Image类型

        /// <summary>
        /// Byte类型转换Image类型
        /// </summary>
        /// <param name="bytes">二进制字节</param>
        /// <returns>返回Image类型</returns>
        public static Image ByteToImage(byte[] bytes)
        {
            MemoryStream stream = new MemoryStream(bytes);
            Image img = Image.FromStream(stream);

            return img;
        }

        #endregion


        #region 重新绘制GroupBox

        public static void GrpupBoxPaint(GroupBox gb, PaintEventArgs e)
        {
            Brush brush = Brushes.Red;
            Font gbFont = gb.Font;
            Pen pen = Pens.Green;
            string gbText = gb.Text.Trim();
            int igbW = gb.Width - 2;
            int igbH = gb.Height - 2;
            e.Graphics.Clear(gb.BackColor); // 设置默认背景色
            e.Graphics.DrawString(gbText, gbFont, brush, 10, 1);
            e.Graphics.DrawLine(pen, 1, 7, 8, 7);   // 左上角的线条
            e.Graphics.DrawLine(pen, e.Graphics.MeasureString(gbText, gbFont).Width + 7, 7, gb.Width, 7);
            e.Graphics.DrawLine(pen, 1, 7, 9, igbH);// 左边的线条
            e.Graphics.DrawLine(pen, 1, igbH, igbW, igbH);  // 底部的线条
            e.Graphics.DrawLine(pen, igbW, 7, igbW, igbH);  // 右边的线条
        }

        #endregion
    }
}
