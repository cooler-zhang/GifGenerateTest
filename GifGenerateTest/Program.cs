using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifGenerateTest
{
    class Program
    {
        private const string SOURCE_IMAGE_FOLDER = @"D:\TestProjects\GifGenerateTest\Images\Source";
        private const string TARGET_IMAGE_FOLDER = @"D:\TestProjects\GifGenerateTest\Images\Target";
        static void Main(string[] args)
        {
            ImageHelper.ImagesToGif(SOURCE_IMAGE_FOLDER, Path.Combine(TARGET_IMAGE_FOLDER, "a.gif"), 200, true);
            ImageHelper.GifToImages(Path.Combine(TARGET_IMAGE_FOLDER, "a.gif"), Path.Combine(SOURCE_IMAGE_FOLDER, "Test"));
        }
    }
}
