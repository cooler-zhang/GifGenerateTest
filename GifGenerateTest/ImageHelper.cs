using Gif.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifGenerateTest
{
    public  class ImageHelper
    {
        /// <summary>
        /// 把Gif文件转成Png文件，放在directory目录下
        /// </summary>
        /// <param name="file"></param>
        /// <param name="imageDirectory"></param>
        public static void GifToImages(string gifFile, string imageDirectory)
        {
            var gifDecoder = new GifDecoder();
            imageDirectory += "\\";
            if (!Directory.Exists(imageDirectory))
            {
                Directory.CreateDirectory(imageDirectory);
            }
            //读取
            gifDecoder.Read(gifFile);
            for (int i = 0, count = gifDecoder.GetFrameCount(); i < count; i++)
            {
                var frame = gifDecoder.GetFrame(i);  // frame i
                frame.Save(imageDirectory + "\\" + i.ToString("d2") + ".png", ImageFormat.Png);
                //转成jpg
                //frame.Save(directory + "\\" + i.ToString("d2") + ".jpg", ImageFormat.Jpeg);
            }
        }

        /// <summary>
        /// 把directory文件夹里的png文件生成为gif文件，放在giffile
        /// </summary>
        /// <param name="imageDirectory">png文件夹</param>
        /// <param name="gifFile">gif保存路径</param>
        /// <param name="delayTime">每帧的时间/ms</param>
        /// <param name="isRepeat">是否重复</param>
        public static void ImagesToGif(string imageDirectory, string gifFile, int delayTime, bool isRepeat)
        {
            //一般文件名按顺序排
            string[] pngFiles = Directory.GetFileSystemEntries(imageDirectory, "*.*");

            var e = new AnimatedGifEncoder();
            e.Start(gifFile);

            //每帧播放时间
            e.SetDelay(delayTime);

            //-1：不重复，0：重复
            e.SetRepeat(isRepeat ? 0 : -1);
            for (int i = 0, count = pngFiles.Length; i < count; i++)
            {
                e.AddFrame(Image.FromFile(pngFiles[i]));
            }
            e.Finish();
        }
    }
}
