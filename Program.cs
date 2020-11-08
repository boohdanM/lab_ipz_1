using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System;
using System.IO;
using System.Net;

namespace task1
{
    class Program
    {
        // cd D:\унив\2 курс\4 semester\sys_proga\lab1\lab1\task1\task1\bin\Debug\netcoreapp3.1
        static void Main(string[] args)
        {
            Task1(args);
        }
        private static void Task1(string[] args)
        {
            if (args?.Length != 2)
            {
                Console.WriteLine("enter 2 arguments");
                return;
            }
            string original = @"D:\унив\2 курс\4 semester\sys_proga\lab1\lab1\task1\task1\original.txt"; // Оригінал файлу
            string light = @"D:\унив\2 курс\4 semester\sys_proga\lab1\lab1\task1\task1\About_LIGHT.txt"; // "Полегшена" версія

            // завантаження файлу
            using (WebClient W = new WebClient())
            {
                W.DownloadFile($"ftp://ftp.ua.debian.org/about/ftp-about-SPmkII.html", original);
            }

            // читання і запис
            using (StreamReader sr = new StreamReader(original))
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(light, FileMode.Create, FileAccess.Write)))
                {
                    while (sr.Peek() != -1)
                    {
                        string line = sr.ReadLine();
                        if (!line.ToLower().Contains(args[0]) && !line.ToLower().Contains(args[1]) && !line.StartsWith("The"))
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            }
            Console.WriteLine("Success!");
        }

    }
}
