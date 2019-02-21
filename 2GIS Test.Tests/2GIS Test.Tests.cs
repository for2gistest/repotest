using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2GIS_Test.Tests
{
    [TestClass]
    public class UnitTest_Find
    {
        [TestInitialize]

        public void TestInit()
        {
            string filename = "Numbers.txt";
            int len = 100;
            Program.WriteNewNumFile(filename, len);
        }

        [TestMethod]
        public void Str_Included_Only_Rus_Symbols()
        {
            string testString = "abcdefghijklmnopqrstuvwxyz";
            int expected = 0;

            List<string> act = new List<string>();
            for (int i = 0; i < testString.Length; i++)
            {
                act = Program.FindAllStrings(testString[i].ToString());
                if (act.Count > 0) break;
            }

            Assert.AreEqual(expected, act.Count);
        }

        [TestMethod]
        public void Str_Nothing()
        {

            string testString = "";
            int expected = 100;

            List<string> act = Program.FindAllStrings(testString);

            Assert.AreEqual(expected, act.Count);

        }

        [TestMethod]
        public void Find_Valid_Str()
        {
            string filename = "Numbers.txt";
            StreamReader sr = new StreamReader(filename);
            Random rnd = new Random(DateTime.Now.Month);
            int strNum = rnd.Next(0, 98);
            for (int i = 0; i < strNum; i++) sr.ReadLine();
            string testString = sr.ReadLine();
            bool expected = true;

            bool result = false;
            List<string> act = Program.FindAllStrings(testString);
            if (act.Count > 0) result = true;

            Assert.AreEqual(expected, result);

        }

    }


    [TestClass]
    public class UnitTest_RndStr
    {
        [TestMethod]
        public void Correct_Len_String()
        {
            string useSymbols = "абвгдежзийклмнопрстуфхцчшщыэюя";
            int lenString = 2;
            int expected = 2;

            int len = Program.GetRandomString(useSymbols, lenString).Length;

            Assert.AreEqual(expected, len);

        }
        [TestMethod]
        public void Correct_Symbols_in_String()
        {
            string useSymbols = "абвгдежзийклмнопрстуфхцчшщыэюя";
            int lenString = 5;

            List<char> useChars = new List<char>();
            for (int i = 0; i < useSymbols.Length; i++) useChars.Add(useSymbols[i]);

            string ourString = Program.GetRandomString(useSymbols, lenString);

            List<char> charsInString = new List<char>();
            for (int i = 0; i < lenString; i++) charsInString.Add(ourString[i]);

            for(int i = 0;i<charsInString.Count;i++)
            CollectionAssert.Contains(useChars, charsInString[i]);

        }

    }
}
