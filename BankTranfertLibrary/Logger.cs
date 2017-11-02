using BankTranfertLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankTranfertLibrary
{
    public enum Severity
    {
        Info, 
        Warning,
        Error,
    }
    public class Logger : ILogger
    {
        public void Log(Severity severity, string message)
        {
            File.AppendAllText("logs.txt", $"{severity.ToString()} - {message}");
        }
    }
}
