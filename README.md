# coure-web-api-solution

## Project Structure

    .
    ├── src                                     # Application Source Files.
            ├──app
                    ├── api
    |                   └── CoureWebAPI       # CoureWebAPI Web API
                        └── CoureWebAPI.Core  # Core Logic
                        └── CoureWebAPI.Test  # Tests
    ├── README.md                             # This file.
    

#### API Documentation
API documentation is [here](https://{deployedLocation}/swagger) after running the application on visual studio 2022

#### Technologies Used
- dotnet 6
- xUnit 
- Moq
- In-Memory

#### Getting Started

##### Prerequisites
- dotnet 6 SDK needs to be installed on your machine. See [dotnet 6 Docs](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Visual studio 2022 needs to be installed

##### Setting up locally
- Clone with SSH => `git@github.com:chiomajoshua/coure-web-api-solution.git`
- Clone with HTTPS => `https://github.com/chiomajoshua/coure-web-api-solution.git`


##### Running the app on an attached device
- Open project with visual studio
- If Nugets do not restore automatically, right-click on the solution folder and select Restore Nuget Packages
- Build and Run the project.