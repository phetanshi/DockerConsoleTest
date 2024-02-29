using DockerConsoleTest.Database;
using DockerConsoleTest.Database.Models;
using Microsoft.Extensions.Logging;

namespace DockerConsoleTest;

public class App(AppDbContext database)
{
    public async Task Run()
    {
        await SaveResponseToDatabase();
    }

    private async Task SaveResponseToDatabase()
    {
        try
        {
            Console.WriteLine($"Entered into SaveResponseToDatabase.");
            var machineName = System.Environment.MachineName;
            var currentDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            var infoString = $"Pod information podName : machineName : {machineName ?? "It is null"} ; currentDateTime : {currentDateTime}";

            AppLog applog = new AppLog();
            applog.InfoString = infoString;
            applog.MachineName = machineName;
            applog.CreatedDate = DateTime.Now;

            database.AppLogs.Add(applog);
            await database.SaveChangesAsync();
            Console.WriteLine($"Returning from SaveResponseToDatabase.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Occured....");
            Console.WriteLine(ex.ToString());
            throw;
        }
    }
}
