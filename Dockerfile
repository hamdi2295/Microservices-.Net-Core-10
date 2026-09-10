FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY ["MySchool/MySchool.csproj", "MySchool/"]

RUN dotnet restore "MySchool/MySchool.csproj"

COPY . .

WORKDIR "/src/MySchool"

RUN dotnet build "MySchool.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/build

FROM build AS publish

ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "MySchool.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

EXPOSE 8080

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "MySchool.dll"]