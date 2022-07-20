FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DynamoDb-MovieRank/DynamoDb-MovieRank.csproj", "DynamoDb-MovieRank/"]
RUN dotnet restore "DynamoDb-MovieRank/DynamoDb-MovieRank.csproj"
COPY . .
WORKDIR "/src/DynamoDb-MovieRank"
RUN dotnet build "DynamoDb-MovieRank.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DynamoDb-MovieRank.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DynamoDb-MovieRank.dll"]
