namespace Contracts.DAL.App.Repositories;

public interface ISubCategoryRepository : IBaseRepository<SubCategory>, ISubCategoryRepositoryCustom<SubCategory>
{
}

public interface ISubCategoryRepositoryCustom<TEntity>
{
}