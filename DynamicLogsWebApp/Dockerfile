FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DynamicLogsWebApp/DynamicLogsWebApp.csproj", "DynamicLogsWebApp/"]
RUN dotnet restore "DynamicLogsWebApp/DynamicLogsWebApp.csproj"
COPY . .
WORKDIR "/src/DynamicLogsWebApp"
RUN dotnet build "DynamicLogsWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DynamicLogsWebApp.csproj" -c Release -o /app/publish

FROM base AS final
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DynamicLogsWebApp.dll"]
