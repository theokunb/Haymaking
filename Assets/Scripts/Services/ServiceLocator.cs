using System.Collections.Generic;

public class ServiceLocator
{
    private static ServiceLocator _instance;
    public static ServiceLocator Instance
    {
        get
        {
            return _instance ?? (_instance = new ServiceLocator());
        }
    }

    private Dictionary<string, IService> _services;

    public ServiceLocator()
    {
        _services = new Dictionary<string, IService>();
    }

    public void Register<T>(T service) where T : IService
    {
        var serviceName = typeof(T).Name;
        if (_services.ContainsKey(serviceName))
        {
            _services[serviceName] = service;
        }
        else
        {
            _services.Add(serviceName, service);
        }
    }

    public T GetService<T>() where T : IService
    {
        var serviceName = typeof(T).Name;
        if (_services.ContainsKey(serviceName))
        {
            return (T)_services[serviceName];
        }
        else
        {
            return default;
        }
    }

    public void Unregister<T>() where T : IService
    {
        var serviceName = typeof(T).Name; 
        if (_services.ContainsKey(serviceName))
        {
            _services.Remove(serviceName);
        }
    }
}