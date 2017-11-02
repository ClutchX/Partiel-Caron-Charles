using BankTranfertLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BankTranfertLibrary
{
    public class BankTransfert
    {
        ILogger log = new Logger();
        IWritter writter = new MyWritter();

        public bool Transfert(uint transactionId, decimal amount, string fromBankIban, string toBankIban)
        {
            if (string.IsNullOrEmpty(fromBankIban) || string.IsNullOrEmpty(toBankIban))
            {
                log.Log(Severity.Error, "Both IBAN should have a value");
                throw new ArgumentNullException();
            }

            var hasTransfered = EmulateTransfert(amount, fromBankIban, toBankIban);

            if (!hasTransfered)
            {
                log.Log(Severity.Error, "Transfert interrupted");
                throw new InvalidOperationException();
            }

            try
            {
                writter.WriteToCsv(transactionId, amount, fromBankIban, toBankIban);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Arguments for writter are not valid.");
            }

            return true;
        }


        /// <summary>
        /// Cette méthode émule une transfert bancaire vers un tiers
        /// Elle se compose d'un timeout et renvoie true
        /// Tester le temps d'execution de la méthod transfert car elle doit toujours être inférieur à 5sec
        /// </summary>
        /// <returns></returns>
        public bool EmulateTransfert(decimal amount, string fromBankIban, string toBankIban)
        {
            System.Threading.Thread.Sleep((int)TimeSpan.FromSeconds(4).TotalMilliseconds);

            return true;
        }


    }
}
