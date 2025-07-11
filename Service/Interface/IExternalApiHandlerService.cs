using School_Subjects_Listing_System.Domain;

namespace School_Subjects_Listing_System.Service.Interface
{
    public interface IExternalApiHandlerService
    {
        public Task<List<Subject>> FetchExternalSubjectsFromApi();
    }
}
