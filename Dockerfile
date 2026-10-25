# Root Dockerfile to build the MySchool solution
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR /src

# Copy entire repository into the build image (build context must be repository root)
COPY . .

# Restore solution
RUN dotnet restore "MySchool.slnx"

# Build and publish the Web project
RUN dotnet build "MySchool/MySchool.csproj" \
	-c $BUILD_CONFIGURATION \
	-o /app/build \
	--no-restore

RUN dotnet publish "MySchool/MySchool.csproj" \
	-c $BUILD_CONFIGURATION \
	-o /app/publish \
	--no-restore \
	/p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
ENV ASPNETCORE_URLS="http://+:8080"
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MySchool.dll"]
