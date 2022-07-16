# .NET 6.0 API containerized in Docker and deployment in Heroku

## Introduction

This repository aims to work as a template to deploy .NET Core apps to Heroku inside a Docker container.

## Pre-requisites

[NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)  
[Docker Desktop](https://www.docker.com/products/docker-desktop/)  
[Heroku CLI](https://devcenter.heroku.com/articles/heroku-cli)

## Steps to run in Windows

### locally

1. Open Visual Studio IDE.
2. Select `net6-local` git branch.
3. Press F5 to run the solution (you can select either Docker or IIS Express as lauchers).

Alternatively you can open a terminal window, navigate to the app's directory and execute `dotnet run`. Then you can open a browser and go to https://localhost:5001/swagger

## Configuring deployment for Heroku

1. Open a terminal window and navigate to the solution directory. 
2. Run `docker build -t netcore-docker-heroku .`

At this point you can try to run the application locally with the command `docker run -it --rm -p 5000:80 -e ASPNETCORE_ENVIRONMENT=Development netcore-docker-heroku` and then browse http://localhost:5000/swagger

3. Go to https://heroku.com/ and create an account, or login if you already have an account.
4. In our Dashboard, go to the *New* button and then *Create new app*.
5. Name your application and then press *Create app*.
6. Select the *Deploy* tab and under *Deployment method* select *Container Registry*
7. Follow the instructions.

For the push and deploy steps, you need to add `-a <APPLICATION-NAME>` at the end of the command.

8. Press the *Open app* button and navigate to the /weatherforecast endpoint
9. (OPTIONAL) Go to *Settings*>*Config Vars*>*Reveal Config Vars* and add the Key:Value ASPNETCORE_ENVIRONMENT:Development. Restart the pool, and now you should be able to use Swagger in your deployed application!
