using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;


namespace BookManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Start logging before application host build
            ConfigureLogger();
            Log.Information("Application Started!!!");

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseSerilog();
                });

        /// <summary>
        /// Overide the built in logger with serilog.
        /// </summary>
        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(@"log.txt")
                .CreateLogger();
        }
    }
}
