namespace School_Subjects_Listing_System.Domain
{
    public class Subject : BaseEntity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? NumberOfWeeklyClasses { get; set; }

        public List<LiteratureUsed> LiteratureUsed { get; set; } = new();
    }
}
