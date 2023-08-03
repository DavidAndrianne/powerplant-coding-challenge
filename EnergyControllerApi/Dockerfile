FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EnergyControllerApi/EnergyControllerApi.csproj", "EnergyControllerApi/"]
RUN dotnet restore "EnergyControllerApi/EnergyControllerApi.csproj"
COPY . .
WORKDIR "/src/EnergyControllerApi"
RUN dotnet build "EnergyControllerApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EnergyControllerApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EnergyControllerApi.dll"]