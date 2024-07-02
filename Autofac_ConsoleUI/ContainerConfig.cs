namespace Autofac_ConsoleUI;

public static class ContainerConfig
{
	public static IContainer Configure()
	{
		var builder = new ContainerBuilder();

		builder.RegisterType<Application>().As<IApplication>();
		// builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();
		builder.RegisterType<BetterBusinessLogic>().As<IBusinessLogic>();

		builder.RegisterAssemblyTypes(Assembly.Load(nameof(Autofac_ClassLibrary)))
			.Where(t => t.Namespace.Contains("Utilities"))
			.As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

		return builder.Build();
	}
}