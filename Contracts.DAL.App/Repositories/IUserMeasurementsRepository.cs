namespace Contracts.DAL.App.Repositories;

public interface IUserMeasurementsRepository: IBaseRepository<UserMeasurements>, IInstructionMeasurementTypeRepositoryCustom<UserMeasurements>
{
}

public interface IInstructionMeasurementTypeRepositoryCustom<TEntity>
{
}