using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;

namespace CQS.Demo.ConsoleApp.Infrastructure
{
    public class Logger : ILogger
    {
        public void Error(string message)  => Console.Error.WriteLine(message);

        public void Error(string pattern, params object[] parameters) => Error(String.Format(pattern, parameters));

        public void Info(string message) => Console.WriteLine(message);

        public void Info(string pattern, params object[] parameters) => Info(String.Format(pattern, parameters));
    }
}
