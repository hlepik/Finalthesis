namespace Contracts.DAL.App.Repositories;
public interface IBodyMeasurementsRepository: IBaseRepository<BodyMeasurements>, IBodyMeasurementsRepositoryCustom<BodyMeasurements>
    {

    }

    public interface IBodyMeasurementsRepositoryCustom<TEntity>
    {
    }
