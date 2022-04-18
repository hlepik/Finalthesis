namespace Contracts.DAL.App.Repositories;

public interface IInstructionRepository : IBaseRepository<Instruction>, IInstructionRepositoryCustom<Instruction>
{
}

public interface IInstructionRepositoryCustom<TEntity>
{
    Task<IEnumerable<TEntity>> GetAllByCategory(Guid id,
        bool noTracking = true);
    Task<IEnumerable<TEntity>> GetLastInsertedAsync(Guid userId = default, bool noTracking = true);
    Task<TEntity?> FirstOrDefaultDtoAsync(Guid id, bool noTracking = true);
    Task<IEnumerable<TEntity?>> GetSearchResult(string searchInput, Guid? categoryId);
    void CalculateMeasurements(Guid id);
}