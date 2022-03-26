namespace DAL.App.EF;

public class AppUnitOfWork : BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
{
    protected IMapper Mapper;

    public AppUnitOfWork(AppDbContext uowDbContext, IMapper mapper) : base(uowDbContext)
    {
        Mapper = mapper;
    }

    public IBodyMeasurementsRepository BodyMeasurements =>
        GetRepository(() => new BodyMeasurementsRepository(UowDbContext, Mapper));

    public ICategoryRepository Category => GetRepository(() => new CategoryRepository(UowDbContext, Mapper));
    public IInstructionRepository Instruction => GetRepository(() => new InstructionRepository(UowDbContext, Mapper));
    public IPatternRepository Pattern => GetRepository(() => new PatternRepository(UowDbContext, Mapper));

    public IPatternInstructionRepository PatternInstruction =>
        GetRepository(() => new PatternInstructionRepository(UowDbContext, Mapper));

    public IPictureRepository Picture => GetRepository(() => new PictureRepository(UowDbContext, Mapper));
    public ISubCategoryRepository SubCategory => GetRepository(() => new SubCategoryRepository(UowDbContext, Mapper));
    public IUnitRepository Unit => GetRepository(() => new UnitRepository(UowDbContext, Mapper));
    public IUserPatternRepository UserPattern => GetRepository(() => new UserPatternRepository(UowDbContext, Mapper));

}