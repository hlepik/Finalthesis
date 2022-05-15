using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace TestProject.IntegrationTestApi
{
    public class ContactTypesApiControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _testOutputHelper;


        public ContactTypesApiControllerIntegrationTests(CustomWebApplicationFactory<Program> factory,
            ITestOutputHelper testOutputHelper)
        {
            _factory = factory;
            _testOutputHelper = testOutputHelper;
            _client = factory
                .WithWebHostBuilder(builder =>
                {
                    builder.UseSetting("test_database_name", Guid.NewGuid().ToString());
                })
                .CreateClient(new WebApplicationFactoryClientOptions()
                    {
                        // dont follow redirects
                        AllowAutoRedirect = false
                    }
                );
        }

        [Fact]
        public async Task Api_Get_Instructions()
        {
            // ARRANGE
            var uri = "/api/v1/Instructions";

            // ACT
            var getTestResponse = await _client.GetAsync(uri);

            // ASSERT
            getTestResponse.EnsureSuccessStatusCode();

            var body = await getTestResponse.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine(body);

            var data = JsonHelper.DeserializeWithWebDefaults<List<DAL.App.DTO.Instruction>>(body);

            Assert.NotNull(data);
            Assert.NotEmpty(data);
            Assert.Single(data);
            Assert.Equal("Type 0", data![0].Description);
        }
    }
}
