# School Subjects Information System

A modern .NET 8 console application for managing and viewing school subjects, combining local database storage and dynamic external API integration.

## Features

- **Comprehensive Subject Listing:** Displays all subjects from both a PostgreSQL database and an external API.
- **Detailed Subject View:** Select any subject to view its description, weekly class count, and literature used.
- **Dynamic Data Expansion:** Fetches additional subjects from a remote JSON API, seamlessly merging with local data.
- **Literature Tracking:** Shows all literature materials associated with each subject.
- **Robust Architecture:** Utilizes dependency injection, repository/service patterns, and asynchronous API calls for scalability and maintainability.

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/) database (connection string configured in `DbConfig`)
- Internet access for external API data

## Subject Model

Each subject includes:
- **Name:** Subject title
- **Description:** Brief overview
- **Number of Weekly Classes:** Integer value
- **Literature Used:** List of literature entries (title, author, year)
- **Additional Properties:** Extendable for future enhancements

## Functionality

- **List Subjects:** Aggregates and displays subjects from both local DB and external API.
- **Select & View Details:** Choose a subject to see all its properties and literature.
- **Database Integration:** Loads initial data from PostgreSQL using Dapper.
- **External API Integration:** Fetches and merges subjects from a remote JSON endpoint.
- **Dependency Injection:** Managed via `Microsoft.Extensions.DependencyInjection` for testability and flexibility.

## Use Cases

- Load subjects from the database
- Fetch and merge subjects from an external API
- Display all subjects in a user-friendly list
- Select a subject to view full details
- Show literature and additional info for each subject

## Architecture Diagrams

### Use Case Diagram


### Class Diagram


## Getting Started

1. **Clone the repository:**
    ```
    git clone https://github.com/MarkoSimka/SchoolSubjectApp.git
    ```
2. **Configure the database:**
    - Set up PostgreSQL and update connection details in `DbConfig`.
    - Ensure tables for `Subject` and `LiteratureUsed` exist.

3. **Run the application:**
    ```
    dotnet run
    ```

4. **Interact:**
    - View the list of subjects.
    - Select a subject to see details and literature.

## External Data Source

This project integrates with a custom GitHub Pages site that I created and maintain:

- **GitHub Pages:** [https://markosimka.github.io/](https://markosimka.github.io/)

The site hosts a JSON file containing additional subject data, which the application fetches dynamically:

- **Subjects JSON:** [https://markosimka.github.io/subjects.json](https://markosimka.github.io/subjects.json)

**Example JSON Structure:**

```
[
  {
    "Id": "{subject_id}",
    "Name": "{subject_name}",
    "Description": "{subject_description}",
    "NumberOfWeeklyClasses": {weekly_class_count},
    "LiteratureUsed": [
      {
        "Id": "{literature_id_1}",
        "Title": "{literature_title_1}",
        "Author": "{author_name_1}",
        "Year": {year_1},
        "SubjectId": "{subject_id}"
      },
      {
        "Id": "{literature_id_2}",
        "Title": "{literature_title_2}",
        "Author": "{author_name_2}",
        "Year": {year_2},
        "SubjectId": "{subject_id}"
      }
    ]
  }
...
]
```

## Contributing

Contributions are welcome! Please open issues or submit pull requests for improvements or bug fixes.

---

Happy coding!
