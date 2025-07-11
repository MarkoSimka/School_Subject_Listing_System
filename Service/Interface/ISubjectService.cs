using School_Subjects_Listing_System.Domain;

namespace School_Subjects_Listing_System.Service.Interface
{
    public interface ISubjectService
    {
        List<Subject> FetchAllSubjects();

        void ListSubjects(List<Subject> subjects);

        void ChooseSubject(List<Subject> subjects);

        void DisplayDetailsForSubject(Subject subject);
    }
}
