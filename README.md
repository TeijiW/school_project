# School Backend Project

The backend of a school classes manager, made with .NET Core and EF Core

**Warning:** Work in progress

## Steps to run

-   `git clone https://github.com/TeijiW/school_project`
-   `cd ./school_project`
-   `dotnet-ef database update`
-   `dotnet watch run`

## Routes

### Resources

-   student
-   teacher
-   school-class

### Routes

-   `/api/resource`
    -   GET - Get a resource collection
    -   POST - Create resource
-   `/api/resource/{id}`
    -   GET - Get resource by ID
    -   PUT - Update resource
    -   DELETE - Remove resource

### Unique Routes

- `/api/school-class/students`
    -   GET - Return the classes with the students

- `/api/school-class/{classId}/teachers`
  - GET - Return all teachers associated with the class

- `/api/school-class/{classId}/teachers/{teacherId}`
  - POST - Add the associated teacher to the class (Don't need body)

## Default JSON model

### Student

```JSON
{
"name": "John Doe",
"birthday": "1970-01-01",
"schoolClassId": "<classID>"
}
```

### Teacher

```JSON
{
	"name": "John Doe",
	"subject": "Programming",
	"birthday": "1970-01-01",
}
```

### SchoolClass (or Class)

```JSON
{
	"name": "Programming Class",
	"year": 2020,
}
```

Made with :heart: by Teiji
