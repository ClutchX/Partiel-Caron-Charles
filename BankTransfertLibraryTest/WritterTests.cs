using BankTranfertLibrary;
using BankTranfertLibrary.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
    }
}
