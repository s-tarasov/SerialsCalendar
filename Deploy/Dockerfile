# Stage 1
FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY src/Calendar.Web/Calendar.Web.csproj ./src/Calendar.Web/Calendar.Web.csproj
RUN dotnet restore ./src/Calendar.Web/Calendar.Web.csproj

# copy everything else and build
COPY . .
RUN dotnet publish --output out --configuration Release

# Stage 2
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Calendar.Web.dll"]