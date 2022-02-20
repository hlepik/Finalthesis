namespace Contracts.DAL.App.Repositories;

public interface IInstructionRepository: IBaseRepository<Instruction>, IInstructionRepositoryCustom<Instruction>
    {

    }

    public interface IInstructionRepositoryCustom<TEntity>
    {
    }
