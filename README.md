# backend-coding-challenge

This is a .NET 5 Rest microservice for Gemography [backend coding challenge](https://github.com/gemography/backend-coding-challenge)

## Functional specs from original challenge requirements

- Develop a REST microservice that list the languages used by the 100 trending public repos on GitHub.
- For every language, you need to calculate the attributes below 👇:
  - Number of repos using this language
  - The list of repos using the language

## Requirements to run the application

In order to run the application you’ll need:

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [VS Code](https://code.visualstudio.com/download) text editor, or another dotnet IDE (Visual studio, Rider)
- Docker
  - [Docker Desktop for Mac & Windows](https://www.docker.com/products/docker-desktop)
  - [Docker Community Edition for Linux](https://docs.docker.com/get-docker)

To run the application you can use the dotnet command:

```
dotnet run
```

And head to `http://localhost:5000/LanguagesInTrendingRepositories`

To run using docker, you can use the following commands:

```
docker run -p 8080:80 binarythistle/simpleapi
docker run -p 80 backend-coding-challenge
```

Then head to and head to `http://localhost:8080/LanguagesInTrendingRepositories`
