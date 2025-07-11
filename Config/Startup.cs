using Damilah_School_Subject_App.Repository.Implementation;
using Damilah_School_Subject_App.Repository.Interface;
using Damilah_School_Subject_App.Service.Implementation;
using Damilah_School_Subject_App.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using static Damilah_School_Subject_App.Config.DbConfigure;

namespace Damilah_School_Subject_App.Config
{
    public class StartupServiceProvider
    {
        private DbConfig DbConfig { get; set; }

        public SubjectRepository SetupSubjectRepository(IServiceProvider serviceProvider)
        {
            try
            {
                DbConfig = serviceProvider.GetRequiredService<DbConfig>();
                return new SubjectRepository(DbConfig.GetConnectionString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }

        public ServiceProvider GetServices()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton(new DbConfig())
                .AddSingleton<ISubjectRepository>(provider => SetupSubjectRepository(provider))
                .AddSingleton<ISubjectService, SubjectService>()
                .AddSingleton<IExternalApiHandlerService, ExternalApiHandlerService>()
                .BuildServiceProvider();


            return serviceProvider;
        }

    }
}
