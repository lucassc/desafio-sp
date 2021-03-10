# run tests
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS test
WORKDIR /tests

COPY . .
RUN dotnet restore
RUN dotnet test

#build api
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

COPY src/InterestCalc.Api/. .
RUN dotnet restore

RUN dotnet publish -c release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "InterestCalc.Api.dll"]
EXPOSE 80
EXPOSE 443