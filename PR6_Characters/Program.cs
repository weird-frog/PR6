using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR6_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            //Занести в файл F 10 символов. Подсчитать, сколько раз встречается среди них буква 'Z'.
            string path = Path.Combine(Environment.CurrentDirectory, "text1.txt"); //путь до папки с exe
            try

            {

                // работа с потоком байтов символы

                FileStream fchar = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                char[] x = new char[10];
                Console.WriteLine("Введите 10 символов");
                //код из лекции, но почему то i увеличивается на 3 при каджой итерации
                for (int i = 0; i < 10; ++i)
                {
                    x[i] = (char)Console.Read();
                    fchar.WriteByte((byte)x[i]); // записывается элемент массива
                }
                Console.ReadLine();
                int a, counter = 0;
                fchar.Seek(0, SeekOrigin.Begin); // текущий указатель - на начало

                for (int i = 0; i < 10; i++)
                {
                    a = fchar.ReadByte();
                    if (a == 90)
                    {
                        counter++;
                    }
                }
                Console.WriteLine($"\nСимвол 'Z' встречается {counter} раз(а)");
                
                fchar.Close();
            }

            catch (Exception e)
            {

                Console.WriteLine("Ошибка работы с файлом: " + e.Message);
            }
            Console.ReadKey();

        }
    }
}
