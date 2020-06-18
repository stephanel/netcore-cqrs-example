using Autofac;
using CQS.Demo.ConsoleApp.Cqs;
using CQS.Demo.ConsoleApp.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace CQS.Demo.ConsoleApp.Infrastructure
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

            builder.RegisterType<Logger>().As<ILogger>();

            //register the QueryDispatcher and CommandDispatcher
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();

            var _assembly = Assembly.GetExecutingAssembly();

            //Register all QHandlers and all CHandlers found in this assembly
            builder.RegisterAssemblyTypes(_assembly)
                   .AsClosedTypesOf(typeof(IQueryHandler<,>));
            builder.RegisterAssemblyTypes(_assembly)
                   .AsClosedTypesOf(typeof(ICommandHandler<>));


            return builder.Build();
        }
    }
}
