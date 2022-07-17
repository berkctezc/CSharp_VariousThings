namespace DIFromScratch.DependencyInjection;

public class ServiceDescriptor
{
    public ServiceDescriptor(object? implementation, ServiceLifeTime lifetime)
    {
        ServiceType = implementation!.GetType();
        Implementation = implementation;
        LifeTime = lifetime;
    }

    public ServiceDescriptor(Type serviceType, ServiceLifeTime lifetime)
    {
        ServiceType = serviceType;
        LifeTime = lifetime;
    }

    public ServiceDescriptor(Type serviceType, Type? implementationType, ServiceLifeTime lifetime)
    {
        ServiceType = serviceType;
        LifeTime = lifetime;
        ImplementationType = implementationType;
    }

    public Type ServiceType { get; }

    public Type? ImplementationType { get; set; }

    public object? Implementation { get; internal set; }

    public ServiceLifeTime LifeTime { get; }
}