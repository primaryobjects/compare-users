# CompareUsers

## Overview
The **CompareUsers** project is a web application built using ASP.NET Core Razor Pages. It allows users to compare two sets of JSON data representing user information. The application identifies and displays newly inserted users and updated users based on the comparison.

## Features
- Upload or paste JSON data for existing users and updated/inserted users.
- Compare the two datasets to identify:
  - **New Users**: Users that are present in the updated dataset but not in the existing dataset.
  - **Updated Users**: Users whose details have changed in the updated dataset compared to the existing dataset.
- Display results dynamically on the page.
- Prettify and format JSON input for better readability.

## Technologies Used
- **ASP.NET Core Razor Pages**: For building the web application.
- **Materialize CSS**: For responsive and modern UI design.
- **System.Text.Json**: For JSON parsing and serialization.
- **C# Reflection**: For dynamic property comparison of user objects.

## Getting Started

### Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation
1. Clone the repository.
2. In VS Code, run the **Run server** or **Docker build and run** launch task.
3. Open your browser and navigate to the url on localhost.

## Usage
1. Enter JSON data for Existing Users and Updated/Inserted Users in the provided text areas.
2. Click the Submit button to compare the datasets.
3. View the results:
    - Inserted Users: Displayed in the "Inserted Users" section.
    - Updated Users: Displayed in the "Updated Users" section.
4. If there are errors in the JSON format, they will be displayed at the bottom of the page.

## Project Structure
- **Pages**: Contains Razor Pages (Index.cshtml and Index.cshtml.cs) for the UI and backend logic.
- **Managers**: Contains the UserManager class for handling user comparison logic.
- **Types**: Contains the User class and related models.

## Key Classes
- **User**:
    - Represents a user object with properties like Id, Name, Email, etc.
    - Includes methods for comparing user objects.
- **UserManager**:
    - Provides methods for parsing JSON data and comparing user datasets.
    - Key methods:
        - GetUsers(string json): Parses JSON into a list of User objects.
        - GetInsertedUpdatedUsers(IEnumerable<User> existingUsers, IEnumerable<User> modifiedUsers): Compares two datasets and returns new and updated users.

## JSON Input Format
The JSON input should be an array of user objects with the following structure:

```json
[
  {
    "_id": "12345",
    "name": "John Doe",
    "email": "john.doe@example.com",
    "company": "ExampleCorp",
    "isActive": true,
    "age": 30,
    "balance": "$1,234.56",
    "gender": "male",
    "phone": "123-456-7890",
    "address": "123 Main St"
  }
]
```

## License

MIT

## Author

Kory Becker
https://primaryobjects.com