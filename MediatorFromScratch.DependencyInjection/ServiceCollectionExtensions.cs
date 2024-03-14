namespace MediatorFromScratch.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddMediator(
		this IServiceCollection services,
		ServiceLifetime lifetime,
		params Type[] markers)
	{
		var handlerInfo = new Dictionary<Type, Type>();

		foreach (var marker in markers)
		{
			var assembly = marker.Assembly;

			var requests = GetClassesImplementingInterface(assembly, typeof(IRequest<>));
			var handlers = GetClassesImplementingInterface(assembly, typeof(IHandler<,>));

			requests.ForEach(x =>
				handlerInfo[x] = handlers.SingleOrDefault(xx => xx == xx.GetInterface("IHandler`2")!.GetGenericArguments()[0])!);

			var serviceDescriptor = handlers.Select(x => new ServiceDescriptor(x, x, lifetime));
			services.TryAdd(serviceDescriptor);
		}

		services.AddSingleton<IMediator>(x => new Mediator(x.GetRequiredService, handlerInfo));

		return services;
	}

	private static List<Type> GetClassesImplementingInterface(Assembly assembly, Type typeToMatch)
	{
		return assembly.ExportedTypes
			.Where(t =>
			{
				var implementRequestType = t.GetInterfaces()
					.Where(x => x.IsGenericType)
					.Any(x => x.GetGenericTypeDefinition() == typeToMatch);
				return !t.IsInterface && !t.IsAbstract && implementRequestType;
			}).ToList();
	}
}
