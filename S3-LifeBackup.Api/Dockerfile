FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["S3-LifeBackup.Api/S3-LifeBackup.Api.csproj", "S3-LifeBackup.Api/"]
RUN dotnet restore "S3-LifeBackup.Api/S3-LifeBackup.Api.csproj"
COPY . .
WORKDIR "/src/S3-LifeBackup.Api"
RUN dotnet build "S3-LifeBackup.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "S3-LifeBackup.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "S3-LifeBackup.Api.dll"]
