using Damilah_School_Subject_App.Domain;
using Damilah_School_Subject_App.Repository.Interface;
using Damilah_School_Subject_App.Service.Interface;


namespace Damilah_School_Subject_App.Service.Implementation
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public List<Subject> FetchAllSubjects()
        {
            var subjects = new List<Subject>();

            var subjectsFromDb = _subjectRepository.FetchAllSubjects();
            var subjectsFromExternalApi = new ExternalApiHandlerService().FetchExternalSubjectsFromApi().Result;

            if (subjectsFromDb != null)
            {
                subjects.AddRange(subjectsFromDb);
            }

            if (subjectsFromExternalApi != null)
            {
                subjects.AddRange(subjectsFromExternalApi);
            }

            return subjects;
        }

        public void ListSubjects(List<Subject> subjects)
        {
            Console.WriteLine("\nSelect a subject to view details:");
            if (subjects?.Count > 0)
            {
                subjects
                    .Select((subject, index) => $"{index + 1}. {subject.Name}")
                    .ToList()
                    .ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("No subjects available.");
            }

        }

        public void ChooseSubject(List<Subject> subjects)
        {
            if (subjects == null || subjects.Count == 0)
            {
                Console.WriteLine("No subjects available to choose from.");

                return;
            }

            Console.WriteLine("Choose a subject: ");

            bool isInputNumeric = int.TryParse(Console.ReadLine(), out int choice);
            bool isInputValid = isInputNumeric && (choice > 0 && choice <= subjects.Count);

            if (!isInputValid)
            {
                Console.WriteLine("Invalid choice. Please select a number from the menu.");
                return;
            }

            Subject selectedSubject = subjects[choice - 1];

            DisplayDetailsForSubject(selectedSubject);

            var input = Console.ReadLine();
            isInputValid = input is "y" or "n";

            if (!isInputValid)
            {
                Console.WriteLine("Invalid input");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void DisplayDetailsForSubject(Subject subject)
        {
            if (subject == null)
            {
                Console.WriteLine("No subject selected.");
                return;
            }

            Console.WriteLine("\nSubject Details:");
            Console.WriteLine($"  Name:                    {subject.Name}");
            Console.WriteLine($"  Description:             {subject.Description}");
            Console.WriteLine($"  Number of Weekly Classes:{subject.NumberOfWeeklyClasses}");

            var isThereLiteratureInfo = subject.LiteratureUsed != null && subject.LiteratureUsed.Count > 0;

            if (!isThereLiteratureInfo)
            {
                Console.WriteLine("No information about the used literature.");
                return;
            }

            Console.WriteLine("Literature used: ");

            subject.LiteratureUsed
                .Select((lit, index) => $"{index + 1} - {lit.Title}, {lit.Year}, {lit.Author}")
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
