# Stage 1
FROM microsoft/aspnetcore-build:2.0.0-preview2-jessie AS builder
WORKDIR /app/

# copy csproj and restore as distinct layers
COPY src/Calendar.Web/Calendar.Web.csproj ./src/Calendar.Web/Calendar.Web.csproj
RUN dotnet restore ./src/Calendar.Web/Calendar.Web.csproj

# copy everything else and build
COPY . .
RUN dotnet publish --output out --configuration Release

# Stage 2
FROM microsoft/aspnetcore:2.0.0-preview2-jessie
WORKDIR /app
COPY --from=builder /app/src/Calendar.Web/out/ .
ENTRYPOINT ["dotnet", "Calendar.Web.dll"]