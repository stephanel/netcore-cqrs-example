using CQS.Demo.ConsoleApp.Database;
using System;

namespace CQS.Demo.ConsoleApp.Entities
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
