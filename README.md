# powerplant-coding-challenge

## Prerequisites
- .net 6 SDK installed
- [optional] Docker (Desktop)
- [optional] a REST client: Postman, Curl, ...

## Build & run the application

#### A. dotnet commandline
dotnet run EnergyControllerApi

#### B. Docker (CLI)
- docker build . -f .\EnergyControllerApi\Dockerfile -t energycontroller:dandrianne
- docker run -it -p 8888:80 energycontroller:dandrianne

## Test the application
See swagger documentation at https://localhost:8888/swagger
