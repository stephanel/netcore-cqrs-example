using Autofac;
using Cqrs.Demo.ConsoleApp.Cqrs;
using Cqrs.Demo.ConsoleApp.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Cqrs.Demo.ConsoleApp.Infrastructure
{
    public static class Bootstrapper
    {
        public static IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            //register the EF DbContext
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            builder.RegisterType<ApplicationDbContext>()
                .AsSelf()
                .WithParameter(new TypedParameter(typeof(DbContextOptions<ApplicationDbContext>), options))
                .InstancePerLifetimeScope();

            var _assembly = Assembly.GetExecutingAssembly();

            // register others types implementing interfaces of assembly
            builder.RegisterAssemblyTypes(_assembly)
                .AsImplementedInterfaces();

            return builder.Build();
        }
    }
}
