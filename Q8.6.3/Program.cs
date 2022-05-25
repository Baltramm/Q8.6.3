using System;
using System.IO;

namespace Q8._6._3
{
    class Program
    {
        public static string filePath = @"C://Filex";
        static void Main(string[] args)
        {


           int origfileInfo = 0;
           int origdirInfo = 0;
           int changedfileInfo = 0;
           int changeddirInfo = 0;
           long originalSize = 0;
           long changedSize = 0;

            if (!File.Exists(filePath))
            {
                try
                {
                    var directory = new DirectoryInfo(filePath);
                    originalSize = DirectorySize.DirSize(directory);
                    Console.WriteLine("Исходный размер в байтах:{0}", originalSize);
                    origfileInfo = FileInfo();
                    origdirInfo = DirInfo();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (!File.Exists(filePath))
            {
                try
                {
                    var directory = new DirectoryInfo(filePath);
                    foreach (FileInfo file in directory.GetFiles())
                    {

                        var deltaTime = DateTime.Now - File.GetLastWriteTime(filePath); ;
                        if (deltaTime == TimeSpan.FromMinutes(30))
                        {
                            file.Delete();
                        }

                    }
                    foreach (DirectoryInfo direc in directory.GetDirectories())
                    {
                        var deltaTime = DateTime.Now - File.GetLastWriteTime(filePath);
                        if (deltaTime == TimeSpan.FromMinutes(30))
                        {
                            direc.Delete(true);
                        }


                    }
                    changedSize = DirectorySize.DirSize(directory);
                    Console.WriteLine("Итоговый размер в байтах:{0}", changedSize);
                    changedfileInfo = FileInfo();
                    changeddirInfo = DirInfo();
                    Console.WriteLine("Файлов было удалено:{0}", origfileInfo - changedfileInfo);
                    Console.WriteLine("Папок было удалено:{0}", origdirInfo - changeddirInfo);
                    Console.WriteLine("Размер очищенных файлов и папок:{0}",originalSize-changedSize);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

      
        public static int FileInfo()
        {
            var directory = new DirectoryInfo(filePath);

            FileInfo[] files = directory.GetFiles();
            int k = 0;
            foreach (FileInfo fi in files)
            {
                k++;
            }
            Console.WriteLine("Количество файлов:{0}", k);
            return k;
        }
        public static int DirInfo()
        {
            var directory = new DirectoryInfo(filePath);
            DirectoryInfo[] directories = directory.GetDirectories();
            int j = 0;
            foreach (DirectoryInfo di in directories)
            {
                j++;
            }
            Console.WriteLine("Количество папок:{0}", j);
            Console.WriteLine();
            return j;
        }
    }
}
