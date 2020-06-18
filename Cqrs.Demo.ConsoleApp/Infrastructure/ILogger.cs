using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs.Demo.ConsoleApp.Infrastructure
{
    public interface ILogger
    {
        void Error(string message);
        void Error(string pattern, params object[] parameters);
        void Info(string message);
        void Info(string pattern , params object[] parameters);
    }
}
