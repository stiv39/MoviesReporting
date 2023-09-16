FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Movies.Reporting.API/Movies.Reporting.API.csproj", "Movies.Reporting.API/"]
COPY ["Movies.Contracts/Movies.Contracts.csproj", "Movies.Contracts/"]
RUN dotnet restore "Movies.Reporting.API/Movies.Reporting.API.csproj"
COPY . .
WORKDIR "/src/Movies.Reporting.API"
RUN dotnet build "Movies.Reporting.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Movies.Reporting.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Movies.Reporting.API.dll"]