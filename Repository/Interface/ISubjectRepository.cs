using Damilah_School_Subject_App.Domain;

namespace Damilah_School_Subject_App.Repository.Interface
{
    public interface ISubjectRepository
    {
        public List<Subject> FetchAllSubjects();
    }
}
