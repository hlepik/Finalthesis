namespace Contracts.DAL.App.Repositories;
public interface IPatternRepository: IBaseRepository<Pattern>, IPatternRepositoryCustom<Pattern>
    {

    }

    public interface IPatternRepositoryCustom<TEntity>
    {
    }
