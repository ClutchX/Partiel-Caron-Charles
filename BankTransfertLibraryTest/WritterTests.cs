using BankTranfertLibrary;
using BankTranfertLibrary.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace BankTransfertLibraryTest
{
    [TestClass]
    public class WritterTests
    {
        [TestMethod]
        public void Test01()
        {
            var bankTransfert = new BankTransfert();
            bankTransfert.Transfert(1, 12.2m, "4514561", "8546129856");
        }

        [TestMethod]
        public void FileExists()
        {
            //Arrange
            IWritter writter = new MyWritter();
            var title = $"transaction_{DateTime.Now.ToString("dd_MM_yy")}.csv";

            //Act
            writter.WriteToCsv(1, 10, "From Bank IBAN", "To Bank IBAN");

            //Assert
            Assert.IsTrue(File.Exists(title));
        }

        [TestMethod]
        public void HeaderCheck()
        {
            //Arrange
            IWritter writter = new MyWritter();
            var title = $"transaction_{DateTime.Now.ToString("dd_MM_yy")}.csv";
            string firstLine;

            //Act
            writter.WriteToCsv(1, 10, "From Bank IBAN", "To Bank IBAN");

            using (StreamReader sr = new StreamReader(title))
            {
                firstLine = sr.ReadLine();
                sr.Close();
            }

            //Assert
            Assert.AreEqual("Transaction;Amount;From;To", firstLine);
        }

        [TestMethod]
        public void WriteInFile()
        {
            //Arrange
            IWritter writter = new MyWritter();
            var title = $"transaction_{DateTime.Now.ToString("dd_MM_yy")}.csv";
            string lastLine = "";

            //Act
            writter.WriteToCsv(2, 20, "From Bank IBAN", "To Bank IBAN");
            using (StreamReader sr = new StreamReader(title))
            {
                while (sr.EndOfStream == false)
                {
                    lastLine = sr.ReadLine();
                }
                sr.Close();
            }

            //Assert
            Assert.AreEqual("2;20;From Bank IBAN;To Bank IBAN", lastLine);
        }
    }
}
