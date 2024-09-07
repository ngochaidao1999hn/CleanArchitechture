#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Presentation/ControllerAPI/ControllerAPI.csproj", "src/Presentation/ControllerAPI/"]
COPY ["src/Application/CleanArchitechture.Application/CleanArchitechture.Application.csproj", "src/Application/CleanArchitechture.Application/"]
COPY ["src/Core/CleanArchitechture.Domain/CleanArchitechture.Domain.csproj", "src/Core/CleanArchitechture.Domain/"]
COPY ["src/Infrastructure/CleanArchitechture.Infrastructure/CleanArchitechture.Infrastructure.csproj", "src/Infrastructure/CleanArchitechture.Infrastructure/"]
RUN dotnet restore "./src/Presentation/ControllerAPI/ControllerAPI.csproj"
COPY . .
WORKDIR "/src/src/Presentation/ControllerAPI"
RUN dotnet build "./ControllerAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ControllerAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ControllerAPI.dll"]