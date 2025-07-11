namespace School_Subjects_Listing_System.Domain
{
    public class LiteratureUsed : BaseEntity
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public Guid SubjectId { get; set; }
    }
}
