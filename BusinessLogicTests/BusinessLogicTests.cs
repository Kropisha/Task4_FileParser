using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4_FileParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_FileParser.Tests
{
    [TestClass()]
    public class BusinessLogicTests
    {
        [TestMethod()]
        public void SearchString_CorrectTest()
        {
            //arrange
            BusinessLogic bl = new BusinessLogic();
            string path = "D:/Projects/Task4_FileParser/Task4_FileParser/Files/Example.txt";
            string word = "unsociable";
            int expected = 1;

            //act
            int actual = bl.SearchString(path, word);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ReplaceString_CorrectTest()
        {
            //arrange
            BusinessLogic bl = new BusinessLogic();
            string path = "D:/Projects/Task4_FileParser/Task4_FileParser/Files/Example1.txt";
            string word = "plah";
            string replace = "";
            string expected = "Nothing found to replace.";

            //act
            string actual = bl.ReplaceString(path, word, replace);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}