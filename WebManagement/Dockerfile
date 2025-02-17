FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8081
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["WebManagement/WebManagement.csproj", "WebManagement/"]
COPY ["WebManagement/ManagementConfig", "/app/ManagementConfig"]
RUN dotnet restore "WebManagement/WebManagement.csproj"
COPY . .
WORKDIR "/src/WebManagement"
RUN dotnet build "WebManagement.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebManagement.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebManagement.dll"]