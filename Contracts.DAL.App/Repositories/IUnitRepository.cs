namespace Contracts.DAL.App.Repositories;

public interface IUnitRepository : IBaseRepository<Unit>, IUnitRepositoryCustom<Unit>
{
}

public interface IUnitRepositoryCustom<TEntity>
{
}