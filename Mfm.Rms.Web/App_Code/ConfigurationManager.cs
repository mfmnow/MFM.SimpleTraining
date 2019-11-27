using Mfm.Rms.Data.Contracts;
using Mfm.Rms.Data.Services;
using Mfm.Rms.Domain.Contracts;
using Mfm.Rms.Domain.Models;
using Mfm.Rms.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Mfm.Rms.Web.App_Code
{
    public class ConfigurationManager
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            var _connectionString = configuration.GetConnectionString("DefaultConnection")
                .Replace("{AppDir}", Directory.GetCurrentDirectory());

            services.AddDbContext<RmsTrainingDbContext>(options =>
            options.UseSqlServer(_connectionString));

            ConfigureSettings(services, configuration);
            ConfigureDataServices(services);
            ConfigureDomainServices(services);
        }

        private static void ConfigureSettings(IServiceCollection services, IConfiguration configuration)
        {
            var config = new AppSettings();
            configuration.Bind("AppSettings", config);
            services.AddSingleton(config);
        }

        private static void ConfigureDataServices(IServiceCollection services)
        {
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<IRmsTrainingDbContext, RmsTrainingDbContext>();
            services.AddScoped<ITrainingDataAccess, TrainingDataAccessService>();
        }

        private static void ConfigureDomainServices(IServiceCollection services)
        {
            services.AddScoped<ITrainingDomain, TrainingDomainService>();
        }

    }
}
