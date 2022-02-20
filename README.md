# Final Thesis Project

~~~sh
dotnet ef migrations add --project DAL.App.EF --startup-project WebApp --context AppDbContext Initial
dotnet ef migrations remove --project DAL.App.EF --startup-project WebApp --context AppDbContext 
~~~

Scaffold controller

~~~sh
cd WebApp
dotnet aspnet-codegenerator controller -name UnitsController       -actions -m  Domain.App.Unit    -dc AppDbContext -outDir Areas/Admin/Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
~~~

Scaffold API controller

~~~sh
dotnet aspnet-codegenerator controller -name UnitsController -actions -m Domain.App.Unit -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
~~~

