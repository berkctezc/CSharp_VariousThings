using Autofac;
using MoqDemo_Library.Logic;
using MoqDemo_Library.Utilities;

namespace MoqDemo_ConsoleUI;

public static class ContainerConfig
{
    public static IContainer Configure()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<Application>().As<IApplication>();
        builder.RegisterType<PersonProcessor>().As<IPersonProcessor>();
        builder.RegisterType<SqliteDataAccess>().As<ISqliteDataAccess>();

        return builder.Build();
    }
}