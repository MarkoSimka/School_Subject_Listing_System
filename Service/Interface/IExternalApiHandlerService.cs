using Damilah_School_Subject_App.Domain;

namespace Damilah_School_Subject_App.Service.Interface
{
    public interface IExternalApiHandlerService
    {
        public Task<List<Subject>> FetchExternalSubjectsFromApi();
    }
}
