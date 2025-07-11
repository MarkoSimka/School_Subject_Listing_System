namespace School_Subjects_Listing_System.Config
{
    static class DbConfigure
    {
        public class DbConfig
        {
            private static string Host => "localhost";
            private static string Port => "5000";
            private static string Username => "postgres";
            private static string Database => "school_subjects";
            private static string Password => "marko123";


            public string GetConnectionString()
            {
                return $"Host={Host};Port={Port};Username={Username};Password={Password};Database={Database};";
            }
        }

    }
}
