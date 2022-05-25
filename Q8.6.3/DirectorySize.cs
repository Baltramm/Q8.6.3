using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Q8._6._3
{
    public static class DirectorySize
    {
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            FileInfo[] files = d.GetFiles();
            foreach (FileInfo fi in files)
            {
                size += fi.Length;
            }
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);

            }
            return size;
        }
    }
}
