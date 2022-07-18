#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./API/netcore-docker-heroku.API.csproj", "."]
RUN dotnet restore "./netcore-docker-heroku.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./API/netcore-docker-heroku.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./API/netcore-docker-heroku.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Run the app.  CMD is required to run on Heroku
# $PORT is set by Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet netcore-docker-heroku.API.dll