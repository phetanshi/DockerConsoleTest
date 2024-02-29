using DockerConsoleTest;
using DockerConsoleTest.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

//1. Create Service Collection for DI
var services = new ServiceCollection();

//2. Build a Configuration 
var baseDir = Path.Combine(AppContext.BaseDirectory);

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(baseDir)
    .AddJsonFile("appsettings.json", optional: true)
    .Build();

//3. Add configuration to the service collection
services.AddSingleton<IConfiguration>(configuration);

string connStr = configuration.GetConnectionString("AppDbConnection");
Console.WriteLine($"Db connection string : {connStr}");

services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(connStr));

services.AddSingleton<App>();
//4. Run application
var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<App>();
if (app != null)
    await app.Run();


#if DEBUG
Console.ReadKey();
#endif
