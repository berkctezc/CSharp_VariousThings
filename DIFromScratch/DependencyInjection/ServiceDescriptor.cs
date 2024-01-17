namespace DIFromScratch.DependencyInjection;

public class ServiceDescriptor(Type serviceType, Type? implementationType, ServiceLifeTime lifetime)
{
    public ServiceDescriptor(object? implementation, ServiceLifeTime lifetime) : this(implementation!.GetType(), null, lifetime)
    {
        Implementation = implementation;
    }

    public ServiceDescriptor(Type serviceType, ServiceLifeTime lifetime) : this(serviceType, null, lifetime)
    {
    }

    public Type ServiceType { get; } = serviceType;

    public Type? ImplementationType { get; set; } = implementationType;

    public object? Implementation { get; internal set; }

    public ServiceLifeTime LifeTime { get; } = lifetime;
}