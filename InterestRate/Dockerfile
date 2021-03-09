FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY src/InterestRate.Api/. .
RUN dotnet restore

# Copy everything else and build website
RUN dotnet publish -c release -o /out

# Final stage / image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "InterestRate.Api.dll"]
EXPOSE 80
EXPOSE 443