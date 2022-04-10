namespace Contracts.DAL.App.Repositories;

public interface IMeasurementTypeRepository: IBaseRepository<MeasurementType>, IMeasurementTypeRepositoryCustom<MeasurementType>
{
}

public interface IMeasurementTypeRepositoryCustom<TEntity>
{
}