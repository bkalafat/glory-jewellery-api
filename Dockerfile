#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY *.sln .
COPY GloryJewelleryApi/*.csproj GloryJewelleryApi/
RUN dotnet restore
COPY . .

WORKDIR /src/GloryJewelleryApi
RUN dotnet build

FROM build AS publish
WORKDIR /src/GloryJewelleryApi
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet GloryJewelleryApi.dll