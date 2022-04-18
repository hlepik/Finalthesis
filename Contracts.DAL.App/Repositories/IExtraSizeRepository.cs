namespace Contracts.DAL.App.Repositories;

public interface IExtraSizeRepository : IBaseRepository<ExtraSize>, IExtraSizeRepositoryCustom<ExtraSize>
{
}

public interface IExtraSizeRepositoryCustom<TEntity>
{
    Task<IEnumerable<TEntity>?> GetAllByInstructionId(Guid id);
    void RemoveByInstructionId(Guid? id);
    

}