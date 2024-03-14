namespace DIFromScratch.DependencyInjection;

public class DiServiceCollection
{
	private readonly List<ServiceDescriptor> _serviceDescriptors = new();

	public void RegisterSingleton<TService>(TService? implementation)
	{
		_serviceDescriptors.Add(new ServiceDescriptor(implementation, ServiceLifeTime.Singleton));
	}

	public void RegisterSingleton<TService, TImplementation>()
		where TImplementation : TService
	{
		_serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifeTime.Singleton));
	}

	public void RegisterSingleton<TService>()
	{
		_serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifeTime.Singleton));
	}

	public void RegisterTransient<TService>()
	{
		_serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifeTime.Transient));
	}

	public void RegisterTransient<TService, TImplementation>()
		where TImplementation : TService
	{
		_serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifeTime.Transient));
	}

	public DiContainer Build()
	{
		return new DiContainer(_serviceDescriptors);
	}
}
