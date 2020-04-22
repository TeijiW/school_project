# School Backend Project

## The backend of a school classes manager, made with .NET

### **WARNING** I'm still working on this project, so it's still in progress

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

### Generic Routes

-   `/api/resource`
    -   GET - Get a resource collection
    -   POST - Create resource
-   `/api/resource/{id}`
    -   GET - Get resource by ID
    -   PUT - Update resource
    -   DELETE - Remove resource

### Unique Routes

-   `/api/school-class/students`
    -   GET - Return the classes with the students

## Default JSON model to requests

### **WARNING** I'm working at "Teacher" and "SchoolClass" relationship, so the model will probably change soon

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
