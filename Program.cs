using School_Subjects_Listing_System.Config;
using School_Subjects_Listing_System.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace School_Subjects_Listing_System
{
    internal class Program(ISubjectService subjectService)
    {
        private readonly ISubjectService _subjectService = subjectService;

        public Task Run()
        {
            while (true)
            {
                var subjects = _subjectService.FetchAllSubjects();
                _subjectService.ListSubjects(subjects);
                _subjectService.ChooseSubject(subjects);
            }
        }

        static async Task Main(string[] args)
        {
            var startupServiceProvider = new StartupServiceProvider();
            var serviceProvider = startupServiceProvider.GetServices();
            var subjectService = serviceProvider.GetRequiredService<ISubjectService>();
            var app = new Program(subjectService);

            await app.Run();
        }
    }
}
