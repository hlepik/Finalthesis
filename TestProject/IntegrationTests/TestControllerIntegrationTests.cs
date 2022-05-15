using Microsoft.VisualStudio.TestPlatform.TestHost;
using Instruction = PublicApi.DTO.v1.Instruction;

namespace TestProject.IntegrationTests
{
    public class TestControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _testOutputHelper;
        private static JwtResponse? _jwt;
        private JwtResponse? _register;
        private DbContextOptionsBuilder<AppDbContext> optionBuilder;


        public TestControllerIntegrationTests(CustomWebApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper)
        {
            optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            // provide new random database name here
            // or parallel test methods will conflict each other
            optionBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
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
        public async Task TestAction_HasSuccessStatusCode()
        {
            // ARRANGE
            var uri = "/test/test";

            // ACT
            var getTestResponse = await _client.GetAsync(uri);

            // ASSERT
            getTestResponse.EnsureSuccessStatusCode();
            Assert.InRange((int)getTestResponse.StatusCode, 200, 299);
        }

        [Fact]
        public async Task TestAuthAction_AuthRedirect()
        {
            // ARRANGE
            var uri = "/test/TestAuth";

            // ACT
            var getTestResponse = await _client.GetAsync(uri);

            // ASSERT
            Assert.Equal(302, (int) getTestResponse.StatusCode);
        }

        [Fact]
        public async Task Get_Register()
        {

            var uri = "/api/v1/Account/Register";

            var register = new Register
            {
                Email = "test@user.ee",
                Password = "Foo.bar1",
                Firstname = "Test",
                Lastname = "user"
            };

            string stringData = JsonConvert.SerializeObject(register);
            stringData.Should().NotBeNullOrEmpty();
            var contentData = new StringContent(stringData,
                System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PostAsync
                (uri, contentData);


            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var data = JsonHelper.DeserializeWithWebDefaults<JwtResponse>(body);

            Assert.Equal("Test", data!.Firstname);
            Assert.Equal("user", data.Lastname);

            _register = data;
            await TestLogin();


        }

        private async Task TestLogin()
        {
            var uri = "/api/v1/Account/Login";
            var jwt = "";

            var contentType = new MediaTypeWithQualityHeaderValue
                ("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);


            var login = new Login
            {
                Email = "test@user.ee",
                Password = "Foo.bar1",

            };
            string stringData = JsonConvert.SerializeObject(login);
            var contentData = new StringContent(stringData,
                System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = _client.PostAsync
                (uri,contentData).Result;

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var resp = JsonConvert.DeserializeObject<JwtResponse>(content);
                jwt = resp!.Token;

            }
            Assert.NotEmpty(jwt);


            //Add product
            uri = "/api/v1/Instructions";
            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer",
                    jwt);

            await PostExtra();
            await PostCategory();
            await PostInstruction();


            var getResponse = await _client.GetAsync(uri);
            getResponse.EnsureSuccessStatusCode();
            var getContent = await getResponse.Content.ReadAsStringAsync();
            var getRes = JsonConvert.DeserializeObject<Instruction[]>(getContent);

            var instruction = getRes![0];
            var instructionId = instruction.Id;

            Assert.True("Test lõige" == instruction.Description);

            uri = "/api/v1/Instructions/" + instructionId;

            await EditProduct(uri);
            await DeleteProduct(uri);
        }

        private async Task DeleteProduct(string uri)
        {
            var getProduct = await _client.GetAsync(uri);
            getProduct.EnsureSuccessStatusCode();
            var productBody = await getProduct.Content.ReadAsStringAsync();
            var productData = JsonHelper.DeserializeWithWebDefaults<Instruction>(productBody);

            var serializedBody = JsonConvert.SerializeObject(productData);
            serializedBody.Should().NotBeNullOrEmpty();

            var response = await _client.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();

            uri = "/api/v1/Instructions";
            var getAllResponse = await _client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var getAllContent = await getAllResponse.Content.ReadAsStringAsync();
            var getAllResp = JsonConvert.DeserializeObject<List<Instruction>>(getAllContent)!;

            Assert.True(0 == getAllResp.Count);

        }

        private async Task EditProduct(string uri)
        {
            var getInstruction = await _client.GetAsync(uri);
            getInstruction.EnsureSuccessStatusCode();
            var instructionBody = await getInstruction.Content.ReadAsStringAsync();
            var instructionData = JsonHelper.DeserializeWithWebDefaults<Instruction>(instructionBody);

            instructionData!.Description = "Test lõige";
            var serializedBody = JsonConvert.SerializeObject(instructionData);
            serializedBody.Should().NotBeNullOrEmpty();
            var httpContent = new StringContent(serializedBody!, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(uri, httpContent);
            response.EnsureSuccessStatusCode();

            getInstruction = await _client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var body = await getInstruction.Content.ReadAsStringAsync();
            var data = JsonHelper.DeserializeWithWebDefaults<PublicApi.DTO.v1.Instruction>(body);
            Assert.Equal("Test lõige", data!.Description);
        }

        private async Task PostInstruction()
        {

            var uri = "/api/v1/Instructions";

            var getUser = await _client.GetAsync("/api/v1/AppUser");
            getUser.EnsureSuccessStatusCode();
            var userBody = await getUser.Content.ReadAsStringAsync();
            var userData = JsonHelper.DeserializeWithWebDefaults<List<PublicApi.DTO.v1.Identity.AppUser>>(userBody);

            var getExtra = await _client.GetAsync("/api/v1/ExtraSizes");
            getExtra.EnsureSuccessStatusCode();
            var extraBody = await getExtra.Content.ReadAsStringAsync();
            var extraData = JsonHelper.DeserializeWithWebDefaults<List<PublicApi.DTO.v1.ExtraSize>>(extraBody);

            var getCategories = await _client.GetAsync("/api/v1/Categories");
            getCategories.EnsureSuccessStatusCode();
            var categoryBody = await getCategories.Content.ReadAsStringAsync();
            var categoryData = JsonHelper.DeserializeWithWebDefaults<List<PublicApi.DTO.v1.Category>>(categoryBody);

            var instruction =  new Instruction()
            {
                Description = "Test lõige 1",
                DateAdded = DateTime.Now,
                CategoryId = categoryData![0].Id,


            };
            var serializedBody = JsonConvert.SerializeObject(instruction);
            serializedBody.Should().NotBeNullOrEmpty();
            var httpContent = new StringContent(serializedBody!, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(uri, httpContent);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            var data = JsonHelper.DeserializeWithWebDefaults<PublicApi.DTO.v1.Instruction>(body);
            Assert.Equal("Test lõige 1", data!.Description);

        }



        private async Task PostExtra()
        {
            var uri = "/api/v1/ExtraSizes";

             var city =  new PublicApi.DTO.v1.ExtraSize()
            {
                Name = "Vööümbermõõt",
                Extra = 3

            };
             var serializedBody = JsonConvert.SerializeObject(city);
             serializedBody.Should().NotBeNullOrEmpty();
             var httpContent = new StringContent(serializedBody!, Encoding.UTF8, "application/json");
             var response = await _client.PostAsync(uri, httpContent);
             response.EnsureSuccessStatusCode();

             var body = await response.Content.ReadAsStringAsync();
             var data = JsonHelper.DeserializeWithWebDefaults<PublicApi.DTO.v1.ExtraSize>(body);
             Assert.Equal("Vööümbermõõt", data!.Name);
        }

        private async Task PostCategory()
        {
            var uri = "/api/v1/Categories";

            var category =  new PublicApi.DTO.v1.Category
            {
                Name = "Seelikud",

            };
            var serializedBody = JsonConvert.SerializeObject(category);
            serializedBody.Should().NotBeNullOrEmpty();
            var httpContent = new StringContent(serializedBody!, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(uri, httpContent);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            var data = JsonHelper.DeserializeWithWebDefaults<PublicApi.DTO.v1.Category>(body);
            Assert.Equal("Seelikud", data!.Name);
        }

    }

}
