namespace Contracts.BLL.App;

public interface IAppBLL : IBaseBLL
{
    IBodyMeasurementsService BodyMeasurements { get; }
    ICategoryService Category { get; }
    IInstructionService Instruction { get; }
    IPatternInstructionService PatternInstruction { get; }
    IExtraSizeService ExtraSize { get; }
    ISubCategoryService SubCategory { get; }
    IUnitService Unit { get; }
    IUserPatternService UserPattern { get; }
    IMeasurementTypeService MeasurementType { get; }
    IUserMeasurementsService UserMeasurements { get; }

}