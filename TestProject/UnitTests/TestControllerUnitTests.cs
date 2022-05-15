using System;
using System.Collections;
using AutoMapper;
using BLL.App;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Controllers;
using WebApp.ViewModels.Test;


namespace TestProject.UnitTests
{
    public class TestControllerUnitTests
    {
        private readonly TestController _testController;
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly AppDbContext _ctx;
        private DbContextOptionsBuilder<AppDbContext> optionBuilder;


        // ARRANGE - common
        public TestControllerUnitTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

            // set up db context for testing - using InMemory db engine
            optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            // provide new random database name here
            // or parallel test methods will conflict each other
            optionBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _ctx = new AppDbContext(optionBuilder.Options);
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<TestController>();

            // SUT
            _testController = new TestController(logger, _ctx);
        }

        public IAppBLL GetBLL()
        {
            var context = new AppDbContext(optionBuilder.Options);


            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DAL.App.DTO.MappingProfiles.AutoMapperProfile>();
                cfg.AddProfile<BLL.App.DTO.MappingProfiles.AutoMapperProfile>();
            });
            var mapper = mockMapper.CreateMapper();
            var uow = new AppUnitOfWork(context, mapper);
            return new AppBLL(uow, mapper);
        }



        [Fact]
        public async Task Action_Test__Returns_ViewModel()
        {
            //see test tagastab vaid viewmodeli ja count peaks olema alati 0
            // ACT
            var result = await _testController.Test();

            // ASSERT
            Assert.NotNull(result); // poleks null
            Assert.IsType<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.NotNull(viewResult); //viewmodel poleks null
            var vm = viewResult!.Model;
            Assert.IsType<TestViewModel>(vm);
            var testVm = vm as TestViewModel;
            Assert.NotNull(testVm!.Instructions);
            // for debugging
            Assert.Equal(0, testVm.Instructions.Count);
        }

        [Fact]
        public async Task Action_Test__Returns_ViewModel_WithData()
        {
            // ARRANGE
            await SeedData();

            // ACT
            var result = await _testController.Test();

            // ASSERT
            var testVm = (result as ViewResult)?.Model as TestViewModel;
            Assert.NotNull(testVm);
            // _testOutputHelper.WriteLine($"Count of elements: {testVm.ContactTypes.Count}");
            Assert.Equal(2, testVm!.Instructions.Count);
            Assert.Equal("Proov seelik 0", testVm.Instructions.First()!.Description);
        }

        [Fact]
        public async Task Action_Test__Returns_ViewModel_WithNoData__Fails_With_Exception()
        {

            // ACT
            var result = await _testController.Test();

            // ASSERT
            var testVm = (result as ViewResult)?.Model as TestViewModel;
            Assert.NotNull(testVm);
            // _testOutputHelper.WriteLine($"Count of elements: {testVm.ContactTypes.Count}");

            Assert.ThrowsAny<Exception>(() => testVm!.Instructions.First());
        }


        [Theory]
        //[InlineData(5)]
        [ClassData(typeof(CountGenerator))]
        public async Task Action_Test__Returns_ViewModel_WithData_Fluent(int count)
        {
            // ARRANGE
            await SeedData(count);

            // ACT
            var result = await _testController.Test();

            // ASSERT
            var testVm = (result as ViewResult)?.Model as TestViewModel;
            testVm.Should().NotBeNull();
            testVm!.Instructions
                .Should().NotBeNull()
                .And.HaveCount(count)
                .And.Contain(ct => ct.Description!.ToString() == "Proov seelik 0")
                .And.Contain(ct => ct.Description!.ToString() == $"Proov seelik {count - 1}");
        }

        [Fact]
        public async Task Action_Test__Returns_Model_WithData()
        {
            var _bll = GetBLL();
            // ARRANGE
            await SeedDataBLL(_bll);

            // ACT
            var result = await _bll.Instruction.GetAllAsync();

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal("Väike must kleit", result.Select(p => p.Description).First());
        }


        [Fact]
        public async Task Action_Test__Returns_Model_WithOneEntity()
        {
            var _bll = GetBLL();
            // ARRANGE
            await SeedDataBLL(_bll);
            // ACT

            var all = await _bll.Instruction.GetAllAsync();
            var instructions = all.ToList();
            var result = await _bll.Instruction.FirstOrDefaultDtoAsync(instructions[0].Id);


            Assert.NotNull(result);
            Assert.Equal("Väike must kleit", result!.Description);
        }



        [Fact]
        public async Task Action_Test__Returns_Model_WithEditedData()
        {
            var _bll = GetBLL();
            // ARRANGE
            await SeedDataBLL(_bll);
            // ACT

            var all = await _bll.Instruction.GetAllAsync();
            var instructions = all.ToList();
            var result = await _bll.Instruction.FirstOrDefaultAsync(instructions[0].Id);
            await EditData(result, _bll);

            Assert.NotNull(result);
            Assert.Equal("Väike must kleit", result!.Description);
        }

        private async Task EditData(BLL.App.DTO.Instruction instruction, IAppBLL _bll)
        {
            _bll = GetBLL();
            instruction.Description = "Väike must kleit";

            _bll.Instruction.Update(instruction);
            await _bll.SaveChangesAsync();
        }

        [Fact]
        public async Task Action_Test__RemovesEntity()
        {
            var _bll = GetBLL();
            // ARRANGE
            await SeedDataBLL(_bll);
            _bll = GetBLL();
            var all = await _bll.Instruction.GetAllAsync();
            var instructions = all.ToList();

            await _bll.Instruction.RemoveAsync(instructions[0].Id);

            await _bll.SaveChangesAsync();
            // ACT
            var result = await _bll.Instruction.GetAllAsync();

            // ASSERT
            Assert.Single(result);
        }

        [Fact]
        public async Task Action_Test__DeleteInstruction()
        {
            var _bll = GetBLL();
            // ARRANGE
            await SeedDataBLL(_bll);
            _bll = GetBLL();
            var all = await _bll.Instruction.GetAllAsync();
            var instructions = all.ToList();

            _bll.Instruction.RemoveAsync(instructions[0].Id);

            await _bll.SaveChangesAsync();
            // ACT
            var result = await _bll.Instruction.GetAllAsync();

            // ASSERT
            Assert.Single(result);
        }


        private async Task SeedDataBLL(IAppBLL tempbll)
        {

            await tempbll.SaveChangesAsync();

            tempbll.Category.Add(new BLL.App.DTO.Category()
            {
                Name = "Seelikud"
            });
            tempbll.Category.Add(new BLL.App.DTO.Category()
            {
                Name = "Kleidid"
            });

            tempbll.Unit.Add(new BLL.App.DTO.Unit()
            {
                ShortName =  "cm",
                Name = "Sentimeeter"
            });
            tempbll.Unit.Add(new BLL.App.DTO.Unit()
            {
                ShortName =  "dm",
                Name = "Detsimeeter"
            });
            tempbll.MeasurementType.Add(new BLL.App.DTO.MeasurementType()
            {
                Name = "Vööümbermõõt",
                DbName = "waistGirth"
            });
            tempbll.MeasurementType.Add(new BLL.App.DTO.MeasurementType()
            {
                Name = "Puusaümbermõõt",
                DbName = "hipGirth"
            });

            await tempbll.SaveChangesAsync();
            var _bll = GetBLL();


            var category = await _bll.Category.GetAllAsync();
            var categoryObject = category.ToList();

            var unit = await _bll.Unit.GetAllAsync();
            var unitObject = unit.ToList();

            var measurementType = await _bll.MeasurementType.GetAllAsync();
            var measurementTypeObject = measurementType.ToList();

            tempbll.Instruction.Add(new BLL.App.DTO.Instruction()
            {
                Description = "Väike must kleit",
                CategoryId = categoryObject[0].Id,
                DateAdded = DateTime.Now,
                TotalStep = 1,
                CircleSkirtType = "",


            });


            await tempbll.SaveChangesAsync();
        }


        private async Task SeedData(int count = 2)
        {
            for (int i = 0; i < count; i++)
            {
                _ctx.Instructions.Add(new Domain.App.Instruction()
                {
                    Description = $"Väike must kleit {i}",

                    Category = new Domain.App.Category
                    {
                        Name = "Seelikud"
                    },


                });
            }
            await _ctx.SaveChangesAsync();
        }
    }






    public class CountGenerator : IEnumerable<object[]>
    {
        private static List<object[]> _data
        {
            get
            {
                var res = new List<Object[]>();
                for (int i = 1; i <= 100; i++)
                {
                    res.Add(new object[]{i});
                }

                return res;
            }
        }

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
