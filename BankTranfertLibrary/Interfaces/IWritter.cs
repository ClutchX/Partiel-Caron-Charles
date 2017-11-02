using System;
using System.Collections.Generic;
using System.Text;

namespace BankTranfertLibrary.Interfaces
{
    public interface IWritter
    {
        void WriteToCsv(uint transactionId, decimal amount, string fromBankIban, string toBankIban);
    }
}
