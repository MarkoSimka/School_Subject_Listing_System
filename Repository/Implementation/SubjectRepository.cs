using School_Subjects_Listing_System.Domain;
using School_Subjects_Listing_System.Repository.Interface;
using Dapper;
using Npgsql;
namespace School_Subjects_Listing_System.Repository.Implementation
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly string _connectionString;

        public SubjectRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Subject> FetchAllSubjects()
        {
            using var dbConnection = new NpgsqlConnection(_connectionString);

            var sql = @"SELECT
                            s.""Id"",
                            s.""Name"",
                            s.""Description"",
                            s.""NumberOfWeeklyClasses"",
                            l.*
                        FROM
                            ""Subject"" s
                        LEFT JOIN
                            ""LiteratureUsed"" l ON s.""Id"" = l.""SubjectId"";";

            var subjectDict = new Dictionary<Guid, Subject>();

            var _ = dbConnection.Query<Subject, LiteratureUsed, Subject>(sql,
                (subject, literature) =>
                {
                    if (!subjectDict.ContainsKey(subject.Id))
                    {
                        subjectDict.Add(subject.Id, subject);
                    }

                    subjectDict[subject.Id].LiteratureUsed.Add(literature);

                    return subject;
                },
                splitOn: "Id")
                .ToList();

            return subjectDict.Select(x => x.Value).ToList();
        }
    }
}
