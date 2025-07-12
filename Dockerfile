FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["KubernetesExample.Api/KubernetesExample.Api.csproj", "KubernetesExample.Api/"]
RUN dotnet restore "KubernetesExample.Api/KubernetesExample.Api.csproj"
COPY . .
WORKDIR "/src/KubernetesExample.Api"
RUN dotnet build "KubernetesExample.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KubernetesExample.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KubernetesExample.Api.dll"]
