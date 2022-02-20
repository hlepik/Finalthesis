namespace BLL.App;

public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBLL
{
    protected IMapper Mapper;

    public AppBLL(IAppUnitOfWork uow, IMapper mapper) : base(uow)
    {
        Mapper = mapper;
    }

    public IBodyMeasurementsService BodyMeasurements =>
        GetService<IBodyMeasurementsService>(() => new BodyMeasurementsService(Uow, Uow.BodyMeasurements, Mapper));


    public ICategoryService Category =>
        GetService<ICategoryService>(() => new CategoryService(Uow, Uow.Category, Mapper));

    public IInstructionService Instruction =>
        GetService<IInstructionService>(() => new InstructionService(Uow, Uow.Instruction, Mapper));

    public IPatternInstructionService PatternInstruction =>
        GetService<IPatternInstructionService>(() =>
            new PatternInstructionService(Uow, Uow.PatternInstruction, Mapper));

    public IPatternService Pattern =>
        GetService<IPatternService>(() => new PatternService(Uow, Uow.Pattern, Mapper));

    public IPictureService Picture =>
        GetService<IPictureService>(() => new PictureService(Uow, Uow.Picture, Mapper));

    public ISubCategoryService SubCategory =>
        GetService<ISubCategoryService>(() => new SubCategoryService(Uow, Uow.SubCategory, Mapper));

    public IUnitService Unit =>
        GetService<IUnitService>(() => new UnitService(Uow, Uow.Unit, Mapper));

    public IUserPatternService UserPattern =>
        GetService<IUserPatternService>(() => new UserPatternService(Uow, Uow.UserPattern, Mapper));
}