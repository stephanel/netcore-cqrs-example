using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs.Demo.ConsoleApp.Database
{
    public interface IEntity
    {
        int Id { get; set; }
    }
}
