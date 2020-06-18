using System;
using System.Collections.Generic;
using System.Text;

namespace CQS.Demo.ConsoleApp.Cqs
{
    public interface IQueryDispatcher
    {
        TResult Dispatch<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IResult;
    }
}
