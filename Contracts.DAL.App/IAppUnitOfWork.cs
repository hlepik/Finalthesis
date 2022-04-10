namespace Contracts.DAL.App;

public interface IAppUnitOfWork : IBaseUnitOfWork
{
    IBodyMeasurementsRepository BodyMeasurements { get; }
    ICategoryRepository Category { get; }
    IInstructionRepository Instruction { get; }
    IExtraSizeRepository ExtraSize { get; }
    IPatternInstructionRepository PatternInstruction { get; }
    ISubCategoryRepository SubCategory { get; }
    IUnitRepository Unit { get; }
    IUserPatternRepository UserPattern { get; }
    IMeasurementTypeRepository MeasurementType { get; }

    IUserMeasurementsRepository UserMeasurements { get; }

}