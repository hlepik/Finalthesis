using DAL.App.DTO.MappingProfiles;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options
        .UseNpgsql(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            o => { o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery); })
        .ConfigureWarnings(w =>
            w.Throw(RelationalEventId.MultipleCollectionIncludeWarning))
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging()
);


builder.Services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
builder.Services.AddScoped<IAppBLL, AppBLL>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.AddAuthentication().AddCookie(options => { options.SlidingExpiration = true; }
).AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Issuer"],

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ClockSkew = TimeSpan.Zero
        };
    }
);
builder.Services.AddSingleton<IConfigureOptions<MvcOptions>, ConfigureModelBindingLocalization>();

builder.Services.AddIdentity<AppUser, AppRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddDefaultUI()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new CustomFloatingPointBinderProvider());
});
builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsAllowAll", builder =>
        {
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            builder.AllowAnyOrigin();
        });
    }
);


builder.Services.AddAutoMapper(typeof(AutoMapperProfile),
    typeof(BLL.App.DTO.MappingProfiles.AutoMapperProfile));

// add support for api versioning
builder.Services.AddApiVersioning(options => { options.ReportApiVersions = true; });
// add support for m2m api documentation
builder.Services.AddVersionedApiExplorer(options => { options.GroupNameFormat = "'v'VVV"; });
// add support to generate human readable documentation from m2m docs
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen();


var app = builder.Build();

using var serviceScope =
    app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
using var ctx = serviceScope.ServiceProvider.GetService<AppDbContext>();

// in case of testing - dont do setup
if (ctx!.Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory")
    return;


using var userManager = serviceScope.ServiceProvider.GetService<UserManager<AppUser>>();
using var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<AppRole>>();
if (ctx != null)
{
    if (builder.Configuration.GetValue<bool>("AppData:DropDatabase"))
    {
        Console.Write("Drop database");
        DataInit.DropDatabase(ctx);
        Console.WriteLine(" - done");
    }

    if (builder.Configuration.GetValue<bool>("AppData:Migrate"))
    {
        Console.Write("Migrate database");
        DataInit.MigrateDatabase(ctx);
        Console.WriteLine(" - done");
    }

    if (builder.Configuration.GetValue<bool>("AppData:SeedIdentity"))
    {
        if (userManager != null && roleManager != null)
            DataInit.SeedIdentity(userManager, roleManager);
        else
            Console.Write(
                $"No user manager {(userManager == null ? "null" : "ok")} or role manager {(roleManager == null ? "null" : "ok")}!");
    }

    if (builder.Configuration.GetValue<bool>("AppData:SeedData"))
    {
        Console.Write("Seed database");
        Console.WriteLine(" - done");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    foreach (var apiVersionDescription in apiVersionDescriptionProvider.ApiVersionDescriptions)
        options.SwaggerEndpoint(
            $"/swagger/{apiVersionDescription.GroupName}/swagger.json",
            apiVersionDescription.GroupName.ToUpperInvariant()
        );
});
app.UseStaticFiles();

app.UseCors("CorsAllowAll");

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        "areas",
        "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        "default",
        "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});
app.MapControllers();
app.Run();