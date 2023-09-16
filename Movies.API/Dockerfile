FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Movies.API/Movies.API.csproj", "Movies.API/"]
COPY ["Movies.Contracts/Movies.Contracts.csproj", "Movies.Contracts/"]
RUN dotnet restore "Movies.API/Movies.API.csproj"
COPY . .
WORKDIR "/src/Movies.API"
RUN dotnet build "Movies.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Movies.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Movies.API.dll"]