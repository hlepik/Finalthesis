namespace Contracts.DAL.App.Repositories;

public interface IPatternInstructionRepository : IBaseRepository<PatternInstruction>,
    IPatternInstructionRepositoryCustom<PatternInstruction>
{
}

public interface IPatternInstructionRepositoryCustom<TEntity>
{
    Task<IEnumerable<TEntity>?> GetAllByInstructionId(Guid id);
    void RemoveByInstructionId(Guid? id);

}