using System;
using System.Collections.Generic;
using System.Text;

namespace BankTranfertLibrary.Interfaces
{
    public interface ILogger
    {
        void Log(Severity severity, string message);
    }
}
