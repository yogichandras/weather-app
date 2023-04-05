
# WEATHER APP

WEATHER APP Created with .NET CORE 3.1 for API & REACT JS for UI.

## API
API Tech Stack :
- .NET CORE 3.1
- SWAGGER UI
- Moq
- AutoFixture
- NUNIT
- Serilog

API Project Stucture :

    ├── Data  # Data Layer
    │   ├── GlobalData   # Global Model or DTO Classes
    ├── Services    # Business Layer
    │   ├── GeneralService  # General Module (References, Configurations etc)
    │   ├── WeatherService  # Weather Module
    ├── Utils    # Utilities Layer
    │   ├── GlobalUtil  # Utilities (Helper, Extensions, Consts)
    ├── WeatherAPI  # Startup Project for Web API
    ├── WeatherUnitTest  # UNIT TESTS


Setup & Installation :

- Install .NET CORE 3.1 SDK

```bash
  https://dotnet.microsoft.com/en-us/download/dotnet/3.1
```
- Clone This Repository
```bash
  git clone https://dotnet.microsoft.com/en-us/download/dotnet/3.1
```
Run API With VS 2019+
- Open WeatherAPI.sln (VS 2019+)
- Restore All Project (Nuget Package)
- Rebuild Solution
- Setup Proper Configuration on appsettings.json & appsettings.development.json
- Set WeatherAPI as Startup Project
- Run With or Without Debugging

Run API Without VS
- Open Terminal/Command Prompt
- cd weather-api
- dotnet restore
- cd WeatherAPI
- dotnet run

Run Unit Test API With VS 2019+
- Open WeatherAPI.sln (VS 2019+)
- Restore All Project (Nuget Package)
- Rebuild Solution
- Setup Proper Configuration on appsettings.json & appsettings.development.json
- Set WeatherUnitTest as Startup Project
- Run Test

Run Unit Test API Without VS
- Open Terminal/Command Prompt
- cd weather-api
- dotnet restore
- cd WeatherAPI
- dotnet test
## UI
UI Tech Stack :
- React JS
- Axios

UI Project Stucture :

    ├── Public    # Static File
    ├── src   
        ├── consts  # Consts Value
        ├── pages  # components, styling & ui page

Setup & Installation :

- Install Node & NPM

```bash
  https://nodejs.org/en/download
```
- Clone This Repository
```bash
  git clone https://dotnet.microsoft.com/en-us/download/dotnet/3.1
```
Run
- Open Terminal/Command Prompt
- cd weather-ui
- npm install
- Setup Proper API Base URL on src/consts/WeatherConst.js
- npm run start
## FAQ

#### Is Weather API generate a real weather?

No, All Value set by Mock & Auto Fixture

## Authors

- [@yogichandras](https://github.com/yogichandras/)
- [@papicoding on Youtube](https://www.youtube.com/channel/UCVxy3e7hZ4QAIRIABVX4Aog)

