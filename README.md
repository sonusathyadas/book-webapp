# Book Manager

## Overview
Book Manager is a .NET 10 MVC application designed to manage book-related operations. It allows users to perform CRUD (Create, Read, Update, Delete) operations on books, providing a user-friendly interface for managing a collection of books.

## Features
- **Add Books**: Users can add new books to the collection.
- **Update Books**: Users can edit the details of existing books.
- **Delete Books**: Users can remove books from the collection.
- **List Books**: Users can view a list of all books in the collection.
- **Retrieve Book Details**: Users can view detailed information about a specific book.

## Technology Stack
- **Framework**: .NET 10
- **Architecture**: MVC (Model-View-Controller)
- **Database**: SQLite
- **ORM**: Entity Framework
- **Design Pattern**: Repository Pattern

## Project Structure
```
BookManager
├── Controllers
│   ├── BooksController.cs
│   └── HomeController.cs
├── Data
│   └── AppDbContext.cs
├── Models
│   ├── Book.cs
│   └── ErrorViewModel.cs
├── Repositories
│   ├── IBookRepository.cs
│   └── BookRepository.cs
├── Migrations
│   ├── InitialCreate.cs
│   └── AppDbContextModelSnapshot.cs
├── Properties
│   └── launchSettings.json
├── Views
│   ├── Books
│   │   ├── Index.cshtml
│   │   ├── Details.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   └── Delete.cshtml
│   ├── Home
│   │   └── Index.cshtml
│   ├── Shared
│   │   ├── _Layout.cshtml
│   │   ├── _ValidationScriptsPartial.cshtml
│   │   └── Error.cshtml
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
├── wwwroot
│   ├── css
│   │   └── site.css
│   └── js
│       └── site.js
├── appsettings.json
├── appsettings.Development.json
├── BookManager.csproj
├── Program.cs
└── README.md
```

## Getting Started
1. Clone the repository.
2. Navigate to the project directory.
3. Run the application using the command: `dotnet run`.
4. Access the application in your web browser at `http://localhost:5000`.

## Contributing
Contributions are welcome! Please feel free to submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for details.