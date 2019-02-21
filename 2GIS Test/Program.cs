using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2GIS_Test
{
    public class Program
    {
        readonly static string filename = "Numbers.txt";
        readonly static int countNumbers = 100;

        public static string GetRandomString(string usesymbols, int len)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            StringBuilder sb = new StringBuilder(len - 1);
            int pos = 0;
            for (int i = 0; i < len; i++)
            {
                pos = rnd.Next(0, usesymbols.Length - 1);
                Thread.Sleep(1);
                sb.Append(usesymbols[pos]);
            }
            return sb.ToString();
        }

        public static void WriteNewNumFile(string fname,int lenght)
        {
            StreamWriter writer = new StreamWriter(fname);
            for (int i = 0; i < lenght; i++)
            {
                string newline = GetRandomString("абвгдежзийклмнопрстуфхцчшщыэюя", 1) + GetRandomString("0123456789", 3) + GetRandomString("абвгдежзийклмнопрстуфхцчшщыэюя", 2);
                writer.WriteLine(newline);
            }
            writer.Close();
            Console.WriteLine("База автомобильных номеров заполнена");
        }

        public static List<string> FindAllStrings(String findString)
        {
            StreamReader reader = new StreamReader(filename);
            List<string> allNum = new List<string>();
            for (int i = 0; i < countNumbers; i++)
            {
                string compareString = reader.ReadLine();
                if(compareString.Contains(findString))
                {
                    allNum.Add(compareString);
                }
            }
            return allNum;
        }

        private static void NewFind()
        {
            Console.WriteLine("Повторить поиск? y/n");
            if (Console.ReadLine() == "y" || Console.ReadLine() == "Y")
            {
                Console.Clear();
                InterfaceProg();
            }
            else return;
        }
        private static void InterfaceProg()
        {
            Console.WriteLine("Введите строку для поиска не меньше одного символа и не больше шести:");
            string findstr = Console.ReadLine();
            if (findstr.Length < 1 || findstr.Length > 6)
            {
                Console.WriteLine("Ошибка! Повторите поиск!");
                NewFind();
            }
            List<string> allNumbers = FindAllStrings(findstr);
            if (allNumbers.Count > 0)
            {
                for (int i = 0; i < allNumbers.Count; i++)
                {
                    Console.WriteLine(allNumbers[i]);
                }
                Console.WriteLine("Всего найдено: " + allNumbers.Count + " результатов");
            }
            NewFind();
        }

        static void Main(string[] args)
        {
            WriteNewNumFile(filename,countNumbers);
            InterfaceProg();
        }
    }
}
