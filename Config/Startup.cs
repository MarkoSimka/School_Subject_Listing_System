using School_Subjects_Listing_System.Repository.Implementation;
using School_Subjects_Listing_System.Repository.Interface;
using School_Subjects_Listing_System.Service.Implementation;
using School_Subjects_Listing_System.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using static School_Subjects_Listing_System.Config.DbConfigure;

namespace School_Subjects_Listing_System.Config
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
