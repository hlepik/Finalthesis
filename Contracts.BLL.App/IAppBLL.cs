namespace Contracts.BLL.App;
public interface IAppBLL : IBaseBLL
    {

        IBodyMeasurementsService BodyMeasurements { get; }
        ICategoryService Category { get; }
        IInstructionService Instruction { get; }
        IPatternInstructionService PatternInstruction { get; }
        IPatternService Pattern { get; }
        IPictureService Picture { get; }
        ISubCategoryService SubCategory { get; }
        IUnitService Unit { get; }
        IUserPatternService UserPattern { get; }
    }