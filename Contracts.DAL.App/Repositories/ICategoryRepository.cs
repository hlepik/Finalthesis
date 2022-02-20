namespace Contracts.DAL.App.Repositories;

public interface ICategoryRepository : IBaseRepository<Category>, ICategoryRepositoryCustom<Category>
{
}

public interface ICategoryRepositoryCustom<TEntity>
{
}