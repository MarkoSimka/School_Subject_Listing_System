using Damilah_School_Subject_App.Config;
using Damilah_School_Subject_App.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Damilah_School_Subject_App
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
