FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ZipArchivationTests/ZipArchivationTests.csproj", "ZipArchivationTests/"]
RUN dotnet restore "ZipArchivationTests/ZipArchivationTests.csproj"
COPY . .
WORKDIR "/src/ZipArchivationTests"
RUN dotnet build "ZipArchivationTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ZipArchivationTests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZipArchivationTests.dll"]
