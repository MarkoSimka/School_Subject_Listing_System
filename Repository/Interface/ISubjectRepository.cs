using School_Subjects_Listing_System.Domain;

namespace School_Subjects_Listing_System.Repository.Interface
{
    public interface ISubjectRepository
    {
        public List<Subject> FetchAllSubjects();
    }
}
