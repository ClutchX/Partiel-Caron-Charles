using BankTranfertLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace BankTransfertLibraryTest
{
    [TestClass]
    public class TransferTests
    {
        [TestMethod]
        public void NoIbanFrom()
        {
            //Arrange
            var bank = new BankTransfert();

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => bank.Transfert(1, 1, "", "IBAN TO"));
        }

        [TestMethod]
        public void NoIbanTo()
        {
            //Arrange
            var bank = new BankTransfert();

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => bank.Transfert(1, 1, "IBAN FROM", ""));
        }

        [TestMethod]
        public void EmulateTransfert()
        {
            //Arrange
            var bank = new BankTransfert();
            Stopwatch sw = new Stopwatch();

            //Act
            sw.Start();
            var test = bank.EmulateTransfert(10, "from", "to");
            sw.Stop();
            var elapsedTime = sw.Elapsed.Seconds;

            //Assert
            Assert.IsFalse(elapsedTime > 5);
        }
    }
}
