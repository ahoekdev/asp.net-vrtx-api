# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS base

WORKDIR /src

COPY ["api.csproj", "src/api/"]

# Restore
RUN dotnet restore "api/api.csproj"

# Build
COPY ["src/api", "api/"]

WORKDIR /src/api

RUN dotnet build "api.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish

RUN dotnet publish "api.csproj" -c Release -o /app/publish

# Run stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0

ENV ASPNETCORE_HTTP_PORTS=5001

EXPOSE 5001

WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT [ "dotnet", "api.dll" ]