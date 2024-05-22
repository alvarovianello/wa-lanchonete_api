FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

ENV ASPNETCORE_URLS=http://+:3001
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 3001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

COPY ./wa-lanchonete_api/Api.csproj wa-lanchonete_api/
COPY ./Application/Application.csproj Application/
COPY ./Infra/Infra.Data.csproj Infra/
COPY ./Domain/Domain.csproj Domain/

RUN dotnet restore wa-lanchonete_api/Api.csproj

COPY . .

RUN dotnet build wa-lanchonete_api/Api.csproj -c Release -o /app

FROM build AS publish

RUN dotnet publish wa-lanchonete_api/Api.csproj -c Release -o /app

FROM base AS final

WORKDIR /app

COPY --from=publish /app .

ENTRYPOINT ["dotnet", "Api.dll"]