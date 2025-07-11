using Damilah_School_Subject_App.Domain;

namespace Damilah_School_Subject_App.Service.Interface
{
    public interface ISubjectService
    {
        List<Subject> FetchAllSubjects();

        void ListSubjects(List<Subject> subjects);

        void ChooseSubject(List<Subject> subjects);

        void DisplayDetailsForSubject(Subject subject);
    }
}
