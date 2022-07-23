#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AWSPluralSightDemo/AWSPluralSightDemo.csproj", "AWSPluralSightDemo/"]
RUN dotnet restore "AWSPluralSightDemo/AWSPluralSightDemo.csproj"
COPY . .
WORKDIR "/src/AWSPluralSightDemo"
RUN dotnet build "AWSPluralSightDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AWSPluralSightDemo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AWSPluralSightDemo.dll"]