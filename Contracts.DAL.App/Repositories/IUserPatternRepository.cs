namespace Contracts.DAL.App.Repositories;
public interface IUserPatternRepository: IBaseRepository<UserPattern>, IUserPatternRepositoryCustom<UserPattern>
    {

    }

    public interface IUserPatternRepositoryCustom<TEntity>
    {
    }
