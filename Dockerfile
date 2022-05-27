#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
COPY . /src
WORKDIR /src
RUN dotnet publish -c release --self-contained false -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
COPY --from=build /src/out ./
ENV ASPNETCORE_ENVIRONMENT=Development
ENV TZ="Asia/Taipei"
ENTRYPOINT ["dotnet", "Shopping.dll"]

