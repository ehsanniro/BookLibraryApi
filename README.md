BookLibraryAPI
A WebAPI for managing books and authors
using CQRS , MediatR , Entity Framework , SQL server

Features:
- add , update books
- add , update authors

How to run:
1. Clone repository: 
git clone https://github.com/ehsanniro/BookLibraryApi.git
2. Make sure you have this packages
MediatR
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Design
3. Create database
dotnet ef migrations add InitialCreate
dotnet ef database update