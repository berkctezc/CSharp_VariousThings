namespace DIFromScratch.DependencyInjection;

public class DiContainer
{
    private readonly List<ServiceDescriptor> _serviceDescriptors;

    public DiContainer(List<ServiceDescriptor> serviceDescriptors)
    {
        _serviceDescriptors = serviceDescriptors;
    }

    public object? GetService(Type serviceType)
    {
        var descriptor = _serviceDescriptors.SingleOrDefault(x => x.ServiceType == serviceType);

        if (descriptor is null) throw new Exception($"service of type {serviceType.Name} isn't registered");

        if (descriptor.Implementation is not null) return descriptor.Implementation;

        var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

        if (actualType.IsAbstract || actualType.IsInterface) throw new Exception("cannot instantiate abstract classes or interfaces");

        var constructorInfo = actualType.GetConstructors().First();

        var parameters = constructorInfo.GetParameters().Select(x => GetService(x.ParameterType)).ToArray();

        var implementation = Activator.CreateInstance(actualType, parameters);

        if (descriptor.LifeTime == ServiceLifeTime.Singleton) descriptor.Implementation = implementation;

        return implementation;
    }

    public T GetService<T>()
    {
        return (T) GetService(typeof(T))!;
    }
}