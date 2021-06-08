# backend-coding-challenge

This is a .NET 5 Rest microservice for Gemography [backend coding challenge](https://github.com/gemography/backend-coding-challenge)

## Functional specs from original challenge requirements

- Develop a REST microservice that list the languages used by the 100 trending public repos on GitHub.
- For every language, you need to calculate the attributes below 👇:
  - Number of repos using this language
  - The list of repos using the language

## Requirements to run the api

In order to run the api you’ll need:

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [VS Code](https://code.visualstudio.com/download) text editor, or another dotnet IDE (Visual studio, Rider)
- Docker
  - [Docker Desktop for Mac & Windows](https://www.docker.com/products/docker-desktop)
  - [Docker Community Edition for Linux](https://docs.docker.com/get-docker)

To run the api you can use the dotnet command:

```
dotnet run
```

And perform a Get http request on `http://localhost:{port}/LanguagesInTrendingRepositories`

To run using docker, you can use the following commands:

```
docker build -t backend-coding-challenge .
docker run -p {port}:80 backend-coding-challenge
```

The api docker image is also available on Docker Hub, you can pull it and run it:

```
docker run -p {port}:80 lghou/backend-coding-challenge
```

Then perform a Get http request on `http://localhost:{port}/LanguagesInTrendingRepositories`

## Api usage:

The api lists the programming languages used in the trending Github repositories in the last 30 days.

Api response example:

```
{
	"total_count": 2,
	"languages": [{
			"name": "Python",
			"github_repositories_count": 2,
			"github_repositories": [{
				"id": 368439610,
				"name": "Tkinter-Designer",
				"startsNumber": 1071,
				"url": "https://github.com/ParthJadhav/Tkinter-Designer",
				"description": "Create Beautiful Tkinter GUIs by Drag and Drop ☄️",
				"language": "Python"
			}, {
				"id": 370199748,
				"name": "Reddit-User-Media-Downloader-Public",
				"startsNumber": 219,
				"url": "https://github.com/MonkeyMaster64/Reddit-User-Media-Downloader-Public",
				"description": null,
				"language": "Python"
			}]
		},
		{
			"name": "C#",
			"github_repositories_count": 1,
			"github_repositories": [{
				"id": 366663429,
				"name": "jynew",
				"startsNumber": 649,
				"url": "https://github.com/jynew/jynew",
				"description": "金庸群侠传3D重制版",
				"language": "C#"
			}]
		}
	]
}
```

In case of an exception, the api returns a NotFount result with the error message.

Note that the implemetation is basic without authentication nor rate limiting.
