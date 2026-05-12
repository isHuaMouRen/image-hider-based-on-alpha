using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageHiderBasedOnAlpha.Utils
{
    public class ImageHider
    {
        /// <summary>
        /// 调整Alpha通道为0来达到隐藏图片的目的
        /// </summary>
        /// <param name="inputPath">图片的路径</param>
        /// <param name="alphaValue">Alpha值</param>
        /// <returns>处理过后的图像</returns>
        /// <exception cref="Exception">alphaValue值取值范围为 0~255</exception>
        public static Bitmap HideImage(string inputPath, int alphaValue)
        {
            if (alphaValue < 0 || alphaValue > 255) 
                throw new Exception("alphaValue值取值范围为 0~255");

            Bitmap temp = new Bitmap(inputPath);
            //新建一个支持ALPHA通道的bitmap，避免输入jpg这类不支持alpha通道的图像
            Bitmap bmp = temp.Clone(new Rectangle(0, 0, temp.Width, temp.Height), System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            temp.Dispose();

            //遍历每个像素
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    //处理像素
                    var originalColor = bmp.GetPixel(x, y);
                    var hiddenColor = Color.FromArgb(alphaValue, originalColor.R, originalColor.G, originalColor.B);

                    bmp.SetPixel(x, y, hiddenColor);
                }
            }

            return bmp;

        }
    }
}
