namespace Contracts.DAL.App.Repositories;

public interface IPictureRepository : IBaseRepository<Picture>, IPictureRepositoryCustom<Picture>
{
}

public interface IPictureRepositoryCustom<TEntity>
{
}