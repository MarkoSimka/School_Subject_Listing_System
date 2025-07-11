namespace Damilah_School_Subject_App.Domain
{
    public class LiteratureUsed : BaseEntity
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public Guid SubjectId { get; set; }
    }
}
