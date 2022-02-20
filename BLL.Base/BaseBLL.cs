﻿namespace BLL.Base;

public class BaseBLL<TUnitOfWork> : IBaseBLL
    where TUnitOfWork : IBaseUnitOfWork
{
    private readonly Dictionary<Type, object> _serviceCache = new();
    protected readonly TUnitOfWork Uow;

    public BaseBLL(TUnitOfWork uow)
    {
        Uow = uow;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await Uow.SaveChangesAsync();
    }

    public TService GetService<TService>(Func<TService> serviceCreationMethod) where TService : class
    {
        if (_serviceCache.TryGetValue(typeof(TService), out var repo)) return (TService) repo;

        var repoInstance = serviceCreationMethod();
        _serviceCache.Add(typeof(TService), repoInstance);
        return repoInstance;
    }
}