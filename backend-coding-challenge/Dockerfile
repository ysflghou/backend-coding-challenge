#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["backend-coding-challenge/backend-coding-challenge.csproj", "backend-coding-challenge/"]
RUN dotnet restore "backend-coding-challenge/backend-coding-challenge.csproj"
COPY . .
WORKDIR "/src/backend-coding-challenge"
RUN dotnet build "backend-coding-challenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "backend-coding-challenge.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "backend-coding-challenge.dll"]