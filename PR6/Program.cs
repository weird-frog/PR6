using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR6
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            string path = Path.Combine(Environment.CurrentDirectory, "text.txt"); //путь до папки с exe
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                byte[] array = new byte[10];

                for (byte i = 0; i < 10; ++i)
                {
                    array[i] = (byte)(random.Next(0,255));
                }

                fileStream.Write(array, 0, 10);
                int x, count = 0;
                fileStream.Seek(0, SeekOrigin.Begin);

                for (int i = 0; i < 10; i++)
                {
                    x = fileStream.ReadByte();
                    if (x % 2 != 0)
                    {
                        count++;
                    }
                    Console.Write(x + " "); //контрольная печать считанного значения
                }
                Console.WriteLine($"\nКоличество нечетных: {count}");
                fileStream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при работе с файлом: " + e.Message);
            }
            Console.ReadKey();
        }
    }
}
