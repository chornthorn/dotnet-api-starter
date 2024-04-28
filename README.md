# DotNetApp

This is a .NET Core application that provides a robust starting point for your web application. It includes a set of middleware, core functionalities, and an authentication system.

## Getting Started

To get started with this project, clone the repository and open the solution file [`DotNetApp.sln`](command:_github.copilot.openRelativePath?%5B%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2FUsers%2Fthorn%2FRiderProjects%2FDotNetApp%2FDotNetApp.sln%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%5D "/Users/thorn/RiderProjects/DotNetApp/DotNetApp.sln") in Visual Studio.

## Building the Project

To build the project, use the build configurations provided in the [`DotNetApp.sln`](command:_github.copilot.openRelativePath?%5B%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2FUsers%2Fthorn%2FRiderProjects%2FDotNetApp%2FDotNetApp.sln%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%5D "/Users/thorn/RiderProjects/DotNetApp/DotNetApp.sln") file.

## Running the Project

The project can be run using the profiles defined in [`DotNetApp/Properties/launchSettings.json`](command:_github.copilot.openRelativePath?%5B%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2FUsers%2Fthorn%2FRiderProjects%2FDotNetApp%2FDotNetApp%2FProperties%2FlaunchSettings.json%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%5D "/Users/thorn/RiderProjects/DotNetApp/DotNetApp/Properties/launchSettings.json"). The application can be accessed at the URLs specified in the profiles.

## Core Features

- **Auto Dependency Injection**: This feature, implemented in [`AutoDependencyInjection.cs`](command:_github.copilot.openSymbolInFile?%5B%22DotNetApp%2FCore%2FAutoDependencyInjection.cs%22%2C%22AutoDependencyInjection.cs%22%5D "DotNetApp/Core/AutoDependencyInjection.cs"), automatically injects dependencies marked with the `InjectableAttribute`.

- **Middlewares**: The project includes a set of middleware for handling various aspects of HTTP requests and responses.

- **Authentication**: The project includes an authentication system implemented in the `Auth` directory.

## Documentation

The project includes a Swagger UI for API documentation, which can be accessed by navigating to the `/swagger` endpoint when the application is running.

## Contributing

Contributions are welcome. Please open an issue to discuss your proposed changes before making a pull request.

## License

This project is licensed under the MIT License.