using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureViewermasterpro
{
    public static class Stat
    {
        public static bool SprawdzPlik(string fileName)
        {
            return File.Exists(fileName);
        }
        public static bool SprawzCzyObraz(string fileName)
        {
            if (!File.Exists(fileName))
                return false;

            if (fileName.ToLower().Contains("jpg"))
                return true;
            else if (fileName.ToLower().Contains("bmp"))
                return true;
            else if (fileName.ToLower().Contains("png"))
                return true;

            return false;
        }
    }
}
