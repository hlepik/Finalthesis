namespace Contracts.DAL.App;

public interface IAppUnitOfWork : IBaseUnitOfWork
{
    IBodyMeasurementsRepository BodyMeasurements { get; }
    ICategoryRepository Category { get; }
    IInstructionRepository Instruction { get; }
    IPatternRepository Pattern { get; }
    IPatternInstructionRepository PatternInstruction { get; }
    ISubCategoryRepository SubCategory { get; }
    IPictureRepository Picture { get; }
    IUnitRepository Unit { get; }
    IUserPatternRepository UserPattern { get; }
}