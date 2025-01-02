BookLibraryAPI
A WebAPI for managing books and authors
using CQRS , MediatR , Entity Framework , SQL server

Features:
- add , update books
- add , update authors

How to run:
1. Clone repository:
```bash
git clone https://github.com/ehsanniro/BookLibraryApi.git
```
3. restore packages
```bash
dotnet restore
```

4. Set up the database:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
