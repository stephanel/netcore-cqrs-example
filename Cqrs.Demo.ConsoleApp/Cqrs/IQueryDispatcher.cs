using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs.Demo.ConsoleApp.Cqrs
{
    public interface IQueryDispatcher
    {
        TResult Dispatch<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IResult;
    }
}
