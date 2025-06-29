# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY ["./api.csproj", "api/"]

# Restore
RUN dotnet restore "api/api.csproj"

# Build
COPY ["./", "api/"]

WORKDIR /src/api

RUN dotnet build "api.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish

RUN dotnet publish "api.csproj" -c Release -o /app/publish

# Run stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0

ENV ASPNETCORE_HTTP_PORTS=5001

EXPOSE 5001

WORKDIR /src/app

COPY --from=publish /app/publish .

ENTRYPOINT [ "dotnet", "api.dll" ]